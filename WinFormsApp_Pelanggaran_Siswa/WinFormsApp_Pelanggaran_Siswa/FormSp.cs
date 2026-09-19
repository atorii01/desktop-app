using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

using LoginDatabase;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormSp : Form
    {
        // Konstanta untuk nama kolom agar kode lebih rapi dan aman dari typo
        private const string ColIdSurat = "id_surat";
        private const string ColNis = "nis";
        private const string ColNama = "nama";
        private const string ColKelas = "kelas";
        private const string ColTotalPoint = "total_point";
        private const string ColTotalPointAtPrint = "total_point_at_print";
        private const string ColTanggal = "tanggal";
        private const string ColJenisSurat = "jenis_surat";
        private const string ColStatus = "status";
        private const string ColKeterangan = "keterangan";
        private const string ColWaliKelas = "wali_kelas";

        private readonly Koneksi Konn = Koneksi.Instance;

        // Sesuaikan nama sekolah & kepala
        private const string SchoolName = "Sekolah Terbang Jaya";
        private const string KepalaSekolah = "Saiful Jamil";
        private const string KepalaTelp = "0812-3456-7890";

        // Ambang poin untuk tiap jenis SP (bisa disesuaikan)
        private const int ThresholdSp1 = 25;
        private const int ThresholdSp2 = 50;
        private const int ThresholdSp3 = 80;
        private const int ThresholdDo = 100;

        // Flag untuk menahan event agar tidak memicu ApplyFilters() berulang
        private bool _suppressFilterEvent = false;

        // Timer auto-refresh 5 detik
        private System.Windows.Forms.Timer refreshTimer;

        public FormSp()
        {
            InitializeComponent();
        }

        private void FormSp_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupComboBoxes();
            SetupEventHandlers();

            // Start timer refresh 5 detik
            refreshTimer = new System.Windows.Forms.Timer { Interval = 5000 };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            // sinkron semua SP saat load
            try
            {
                SyncAllSPOnLoad();
            }
            catch (Exception ex)
            {
                // jangan crash app kalau DB sibuk; tampilkan info sederhana
                MessageBox.Show("Gagal sinkronisasi SP saat load: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // load awal data (setelah sinkron)
            LoadData();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.IsDisposed) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        CleanupAndSyncAllSuratPeringatan();
                        ApplyFilters();
                    }));
                }
                else
                {
                    CleanupAndSyncAllSuratPeringatan();
                    ApplyFilters();
                }
            }
            catch
            {
                // swallow exceptions to keep timer alive
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Dispose();
                refreshTimer = null;
            }
        }

        private void SetupDataGridView()
        {
            // DataGridView behaviour (tidak full dock, sesuai permintaan)
            dataGridView1.Dock = DockStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Tampilan
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupComboBoxes()
        {
            // Isi ComboBox status & jenis
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Semua");
            cbStatus.Items.Add("Pending");
            cbStatus.Items.Add("Tercetak");

            cbJenisSP.Items.Clear();
            cbJenisSP.Items.Add("Semua");
            cbJenisSP.Items.Add("SP1");
            cbJenisSP.Items.Add("SP2");
            cbJenisSP.Items.Add("SP3");
            cbJenisSP.Items.Add("DO");

            // Default selected
            cbStatus.SelectedIndex = 0;
            cbJenisSP.SelectedIndex = 0;

            // Pastikan TextBox
            txtnis.ReadOnly = true;
            txtNoSurat.ReadOnly = false;
        }

        private void SetupEventHandlers()
        {
            // Event handlers
            cbStatus.SelectedIndexChanged += CbFilter_SelectedIndexChanged;
            cbJenisSP.SelectedIndexChanged += CbFilter_SelectedIndexChanged;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.RowPrePaint += DataGridView1_RowPrePaint;
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressFilterEvent) return;
            ApplyFilters();
        }

        private void LoadData()
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                string statusFilterDisplay = cbStatus.SelectedItem?.ToString() ?? "Semua";
                string jenisFilter = cbJenisSP.SelectedItem?.ToString() ?? "Semua";

                // Base query - PENTING: Surat tercetak menggunakan total_point_at_print (snapshot frozen)
                string query = @"
                    SELECT 
                        p.id_surat, 
                        p.nis, 
                        s.nama, 
                        s.kelas,
                        CASE 
                            WHEN LOWER(p.status) = 'tercetak' AND p.total_point_at_print IS NOT NULL AND p.total_point_at_print > 0
                            THEN p.total_point_at_print
                            ELSE ISNULL(s.total_point, 0)
                        END AS total_point,
                        p.total_point_at_print,
                        p.tanggal, 
                        p.jenis_surat, 
                        p.status, 
                        p.keterangan,
                        s.wali_kelas
                    FROM surat_peringatan p
                    INNER JOIN siswa s ON p.nis = s.nis";

                // WHERE clauses
                var whereList = new List<string>();
                if (!string.Equals(statusFilterDisplay, "Semua", StringComparison.OrdinalIgnoreCase))
                {
                    whereList.Add("LOWER(p.status) = LOWER(@statusFilter)");
                }
                if (!string.Equals(jenisFilter, "Semua", StringComparison.OrdinalIgnoreCase))
                {
                    whereList.Add("p.jenis_surat = @jenisFilter");
                }
                if (whereList.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", whereList);
                }

                // Ordering
                query += @"
                    ORDER BY
                        CASE WHEN LOWER(p.status) = 'pending' THEN 1 ELSE 2 END,
                        CASE 
                            WHEN p.jenis_surat = 'SP1' THEN 1 
                            WHEN p.jenis_surat = 'SP2' THEN 2 
                            WHEN p.jenis_surat = 'SP3' THEN 3
                            WHEN p.jenis_surat = 'DO' THEN 4
                            ELSE 5 
                        END,
                        p.tanggal DESC, p.id_surat DESC";

                using (var conn = Konn.GetConn())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (!string.Equals(statusFilterDisplay, "Semua", StringComparison.OrdinalIgnoreCase))
                        {
                            string dbStatus = MapStatusDisplayToDb(statusFilterDisplay);
                            cmd.Parameters.AddWithValue("@statusFilter", dbStatus);
                        }
                        if (!string.Equals(jenisFilter, "Semua", StringComparison.OrdinalIgnoreCase))
                        {
                            cmd.Parameters.AddWithValue("@jenisFilter", jenisFilter);
                        }

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);

                            _suppressFilterEvent = true;
                            try
                            {
                                dataGridView1.DataSource = dt;
                            }
                            finally
                            {
                                _suppressFilterEvent = false;
                            }

                            if (dataGridView1.Columns.Contains(ColTotalPoint))
                                dataGridView1.Columns[ColTotalPoint].HeaderText = "Total Point";
                            if (dataGridView1.Columns.Contains(ColTotalPointAtPrint))
                                dataGridView1.Columns[ColTotalPointAtPrint].Visible = false;
                            if (dataGridView1.Columns.Contains(ColWaliKelas))
                                dataGridView1.Columns[ColWaliKelas].Visible = false;
                            if (dataGridView1.Columns.Contains(ColKeterangan))
                                dataGridView1.Columns[ColKeterangan].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method utama untuk cleanup dan sinkronisasi semua surat peringatan
        /// Dipanggil oleh timer setiap 5 detik
        /// </summary>
        private void CleanupAndSyncAllSuratPeringatan()
        {
            try
            {
                using (var conn = Konn.GetConn())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // Step 1: Hapus surat pending yang siswa tidak ada (orphan)
                            string delOrphan = @"
                                DELETE p
                                FROM surat_peringatan p
                                LEFT JOIN siswa s ON p.nis = s.nis
                                WHERE LOWER(p.status) = 'pending' AND s.nis IS NULL";

                            using (var cmd = new SqlCommand(delOrphan, conn, tx))
                            {
                                cmd.CommandTimeout = 30;
                                cmd.ExecuteNonQuery();
                            }

                            // Step 2: Hapus surat pending dimana total point siswa = 0
                            string delZero = @"
                                DELETE p
                                FROM surat_peringatan p
                                INNER JOIN siswa s ON p.nis = s.nis
                                WHERE LOWER(p.status) = 'pending' 
                                  AND ISNULL(s.total_point, 0) = 0";

                            using (var cmd = new SqlCommand(delZero, conn, tx))
                            {
                                cmd.CommandTimeout = 30;
                                cmd.ExecuteNonQuery();
                            }

                            // Step 3: Sinkronkan semua siswa - hapus surat yang tidak sesuai threshold
                            var daftarSiswa = new List<KeyValuePair<string, int>>();
                            string qSiswa = "SELECT nis, ISNULL(total_point, 0) AS total_point FROM siswa";

                            using (var cmd = new SqlCommand(qSiswa, conn, tx))
                            using (var rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    if (rdr.IsDBNull(0)) continue;
                                    string nis = rdr.GetString(0);
                                    int tot = rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1);
                                    daftarSiswa.Add(new KeyValuePair<string, int>(nis, tot));
                                }
                            }

                            // Untuk setiap siswa, hapus surat yang tidak memenuhi threshold
                            foreach (var kv in daftarSiswa)
                            {
                                CleanupSuratBelowThreshold(kv.Key, kv.Value, conn, tx);
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            try { tx.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            catch
            {
                // Swallow error agar timer tidak crash
            }
        }

        /// <summary>
        /// Menghapus surat peringatan yang tidak lagi memenuhi threshold berdasarkan total_point siswa saat ini
        /// PENTING: Hanya menghapus surat dengan status 'pending'. Surat 'tercetak' tetap dipertahankan.
        /// </summary>
        private void CleanupSuratBelowThreshold(string nis, int totalPointSekarang, SqlConnection conn, SqlTransaction tx)
        {
            // Query untuk mendapatkan semua surat peringatan siswa ini
            string getSurat = @"
                SELECT id_surat, jenis_surat, status 
                FROM surat_peringatan 
                WHERE nis = @nis";

            var listToDelete = new List<int>();

            using (var cmd = new SqlCommand(getSurat, conn, tx))
            {
                cmd.Parameters.AddWithValue("@nis", nis);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idSurat = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        string jenis = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        string status = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                        // HANYA proses surat dengan status 'pending'
                        // Surat yang sudah 'tercetak' tidak boleh dihapus
                        if (!status.Equals("pending", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        // Tentukan threshold minimal untuk jenis surat ini
                        int thresholdMinimal = GetThresholdForJenis(jenis);

                        // Jika poin siswa sekarang di bawah threshold, tandai untuk dihapus
                        if (thresholdMinimal > 0 && totalPointSekarang < thresholdMinimal)
                        {
                            listToDelete.Add(idSurat);
                        }
                    }
                }
            }

            // Hapus surat yang tidak memenuhi threshold
            if (listToDelete.Count > 0)
            {
                string delSql = "DELETE FROM surat_peringatan WHERE id_surat = @id";
                using (var delCmd = new SqlCommand(delSql, conn, tx))
                {
                    delCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    foreach (int id in listToDelete)
                    {
                        delCmd.Parameters["@id"].Value = id;
                        delCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Mendapatkan threshold minimal untuk jenis surat tertentu
        /// </summary>
        private int GetThresholdForJenis(string jenis)
        {
            if (string.IsNullOrEmpty(jenis)) return 0;

            switch (jenis.ToUpper())
            {
                case "SP1": return ThresholdSp1;
                case "SP2": return ThresholdSp2;
                case "SP3": return ThresholdSp3;
                case "DO": return ThresholdDo;
                default: return 0;
            }
        }

        private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            var row = dataGridView1.Rows[e.RowIndex];

            if (dataGridView1.Columns.Contains(ColJenisSurat) && !row.IsNewRow)
            {
                var jenisSurat = row.Cells[ColJenisSurat].Value?.ToString();

                switch (jenisSurat?.ToUpper())
                {
                    case "SP1":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "SP2":
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case "SP3":
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case "DO":
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = e.RowIndex % 2 == 0 ? Color.FromArgb(238, 239, 249) : Color.White;
                        break;
                }
            }
        }

        private static string MapStatusDisplayToDb(string display)
        {
            if (string.IsNullOrEmpty(display)) return "pending";
            if (display.Equals("Pending", StringComparison.OrdinalIgnoreCase)) return "pending";
            if (display.Equals("Tercetak", StringComparison.OrdinalIgnoreCase)) return "tercetak";
            return display.ToLower();
        }

        private string DetermineJenisSpFromPoints(int points)
        {
            if (points >= ThresholdDo) return "DO";
            if (points >= ThresholdSp3) return "SP3";
            if (points >= ThresholdSp2) return "SP2";
            if (points >= ThresholdSp1) return "SP1";
            return "SP1";
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    ClearFormFields();
                    return;
                }

                _suppressFilterEvent = true;
                try
                {
                    var row = dataGridView1.SelectedRows[0];
                    string nisVal = ColumnValue(row, ColNis, "");
                    txtnis.Text = nisVal;

                    string idSurat = ColumnValue(row, ColIdSurat, "");
                    txtNoSurat.Text = !string.IsNullOrEmpty(idSurat) ? $"{idSurat}/SP/{DateTime.Now.Year}" : "";

                    string statusDb = ColumnValue(row, ColStatus, "").ToLower();
                    if (statusDb == "pending") cbStatus.SelectedItem = "Pending";
                    else if (statusDb == "tercetak") cbStatus.SelectedItem = "Tercetak";
                    else cbStatus.SelectedIndex = 0;

                    string jenisDb = ColumnValue(row, ColJenisSurat, "");
                    if (int.TryParse(ColumnValue(row, ColTotalPoint, "0"), out int point))
                    {
                        string auto = DetermineJenisSpFromPoints(point);
                        if (!string.IsNullOrEmpty(jenisDb) && cbJenisSP.Items.Contains(jenisDb))
                            cbJenisSP.SelectedItem = jenisDb;
                        else if (cbJenisSP.Items.Contains(auto))
                            cbJenisSP.SelectedItem = auto;
                        else
                            cbJenisSP.SelectedIndex = 0;
                    }
                    else if (!string.IsNullOrEmpty(jenisDb) && cbJenisSP.Items.Contains(jenisDb))
                        cbJenisSP.SelectedItem = jenisDb;
                    else
                        cbJenisSP.SelectedIndex = 0;
                }
                finally
                {
                    _suppressFilterEvent = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data baris: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormFields()
        {
            txtnis.Text = string.Empty;
            txtNoSurat.Text = string.Empty;

            _suppressFilterEvent = true;
            try
            {
                cbStatus.SelectedIndex = 0;
                cbJenisSP.SelectedIndex = 0;
            }
            finally
            {
                _suppressFilterEvent = false;
            }
        }

        private string ColumnValue(DataGridViewRow row, string columnName, string defaultValue)
        {
            if (row == null || row.DataGridView == null || !row.DataGridView.Columns.Contains(columnName))
            {
                return defaultValue;
            }

            var val = row.Cells[columnName].Value;
            return val == DBNull.Value || val == null ? defaultValue : val.ToString();
        }

        private void btncetak_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row == null || row.IsNewRow)
            {
                MessageBox.Show("Pilih salah satu data siswa yang ingin dicetak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idSurat = ColumnValue(row, ColIdSurat, "");
            string nis = ColumnValue(row, ColNis, "");
            string nama = ColumnValue(row, ColNama, "-");
            string kelas = ColumnValue(row, ColKelas, "-");
            string waliKelas = ColumnValue(row, ColWaliKelas, "-");
            string tanggalCell = ColumnValue(row, ColTanggal, "");
            string statusDb = ColumnValue(row, ColStatus, "");
            int totalPoint = 0;

            // CRITICAL: Gunakan snapshot untuk surat tercetak, poin terbaru untuk pending
            if (statusDb.Equals("tercetak", StringComparison.OrdinalIgnoreCase))
            {
                // Surat sudah tercetak - WAJIB gunakan snapshot (total_point_at_print)
                string pointAtPrintStr = ColumnValue(row, ColTotalPointAtPrint, "0");
                if (int.TryParse(pointAtPrintStr, out int pointAtPrint) && pointAtPrint > 0)
                {
                    totalPoint = pointAtPrint;
                }
                else
                {
                    // Fallback jika total_point_at_print kosong (seharusnya tidak terjadi)
                    if (int.TryParse(ColumnValue(row, ColTotalPoint, "0"), out int fallback))
                    {
                        totalPoint = fallback;
                    }
                }
            }
            else
            {
                // Surat masih pending - gunakan poin terbaru dari siswa
                if (int.TryParse(ColumnValue(row, ColTotalPoint, "0"), out int pointFromGrid))
                {
                    totalPoint = pointFromGrid;
                }
            }

            if (string.IsNullOrEmpty(nis))
            {
                MessageBox.Show("Data NIS tidak ditemukan. Tidak dapat mencetak.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime tgl = DateTime.Now;
            if (!string.IsNullOrEmpty(tanggalCell) && DateTime.TryParse(tanggalCell, out DateTime parsed))
                tgl = parsed;
            string tanggal = tgl.ToString("dd MMMM yyyy");

            string jenisFromCb = cbJenisSP.SelectedItem?.ToString();
            string jenisAuto = DetermineJenisSpFromPoints(totalPoint);
            string jenisSuratDipakai = (jenisFromCb != null && jenisFromCb != "Semua") ? jenisFromCb : jenisAuto;

            string nomorSurat = txtNoSurat.Text.Trim();
            if (string.IsNullOrEmpty(nomorSurat))
                nomorSurat = string.IsNullOrEmpty(idSurat) ? $"{nis}/SP/{DateTime.Now.Year}" : $"{idSurat}/SP/{DateTime.Now.Year}";

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"SuratPeringatan_{nis}_{jenisSuratDipakai}.pdf"
            };
            if (saveFile.ShowDialog() != DialogResult.OK) return;

            try
            {
                GenerateAndSavePdf(saveFile.FileName, nomorSurat, tanggal, nis, nama, kelas, totalPoint, jenisSuratDipakai, waliKelas);
                UpdateDatabase(idSurat, jenisSuratDipakai, saveFile.FileName, totalPoint);
                ApplyFilters();
                MessageBox.Show("Surat peringatan berhasil dibuat (A4 satu halaman) dan status diupdate menjadi 'tercetak'.\nFile: " + saveFile.FileName, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat surat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateAndSavePdf(string filePath, string nomorSurat, string tanggal, string nis, string nama, string kelas, int totalPoint, string jenisSurat, string waliKelas)
        {
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30, 30, 30, 30))
                {
                    using (var writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                        if (!File.Exists(fontPath))
                        {
                            fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        }
                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        var kopFont = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.BOLD);
                        var titleFont = new iTextSharp.text.Font(baseFont, 13, iTextSharp.text.Font.BOLD);
                        var normal = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.NORMAL);
                        var small = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                        var italic = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.ITALIC);

                        // Kop surat
                        doc.Add(new iTextSharp.text.Paragraph($"PEMERINTAH KABUPATEN/KOTA\nDINAS PENDIDIKAN\n{SchoolName}\nAlamat Sekolah: Jl. Pelita Jaya No. 7 — Telp. {KepalaTelp}\n\n", kopFont)
                        { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                        doc.Add(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.Element.ALIGN_CENTER, -2f));
                        doc.Add(new iTextSharp.text.Chunk("\n"));

                        // Judul
                        doc.Add(new iTextSharp.text.Paragraph("SURAT PERINGATAN", titleFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                        doc.Add(new iTextSharp.text.Paragraph($"({jenisSurat})", italic) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                        doc.Add(new iTextSharp.text.Chunk("\n"));

                        doc.Add(new iTextSharp.text.Paragraph($"Nomor : {nomorSurat}\nTanggal : {tanggal}\n\n", normal) { Alignment = iTextSharp.text.Element.ALIGN_LEFT });

                        // Isi surat
                        string intro = $"Yang bertanda tangan di bawah ini, Kepala {SchoolName}, setelah melakukan penelaahan, verifikasi, dan berdasarkan laporan serta catatan dari wali kelas dan guru mata pelajaran, menyatakan bahwa siswa yang namanya tercantum di bawah ini telah melakukan pelanggaran tata tertib sekolah. Surat peringatan ini dibuat sebagai upaya pembinaan agar siswa menyadari dampak perilaku yang tidak sesuai, memperbaiki sikap, dan kembali berperan positif di lingkungan sekolah.\n\n";
                        string studentInfo = $"NIS  \t: {nis}\nNama  \t: {nama}\nKelas \t: {kelas}\nTotal Point : {totalPoint}\n\n";
                        string expanded = "Berdasarkan hasil pengumpulan data dan pembinaan awal, ditemukan adanya pelanggaran yang memerlukan perhatian serius. Sebagai lembaga pendidikan, sekolah berkewajiban menjaga keteraturan proses belajar mengajar dan menjunjung tinggi disiplin. Oleh karena itu, surat peringatan ini diberikan bukan semata untuk menghukum, melainkan sebagai peringatan formal serta alat pembinaan untuk mendukung perbaikan perilaku siswa.\n\nDalam pelaksanaan pembinaan ini, pihak sekolah akan melakukan koordinasi intensif dengan wali kelas dan orang tua/wali, serta memonitor perkembangan sikap dan prestasi belajar. Siswa diharapkan menunjukkan itikad baik dengan menaati arahan guru, aktif mengikuti kegiatan pembinaan, serta menunjukkan perubahan perilaku yang konsisten dan berkelanjutan.\n\nSelain itu, apabila siswa menunjukkan perbaikan, sekolah akan mencatat hal tersebut sebagai bukti perbaikan yang dapat dipertimbangkan dalam evaluasi kedisiplinan di masa mendatang. Namun demikian, apabila pelanggaran berulang terjadi setelah peringatan ini, pihak sekolah akan menindaklanjuti sesuai dengan ketentuan tata tertib, termasuk sanksi administratif yang lebih tegas.\n\n";

                        string rekomendasi = GetRekomendasi(jenisSurat);
                        string closing = "Demikian surat peringatan ini dibuat untuk dijadikan perhatian dan dasar pembinaan. Kami berharap adanya kerja sama yang baik antara pihak sekolah dan orang tua/wali agar proses pembinaan berjalan efektif dan memberi manfaat bagi perkembangan siswa.\n\n";

                        if (jenisSurat.ToUpper() == "DO")
                        {
                            doc.Add(new iTextSharp.text.Paragraph("SURAT PEMBERHENTIAN SISWA", titleFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                            doc.Add(new iTextSharp.text.Paragraph("DO (DROP OUT)", italic) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                            doc.Add(new iTextSharp.text.Chunk("\n"));

                            string introDO = $"Sehubungan dengan tingginya akumulasi poin pelanggaran yang telah dilakukan oleh siswa berikut ini:\n\n";
                            string studentInfoDO = $"NIS  : {nis}\nNama  : {nama}\nKelas : {kelas}\nTotal Point : {totalPoint}\n\n";
                            string expandedDO = "Mengingat siswa yang bersangkutan telah berulang kali mendapatkan surat peringatan (SP1, SP2, SP3) namun tidak menunjukkan perbaikan signifikan dalam perilaku dan kedisiplinan, maka dengan berat hati pihak sekolah memutuskan untuk memberhentikan siswa dari kegiatan belajar-mengajar. Keputusan ini diambil setelah melalui proses musyawarah dewan guru, konseling, dan pemanggilan orang tua/wali.\n\nKeputusan Drop Out ini diharapkan dapat menjadi pelajaran bagi siswa lain untuk senantiasa mematuhi tata tertib sekolah yang berlaku. Pihak sekolah mengucapkan terima kasih atas partisipasi dan kerjasama orang tua/wali selama ini.\n\n";
                            string closingDO = "Demikian surat ini dibuat untuk dapat dimaklumi.\n\n";

                            string isiPenuhDO = introDO + studentInfoDO + expandedDO + closingDO;
                            doc.Add(new iTextSharp.text.Paragraph(isiPenuhDO, normal)
                            {
                                Alignment = iTextSharp.text.Element.ALIGN_JUSTIFIED,
                                FirstLineIndent = 20f,
                                SpacingBefore = 4f,
                                SpacingAfter = 4f
                            });
                        }
                        else
                        {
                            string isiPenuh = intro + studentInfo + expanded + rekomendasi + closing;
                            doc.Add(new iTextSharp.text.Paragraph(isiPenuh, normal)
                            {
                                Alignment = iTextSharp.text.Element.ALIGN_JUSTIFIED,
                                FirstLineIndent = 20f,
                                SpacingBefore = 4f,
                                SpacingAfter = 4f
                            });
                        }

                        doc.Add(new iTextSharp.text.Paragraph("Kewajiban yang harus dipenuhi oleh siswa:", normal) { SpacingBefore = 6f });
                        var list = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 10f) { IndentationLeft = 20f, Symbol = new Chunk("\u2022", normal) };
                        list.Add(new iTextSharp.text.ListItem("Mengikuti program pembinaan yang ditetapkan sekolah.", small));
                        list.Add(new iTextSharp.text.ListItem("Menunjukkan perubahan perilaku secara konsisten.", small));
                        list.Add(new iTextSharp.text.ListItem("Berkoordinasi dengan wali kelas dan orang tua/wali.", small));
                        list.Add(new iTextSharp.text.ListItem("Mematuhi tata tertib sekolah mulai saat surat ini diterbitkan.", small));
                        doc.Add(list);
                        doc.Add(new iTextSharp.text.Chunk("\n"));

                        PdfPTable ttdTable = new PdfPTable(2) { WidthPercentage = 100f };
                        ttdTable.SetWidths(new float[] { 50f, 50f });

                        var left = new iTextSharp.text.Paragraph($"Mengetahui,\nWali Kelas {waliKelas}\n\n\n(_________________)\n", normal) { Alignment = iTextSharp.text.Element.ALIGN_LEFT };
                        var right = new iTextSharp.text.Paragraph($"{SchoolName}, {tanggal}\nKepala Sekolah,\n\n\n(_________________)\nNama : {KepalaSekolah}\nTelp : {KepalaTelp}", normal) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT };

                        ttdTable.AddCell(new PdfPCell(left) { Border = PdfPCell.NO_BORDER });
                        ttdTable.AddCell(new PdfPCell(right) { Border = PdfPCell.NO_BORDER });
                        doc.Add(ttdTable);

                        doc.Close();
                    }
                }
            }
        }

        private string GetRekomendasi(string jenisSurat)
        {
            switch (jenisSurat?.ToUpper())
            {
                case "SP1":
                    return "Rekomendasi tindak lanjut (SP1):\n1. Pembinaan intensif oleh wali kelas selama 2 minggu.\n2. Siswa diwajibkan mengikuti sesi bimbingan kedisiplinan.\n3. Orang tua/wali diminta mendampingi proses pembinaan di rumah.\n\n";
                case "SP2":
                    return "Rekomendasi tindak lanjut (SP2):\n1. Evaluasi mingguan oleh wali kelas selama 1 bulan.\n2. Pemanggilan orang tua/wali untuk rapat pembinaan bersama pihak sekolah.\n3. Penerapan sanksi administratif tambahan bila tidak ada perbaikan.\n\n";
                case "SP3":
                    return "Rekomendasi tindak lanjut (SP3):\n1. Pemanggilan resmi orang tua/wali untuk pembinaan intensif.\n2. Pertimbangan sanksi administratif yang lebih berat (mis. skorsing).\n3. Evaluasi kemungkinan pemberhentian jika tidak ada perubahan.\n\n";
                case "DO":
                    return "Rekomendasi tindak lanjut (DO):\n1. Surat pemberhentian siswa resmi telah diterbitkan.\n2. Siswa secara resmi tidak lagi menjadi bagian dari sekolah.\n3. Dokumen terkait akan diserahkan kepada orang tua/wali untuk proses selanjutnya.\n\n";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Update database saat cetak surat:
        /// - Set status menjadi 'tercetak'
        /// - Simpan snapshot total_point_at_print (HANYA jika masih NULL/0)
        /// - Set metadata cetak (printed_by, printed_at, pdf_path)
        /// 
        /// PENTING: total_point_at_print hanya diisi SEKALI saat pertama kali dicetak.
        /// Setelah itu, nilai tersebut TIDAK BOLEH diubah meskipun total_point siswa berubah.
        /// </summary>
        private string UpdateDatabase(string idSurat, string jenisSurat, string pdfPath, int totalPoint)
        {
            if (string.IsNullOrWhiteSpace(jenisSurat)) jenisSurat = "";

            using (var conn = Konn.GetConn())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Jika idSurat kosong, throw error karena harus ada record pending terlebih dahulu
                        if (string.IsNullOrWhiteSpace(idSurat))
                        {
                            throw new InvalidOperationException("ID Surat tidak boleh kosong. Pastikan sudah ada record surat_peringatan dengan status 'pending' sebelum mencetak.");
                        }

                        // Update existing surat_peringatan
                        // CRITICAL: total_point_at_print hanya diset jika masih NULL atau 0
                        // Ini memastikan snapshot poin TIDAK BERUBAH setelah surat pertama kali dicetak
                        string upd = @"
                            UPDATE surat_peringatan
                            SET
                                status = 'tercetak',
                                jenis_surat = @jenis,
                                printed_by = @printedBy,
                                printed_at = CASE WHEN printed_at IS NULL THEN @printedAt ELSE printed_at END,
                                pdf_path = @pdfPath,
                                total_point_at_print = CASE 
                                    WHEN total_point_at_print IS NULL OR total_point_at_print = 0 
                                    THEN @totalPoint 
                                    ELSE total_point_at_print 
                                END
                            WHERE id_surat = @id";

                        using (var cmd = new SqlCommand(upd, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@jenis", jenisSurat);
                            cmd.Parameters.AddWithValue("@printedBy", Environment.UserName ?? "SYSTEM");
                            cmd.Parameters.AddWithValue("@printedAt", DateTime.Now);
                            cmd.Parameters.AddWithValue("@pdfPath", pdfPath ?? "");
                            cmd.Parameters.AddWithValue("@totalPoint", totalPoint);
                            cmd.Parameters.AddWithValue("@id", idSurat);

                            int affected = cmd.ExecuteNonQuery();
                            if (affected == 0)
                            {
                                throw new Exception($"Tidak ada surat dengan id_surat = {idSurat}. Periksa ID yang dikirim.");
                            }
                        }

                        tx.Commit();
                        return idSurat;
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            // Memastikan ada baris yang dipilih di DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih salah satu data surat peringatan yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil id_surat dari baris yang dipilih
            string idSurat = ColumnValue(dataGridView1.SelectedRows[0], ColIdSurat, "");

            if (string.IsNullOrEmpty(idSurat))
            {
                MessageBox.Show("ID Surat tidak ditemukan. Tidak dapat menghapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Meminta konfirmasi dari pengguna
            var confirmResult = MessageBox.Show($"Apakah Anda yakin ingin menghapus surat dengan ID {idSurat}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var conn = Konn.GetConn())
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();
                        string query = "DELETE FROM surat_peringatan WHERE id_surat = @id";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idSurat);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data surat peringatan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Gagal menghapus data. Data mungkin sudah tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Muat ulang data untuk menyegarkan DataGridView
                    ApplyFilters();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Sinkronisasi semua siswa saat form load:
        /// - Hapus surat pending yang orphan (siswa tidak ada)
        /// - Hapus surat pending yang siswa total_point = 0
        /// - Hapus surat pending yang tidak memenuhi threshold
        /// Dilakukan dalam 1 transaksi agar konsisten.
        /// </summary>
        private void SyncAllSPOnLoad()
        {
            using (var conn = Konn.GetConn())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Hapus orphan (surat pending tanpa siswa)
                        string delOrphan = @"
                            DELETE p
                            FROM surat_peringatan p
                            LEFT JOIN siswa s ON p.nis = s.nis
                            WHERE LOWER(p.status) = 'pending' AND s.nis IS NULL";

                        using (var cmd = new SqlCommand(delOrphan, conn, tx))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Step 2: Hapus surat pending dimana siswa total_point = 0
                        string delZero = @"
                            DELETE p
                            FROM surat_peringatan p
                            INNER JOIN siswa s ON p.nis = s.nis
                            WHERE LOWER(p.status) = 'pending' 
                              AND ISNULL(s.total_point, 0) = 0";

                        using (var cmd = new SqlCommand(delZero, conn, tx))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Step 3: Ambil daftar siswa dan sinkronkan threshold
                        var daftar = new List<KeyValuePair<string, int>>();
                        string q = "SELECT nis, ISNULL(total_point, 0) AS total_point FROM siswa";
                        using (var cmd = new SqlCommand(q, conn, tx))
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if (rdr.IsDBNull(0)) continue;
                                string nis = rdr.GetString(0);
                                int tot = rdr.IsDBNull(1) ? 0 : rdr.GetInt32(1);
                                daftar.Add(new KeyValuePair<string, int>(nis, tot));
                            }
                        }

                        // Loop dan cleanup threshold untuk setiap siswa
                        foreach (var kv in daftar)
                        {
                            CleanupSuratBelowThreshold(kv.Key, kv.Value, conn, tx);
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }
    }
}