using LoginDatabase;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Formtambahsiswa : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;

        private readonly Dictionary<string, string> WaliPerKelas = new Dictionary<string, string>
        {
            { "X - RPL", "Pak Agus" }, { "X - AKL", "Bu Siti" }, { "X - DKV", "Pak Budi" },
            { "X - BR1", "Bu Rina" }, { "X - BR2", "Pak Joko" }, { "X - BD", "Bu Lina" },
            { "X - MP1", "Pak Anton" }, { "X - MP2", "Bu Maya" }, { "X - TKJ", "Pak Ahmad" },
            { "X - TKR", "Pak Zul" }
        };

        private int selectedRowIndex = -1;
        private string currentWalas = "";
        private System.Windows.Forms.Timer refreshTimer;

        // Flag untuk mencegah operasi ganda
        private bool isProcessing = false;

        public Formtambahsiswa()
        {
            InitializeComponent();
            this.Load += Formtambahsiswa_Load;
            this.FormClosing += Formtambahsiswa_FormClosing;

            if (this.Controls.Find("cbkelas", true).Length > 0)
                cbkelas.SelectedIndexChanged += cbkelas_SelectedIndexChanged;
            if (this.Controls.Find("txtcari", true).Length > 0)
                txtcari.TextChanged += txtcari_TextChanged;
            if (this.Controls.Find("dataGridView1", true).Length > 0)
                dataGridView1.CellClick += dataGridView1_CellClick;
            if (this.Controls.Find("btntambah", true).Length > 0)
                btntambah.Click += btntambah_Click;
            if (this.Controls.Find("btnEdit", true).Length > 0)
                btnEdit.Click += btnEdit_Click;
            if (this.Controls.Find("btnUpdate", true).Length > 0)
                btnUpdate.Click += btnUpdate_Click;
            if (this.Controls.Find("btnhapus", true).Length > 0)
                btnhapus.Click += btnhapus_Click;
            if (this.Controls.Find("btnbatal", true).Length > 0)
                btnbatal.Click += btnbatal_Click;

            InitializeRefreshTimer();
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer { Interval = 20000 };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void Formtambahsiswa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Dispose();
                refreshTimer = null;
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (isProcessing) return; // Skip jika sedang proses

            try
            {
                var tc = this.Controls.Find("txtcari", true).FirstOrDefault() as TextBox;
                if (tc != null)
                {
                    if (tc.Focused) return;
                    if (!string.IsNullOrWhiteSpace(tc.Text)) return;
                }

                string selectedNis = null;
                int firstDisplayed = -1;
                var dgvCtrls = this.Controls.Find("dataGridView1", true);

                if (dgvCtrls.Length > 0 && dgvCtrls[0] is DataGridView dgv)
                {
                    try
                    {
                        if (dgv.SelectedRows.Count > 0)
                        {
                            var cell = dgv.SelectedRows[0].Cells.Cast<DataGridViewCell>()
                                .FirstOrDefault(c => string.Equals(c.OwningColumn.Name, "nis", StringComparison.OrdinalIgnoreCase));
                            if (cell != null) selectedNis = (cell.Value ?? "").ToString();
                        }
                        try { firstDisplayed = dgv.FirstDisplayedScrollingRowIndex; } catch { }
                    }
                    catch { }
                }

                LoadData();

                if (dgvCtrls.Length > 0 && dgvCtrls[0] is DataGridView dgv2)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(selectedNis))
                        {
                            for (int i = 0; i < dgv2.Rows.Count; i++)
                            {
                                var cell = dgv2.Rows[i].Cells.Cast<DataGridViewCell>()
                                    .FirstOrDefault(c => string.Equals(c.OwningColumn.Name, "nis", StringComparison.OrdinalIgnoreCase));
                                if (cell != null && (cell.Value ?? "").ToString() == selectedNis)
                                {
                                    dgv2.ClearSelection();
                                    dgv2.Rows[i].Selected = true;
                                    dgv2.CurrentCell = dgv2.Rows[i].Cells[0];
                                    try { dgv2.FirstDisplayedScrollingRowIndex = Math.Max(0, i - 2); } catch { }
                                    break;
                                }
                            }
                        }
                        else if (firstDisplayed >= 0 && dgv2.Rows.Count > 0)
                        {
                            try { dgv2.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayed, Math.Max(0, dgv2.Rows.Count - 1)); } catch { }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void Formtambahsiswa_Load(object sender, EventArgs e)
        {
            if (this.Controls.Find("cbkelas", true).Length > 0)
            {
                cbkelas.Items.Clear();
                cbkelas.Items.AddRange(new object[] {
                    "X - RPL","X - AKL","X - DKV","X - BR1","X - BR2",
                    "X - BD","X - MP1","X - MP2","X - TKJ","X - TKR"
                });
                if (cbkelas.Items.Count > 0) cbkelas.SelectedIndex = 0;
            }

            SetWalasForSelectedClass();

            if (this.Controls.Find("txtnis", true).Length > 0)
                txtnis.Text = GenerateNextNis();

            if (this.Controls.Find("dataGridView1", true).Length > 0)
                LoadData();

            SetInitialButtonState();
        }

        private void SetInitialButtonState()
        {
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = true;
            if (this.Controls.Find("btnEdit", true).Length > 0) btnEdit.Enabled = false;
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = false;
            if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = false;
        }

        private void SetWalasForSelectedClass()
        {
            string kelas = "";
            if (this.Controls.Find("cbkelas", true).Length > 0)
                kelas = cbkelas.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(kelas) && WaliPerKelas.ContainsKey(kelas))
                currentWalas = WaliPerKelas[kelas];
            else
                currentWalas = string.Empty;

            var tb = this.Controls.Find("txtwalas", true).FirstOrDefault() as TextBox;
            if (tb != null) { tb.Text = currentWalas; return; }

            var lbl = this.Controls.Find("lblWalas", true).FirstOrDefault() as Label;
            if (lbl != null) lbl.Text = currentWalas;
        }

        private string GenerateNextNis()
        {
            const int START_NIS = 2023001;
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT ISNULL(MAX(TRY_CAST(nis AS INT)), 0) AS maxNis FROM siswa";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object val = cmd.ExecuteScalar();
                        int maxNis = Convert.ToInt32(val);
                        return Math.Max(maxNis + 1, START_NIS).ToString();
                    }
                }
            }
            catch { return START_NIS.ToString(); }
        }

        private string GetControlText(string name)
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls.Length == 0) return "";
            if (ctrls[0] is TextBox tb) return tb.Text;
            if (ctrls[0] is Label lbl) return lbl.Text;
            return "";
        }

        private void SetControlTextIfExists(string name, string text)
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls.Length == 0) return;
            if (ctrls[0] is TextBox tb) tb.Text = text;
            if (ctrls[0] is Label lbl) lbl.Text = text;
        }

        // ===== FUNGSI CLEAR FORM LENGKAP =====
        private void ClearAllForms()
        {
            // Clear Form Siswa
            if (this.Controls.Find("txtnis", true).Length > 0)
                SetControlTextIfExists("txtnis", GenerateNextNis());
            SetControlTextIfExists("txtnama", "");
            SetControlTextIfExists("txtnotelp", "");

            if (this.Controls.Find("rblaki", true).Length > 0)
                (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked = true;
            if (this.Controls.Find("cbkelas", true).Length > 0)
                cbkelas.SelectedIndex = 0;

            SetWalasForSelectedClass();

            // Clear Form Pelanggaran (TAMBAHAN INI YANG PENTING!)
            SetControlTextIfExists("txtIdPelanggaran", "");
            SetControlTextIfExists("txtNisPelanggaran", "");
            SetControlTextIfExists("txtNamaPelanggaran", "");
            SetControlTextIfExists("txtJenisPelanggaran", "");
            SetControlTextIfExists("txtPoint", "");
            SetControlTextIfExists("txtKeterangan", "");

            // Clear DateTimePicker jika ada
            var dtpCtrls = this.Controls.Find("dtpTanggal", true);
            if (dtpCtrls.Length > 0 && dtpCtrls[0] is DateTimePicker dtp)
                dtp.Value = DateTime.Now;

            selectedRowIndex = -1;
            SetInitialButtonState();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, 
                               ISNULL(total_point,0) AS total_point, 
                               ISNULL(status,'aktif') AS status
                        FROM siswa
                        ORDER BY nama";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        var dgvControls = this.Controls.Find("dataGridView1", true);
                        if (dgvControls.Length > 0 && dgvControls[0] is DataGridView dgv)
                        {
                            dgv.DataSource = dt;
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgv.MultiSelect = false;
                            dgv.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

                            if (dgv.Columns.Contains("nis")) dgv.Columns["nis"].HeaderText = "NIS";
                            if (dgv.Columns.Contains("nama")) dgv.Columns["nama"].HeaderText = "Nama";
                            if (dgv.Columns.Contains("jenis_kelamin")) dgv.Columns["jenis_kelamin"].HeaderText = "JK";
                            if (dgv.Columns.Contains("kelas")) dgv.Columns["kelas"].HeaderText = "Kelas";
                            if (dgv.Columns.Contains("wali_kelas")) dgv.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                            if (dgv.Columns.Contains("no_telp")) dgv.Columns["no_telp"].HeaderText = "No. Telp";

                            if (dgv.Columns.Contains("total_point"))
                            {
                                dgv.Columns["total_point"].HeaderText = "Point";
                                dgv.Columns["total_point"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dgv.Columns["total_point"].ReadOnly = true;
                                dgv.Columns["total_point"].Width = 80;
                            }

                            if (dgv.Columns.Contains("status"))
                            {
                                dgv.Columns["status"].HeaderText = "Status";
                                dgv.Columns["status"].Width = 80;
                            }

                            int idx = 0;
                            if (dgv.Columns.Contains("nis")) dgv.Columns["nis"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("nama")) dgv.Columns["nama"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("jenis_kelamin")) dgv.Columns["jenis_kelamin"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("kelas")) dgv.Columns["kelas"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("wali_kelas")) dgv.Columns["wali_kelas"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("no_telp")) dgv.Columns["no_telp"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("total_point")) dgv.Columns["total_point"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("status")) dgv.Columns["status"].DisplayIndex = idx++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                try { MessageBox.Show("Gagal load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }
        }

        private void SearchData(string keyword)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, total_point, status
                        FROM siswa
                        WHERE nis LIKE @q OR nama LIKE @q OR kelas LIKE @q OR wali_kelas LIKE @q
                        ORDER BY nama";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + keyword + "%");
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            var dgvControls = this.Controls.Find("dataGridView1", true);
                            if (dgvControls.Length > 0 && dgvControls[0] is DataGridView dgv)
                                dgv.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal cari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers
        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            string q = GetControlText("txtcari").Trim();
            if (string.IsNullOrWhiteSpace(q)) LoadData();
            else SearchData(q);
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetWalasForSelectedClass();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedRowIndex = e.RowIndex;

            var dgv = this.Controls.Find("dataGridView1", true)[0] as DataGridView;
            var row = dgv.Rows[e.RowIndex];

            SetControlTextIfExists("txtnis", row.Cells["nis"].Value?.ToString() ?? "");
            SetControlTextIfExists("txtnama", row.Cells["nama"].Value?.ToString() ?? "");

            string jk = row.Cells["jenis_kelamin"].Value?.ToString() ?? "";
            if (this.Controls.Find("rblaki", true).Length > 0 && this.Controls.Find("rbpr", true).Length > 0)
            {
                if (!string.IsNullOrEmpty(jk) && jk.ToLower().StartsWith("l"))
                    (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked = true;
                else
                    (this.Controls.Find("rbpr", true)[0] as RadioButton).Checked = true;
            }

            string kelasVal = row.Cells["kelas"].Value?.ToString() ?? "";
            if (this.Controls.Find("cbkelas", true).Length > 0 && cbkelas.Items.Contains(kelasVal))
                cbkelas.SelectedItem = kelasVal;

            currentWalas = row.Cells["wali_kelas"].Value?.ToString() ?? currentWalas;
            SetControlTextIfExists("txtwalas", currentWalas);
            SetControlTextIfExists("lblWalas", currentWalas);
            SetControlTextIfExists("txtnotelp", row.Cells["no_telp"].Value?.ToString() ?? "");

            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;
            if (this.Controls.Find("btnEdit", true).Length > 0) btnEdit.Enabled = true;
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = false;
            if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = true;
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            string nis = GetControlText("txtnis").Trim();
            string nama = GetControlText("txtnama").Trim();

            if (string.IsNullOrWhiteSpace(nis) || string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("NIS dan Nama wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string jk = "";
            if (this.Controls.Find("rblaki", true).Length > 0 && (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked) jk = "L";
            else jk = "P";

            string kelas = this.Controls.Find("cbkelas", true).Length > 0 ? cbkelas.SelectedItem?.ToString() ?? "" : "";
            string walasToUse = currentWalas;
            string notelp = GetControlText("txtnotelp");

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO siswa (nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, total_point, status, created_at)
                        VALUES (@nis, @nama, @jk, @kelas, @walas, @notelp, 0, 'aktif', GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nis", nis);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@jk", jk);
                        cmd.Parameters.AddWithValue("@kelas", kelas);
                        cmd.Parameters.AddWithValue("@walas", walasToUse);
                        cmd.Parameters.AddWithValue("@notelp", notelp);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Siswa berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify event bahwa data siswa berubah
                DataChangedEventManager.Instance.NotifySiswaDataChanged();

                ClearAllForms();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah siswa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Pilih baris yang akan diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = true;
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nis = GetControlText("txtnis").Trim();
            string nama = GetControlText("txtnama").Trim();
            string jk = "";

            if (this.Controls.Find("rblaki", true).Length > 0 && (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked) jk = "L";
            else jk = "P";

            string kelas = this.Controls.Find("cbkelas", true).Length > 0 ? cbkelas.SelectedItem?.ToString() ?? "" : "";
            string walasToUse = currentWalas;
            string notelp = GetControlText("txtnotelp");

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE siswa
                        SET nama = @nama, jenis_kelamin = @jk, kelas = @kelas,
                            wali_kelas = @walas, no_telp = @notelp
                        WHERE nis = @nis";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@jk", jk);
                        cmd.Parameters.AddWithValue("@kelas", kelas);
                        cmd.Parameters.AddWithValue("@walas", walasToUse);
                        cmd.Parameters.AddWithValue("@notelp", notelp);
                        cmd.Parameters.AddWithValue("@nis", nis);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            MessageBox.Show("Data siswa diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Update gagal (NIS tidak ditemukan).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Notify event bahwa data siswa berubah
                DataChangedEventManager.Instance.NotifySiswaDataChanged();

                LoadData();
                ClearAllForms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Pilih baris yang akan dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nis = GetControlText("txtnis").Trim();
            var conf = MessageBox.Show($"Hapus siswa dengan NIS {nis} ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conf != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "DELETE FROM siswa WHERE nis = @nis";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nis", nis);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Siswa dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Hapus gagal (NIS tidak ditemukan).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Notify event bahwa data siswa berubah
                DataChangedEventManager.Instance.NotifySiswaDataChanged();

                LoadData();
                ClearAllForms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            ClearAllForms();
        }

        // ===== FUNGSI EKSPOR DENGAN PERBAIKAN =====
        // ===== FUNGSI EKSPOR DENGAN PERBAIKAN (TANPA REFLECTION) =====
        // ===== FUNGSI EKSPOR =====
        // ===== FUNGSI EKSPOR =====
        // ===== FUNGSI EKSPOR =====
        private void btnEkspor_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("Proses sedang berjalan, mohon tunggu...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                isProcessing = true;
                refreshTimer.Stop();

                var dgvCtrls = this.Controls.Find("dataGridView1", true);
                if (dgvCtrls.Length == 0 || !(dgvCtrls[0] is DataGridView dgv) || dgv.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diekspor.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FileName = $"siswa_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    string exportDir = Path.GetDirectoryName(sfd.FileName);
                    string siswaCsv = sfd.FileName;
                    string pelanggaranCsv = Path.Combine(exportDir, $"pelanggaran_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
                    string suratCsv = Path.Combine(exportDir, $"surat_peringatan_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

                    ExportTableToCsv("siswa", siswaCsv);
                    ExportTableToCsv("pelanggaran", pelanggaranCsv);
                    ExportTableToCsv("surat_peringatan", suratCsv);

                    var confirm = MessageBox.Show(
                        $"Ekspor selesai ke folder:\n{exportDir}\n\nApakah Anda yakin ingin mengosongkan seluruh data di tabel siswa? Tindakan ini TIDAK DAPAT DIBATALKAN.",
                        "Konfirmasi Hapus Semua Data",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (confirm != DialogResult.Yes)
                    {
                        MessageBox.Show("Data tidak dihapus. Ekspor selesai.", "Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (SqlConnection conn = Konn.GetConn())
                    {
                        conn.Open();
                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            try
                            {
                                var parentInfos = new List<(string Schema, string Table, string ParentColumn)>();
                                using (SqlCommand cParents = new SqlCommand(@"
                    SELECT DISTINCT
                        SCHEMA_NAME(pt.schema_id) AS parent_schema,
                        pt.name AS parent_table,
                        pc.name AS parent_column
                    FROM sys.foreign_keys fk
                    JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                    JOIN sys.tables pt ON fk.parent_object_id = pt.object_id
                    JOIN sys.columns pc ON fkc.parent_object_id = pc.object_id AND fkc.parent_column_id = pc.column_id
                    WHERE fk.referenced_object_id = OBJECT_ID(N'dbo.siswa');", conn, tran))
                                using (var rdr = cParents.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {
                                        string schema = rdr.IsDBNull(0) ? "dbo" : rdr.GetString(0);
                                        string table = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                                        string parentCol = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                                        if (!string.IsNullOrEmpty(table) && !string.IsNullOrEmpty(parentCol))
                                        {
                                            parentInfos.Add((schema, table, parentCol));
                                        }
                                    }
                                }

                                var summary = new StringBuilder();
                                var grouped = parentInfos
                                    .GroupBy(p => p.Schema + "." + p.Table)
                                    .Select(g => new { SchemaTable = g.Key, Schema = g.First().Schema, Table = g.First().Table, ParentColumn = g.First().ParentColumn })
                                    .ToList();

                                foreach (var p in grouped)
                                {
                                    string parentSchema = p.Schema;
                                    string parentTable = p.Table;
                                    string parentColumn = p.ParentColumn;
                                    string parentFull = "[" + parentSchema + "].[" + parentTable + "]";
                                    string backupTable = parentTable + "_backup";

                                    summary.AppendLine($"Memproses tabel: {parentFull} (kolom FK: {parentColumn})");

                                    string createBackupSql = $@"
                        IF OBJECT_ID(N'{parentSchema}.{backupTable}','U') IS NULL
                        BEGIN
                          SELECT TOP 0 * INTO [{parentSchema}].[{backupTable}] FROM [{parentSchema}].[{parentTable}];
                        END";
                                    using (SqlCommand cCreate = new SqlCommand(createBackupSql, conn, tran))
                                    {
                                        cCreate.ExecuteNonQuery();
                                    }

                                    var cols = new List<string>();
                                    using (SqlCommand cCols = new SqlCommand(@"
                        SELECT c.name
                        FROM sys.columns c
                        JOIN sys.tables t ON c.object_id = t.object_id
                        WHERE t.name = @tname AND SCHEMA_NAME(t.schema_id) = @schema
                        ORDER BY c.column_id;", conn, tran))
                                    {
                                        cCols.Parameters.AddWithValue("@tname", parentTable);
                                        cCols.Parameters.AddWithValue("@schema", parentSchema);
                                        using (var rdrCols = cCols.ExecuteReader())
                                        {
                                            while (rdrCols.Read()) cols.Add(rdrCols.GetString(0));
                                        }
                                    }

                                    if (cols.Count == 0)
                                    {
                                        summary.AppendLine($" - Gagal: tidak ada kolom ditemukan");
                                        continue;
                                    }

                                    string columnList = string.Join(", ", cols.Select(c => "[" + c + "]"));

                                    bool backupHasIdentity = false;
                                    using (SqlCommand cCheckBackupId = new SqlCommand(@"
                        SELECT TOP 1 1
                        FROM sys.columns c
                        JOIN sys.tables t ON c.object_id = t.object_id
                        WHERE t.name = @backupName AND SCHEMA_NAME(t.schema_id)=@schema AND c.is_identity = 1;", conn, tran))
                                    {
                                        cCheckBackupId.Parameters.AddWithValue("@backupName", backupTable);
                                        cCheckBackupId.Parameters.AddWithValue("@schema", parentSchema);
                                        object o = cCheckBackupId.ExecuteScalar();
                                        backupHasIdentity = o != null && o != DBNull.Value;
                                    }

                                    // ✅ TENTUKAN PRIMARY KEY COLUMN
                                    string pkColumn = "";
                                    if (parentTable == "pelanggaran") pkColumn = "id_pelanggaran";
                                    else if (parentTable == "surat_peringatan") pkColumn = "id_surat";
                                    else pkColumn = parentColumn; // fallback

                                    int inserted = 0;
                                    if (backupHasIdentity)
                                    {
                                        using (SqlCommand cOn = new SqlCommand($"SET IDENTITY_INSERT [{parentSchema}].[{backupTable}] ON;", conn, tran))
                                        {
                                            cOn.ExecuteNonQuery();
                                        }

                                        // ✅ GUNAKAN NOT EXISTS untuk skip duplikat
                                        string insertSql = $@"
                                    INSERT INTO [{parentSchema}].[{backupTable}] ({columnList}) 
                                    SELECT {columnList} 
                                    FROM [{parentSchema}].[{parentTable}] src
                                    WHERE src.[{parentColumn}] IN (SELECT nis FROM dbo.siswa)
                                    AND NOT EXISTS (
                                        SELECT 1 FROM [{parentSchema}].[{backupTable}] bak
                                        WHERE bak.[{pkColumn}] = src.[{pkColumn}]
                                    )";

                                        using (SqlCommand cInsert = new SqlCommand(insertSql, conn, tran))
                                        {
                                            cInsert.CommandTimeout = 0;
                                            inserted = cInsert.ExecuteNonQuery();
                                        }

                                        using (SqlCommand cOff = new SqlCommand($"SET IDENTITY_INSERT [{parentSchema}].[{backupTable}] OFF;", conn, tran))
                                        {
                                            cOff.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        // ✅ GUNAKAN NOT EXISTS untuk skip duplikat
                                        string insertSql = $@"
                                    INSERT INTO [{parentSchema}].[{backupTable}] ({columnList}) 
                                    SELECT {columnList} 
                                    FROM [{parentSchema}].[{parentTable}] src
                                    WHERE src.[{parentColumn}] IN (SELECT nis FROM dbo.siswa)
                                    AND NOT EXISTS (
                                        SELECT 1 FROM [{parentSchema}].[{backupTable}] bak
                                        WHERE bak.[{pkColumn}] = src.[{pkColumn}]
                                    )";

                                        using (SqlCommand cInsert = new SqlCommand(insertSql, conn, tran))
                                        {
                                            cInsert.CommandTimeout = 0;
                                            inserted = cInsert.ExecuteNonQuery();
                                        }
                                    }

                                    int deletedChild = 0;
                                    string delSql = $"DELETE FROM [{parentSchema}].[{parentTable}] WHERE [{parentColumn}] IN (SELECT nis FROM dbo.siswa);";
                                    using (SqlCommand cDel = new SqlCommand(delSql, conn, tran))
                                    {
                                        cDel.CommandTimeout = 0;
                                        deletedChild = cDel.ExecuteNonQuery();
                                    }

                                    summary.AppendLine($" - Diarsipkan: {inserted} baris (baru)");
                                    summary.AppendLine($" - Dihapus child: {deletedChild} baris");
                                }

                                int deletedMaster = 0;
                                using (SqlCommand cDelMaster = new SqlCommand("DELETE FROM dbo.siswa;", conn, tran))
                                {
                                    deletedMaster = cDelMaster.ExecuteNonQuery();
                                }

                                tran.Commit();

                                LoadData();
                                ClearAllForms();

                                summary.AppendLine($"\nBaris siswa yang dihapus: {deletedMaster}");

                                DataChangedEventManager.Instance.NotifyAllDataCleared();

                                MessageBox.Show(summary.ToString(), "Sukses - Arsip & Hapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception exTran)
                            {
                                try { tran.Rollback(); } catch { }
                                MessageBox.Show("Gagal menghapus/arsipkan data: " + exTran.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal proses ekspor & hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                refreshTimer.Start();
            }
        }
        // ===== FUNGSI IMPOR =====
        // ===== FUNGSI IMPOR - VERSI PERBAIKAN =====
        // ===== FUNGSI IMPOR - VERSI PERBAIKAN V2 (HANDLE DUPLICATE KEY) =====
        private void btnimpor_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("Proses sedang berjalan, mohon tunggu...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                isProcessing = true;
                refreshTimer.Stop();

                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    ofd.Title = "Pilih file siswa.csv";

                    if (ofd.ShowDialog() != DialogResult.OK) return;

                    string importDir = Path.GetDirectoryName(ofd.FileName);
                    string siswaCsv = ofd.FileName;
                    string pelanggaranCsv = Directory.GetFiles(importDir, "pelanggaran_export_*.csv").FirstOrDefault();
                    string suratCsv = Directory.GetFiles(importDir, "surat_peringatan_export_*.csv").FirstOrDefault();

                    if (string.IsNullOrEmpty(pelanggaranCsv) || string.IsNullOrEmpty(suratCsv))
                    {
                        MessageBox.Show("Tidak ditemukan pelanggaran.csv atau surat_peringatan.csv di folder yang sama.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var importLog = new StringBuilder();
                    importLog.AppendLine("=== PROSES IMPORT ===");

                    // ===== TRUNCATE TABLES DULU SEBELUM IMPORT =====
                    try
                    {
                        using (SqlConnection conn = Konn.GetConn())
                        {
                            conn.Open();
                            using (SqlTransaction tran = conn.BeginTransaction())
                            {
                                try
                                {
                                    // Hapus data di child tables dulu
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.surat_peringatan;", conn, tran))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.pelanggaran;", conn, tran))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.siswa;", conn, tran))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }

                                    tran.Commit();
                                    importLog.AppendLine("✓ Tabel berhasil dikosongkan");
                                }
                                catch
                                {
                                    tran.Rollback();
                                    throw;
                                }
                            }
                        }
                    }
                    catch (Exception exTruncate)
                    {
                        importLog.AppendLine($"✗ Gagal mengosongkan tabel: {exTruncate.Message}");
                    }

                    try
                    {
                        importLog.AppendLine("1. Import siswa...");
                        ImportCsvToTable(siswaCsv, "siswa");
                        importLog.AppendLine("   ✓ Siswa berhasil di-import");

                        importLog.AppendLine("2. Import pelanggaran...");
                        ImportCsvToTable(pelanggaranCsv, "pelanggaran");
                        importLog.AppendLine("   ✓ Pelanggaran berhasil di-import");

                        importLog.AppendLine("3. Import surat peringatan...");
                        ImportCsvToTable(suratCsv, "surat_peringatan");
                        importLog.AppendLine("   ✓ Surat peringatan berhasil di-import");
                    }
                    catch (Exception exImport)
                    {
                        MessageBox.Show($"Gagal import CSV: {exImport.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    importLog.AppendLine();
                    importLog.AppendLine("=== RECALCULATE TOTAL POINT ===");
                    try
                    {
                        PointsRecalculator.RecalculateAllPoints(Konn);
                        importLog.AppendLine("✓ Total point siswa berhasil dihitung ulang");
                    }
                    catch (Exception exRecalc)
                    {
                        importLog.AppendLine($"✗ Gagal recalculate point: {exRecalc.Message}");
                    }

                    // ===== RESTORE BACKUP TABLES - V2 WITH ROW-BY-ROW INSERT =====
                    importLog.AppendLine();
                    importLog.AppendLine("=== RESTORE BACKUP TABLES ===");
                    try
                    {
                        using (SqlConnection conn = Konn.GetConn())
                        {
                            conn.Open();
                            using (SqlTransaction tran = conn.BeginTransaction())
                            {
                                try
                                {
                                    // ===== CHECK TABEL BACKUP EXISTS =====
                                    bool pelanggaranBackupExists = false;
                                    bool suratBackupExists = false;

                                    using (SqlCommand cmd = new SqlCommand(@"
                                SELECT COUNT(1) 
                                FROM INFORMATION_SCHEMA.TABLES 
                                WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='pelanggaran_backup'", conn, tran))
                                    {
                                        pelanggaranBackupExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                                    }

                                    using (SqlCommand cmd = new SqlCommand(@"
                                SELECT COUNT(1) 
                                FROM INFORMATION_SCHEMA.TABLES 
                                WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='surat_peringatan_backup'", conn, tran))
                                    {
                                        suratBackupExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                                    }

                                    if (!pelanggaranBackupExists && !suratBackupExists)
                                    {
                                        importLog.AppendLine("ℹ️ Tidak ada tabel backup yang ditemukan");
                                        tran.Commit();
                                        LoadData();
                                        ClearAllForms();
                                        DataChangedEventManager.Instance.NotifyAllDataCleared();
                                        MessageBox.Show(importLog.ToString(), "✓ Import Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }

                                    // ===== RESTORE PELANGGARAN BACKUP - ROW BY ROW =====
                                    if (pelanggaranBackupExists)
                                    {
                                        int pelanggaranBackupCount = 0;
                                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM pelanggaran_backup", conn, tran))
                                        {
                                            pelanggaranBackupCount = Convert.ToInt32(cmd.ExecuteScalar());
                                        }

                                        importLog.AppendLine($"📦 pelanggaran_backup: {pelanggaranBackupCount} baris ditemukan");

                                        if (pelanggaranBackupCount > 0)
                                        {
                                            // Ambil column list
                                            var pelanggaranCols = new List<string>();
                                            using (SqlCommand cmd = new SqlCommand(@"
                                        SELECT COLUMN_NAME 
                                        FROM INFORMATION_SCHEMA.COLUMNS 
                                        WHERE TABLE_NAME='pelanggaran' AND TABLE_SCHEMA='dbo'
                                        ORDER BY ORDINAL_POSITION", conn, tran))
                                            {
                                                using (var reader = cmd.ExecuteReader())
                                                {
                                                    while (reader.Read()) pelanggaranCols.Add(reader.GetString(0));
                                                }
                                            }

                                            if (pelanggaranCols.Count > 0)
                                            {
                                                string colList = string.Join(", ", pelanggaranCols.Select(c => "[" + c + "]"));

                                                // SET IDENTITY_INSERT ON
                                                using (SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.pelanggaran ON;", conn, tran))
                                                {
                                                    cmd.ExecuteNonQuery();
                                                }

                                                // FETCH DATA FROM BACKUP
                                                DataTable dtBackup = new DataTable();
                                                using (SqlCommand cmd = new SqlCommand($"SELECT {colList} FROM pelanggaran_backup", conn, tran))
                                                {
                                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                                    {
                                                        da.Fill(dtBackup);
                                                    }
                                                }

                                                int restored = 0;
                                                int skipped = 0;

                                                // INSERT ROW BY ROW DENGAN ERROR HANDLING
                                                foreach (DataRow row in dtBackup.Rows)
                                                {
                                                    try
                                                    {
                                                        int idPelanggaran = Convert.ToInt32(row["id_pelanggaran"]);

                                                        // Cek apakah ID sudah ada
                                                        bool exists = false;
                                                        using (SqlCommand cmdCheck = new SqlCommand(
                                                            "SELECT COUNT(1) FROM pelanggaran WHERE id_pelanggaran = @id", conn, tran))
                                                        {
                                                            cmdCheck.Parameters.AddWithValue("@id", idPelanggaran);
                                                            exists = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                                                        }

                                                        if (exists)
                                                        {
                                                            skipped++;
                                                            continue; // Skip jika sudah ada
                                                        }

                                                        // Build INSERT statement
                                                        var paramNames = pelanggaranCols.Select(c => "@" + c).ToList();
                                                        string insertSql = $"INSERT INTO dbo.pelanggaran ({colList}) VALUES ({string.Join(", ", paramNames)})";

                                                        using (SqlCommand cmdInsert = new SqlCommand(insertSql, conn, tran))
                                                        {
                                                            foreach (var col in pelanggaranCols)
                                                            {
                                                                cmdInsert.Parameters.AddWithValue("@" + col,
                                                                    row[col] == DBNull.Value ? (object)DBNull.Value : row[col]);
                                                            }
                                                            cmdInsert.ExecuteNonQuery();
                                                            restored++;
                                                        }
                                                    }
                                                    catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                                                    {
                                                        // Duplicate key - skip
                                                        skipped++;
                                                        System.Diagnostics.Debug.WriteLine($"Skipped duplicate ID: {row["id_pelanggaran"]}");
                                                    }
                                                    catch (Exception exRow)
                                                    {
                                                        System.Diagnostics.Debug.WriteLine($"Error restore row ID {row["id_pelanggaran"]}: {exRow.Message}");
                                                        skipped++;
                                                    }
                                                }

                                                // SET IDENTITY_INSERT OFF
                                                using (SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.pelanggaran OFF;", conn, tran))
                                                {
                                                    cmd.ExecuteNonQuery();
                                                }

                                                importLog.AppendLine($"✅ Restored {restored} baris dari pelanggaran_backup");
                                                if (skipped > 0)
                                                {
                                                    importLog.AppendLine($"⏭️ Skipped {skipped} baris (duplicate/error)");
                                                }
                                            }
                                            else
                                            {
                                                importLog.AppendLine("⚠️ Tidak ada kolom ditemukan untuk pelanggaran");
                                            }
                                        }
                                    }

                                    // ===== RESTORE SURAT PERINGATAN BACKUP - ROW BY ROW =====
                                    if (suratBackupExists)
                                    {
                                        int suratBackupCount = 0;
                                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM surat_peringatan_backup", conn, tran))
                                        {
                                            suratBackupCount = Convert.ToInt32(cmd.ExecuteScalar());
                                        }

                                        importLog.AppendLine($"📦 surat_peringatan_backup: {suratBackupCount} baris ditemukan");

                                        if (suratBackupCount > 0)
                                        {
                                            // Ambil column list
                                            var suratCols = new List<string>();
                                            using (SqlCommand cmd = new SqlCommand(@"
                                        SELECT COLUMN_NAME 
                                        FROM INFORMATION_SCHEMA.COLUMNS 
                                        WHERE TABLE_NAME='surat_peringatan' AND TABLE_SCHEMA='dbo'
                                        ORDER BY ORDINAL_POSITION", conn, tran))
                                            {
                                                using (var reader = cmd.ExecuteReader())
                                                {
                                                    while (reader.Read()) suratCols.Add(reader.GetString(0));
                                                }
                                            }

                                            if (suratCols.Count > 0)
                                            {
                                                string colList = string.Join(", ", suratCols.Select(c => "[" + c + "]"));

                                                // SET IDENTITY_INSERT ON
                                                using (SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.surat_peringatan ON;", conn, tran))
                                                {
                                                    cmd.ExecuteNonQuery();
                                                }

                                                // FETCH DATA FROM BACKUP
                                                DataTable dtBackup = new DataTable();
                                                using (SqlCommand cmd = new SqlCommand($"SELECT {colList} FROM surat_peringatan_backup", conn, tran))
                                                {
                                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                                    {
                                                        da.Fill(dtBackup);
                                                    }
                                                }

                                                int restored = 0;
                                                int skipped = 0;

                                                // INSERT ROW BY ROW DENGAN ERROR HANDLING
                                                foreach (DataRow row in dtBackup.Rows)
                                                {
                                                    try
                                                    {
                                                        int idSurat = Convert.ToInt32(row["id_surat"]);

                                                        // Cek apakah ID sudah ada
                                                        bool exists = false;
                                                        using (SqlCommand cmdCheck = new SqlCommand(
                                                            "SELECT COUNT(1) FROM surat_peringatan WHERE id_surat = @id", conn, tran))
                                                        {
                                                            cmdCheck.Parameters.AddWithValue("@id", idSurat);
                                                            exists = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                                                        }

                                                        if (exists)
                                                        {
                                                            skipped++;
                                                            continue; // Skip jika sudah ada
                                                        }

                                                        // Build INSERT statement
                                                        var paramNames = suratCols.Select(c => "@" + c).ToList();
                                                        string insertSql = $"INSERT INTO dbo.surat_peringatan ({colList}) VALUES ({string.Join(", ", paramNames)})";

                                                        using (SqlCommand cmdInsert = new SqlCommand(insertSql, conn, tran))
                                                        {
                                                            foreach (var col in suratCols)
                                                            {
                                                                cmdInsert.Parameters.AddWithValue("@" + col,
                                                                    row[col] == DBNull.Value ? (object)DBNull.Value : row[col]);
                                                            }
                                                            cmdInsert.ExecuteNonQuery();
                                                            restored++;
                                                        }
                                                    }
                                                    catch (SqlException sqlEx) when (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                                                    {
                                                        // Duplicate key - skip
                                                        skipped++;
                                                        System.Diagnostics.Debug.WriteLine($"Skipped duplicate ID: {row["id_surat"]}");
                                                    }
                                                    catch (Exception exRow)
                                                    {
                                                        System.Diagnostics.Debug.WriteLine($"Error restore row ID {row["id_surat"]}: {exRow.Message}");
                                                        skipped++;
                                                    }
                                                }

                                                // SET IDENTITY_INSERT OFF
                                                using (SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.surat_peringatan OFF;", conn, tran))
                                                {
                                                    cmd.ExecuteNonQuery();
                                                }

                                                importLog.AppendLine($"✅ Restored {restored} baris dari surat_peringatan_backup");
                                                if (skipped > 0)
                                                {
                                                    importLog.AppendLine($"⏭️ Skipped {skipped} baris (duplicate/error)");
                                                }
                                            }
                                            else
                                            {
                                                importLog.AppendLine("⚠️ Tidak ada kolom ditemukan untuk surat_peringatan");
                                            }
                                        }
                                    }

                                    tran.Commit();
                                    importLog.AppendLine("✅ Restore backup selesai");
                                }
                                catch (Exception exRestore)
                                {
                                    tran.Rollback();
                                    importLog.AppendLine($"❌ Gagal restore backup: {exRestore.Message}");
                                    System.Diagnostics.Debug.WriteLine($"Restore Error Detail: {exRestore.ToString()}");
                                }
                            }
                        }
                    }
                    catch (Exception exBackup)
                    {
                        importLog.AppendLine($"❌ Error saat proses restore: {exBackup.Message}");
                        System.Diagnostics.Debug.WriteLine($"Backup Process Error: {exBackup.ToString()}");
                    }

                    LoadData();
                    ClearAllForms();

                    DataChangedEventManager.Instance.NotifyAllDataCleared();

                    MessageBox.Show(importLog.ToString(), "✓ Import Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal proses impor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                refreshTimer.Start();
            }
        }



        private string QuoteCsv(string s)
        {
            if (s == null) return "";
            bool mustQuote = s.Contains(",") || s.Contains("\"") || s.Contains("\r") || s.Contains("\n");
            string escaped = s.Replace("\"", "\"\"");
            return mustQuote ? $"\"{escaped}\"" : escaped;
        }

        // ===== HELPER: PARSE CSV LINE =====
        private List<string> ParseCsvLine(string line)
        {
            var fields = new List<string>();
            if (line == null) return fields;

            var cur = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            cur.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        cur.Append(c);
                    }
                }
                else
                {
                    if (c == ',')
                    {
                        fields.Add(cur.ToString());
                        cur.Clear();
                    }
                    else if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else
                    {
                        cur.Append(c);
                    }
                }
            }
            fields.Add(cur.ToString());
            return fields;
        }

        // ===== HELPER: EXPORT TABLE TO CSV =====
        private void ExportTableToCsv(string tableName, string csvFilePath)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = $"SELECT * FROM dbo.{tableName}";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        using (var sw = new StreamWriter(csvFilePath, false, new UTF8Encoding(true)))
                        {
                            string headerLine = string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => QuoteCsv(c.ColumnName)));
                            sw.WriteLine(headerLine);

                            foreach (DataRow row in dt.Rows)
                            {
                                string line = string.Join(",", row.ItemArray.Select(v => QuoteCsv(v?.ToString())));
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal ekspor tabel {tableName}: {ex.Message}");
            }
        }

        // ===== HELPER: IMPORT CSV TO TABLE =====
        private void ImportCsvToTable(string csvFilePath, string tableName)
        {
            if (!File.Exists(csvFilePath))
                throw new FileNotFoundException($"File CSV tidak ditemukan: {csvFilePath}");

            int inserted = 0, skipped = 0;
            var errors = new List<string>();
            var lines = File.ReadAllLines(csvFilePath, Encoding.UTF8);

            if (lines.Length == 0) throw new Exception("File CSV kosong.");

            System.Diagnostics.Debug.WriteLine($"📄 CSV File: {Path.GetFileName(csvFilePath)}");
            System.Diagnostics.Debug.WriteLine($"📊 Total Lines: {lines.Length} (termasuk header)");

            var headerFields = ParseCsvLine(lines[0].Trim());
            var colIndex = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < headerFields.Count; i++)
                colIndex[headerFields[i]] = i;

            string pkColumn = "";
            if (tableName == "siswa") pkColumn = "nis";
            else if (tableName == "pelanggaran") pkColumn = "id_pelanggaran";
            else if (tableName == "surat_peringatan") pkColumn = "id_surat";
            else throw new ArgumentException("Tabel tidak didukung.");

            if (!colIndex.ContainsKey(pkColumn))
                throw new Exception($"Header CSV harus berisi kolom PK '{pkColumn}'.");

            var tableCols = GetTableColumns(tableName);

            using (SqlConnection conn = Konn.GetConn())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        bool hasIdentity = IsIdentityColumn(tableName, pkColumn, conn, tran);

                        for (int r = 1; r < lines.Length; r++)
                        {
                            string raw = lines[r];
                            if (string.IsNullOrWhiteSpace(raw))
                            {
                                System.Diagnostics.Debug.WriteLine($"⚠️ Baris {r + 1}: Kosong, skip");
                                skipped++;
                                continue;
                            }

                            var fields = ParseCsvLine(raw);
                            if (fields.Count == 0)
                            {
                                System.Diagnostics.Debug.WriteLine($"⚠️ Baris {r + 1}: Tidak ada field, skip");
                                skipped++;
                                continue;
                            }

                            string pkVal = colIndex.ContainsKey(pkColumn) && colIndex[pkColumn] < fields.Count
                                ? fields[colIndex[pkColumn]] : "";

                            if (string.IsNullOrWhiteSpace(pkVal))
                            {
                                string errorMsg = $"Baris {r + 1}: PK '{pkColumn}' kosong, dilewati.";
                                errors.Add(errorMsg);
                                System.Diagnostics.Debug.WriteLine($"❌ {errorMsg}");
                                skipped++;
                                continue;
                            }

                            System.Diagnostics.Debug.WriteLine($"🔄 Processing Row {r + 1}: {pkColumn}={pkVal}");

                            var paramDict = new Dictionary<string, object>();
                            foreach (var col in tableCols)
                            {
                                if (colIndex.ContainsKey(col) && colIndex[col] < fields.Count)
                                {
                                    string val = fields[colIndex[col]];
                                    paramDict[col] = string.IsNullOrEmpty(val) ? DBNull.Value : (object)val;
                                }
                            }

                            bool exists = false;
                            try
                            {
                                using (SqlCommand ccheck = new SqlCommand($"SELECT COUNT(1) FROM dbo.{tableName} WHERE {pkColumn} = @pk", conn, tran))
                                {
                                    ccheck.Parameters.AddWithValue("@pk", pkVal);
                                    exists = Convert.ToInt32(ccheck.ExecuteScalar()) > 0;
                                }
                            }
                            catch (Exception exCheck)
                            {
                                string errorMsg = $"Baris {r + 1}: Error saat cek exist - {exCheck.Message}";
                                errors.Add(errorMsg);
                                System.Diagnostics.Debug.WriteLine($"❌ {errorMsg}");
                                skipped++;
                                continue;
                            }

                            if (exists)
                            {
                                System.Diagnostics.Debug.WriteLine($"⏭️ Skip: {pkColumn}={pkVal} (sudah ada)");
                                skipped++;
                                continue;
                            }

                            try
                            {
                                var insertCols = paramDict.Keys.ToList();
                                string colList = string.Join(", ", insertCols.Select(c => "[" + c + "]"));
                                string valList = string.Join(", ", insertCols.Select(c => "@" + c));

                                string insertSql = $"INSERT INTO dbo.{tableName} ({colList}) VALUES ({valList})";

                                if (hasIdentity)
                                {
                                    using (SqlCommand cOn = new SqlCommand($"SET IDENTITY_INSERT dbo.{tableName} ON;", conn, tran))
                                    {
                                        cOn.ExecuteNonQuery();
                                    }
                                }

                                using (SqlCommand cIns = new SqlCommand(insertSql, conn, tran))
                                {
                                    foreach (var kv in paramDict)
                                    {
                                        cIns.Parameters.AddWithValue("@" + kv.Key, kv.Value);
                                    }
                                    cIns.ExecuteNonQuery();
                                    inserted++;
                                    System.Diagnostics.Debug.WriteLine($"✅ Inserted: {pkColumn}={pkVal}");
                                }

                                if (hasIdentity)
                                {
                                    using (SqlCommand cOff = new SqlCommand($"SET IDENTITY_INSERT dbo.{tableName} OFF;", conn, tran))
                                    {
                                        cOff.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch (Exception exInsert)
                            {
                                string errorMsg = $"Baris {r + 1} ({pkColumn}={pkVal}): {exInsert.Message}";
                                errors.Add(errorMsg);
                                System.Diagnostics.Debug.WriteLine($"❌ Insert Error: {errorMsg}");

                                if (exInsert.Message.Contains("FOREIGN KEY") || exInsert.Message.Contains("REFERENCE"))
                                {
                                    System.Diagnostics.Debug.WriteLine($"   💡 Hint: Mungkin NIS siswa belum ada di tabel siswa");
                                }

                                skipped++;
                                continue;
                            }
                        }

                        tran.Commit();

                        System.Diagnostics.Debug.WriteLine("");
                        System.Diagnostics.Debug.WriteLine($"📊 IMPORT SUMMARY - {tableName}");
                        System.Diagnostics.Debug.WriteLine($"   ✅ Inserted: {inserted}");
                        System.Diagnostics.Debug.WriteLine($"   ⏭️ Skipped: {skipped}");
                        System.Diagnostics.Debug.WriteLine($"   ❌ Errors: {errors.Count}");

                        if (errors.Count > 0)
                        {
                            System.Diagnostics.Debug.WriteLine($"   📝 Error Details:");
                            foreach (var err in errors.Take(10))
                            {
                                System.Diagnostics.Debug.WriteLine($"      - {err}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        System.Diagnostics.Debug.WriteLine($"💥 FATAL ERROR during import {tableName}: {ex.Message}");
                        throw new Exception($"Gagal impor {tableName}: {ex.Message}");
                    }
                }
            }
        }

        // ===== HELPER: GET TABLE COLUMNS =====
        private List<string> GetTableColumns(string tableName)
        {
            var cols = new List<string>();
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                SELECT COLUMN_NAME 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA = 'dbo'
                ORDER BY ORDINAL_POSITION";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tableName", tableName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cols.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch { }
            return cols;
        }

        // ===== HELPER: CHECK IDENTITY COLUMN =====
        private bool IsIdentityColumn(string tableName, string columnName, SqlConnection conn, SqlTransaction tran)
        {
            try
            {
                string sql = @"
            SELECT COLUMNPROPERTY(OBJECT_ID(@tableName), @columnName, 'IsIdentity')";

                using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@tableName", "dbo." + tableName);
                    cmd.Parameters.AddWithValue("@columnName", columnName);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value && Convert.ToInt32(result) == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        private void txtnis_TextChanged(object sender, EventArgs e) { }
        private void txtnama_TextChanged(object sender, EventArgs e) { }
        private void rblaki_CheckedChanged(object sender, EventArgs e) { }
        private void rbpr_CheckedChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Formtambahsiswa_Load_1(object sender, EventArgs e) { }
        private void groupBox4_Enter(object sender, EventArgs e) { }
    }
}