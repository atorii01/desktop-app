using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormInputPelanggaran : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private int selectedIdPelanggaran = -1;
        private BindingSource bs = new BindingSource();
        private readonly string placeholderCari = "cari pelanggaran";
        private bool isProcessing = false;

        public FormInputPelanggaran()
        {
            InitializeComponent();

            // Subscribe ke event manager SEBELUM load
            DataChangedEventManager.Instance.SiswaDataChanged += OnSiswaDataChanged;
            DataChangedEventManager.Instance.AllDataCleared += OnAllDataCleared;

            // Load event - tambahkan di sini juga
            this.Load += FormInputPelanggaran_Load_1;

            // Event wiring
            if (txtNisSiswa != null) txtNisSiswa.Leave += TxtNisSiswa_Leave;
            if (txtidjenispelanggaran != null) txtidjenispelanggaran.Leave += TxtIdJenisPelanggaran_Leave;
            if (btntambah != null) btntambah.Click += btntambah_Click;
            if (btnEdit != null) btnEdit.Click += btnEdit_Click;
            if (btnUpdate != null) btnUpdate.Click += btnUpdate_Click;
            if (btnhapus != null) btnhapus.Click += btnhapus_Click;
            if (btnbatal != null) btnbatal.Click += btnbatal_Click;
            if (dataGridView1 != null) dataGridView1.CellClick += dataGridView1_CellClick;

            if (txtcari != null)
            {
                txtcari.GotFocus += Txtcari_GotFocus;
                txtcari.LostFocus += Txtcari_LostFocus;
                txtcari.TextChanged += Txtcari_TextChanged;
                txtcari.ForeColor = Color.Gray;
                txtcari.Text = placeholderCari;
            }

            // Subscribe form closing untuk cleanup
            this.FormClosing += FormInputPelanggaran_FormClosing;
        }

        // ===== NEW: HELPER METHOD UNTUK SYNC BACKUP =====
        private void SyncBackupTable(SqlConnection conn, SqlTransaction tran, string tableName, string pkColumn, object pkValue, string operation)
        {
            try
            {
                string backupTableName = tableName + "_backup";

                // Cek apakah tabel backup exists
                bool backupExists = false;
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(1) 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@tname", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@tname", backupTableName);
                    backupExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }

                if (!backupExists)
                {
                    System.Diagnostics.Debug.WriteLine($"Backup table {backupTableName} tidak ada, skip sync");
                    return;
                }

                if (operation == "DELETE")
                {
                    // Hapus dari backup juga
                    string deleteSql = $"DELETE FROM dbo.{backupTableName} WHERE [{pkColumn}] = @pk";
                    using (SqlCommand cmd = new SqlCommand(deleteSql, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@pk", pkValue);
                        int deleted = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Sync backup: Deleted {deleted} rows from {backupTableName}");
                    }
                }
                else if (operation == "INSERT" || operation == "UPDATE")
                {
                    // Ambil column list
                    var cols = new List<string>();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT COLUMN_NAME 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_NAME=@tname AND TABLE_SCHEMA='dbo'
                        ORDER BY ORDINAL_POSITION", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@tname", tableName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) cols.Add(reader.GetString(0));
                        }
                    }

                    if (cols.Count == 0) return;

                    string colList = string.Join(", ", cols.Select(c => "[" + c + "]"));

                    // Cek apakah data sudah ada di backup
                    bool existsInBackup = false;
                    using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(1) FROM dbo.{backupTableName} WHERE [{pkColumn}] = @pk", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@pk", pkValue);
                        existsInBackup = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }

                    // Cek apakah table punya identity column
                    bool hasIdentity = false;
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT COLUMNPROPERTY(OBJECT_ID(@tableName), @columnName, 'IsIdentity')", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@tableName", "dbo." + backupTableName);
                        cmd.Parameters.AddWithValue("@columnName", pkColumn);
                        object result = cmd.ExecuteScalar();
                        hasIdentity = result != null && result != DBNull.Value && Convert.ToInt32(result) == 1;
                    }

                    if (existsInBackup)
                    {
                        // UPDATE di backup
                        if (hasIdentity)
                        {
                            using (SqlCommand cmd = new SqlCommand($"SET IDENTITY_INSERT dbo.{backupTableName} ON;", conn, tran))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string updateSql = $@"
                            DELETE FROM dbo.{backupTableName} WHERE [{pkColumn}] = @pk;
                            INSERT INTO dbo.{backupTableName} ({colList})
                            SELECT {colList} FROM dbo.{tableName} WHERE [{pkColumn}] = @pk";

                        using (SqlCommand cmd = new SqlCommand(updateSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pk", pkValue);
                            cmd.ExecuteNonQuery();
                            System.Diagnostics.Debug.WriteLine($"Sync backup: Updated row in {backupTableName}");
                        }

                        if (hasIdentity)
                        {
                            using (SqlCommand cmd = new SqlCommand($"SET IDENTITY_INSERT dbo.{backupTableName} OFF;", conn, tran))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // INSERT ke backup
                        if (hasIdentity)
                        {
                            using (SqlCommand cmd = new SqlCommand($"SET IDENTITY_INSERT dbo.{backupTableName} ON;", conn, tran))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string insertSql = $@"
                            INSERT INTO dbo.{backupTableName} ({colList})
                            SELECT {colList} FROM dbo.{tableName} WHERE [{pkColumn}] = @pk";

                        using (SqlCommand cmd = new SqlCommand(insertSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pk", pkValue);
                            int inserted = cmd.ExecuteNonQuery();
                            System.Diagnostics.Debug.WriteLine($"Sync backup: Inserted {inserted} rows to {backupTableName}");
                        }

                        if (hasIdentity)
                        {
                            using (SqlCommand cmd = new SqlCommand($"SET IDENTITY_INSERT dbo.{backupTableName} OFF;", conn, tran))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error syncing backup table: {ex.Message}");
                // Jangan throw error, biarkan operasi utama tetap jalan
            }
        }

        private void FormInputPelanggaran_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe dari event manager untuk mencegah memory leak
            DataChangedEventManager.Instance.SiswaDataChanged -= OnSiswaDataChanged;
            DataChangedEventManager.Instance.AllDataCleared -= OnAllDataCleared;
        }

        // Handler ketika data siswa berubah dari form lain
        private void OnSiswaDataChanged(object sender, EventArgs e)
        {
            // Reload grid karena data siswa berubah (bisa mempengaruhi relasi)
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => LoadGrid()));
            }
            else
            {
                LoadGrid();
            }
        }

        // Handler ketika semua data dihapus (setelah ekspor)
        private void OnAllDataCleared(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("FormInputPelanggaran: OnAllDataCleared triggered!");

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        System.Diagnostics.Debug.WriteLine("FormInputPelanggaran: Executing reset and LoadGrid");

                        // ===== RESET FILTER DULU SEBELUM LOAD =====
                        if (bs != null)
                        {
                            bs.RemoveFilter();
                        }

                        if (txtcari != null)
                        {
                            txtcari.TextChanged -= Txtcari_TextChanged;
                            txtcari.Text = placeholderCari;
                            txtcari.ForeColor = Color.Gray;
                            txtcari.TextChanged += Txtcari_TextChanged;
                        }

                        // Load grid & clear form
                        LoadGrid();
                        ClearForm();

                        MessageBox.Show("Form Pelanggaran telah di-reset.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("FormInputPelanggaran: Executing reset and LoadGrid (direct)");

                    // Reset filter
                    if (bs != null)
                    {
                        bs.RemoveFilter();
                    }

                    if (txtcari != null)
                    {
                        txtcari.TextChanged -= Txtcari_TextChanged;
                        txtcari.Text = placeholderCari;
                        txtcari.ForeColor = Color.Gray;
                        txtcari.TextChanged += Txtcari_TextChanged;
                    }

                    LoadGrid();
                    ClearForm();

                    MessageBox.Show("Form Pelanggaran telah di-reset.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FormInputPelanggaran: Error in OnAllDataCleared - {ex.Message}");
                MessageBox.Show($"Error clearing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txtcari_TextChanged(object sender, EventArgs e)
        {
            if (txtcari.Text == placeholderCari) return;
            string keyword = txtcari.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword))
            {
                bs.RemoveFilter();
            }
            else
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    string filter = $"nis LIKE '%{keyword}%' OR nama_siswa LIKE '%{keyword}%' OR nama_pelanggaran LIKE '%{keyword}%'";
                    bs.Filter = filter;
                }
            }
        }

        private void Txtcari_GotFocus(object sender, EventArgs e)
        {
            if (txtcari.Text == placeholderCari)
            {
                txtcari.Text = "";
                txtcari.ForeColor = Color.Black;
            }
        }

        private void Txtcari_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcari.Text))
            {
                txtcari.Text = placeholderCari;
                txtcari.ForeColor = Color.Gray;
            }
        }

        private void FormInputPelanggaran_Load_1(object sender, EventArgs e)
        {
            if (txtid_pelanggaran != null)
            {
                txtid_pelanggaran.Text = GetNextIdPelanggaran().ToString();
                txtid_pelanggaran.ReadOnly = true;
            }
            if (dateKejadian != null) dateKejadian.Value = DateTime.Today;
            if (txtWaktuKejadian != null) txtWaktuKejadian.Text = DateTime.Now.ToString("HH:mm");

            LoadGrid();
            SetInitialButtonState();
        }

        private void SetInitialButtonState()
        {
            btntambah.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnhapus.Enabled = false;
        }

        private int GetNextIdPelanggaran()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(id_pelanggaran),0)+1 FROM dbo.pelanggaran", conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 1;
            }
        }

        private bool ColumnExists(string tableName, string columnName)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@table AND COLUMN_NAME=@col";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@table", tableName);
                        cmd.Parameters.AddWithValue("@col", columnName);
                        return Convert.ToInt32(cmd.ExecuteScalar() ?? 0) > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void LoadGrid()
        {
            try
            {
                bool hasKodeGuru = ColumnExists("pelanggaran", "kode_guru");

                string selectCols = @"
            p.id_pelanggaran,
            p.nis,
            ISNULL(s.nama, '') AS nama_siswa,
            ISNULL(s.kelas, '') AS kelas,
            ISNULL(s.wali_kelas, '') AS wali_kelas,
            p.id_jenis,
            ISNULL(j.nama_pelanggaran, '') AS nama_pelanggaran,
            ISNULL(j.point, 0) AS point,
            p.tanggal, p.waktu, p.tempat_kejadian, p.keterangan, p.created_at";

                if (hasKodeGuru) selectCols += ", p.kode_guru";

                string sql = $"SELECT {selectCols} FROM dbo.pelanggaran p LEFT JOIN dbo.siswa s ON p.nis = s.nis LEFT JOIN dbo.jenis_pelanggaran j ON p.id_jenis = j.id_jenis ORDER BY p.id_pelanggaran DESC";

                DataTable dt = new DataTable();
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }
                }

                // ===== LOG UNTUK DEBUG =====
                System.Diagnostics.Debug.WriteLine($"LoadGrid: Query returned {dt.Rows.Count} rows from database");

                foreach (DataRow r in dt.Rows)
                    for (int c = 0; c < dt.Columns.Count; c++)
                        if (r.IsNull(c)) r[c] = "";

                bs.DataSource = dt;
                bs.RemoveFilter(); // ===== PENTING: REMOVE FILTER APAPUN =====
                dataGridView1.DataSource = bs;

                // ===== LOG SETELAH BINDING =====
                System.Diagnostics.Debug.WriteLine($"LoadGrid: Grid now has {dataGridView1.Rows.Count} visible rows");
                System.Diagnostics.Debug.WriteLine($"LoadGrid: BindingSource filter = '{bs.Filter}'");

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.RowTemplate.Height = 26;

                // ... (header text setup sama seperti sebelumnya)
                if (dataGridView1.Columns.Contains("id_pelanggaran")) dataGridView1.Columns["id_pelanggaran"].HeaderText = "ID";
                if (dataGridView1.Columns.Contains("nis")) dataGridView1.Columns["nis"].HeaderText = "NIS";
                if (dataGridView1.Columns.Contains("nama_siswa")) dataGridView1.Columns["nama_siswa"].HeaderText = "Nama";
                if (dataGridView1.Columns.Contains("kelas")) dataGridView1.Columns["kelas"].HeaderText = "Kelas";
                if (dataGridView1.Columns.Contains("wali_kelas")) dataGridView1.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                if (dataGridView1.Columns.Contains("id_jenis")) dataGridView1.Columns["id_jenis"].HeaderText = "ID Jenis";
                if (dataGridView1.Columns.Contains("nama_pelanggaran")) dataGridView1.Columns["nama_pelanggaran"].HeaderText = "Jenis Peringatan";
                if (dataGridView1.Columns.Contains("point")) dataGridView1.Columns["point"].HeaderText = "Point";
                if (dataGridView1.Columns.Contains("tanggal")) dataGridView1.Columns["tanggal"].HeaderText = "Tanggal";
                if (dataGridView1.Columns.Contains("waktu")) dataGridView1.Columns["waktu"].HeaderText = "Waktu";
                if (dataGridView1.Columns.Contains("tempat_kejadian")) dataGridView1.Columns["tempat_kejadian"].HeaderText = "Tempat";
                if (dataGridView1.Columns.Contains("keterangan")) dataGridView1.Columns["keterangan"].HeaderText = "Keterangan";
                if (hasKodeGuru && dataGridView1.Columns.Contains("kode_guru")) dataGridView1.Columns["kode_guru"].HeaderText = "Kode Guru";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data pelanggaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetIfControlExists(string name, string value)
        {
            var arr = this.Controls.Find(name, true);
            if (arr.Length > 0)
            {
                if (arr[0] is TextBox tb) tb.Text = value;
                else arr[0].Text = value;
            }
        }

        private string GetIfControlText(string name)
        {
            var arr = this.Controls.Find(name, true);
            if (arr.Length == 0) return "";
            if (arr[0] is TextBox tb) return tb.Text;
            return arr[0].Text;
        }

        private void RecalculateTotalPoint(SqlConnection conn, SqlTransaction tr, string nis)
        {
            string recalcSql = @"
                UPDATE dbo.siswa
                SET total_point = ISNULL(t.sum_point, 0)
                FROM dbo.siswa s
                LEFT JOIN (
                    SELECT p.nis, SUM(ISNULL(j.point,0)) AS sum_point
                    FROM dbo.pelanggaran p
                    LEFT JOIN dbo.jenis_pelanggaran j ON p.id_jenis = j.id_jenis
                    WHERE p.nis = @nis
                    GROUP BY p.nis
                ) t ON s.nis = t.nis
                WHERE s.nis = @nis";
            using (SqlCommand cmd = new SqlCommand(recalcSql, conn, tr))
            {
                cmd.Parameters.AddWithValue("@nis", nis);
                cmd.ExecuteNonQuery();
            }
        }

        private void TxtNisSiswa_Leave(object sender, EventArgs e)
        {
            string nis = GetIfControlText("txtNisSiswa").Trim();
            if (string.IsNullOrWhiteSpace(nis)) return;

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT nama, kelas, wali_kelas FROM dbo.siswa WHERE nis = @nis";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nis", nis);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                SetIfControlExists("txtNama", r["nama"]?.ToString() ?? "");
                                SetIfControlExists("txtkelassiswa", r["kelas"]?.ToString() ?? "");
                                SetIfControlExists("txtWalas", r["wali_kelas"]?.ToString() ?? "");
                            }
                            else
                            {
                                SetIfControlExists("txtNama", "");
                                SetIfControlExists("txtkelassiswa", "");
                                SetIfControlExists("txtWalas", "");
                                MessageBox.Show("NIS tidak ditemukan di data siswa.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ambil data siswa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtIdJenisPelanggaran_Leave(object sender, EventArgs e)
        {
            string idJenisText = GetIfControlText("txtidjenispelanggaran").Trim();
            if (string.IsNullOrWhiteSpace(idJenisText)) return;

            if (!int.TryParse(idJenisText, out int idJenis))
            {
                MessageBox.Show("ID jenis harus angka (contoh: 1, 2, ...).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT nama_pelanggaran, ISNULL(point,0) AS point FROM dbo.jenis_pelanggaran WHERE id_jenis = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idJenis);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                SetIfControlExists("txtNamaPelanggaran", r["nama_pelanggaran"]?.ToString() ?? "");
                                SetIfControlExists("txtPoint", r["point"]?.ToString() ?? "0");
                            }
                            else
                            {
                                SetIfControlExists("txtNamaPelanggaran", "");
                                SetIfControlExists("txtPoint", "0");
                                MessageBox.Show("ID jenis tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ambil data jenis: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btntambah.Enabled = false;

            try
            {
                string nis = GetIfControlText("txtNisSiswa").Trim();
                string kodeGuru = GetIfControlText("txtKodeGuru").Trim();
                string idJenisText = GetIfControlText("txtidjenispelanggaran").Trim();
                DateTime tanggal = dateKejadian.Value.Date;
                string waktuText = GetIfControlText("txtWaktuKejadian").Trim();
                string tempat = GetIfControlText("txtTempatKejadian").Trim();
                string keterangan = GetIfControlText("txtketeranganKejadian").Trim();

                if (string.IsNullOrWhiteSpace(nis) || string.IsNullOrWhiteSpace(idJenisText))
                {
                    string missing = "";
                    if (string.IsNullOrWhiteSpace(nis)) missing += "NIS, ";
                    if (string.IsNullOrWhiteSpace(idJenisText)) missing += "ID Jenis, ";
                    if (missing.EndsWith(", ")) missing = missing.Substring(0, missing.Length - 2);
                    MessageBox.Show($"Lengkapi field berikut: {missing}", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(idJenisText, out int idJenis))
                {
                    MessageBox.Show("ID Jenis harus berupa angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TimeSpan.TryParse(waktuText, out TimeSpan waktu))
                {
                    MessageBox.Show("Format waktu salah. Gunakan HH:mm (contoh: 13:30).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hasKodeGuru = ColumnExists("pelanggaran", "kode_guru");
                int newIdPelanggaran = -1;

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            int currentTotalPoint = 0;
                            using (SqlCommand chk = new SqlCommand("SELECT ISNULL(total_point,0) FROM dbo.siswa WHERE nis=@nis", conn, tr))
                            {
                                chk.Parameters.AddWithValue("@nis", nis);
                                object o = chk.ExecuteScalar();
                                currentTotalPoint = Convert.ToInt32(o ?? 0);
                            }

                            if (currentTotalPoint > 100)
                            {
                                tr.Rollback();
                                MessageBox.Show(
                                    $"Tidak bisa menambahkan pelanggaran. Total poin siswa saat ini sudah {currentTotalPoint} (lebih dari 100).",
                                    "Peringatan",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }

                            string insertSql = hasKodeGuru
                                ? @"INSERT INTO dbo.pelanggaran (nis, id_jenis, tanggal, waktu, tempat_kejadian, keterangan, kode_guru, created_at)
                                    VALUES (@nis, @idjenis, @tanggal, @waktu, @tempat, @keterangan, @kodeguru, GETDATE());
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);"
                                : @"INSERT INTO dbo.pelanggaran (nis, id_jenis, tanggal, waktu, tempat_kejadian, keterangan, created_at)
                                    VALUES (@nis, @idjenis, @tanggal, @waktu, @tempat, @keterangan, GETDATE());
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            using (SqlCommand cmd = new SqlCommand(insertSql, conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@nis", nis);
                                cmd.Parameters.AddWithValue("@idjenis", idJenis);
                                cmd.Parameters.AddWithValue("@tanggal", tanggal);
                                cmd.Parameters.AddWithValue("@waktu", waktu);
                                cmd.Parameters.AddWithValue("@tempat", string.IsNullOrWhiteSpace(tempat) ? (object)DBNull.Value : tempat);
                                cmd.Parameters.AddWithValue("@keterangan", string.IsNullOrWhiteSpace(keterangan) ? (object)DBNull.Value : keterangan);
                                if (hasKodeGuru) cmd.Parameters.AddWithValue("@kodeguru", string.IsNullOrWhiteSpace(kodeGuru) ? (object)DBNull.Value : kodeGuru);

                                newIdPelanggaran = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            RecalculateTotalPoint(conn, tr, nis);

                            // ===== SYNC KE BACKUP TABLE =====
                            SyncBackupTable(conn, tr, "pelanggaran", "id_pelanggaran", newIdPelanggaran, "INSERT");

                            tr.Commit();
                        }
                        catch (Exception)
                        {
                            try { tr.Rollback(); } catch { }
                            throw;
                        }
                    }
                }

                MessageBox.Show("Pelanggaran berhasil ditambah dan poin siswa terupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify bahwa data pelanggaran berubah
                DataChangedEventManager.Instance.NotifyPelanggaranDataChanged();
                DataChangedEventManager.Instance.NotifySiswaDataChanged();

                LoadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah pelanggaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btntambah.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIdPelanggaran <= 0) { MessageBox.Show("Pilih baris pelanggaran dulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            btnUpdate.Enabled = true;
            btntambah.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnUpdate.Enabled = false;

            try
            {
                if (selectedIdPelanggaran <= 0) { MessageBox.Show("Pilih pelanggaran dulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                string nisNew = GetIfControlText("txtNisSiswa").Trim();
                string idJenisText = GetIfControlText("txtidjenispelanggaran").Trim();
                DateTime tanggal = dateKejadian.Value.Date;
                string waktuText = GetIfControlText("txtWaktuKejadian").Trim();
                string tempat = GetIfControlText("txtTempatKejadian").Trim();
                string keterangan = GetIfControlText("txtketeranganKejadian").Trim();
                string kodeGuruNew = GetIfControlText("txtKodeGuru").Trim();

                if (string.IsNullOrWhiteSpace(nisNew) || string.IsNullOrWhiteSpace(idJenisText))
                {
                    MessageBox.Show("NIS dan ID Jenis wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(idJenisText, out int idJenisNew))
                {
                    MessageBox.Show("ID Jenis harus angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TimeSpan.TryParse(waktuText, out TimeSpan waktu))
                {
                    MessageBox.Show("Format waktu salah. Gunakan HH:mm.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hasKodeGuru = ColumnExists("pelanggaran", "kode_guru");

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            string nisOld = null;
                            string sel = "SELECT nis FROM dbo.pelanggaran WHERE id_pelanggaran=@id";
                            using (SqlCommand c = new SqlCommand(sel, conn, tr))
                            {
                                c.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                nisOld = (c.ExecuteScalar() as string)?.Trim();
                            }

                            string sqlUpdate = hasKodeGuru
                                ? @"UPDATE dbo.pelanggaran
                                    SET nis=@nis, id_jenis=@idjenis, tanggal=@tanggal, waktu=@waktu, tempat_kejadian=@tempat, keterangan=@keterangan, kode_guru=@kodeguru
                                    WHERE id_pelanggaran=@id"
                                : @"UPDATE dbo.pelanggaran
                                    SET nis=@nis, id_jenis=@idjenis, tanggal=@tanggal, waktu=@waktu, tempat_kejadian=@tempat, keterangan=@keterangan
                                    WHERE id_pelanggaran=@id";

                            using (SqlCommand u = new SqlCommand(sqlUpdate, conn, tr))
                            {
                                u.Parameters.AddWithValue("@nis", nisNew);
                                u.Parameters.AddWithValue("@idjenis", idJenisNew);
                                u.Parameters.AddWithValue("@tanggal", tanggal);
                                u.Parameters.AddWithValue("@waktu", waktu);
                                u.Parameters.AddWithValue("@tempat", string.IsNullOrWhiteSpace(tempat) ? (object)DBNull.Value : tempat);
                                u.Parameters.AddWithValue("@keterangan", string.IsNullOrWhiteSpace(keterangan) ? (object)DBNull.Value : keterangan);
                                if (hasKodeGuru) u.Parameters.AddWithValue("@kodeguru", string.IsNullOrWhiteSpace(kodeGuruNew) ? (object)DBNull.Value : kodeGuruNew);
                                u.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                u.ExecuteNonQuery();
                            }

                            if (!string.IsNullOrWhiteSpace(nisOld) && nisOld != nisNew)
                            {
                                RecalculateTotalPoint(conn, tr, nisOld);
                            }
                            RecalculateTotalPoint(conn, tr, nisNew);

                            // ===== SYNC KE BACKUP TABLE =====
                            SyncBackupTable(conn, tr, "pelanggaran", "id_pelanggaran", selectedIdPelanggaran, "UPDATE");

                            tr.Commit();
                        }
                        catch (Exception)
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Pelanggaran & poin siswa berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify data changed
                DataChangedEventManager.Instance.NotifyPelanggaranDataChanged();
                DataChangedEventManager.Instance.NotifySiswaDataChanged();

                LoadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update pelanggaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnUpdate.Enabled = true;
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            btnhapus.Enabled = false;

            try
            {
                if (selectedIdPelanggaran <= 0) { MessageBox.Show("Pilih pelanggaran dulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (MessageBox.Show("Yakin hapus pelanggaran ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            string nis = null;
                            string sel = "SELECT nis FROM dbo.pelanggaran WHERE id_pelanggaran=@id";
                            using (SqlCommand sc = new SqlCommand(sel, conn, tr))
                            {
                                sc.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                nis = (sc.ExecuteScalar() as string)?.Trim();
                            }

                            // ===== HAPUS DARI BACKUP TABLE DULU =====
                            SyncBackupTable(conn, tr, "pelanggaran", "id_pelanggaran", selectedIdPelanggaran, "DELETE");

                            using (SqlCommand del = new SqlCommand("DELETE FROM dbo.pelanggaran WHERE id_pelanggaran=@id", conn, tr))
                            {
                                del.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                del.ExecuteNonQuery();
                            }

                            if (!string.IsNullOrWhiteSpace(nis))
                                RecalculateTotalPoint(conn, tr, nis);

                            tr.Commit();
                        }
                        catch (Exception)
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Pelanggaran dihapus dan poin siswa disesuaikan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify data changed
                DataChangedEventManager.Instance.NotifyPelanggaranDataChanged();
                DataChangedEventManager.Instance.NotifySiswaDataChanged();

                LoadGrid();
                ClearForm();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Gagal hapus: data sedang dipakai (FK).", "Constraint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnhapus.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                var row = dataGridView1.Rows[e.RowIndex];
                string idStr = (row.Cells["id_pelanggaran"].Value ?? "").ToString();
                if (!int.TryParse(idStr, out int id))
                {
                    selectedIdPelanggaran = -1;
                    return;
                }

                selectedIdPelanggaran = id;
                SetIfControlExists("txtid_pelanggaran", id.ToString());
                SetIfControlExists("txtNisSiswa", row.Cells["nis"].Value?.ToString() ?? "");
                SetIfControlExists("txtNama", row.Cells["nama_siswa"].Value?.ToString() ?? "");
                SetIfControlExists("txtkelassiswa", row.Cells["kelas"].Value?.ToString() ?? "");
                SetIfControlExists("txtWalas", row.Cells["wali_kelas"].Value?.ToString() ?? "");
                SetIfControlExists("txtidjenispelanggaran", row.Cells["id_jenis"].Value?.ToString() ?? "");
                SetIfControlExists("txtNamaPelanggaran", row.Cells["nama_pelanggaran"].Value?.ToString() ?? "");
                SetIfControlExists("txtPoint", row.Cells["point"].Value?.ToString() ?? "0");

                if (row.Cells["tanggal"].Value != null && DateTime.TryParse(row.Cells["tanggal"].Value.ToString(), out DateTime t))
                    dateKejadian.Value = t;
                if (row.Cells["waktu"].Value != null)
                {
                    TimeSpan waktuSpan;
                    if (TimeSpan.TryParse(row.Cells["waktu"].Value.ToString(), out waktuSpan))
                    {
                        SetIfControlExists("txtWaktuKejadian", waktuSpan.ToString(@"hh\:mm"));
                    }
                }

                SetIfControlExists("txtTempatKejadian", row.Cells["tempat_kejadian"].Value?.ToString() ?? "");
                SetIfControlExists("txtketeranganKejadian", row.Cells["keterangan"].Value?.ToString() ?? "");

                if (dataGridView1.Columns.Contains("kode_guru"))
                    SetIfControlExists("txtKodeGuru", row.Cells["kode_guru"]?.Value?.ToString() ?? "");
                else
                    SetIfControlExists("txtKodeGuru", "");

                btntambah.Enabled = false;
                btnEdit.Enabled = true;
                btnUpdate.Enabled = true;
                btnhapus.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal pilih baris: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetInitialButtonState();
        }

        private void ClearForm()
        {
            selectedIdPelanggaran = -1;
            SetIfControlExists("txtid_pelanggaran", GetNextIdPelanggaran().ToString());
            SetIfControlExists("txtNisSiswa", "");
            SetIfControlExists("txtNama", "");
            SetIfControlExists("txtkelassiswa", "");
            SetIfControlExists("txtWalas", "");
            SetIfControlExists("txtidjenispelanggaran", "");
            SetIfControlExists("txtNamaPelanggaran", "");
            SetIfControlExists("txtPoint", "0");

            if (dateKejadian != null) dateKejadian.Value = DateTime.Today;

            SetIfControlExists("txtWaktuKejadian", DateTime.Now.ToString("HH:mm"));
            SetIfControlExists("txtTempatKejadian", "");
            SetIfControlExists("txtketeranganKejadian", "");
            SetIfControlExists("txtKodeGuru", "");

            // ===== PENTING: RESET FILTER TXTCARI =====
            if (txtcari != null)
            {
                // Unsubscribe dulu biar tidak trigger event
                txtcari.TextChanged -= Txtcari_TextChanged;
                txtcari.Text = placeholderCari;
                txtcari.ForeColor = Color.Gray;
                // Subscribe lagi
                txtcari.TextChanged += Txtcari_TextChanged;
            }

            // ===== RESET BINDING SOURCE FILTER =====
            if (bs != null)
            {
                bs.RemoveFilter();
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}