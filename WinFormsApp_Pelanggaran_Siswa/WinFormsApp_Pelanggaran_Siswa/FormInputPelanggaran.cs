using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormInputPelanggaran : Form
    {
        private readonly Koneksi Konn = new Koneksi();
        private int selectedIdPelanggaran = -1;
        private BindingSource bs = new BindingSource();
        private readonly string placeholderCari = "cari pelanggaran";
        private bool isProcessing = false; // guard re-entrancy

        public FormInputPelanggaran()
        {
            InitializeComponent();

            // safe attach Load
            this.Load -= FormInputPelanggaran_Load;
            this.Load += FormInputPelanggaran_Load;

            // safe event wiring (remove then add)
            if (this.Controls.Find("txtNisSiswa", true).Length > 0)
            {
                txtNisSiswa.Leave -= TxtNisSiswa_Leave;
                txtNisSiswa.Leave += TxtNisSiswa_Leave;
            }

            if (this.Controls.Find("txtidjenispelanggaran", true).Length > 0)
            {
                txtidjenispelanggaran.Leave -= TxtIdJenisPelanggaran_Leave;
                txtidjenispelanggaran.Leave += TxtIdJenisPelanggaran_Leave;
            }

            if (this.Controls.Find("btntambah", true).Length > 0)
            {
                btntambah.Click -= btntambah_Click;
                btntambah.Click += btntambah_Click;
            }

            if (this.Controls.Find("btnEdit", true).Length > 0)
            {
                btnEdit.Click -= btnEdit_Click;
                btnEdit.Click += btnEdit_Click;
            }

            if (this.Controls.Find("btnUpdate", true).Length > 0)
            {
                btnUpdate.Click -= btnUpdate_Click;
                btnUpdate.Click += btnUpdate_Click;
            }

            if (this.Controls.Find("btnhapus", true).Length > 0)
            {
                btnhapus.Click -= btnhapus_Click;
                btnhapus.Click += btnhapus_Click;
            }

            if (this.Controls.Find("btnbatal", true).Length > 0)
            {
                btnbatal.Click -= btnbatal_Click;
                btnbatal.Click += btnbatal_Click;
            }

            if (this.Controls.Find("dataGridView1", true).Length > 0)
            {
                dataGridView1.CellClick -= dataGridView1_CellClick;
                dataGridView1.CellClick += dataGridView1_CellClick;
            }

            if (this.Controls.Find("txtcari", true).Length > 0)
            {
                txtcari.GotFocus -= Txtcari_GotFocus;
                txtcari.LostFocus -= Txtcari_LostFocus;
                txtcari.TextChanged -= Txtcari_TextChanged;

                txtcari.ForeColor = Color.Gray;
                txtcari.Text = placeholderCari;

                txtcari.GotFocus += Txtcari_GotFocus;
                txtcari.LostFocus += Txtcari_LostFocus;
                txtcari.TextChanged += Txtcari_TextChanged;
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

        private void FormInputPelanggaran_Load(object sender, EventArgs e)
        {
            if (this.Controls.Find("txtid_pelanggaran", true).Length > 0)
            {
                txtid_pelanggaran.Text = GetNextIdPelanggaran().ToString();
                txtid_pelanggaran.ReadOnly = true;
            }
            if (this.Controls.Find("dateKejadian", true).Length > 0) dateKejadian.Value = DateTime.Today;
            if (this.Controls.Find("txtWaktuKejadian", true).Length > 0) txtWaktuKejadian.Text = DateTime.Now.ToString("HH:mm");

            LoadGrid();
            SetInitialButtonState();
        }

        private void SetInitialButtonState()
        {
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = true;
            if (this.Controls.Find("btnEdit", true).Length > 0) btnEdit.Enabled = false;
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = false;
            if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = false;
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
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@table AND COLUMN_NAME=@col", conn))
                    {
                        cmd.Parameters.AddWithValue("@table", tableName);
                        cmd.Parameters.AddWithValue("@col", columnName);
                        int c = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        return c > 0;
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

                foreach (DataRow r in dt.Rows)
                    for (int c = 0; c < dt.Columns.Count; c++)
                        if (r.IsNull(c)) r[c] = "";

                bs.DataSource = dt;
                dataGridView1.DataSource = bs;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.RowTemplate.Height = 26;

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

        // helper: set control text safe
        private void SetIfControlExists(string name, string value)
        {
            var arr = this.Controls.Find(name, true);
            if (arr.Length > 0)
            {
                if (arr[0] is TextBox tb) tb.Text = value;
                else arr[0].Text = value;
            }
        }

        // helper: get control text safe
        private string GetIfControlText(string name)
        {
            var arr = this.Controls.Find(name, true);
            if (arr.Length == 0) return "";
            if (arr[0] is TextBox tb) return tb.Text;
            return arr[0].Text;
        }

        // helper: cek record duplicate untuk insert berdasarkan nis,id_jenis,tanggal,waktu
        private bool RecordExistsForInsert(SqlConnection conn, SqlTransaction tr, string nis, int idJenis, DateTime tanggal, TimeSpan waktu)
        {
            string chkSql = @"SELECT COUNT(1) FROM dbo.pelanggaran 
                              WHERE nis = @nis AND id_jenis = @idjenis AND tanggal = @tanggal AND waktu = @waktu";
            using (SqlCommand chk = new SqlCommand(chkSql, conn, tr))
            {
                chk.Parameters.AddWithValue("@nis", nis);
                chk.Parameters.AddWithValue("@idjenis", idJenis);
                chk.Parameters.AddWithValue("@tanggal", tanggal);
                chk.Parameters.AddWithValue("@waktu", waktu);
                int cnt = Convert.ToInt32(chk.ExecuteScalar() ?? 0);
                return cnt > 0;
            }
        }

        // helper: recalc total_point for a nis (safer than incremental add)
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

        // when user leaves NIS field -> autopopulate siswa data
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

        // when user leaves id jenis field -> autopopulate jenis_pelanggaran data
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

        // INSERT (defensive + uses recalc)
        private void btntambah_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;

            try
            {
                int idPelanggaranPreview = GetNextIdPelanggaran();
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
                    if (!TimeSpan.TryParseExact(waktuText, "hh\\:mm", null, out waktu))
                    {
                        MessageBox.Show("Format waktu salah. Gunakan HH:mm (contoh: 13:30).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                bool hasKodeGuru = ColumnExists("pelanggaran", "kode_guru");

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            // Prevent duplicate identical event
                            if (RecordExistsForInsert(conn, tr, nis, idJenis, tanggal, waktu))
                            {
                                MessageBox.Show("Pelanggaran serupa sudah tercatat. Insert dibatalkan untuk mencegah duplikasi.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tr.Rollback();
                                return;
                            }

                            // Insert
                            bool idIsIdentity = false;
                            using (SqlCommand idCheck = new SqlCommand(@"
                                SELECT COLUMNPROPERTY(OBJECT_ID('dbo.pelanggaran'),'id_pelanggaran','IsIdentity')", conn, tr))
                            {
                                var obj = idCheck.ExecuteScalar();
                                if (obj != DBNull.Value && obj != null && Convert.ToInt32(obj) == 1) idIsIdentity = true;
                            }

                            if (idIsIdentity)
                            {
                                string insertSql = hasKodeGuru
                                    ? @"INSERT INTO dbo.pelanggaran (nis, id_jenis, tanggal, waktu, tempat_kejadian, keterangan, kode_guru, created_at)
                                        VALUES (@nis, @idjenis, @tanggal, @waktu, @tempat, @keterangan, @kodeguru, GETDATE());
                                      SELECT SCOPE_IDENTITY();"
                                    : @"INSERT INTO dbo.pelanggaran (nis, id_jenis, tanggal, waktu, tempat_kejadian, keterangan, created_at)
                                        VALUES (@nis, @idjenis, @tanggal, @waktu, @tempat, @keterangan, GETDATE());
                                      SELECT SCOPE_IDENTITY();";

                                using (SqlCommand cmd = new SqlCommand(insertSql, conn, tr))
                                {
                                    cmd.Parameters.AddWithValue("@nis", nis);
                                    cmd.Parameters.AddWithValue("@idjenis", idJenis);
                                    cmd.Parameters.AddWithValue("@tanggal", tanggal);
                                    cmd.Parameters.AddWithValue("@waktu", waktu);
                                    cmd.Parameters.AddWithValue("@tempat", string.IsNullOrWhiteSpace(tempat) ? (object)DBNull.Value : tempat);
                                    cmd.Parameters.AddWithValue("@keterangan", string.IsNullOrWhiteSpace(keterangan) ? (object)DBNull.Value : keterangan);
                                    if (hasKodeGuru) cmd.Parameters.AddWithValue("@kodeguru", string.IsNullOrWhiteSpace(kodeGuru) ? (object)DBNull.Value : kodeGuru);
                                    cmd.ExecuteScalar();
                                }
                            }
                            else
                            {
                                string insertSql = hasKodeGuru
                                    ? @"INSERT INTO dbo.pelanggaran (id_pelanggaran, nis, id_jenis, tanggal, waktu, tempat_kejadian, keterangan, kode_guru, created_at)
                                        VALUES (@id, @nis, @idjenis, @tanggal, @waktu, @tempat, @keterangan, @kodeguru, GETDATE())"
                                    : @"INSERT INTO dbo.pelanggaran (id_pelanggaran, nis, id_jenis, tanggal, waktu, tempat_kejadian, keterangan, created_at)
                                        VALUES (@id, @nis, @idjenis, @tanggal, @waktu, @tempat, @keterangan, GETDATE())";

                                using (SqlCommand cmd = new SqlCommand(insertSql, conn, tr))
                                {
                                    cmd.Parameters.AddWithValue("@id", idPelanggaranPreview);
                                    cmd.Parameters.AddWithValue("@nis", nis);
                                    cmd.Parameters.AddWithValue("@idjenis", idJenis);
                                    cmd.Parameters.AddWithValue("@tanggal", tanggal);
                                    cmd.Parameters.AddWithValue("@waktu", waktu);
                                    cmd.Parameters.AddWithValue("@tempat", string.IsNullOrWhiteSpace(tempat) ? (object)DBNull.Value : tempat);
                                    cmd.Parameters.AddWithValue("@keterangan", string.IsNullOrWhiteSpace(keterangan) ? (object)DBNull.Value : keterangan);
                                    if (hasKodeGuru) cmd.Parameters.AddWithValue("@kodeguru", string.IsNullOrWhiteSpace(kodeGuru) ? (object)DBNull.Value : kodeGuru);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Recalculate total_point for this student (one-time, robust)
                            RecalculateTotalPoint(conn, tr, nis);

                            tr.Commit();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    } // transaksi
                } // conn

                MessageBox.Show("Pelanggaran berhasil ditambah dan poin siswa terupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIdPelanggaran <= 0) { MessageBox.Show("Pilih baris pelanggaran dulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = true;
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;
        }

        // UPDATE (uses recalc)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = false;

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
                    if (!TimeSpan.TryParseExact(waktuText, "hh\\:mm", null, out waktu))
                    {
                        MessageBox.Show("Format waktu salah. Gunakan HH:mm.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                bool hasKodeGuru = ColumnExists("pelanggaran", "kode_guru");

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            // ambil old record
                            string sel = "SELECT nis, id_jenis FROM dbo.pelanggaran WHERE id_pelanggaran=@id";
                            string nisOld = null; int idJenisOld = 0;
                            using (SqlCommand c = new SqlCommand(sel, conn, tr))
                            {
                                c.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                using (var r = c.ExecuteReader())
                                {
                                    if (r.Read())
                                    {
                                        nisOld = r["nis"]?.ToString();
                                        idJenisOld = r["id_jenis"] == DBNull.Value ? 0 : Convert.ToInt32(r["id_jenis"]);
                                    }
                                    else throw new Exception("Data pelanggaran tidak ditemukan.");
                                }
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

                            // recalc for old and new NIS (if changed)
                            if (!string.IsNullOrWhiteSpace(nisOld))
                                RecalculateTotalPoint(conn, tr, nisOld);
                            if (!string.IsNullOrWhiteSpace(nisNew) && nisNew != nisOld)
                                RecalculateTotalPoint(conn, tr, nisNew);

                            tr.Commit();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Pelanggaran & poin siswa berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = true;
            }
        }

        // DELETE (uses recalc)
        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;
            isProcessing = true;
            if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = false;

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
                            string sel = "SELECT nis, id_jenis FROM dbo.pelanggaran WHERE id_pelanggaran=@id";
                            string nis = null; int idJenis = 0;
                            using (SqlCommand sc = new SqlCommand(sel, conn, tr))
                            {
                                sc.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                using (var r = sc.ExecuteReader())
                                {
                                    if (r.Read())
                                    {
                                        nis = r["nis"]?.ToString();
                                        idJenis = r["id_jenis"] == DBNull.Value ? 0 : Convert.ToInt32(r["id_jenis"]);
                                    }
                                    else throw new Exception("Data tidak ditemukan.");
                                }
                            }

                            using (SqlCommand del = new SqlCommand("DELETE FROM dbo.pelanggaran WHERE id_pelanggaran=@id", conn, tr))
                            {
                                del.Parameters.AddWithValue("@id", selectedIdPelanggaran);
                                del.ExecuteNonQuery();
                            }

                            if (!string.IsNullOrWhiteSpace(nis))
                                RecalculateTotalPoint(conn, tr, nis);

                            tr.Commit();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Pelanggaran dihapus dan poin siswa disesuaikan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                var row = dataGridView1.Rows[e.RowIndex];
                string idStr = (row.Cells["id_pelanggaran"].Value ?? "").ToString();
                if (!int.TryParse(idStr, out int id)) { selectedIdPelanggaran = -1; return; }

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
                if (row.Cells["waktu"].Value != null) SetIfControlExists("txtWaktuKejadian", row.Cells["waktu"].Value.ToString());

                SetIfControlExists("txtTempatKejadian", row.Cells["tempat_kejadian"].Value?.ToString() ?? "");
                SetIfControlExists("txtketeranganKejadian", row.Cells["keterangan"].Value?.ToString() ?? "");

                if (dataGridView1.Columns.Contains("kode_guru"))
                    SetIfControlExists("txtKodeGuru", row.Cells["kode_guru"]?.Value?.ToString() ?? "");
                else
                    SetIfControlExists("txtKodeGuru", "");

                if (this.Controls.Find("btnEdit", true).Length > 0) btnEdit.Enabled = true;
                if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = true;
                if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;
                if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal pilih baris: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txtcari_TextChanged(object sender, EventArgs e)
        {
            if (txtcari.Text == placeholderCari) return;
            string keyword = txtcari.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword)) bs.RemoveFilter();
            else bs.Filter = $"nis LIKE '%{keyword}%' OR nama_siswa LIKE '%{keyword}%' OR nama_pelanggaran LIKE '%{keyword}%'";
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
            SetIfControlExists("txtWaktuKejadian", DateTime.Now.ToString("HH:mm"));
            SetIfControlExists("txtTempatKejadian", "");
            SetIfControlExists("txtketeranganKejadian", "");
            SetIfControlExists("txtKodeGuru", "");
        }

        // designer mungkin menghasilkan overload; biarkan kosong
        private void FormInputPelanggaran_Load_1(object sender, EventArgs e) { }

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            Pengaturan form = new Pengaturan();
            form.Show();
            this.Hide();
        }

        private void btnDataSiswa_Click(object sender, EventArgs e)
        {
            Formsiswa form = new Formsiswa();
            form.Show();
            this.Hide();
        }

        private void btnDataGuru_Click(object sender, EventArgs e)
        {
            FormUserGuru form = new FormUserGuru();
            form.Show();
            this.Hide();
        }

        private void btnJenisPelanggaran_Click(object sender, EventArgs e)
        {
            Formjenispelanggaran form = new Formjenispelanggaran();
            form.Show();
            this.Hide();
        }

        private void btnPersiswa_Click(object sender, EventArgs e)
        {
            FormLaporanpersiswa form = new FormLaporanpersiswa();
            form.Show();
            this.Hide();
        }

        private void btnPerkelas_Click(object sender, EventArgs e)
        {
            FormLaporanperkelas form = new FormLaporanperkelas();
            form.Show();
            this.Hide();
        }

        private void btnSuratperingatan_Click(object sender, EventArgs e)
        {
            SuratPeringatan form = new SuratPeringatan();
            form.Show();
            this.Hide();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            FormPelanggara form = new FormPelanggara();
            form.Show();
            this.Hide();
        }
    }
}
