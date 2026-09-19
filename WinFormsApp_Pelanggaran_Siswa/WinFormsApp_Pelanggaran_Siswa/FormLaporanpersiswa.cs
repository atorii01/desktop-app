using LoginDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormLaporanpersiswa : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private readonly BindingSource bs = new BindingSource();
        private DataView dvSiswa = null;
        private readonly string placeholderCari = "Cari siswa...";

        // toggle sorting
        private bool nisSortAsc = true;
        private bool totalPointSortDesc = true;

        // resolved table names
        private string tableSiswaSchema = null, tableSiswaName = null;
        private string tablePelanggaranSchema = null, tablePelanggaranName = null;

        // resolved actual column names (as exist in DB). We'll alias them in SELECT to stable names.
        private string colNis, colNama, colJK, colKelas, colWali, colNoTelp, colTotalPoint, colStatus, colPelanggaranNis;

        // timer untuk refresh otomatis
        private System.Windows.Forms.Timer refreshTimer;

        public FormLaporanpersiswa()
        {
            InitializeComponent();

            this.Load += FormLaporanpersiswa_Load_1;
            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
            txtcari.Enter += (s, e) => RemovePlaceholder();
            txtcari.Leave += (s, e) => SetPlaceholder();
            txtcari.TextChanged += (s, e) => FilterData();

            btnnis.Click += btnnis_Click;
            btntotalpoint.Click += btntotalpoint_Click;
        }

        // ----------------------- Resolve table(s) and columns -----------------------
        private bool ResolveTableNamesAndColumns()
        {
            try
            {
                using (var conn = Konn.GetConn())
                {
                    conn.Open();

                    // cari tabel siswa (prioritaskan exact tblsiswa)
                    string findSiswaSql = @"
                        SELECT TABLE_SCHEMA, TABLE_NAME
                        FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_TYPE='BASE TABLE'
                          AND (TABLE_NAME = 'tblsiswa' OR TABLE_NAME LIKE '%siswa%')";
                    var dt = new DataTable();
                    using (var da = new SqlDataAdapter(findSiswaSql, conn))
                        da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        var db = new SqlCommand("SELECT DB_NAME()", conn).ExecuteScalar()?.ToString() ?? "(unknown)";
                        MessageBox.Show($"Tidak menemukan tabel siswa pada database: {db}. Periksa connection string / nama tabel.",
                            "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // pilih best match (prefer exact tblsiswa)
                    DataRow chosen = dt.AsEnumerable()
                        .FirstOrDefault(r => r.Field<string>("TABLE_NAME").Equals("tblsiswa", StringComparison.OrdinalIgnoreCase))
                        ?? dt.Rows[0];

                    tableSiswaSchema = chosen["TABLE_SCHEMA"].ToString();
                    tableSiswaName = chosen["TABLE_NAME"].ToString();

                    // cari tabel pelanggaran jika ada
                    string findPel = @"
                        SELECT TABLE_SCHEMA, TABLE_NAME
                        FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_TYPE='BASE TABLE'
                          AND (TABLE_NAME = 'tblpelanggaran' OR TABLE_NAME LIKE '%pelanggaran%')";
                    var dtP = new DataTable();
                    using (var da2 = new SqlDataAdapter(findPel, conn))
                        da2.Fill(dtP);

                    if (dtP.Rows.Count > 0)
                    {
                        var ch = dtP.Rows[0];
                        tablePelanggaranSchema = ch["TABLE_SCHEMA"].ToString();
                        tablePelanggaranName = ch["TABLE_NAME"].ToString();
                    }
                    else
                    {
                        tablePelanggaranSchema = null;
                        tablePelanggaranName = null;
                    }

                    // Ambil kolom pada table siswa
                    var cols = new List<string>();
                    using (var cmdCols = new SqlCommand(
                        "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA=@schema AND TABLE_NAME=@name", conn))
                    {
                        cmdCols.Parameters.AddWithValue("@schema", tableSiswaSchema);
                        cmdCols.Parameters.AddWithValue("@name", tableSiswaName);
                        using (var da3 = new SqlDataAdapter(cmdCols))
                        {
                            var dtCols = new DataTable();
                            da3.Fill(dtCols);
                            foreach (DataRow r in dtCols.Rows) cols.Add(r["COLUMN_NAME"].ToString());
                        }
                    }

                    // helper untuk mencocokkan nama kolom (case-insensitive)
                    string match(params string[] candidates)
                    {
                        foreach (var c in candidates)
                        {
                            var found = cols.FirstOrDefault(x => x.Equals(c, StringComparison.OrdinalIgnoreCase));
                            if (found != null) return found;
                        }
                        // jika tidak ketemu, cari kandidat yang mengandung kata (mis. contains 'nis')
                        foreach (var c in candidates)
                        {
                            var found = cols.FirstOrDefault(x => x.IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0);
                            if (found != null) return found;
                        }
                        return null;
                    }

                    // cari kolom dasar
                    colNis = match("NIS", "nis");
                    colNama = match("Nama", "nama", "name");
                    colJK = match("Jenis_Kelamin", "jenis_kelamin", "jeniskelamin", "jenis_kel");
                    colKelas = match("Kelas", "kelas");
                    colWali = match("Wali_Kelas", "wali_kelas", "walikelas", "wali");
                    colNoTelp = match("No_Telp", "no_telp", "no_telp", "notelp", "no_telp");
                    colTotalPoint = match("Total_Point", "total_point", "TotalPoint", "totalpoint", "total_point");
                    colStatus = match("Status", "status");

                    // jika ada tabel pelanggaran, cari kolom NIS di pelanggaran
                    if (!string.IsNullOrEmpty(tablePelanggaranName))
                    {
                        var colsPel = new List<string>();
                        using (var cmdColsP = new SqlCommand(
                            "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA=@schema AND TABLE_NAME=@name", conn))
                        {
                            cmdColsP.Parameters.AddWithValue("@schema", tablePelanggaranSchema);
                            cmdColsP.Parameters.AddWithValue("@name", tablePelanggaranName);
                            using (var da4 = new SqlDataAdapter(cmdColsP))
                            {
                                var dtp = new DataTable();
                                da4.Fill(dtp);
                                foreach (DataRow r in dtp.Rows) colsPel.Add(r["COLUMN_NAME"].ToString());
                            }
                        }

                        colPelanggaranNis = colsPel.FirstOrDefault(x => x.Equals("NIS", StringComparison.OrdinalIgnoreCase))
                                            ?? colsPel.FirstOrDefault(x => x.IndexOf("nis", StringComparison.OrdinalIgnoreCase) >= 0);
                    }

                    // jika kolom wajib tidak ditemukan, beri pesan ke user dan tutup load
                    var missing = new List<string>();
                    if (colNis == null) missing.Add("NIS");
                    if (colNama == null) missing.Add("Nama");
                    if (colTotalPoint == null) missing.Add("Total_Point");
                    if (missing.Count > 0)
                    {
                        MessageBox.Show("Kolom penting tidak ditemukan pada tabel siswa: " + string.Join(", ", missing) +
                            $"\nTabel yang dipakai: [{tableSiswaSchema}].[{tableSiswaName}]\nPeriksa struktur tabel / connection string.",
                            "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal resolusi tabel/kolom: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ----------------------- Hitung gender -----------------------
        private void HitungJumlahGender()
        {
            if (string.IsNullOrEmpty(tableSiswaName)) return;

            try
            {
                using (var conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = $"SELECT [{colJK}] AS jk, COUNT(*) AS jml FROM [{tableSiswaSchema}].[{tableSiswaName}] GROUP BY [{colJK}]";
                    using (var cmd = new SqlCommand(sql, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        int laki = 0, perempuan = 0;
                        while (dr.Read())
                        {
                            string jk = dr["jk"]?.ToString() ?? "";
                            int jml = dr["jml"] == DBNull.Value ? 0 : Convert.ToInt32(dr["jml"]);
                            if (jk.Equals("L", StringComparison.OrdinalIgnoreCase)) laki = jml;
                            else if (jk.Equals("P", StringComparison.OrdinalIgnoreCase)) perempuan = jml;
                        }

                        lbllaki.Text = laki.ToString();
                        lblperempuan.Text = perempuan.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung jumlah gender: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------- Load semua siswa -----------------------
        private void LoadAllSiswa()
        {
            if (string.IsNullOrEmpty(tableSiswaName)) return;

            try
            {
                var dt = new DataTable();
                using (var conn = Konn.GetConn())
                {
                    conn.Open();

                    // build subquery jumlah kasus jika tabel pelanggaran dan kolom NIS pelanggaran ditemukan
                    string pelSub = "0 AS Jumlah_Kasus";
                    if (!string.IsNullOrEmpty(tablePelanggaranName) && !string.IsNullOrEmpty(colPelanggaranNis))
                    {
                        pelSub = $"(SELECT COUNT(*) FROM [{tablePelanggaranSchema}].[{tablePelanggaranName}] p WHERE p.[{colPelanggaranNis}] = s.[{colNis}]) AS Jumlah_Kasus";
                    }

                    // SELECT menggunakan nama kolom yang benar dari DB, lalu beri alias stabil (NIS, Nama, Total_Point, dll.)
                    string sql = $@"
                        SELECT
                            s.[{colNis}] AS NIS,
                            s.[{colNama}] AS Nama,
                            s.[{colJK}] AS Jenis_Kelamin,
                            s.[{colKelas}] AS Kelas,
                            s.[{colWali}] AS Wali_Kelas,
                            {((colNoTelp != null) ? $"s.[{colNoTelp}] AS No_Telp," : "NULL AS No_Telp,")}
                            s.[{colTotalPoint}] AS Total_Point,
                            {((colStatus != null) ? $"s.[{colStatus}] AS Status," : "'' AS Status,")}
                            {pelSub}
                        FROM [{tableSiswaSchema}].[{tableSiswaName}] s";

                    using (var da = new SqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    dvSiswa = null;
                    bs.DataSource = null;
                    dataGridView2.DataSource = null;
                    // jangan selalu tunjukkan MessageBox saat auto-refresh, hanya pada load pertama
                    return;
                }

                // tambahkan kolom bantu NIS_num
                if (!dt.Columns.Contains("NIS_num"))
                    dt.Columns.Add("NIS_num", typeof(int));

                foreach (DataRow r in dt.Rows)
                {
                    if (r["NIS"] != DBNull.Value && int.TryParse(r["NIS"].ToString(), out int n))
                        r["NIS_num"] = n;
                    else
                        r["NIS_num"] = 0;
                }

                dvSiswa = new DataView(dt) { Sort = "NIS_num ASC" };
                bs.DataSource = dvSiswa;

                // memastikan grid otomatis men-generate columns saat refresh
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = bs;

                ConfigureGridColumns(); // set header text, hide NIS_num
            }
            catch (SqlException ex)
            {
                // pada auto-refresh sebaiknya tidak spam MessageBox, namun tampilkan sekali
                // di sini kita tampilkan, tapi bila mengganggu bisa ubah ke logging
                MessageBox.Show("Gagal memuat data siswa: " + ex.Message + "\nPeriksa connection string dan struktur tabel.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data siswa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------- Atur header & kolom grid -----------------------
        private void ConfigureGridColumns()
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Font = new Font("Segoe UI", 11);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.RowTemplate.Height = 28;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dataGridView2.Columns.Contains("NIS")) dataGridView2.Columns["NIS"].HeaderText = "NIS";
            if (dataGridView2.Columns.Contains("Nama")) dataGridView2.Columns["Nama"].HeaderText = "Nama";
            if (dataGridView2.Columns.Contains("Jenis_Kelamin")) dataGridView2.Columns["Jenis_Kelamin"].HeaderText = "JK";
            if (dataGridView2.Columns.Contains("Kelas")) dataGridView2.Columns["Kelas"].HeaderText = "Kelas";
            if (dataGridView2.Columns.Contains("Wali_Kelas")) dataGridView2.Columns["Wali_Kelas"].HeaderText = "Wali Kelas";
            if (dataGridView2.Columns.Contains("No_Telp")) dataGridView2.Columns["No_Telp"].HeaderText = "No Telp";
            if (dataGridView2.Columns.Contains("Total_Point")) dataGridView2.Columns["Total_Point"].HeaderText = "Total Point";
            if (dataGridView2.Columns.Contains("Status")) dataGridView2.Columns["Status"].HeaderText = "Status";
            if (dataGridView2.Columns.Contains("Jumlah_Kasus")) dataGridView2.Columns["Jumlah_Kasus"].HeaderText = "Jumlah Kasus";

            if (dataGridView2.Columns.Contains("NIS_num"))
                dataGridView2.Columns["NIS_num"].Visible = false;
        }

        // ----------------------- Filter (pencarian) -----------------------
        private void FilterData()
        {
            if (dvSiswa == null) return;
            if (txtcari.ForeColor == Color.Gray)
            {
                dvSiswa.RowFilter = string.Empty;
                return;
            }

            string filter = txtcari.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(filter))
                dvSiswa.RowFilter = string.Empty;
            else
                dvSiswa.RowFilter = $"Convert(NIS, 'System.String') LIKE '%{filter}%' OR Nama LIKE '%{filter}%' OR Kelas LIKE '%{filter}%' OR Wali_Kelas LIKE '%{filter}%'";
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtcari.Text))
            {
                txtcari.Text = placeholderCari;
                txtcari.ForeColor = Color.Gray;
            }
        }
        private void RemovePlaceholder()
        {
            if (txtcari.Text == placeholderCari)
            {
                txtcari.Text = string.Empty;
                txtcari.ForeColor = Color.Black;
            }
        }

        // ----------------------- Coloring rows berdasarkan Total_Point -----------------------
        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (!dataGridView2.Columns.Contains("Total_Point")) return;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cell = row.Cells["Total_Point"];
                    if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out int point))
                    {
                        row.DefaultCellStyle.BackColor = point switch
                        {
                            >= 100 => Color.LightGray,
                            >= 50 => Color.LightCoral,
                            >= 25 => Color.Khaki,
                            _ => Color.LightGreen
                        };
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch { /* ignore coloring errors */ }
        }

        // ----------------------- Tombol sort -----------------------
        private void btnnis_Click(object sender, EventArgs e)
        {
            if (dvSiswa == null) return;
            nisSortAsc = !nisSortAsc;
            dvSiswa.Sort = $"NIS_num {(nisSortAsc ? "ASC" : "DESC")}";
        }

        private void btntotalpoint_Click(object sender, EventArgs e)
        {
            if (dvSiswa == null) return;
            totalPointSortDesc = !totalPointSortDesc;
            dvSiswa.Sort = $"Total_Point {(totalPointSortDesc ? "DESC" : "ASC")}";
        }

        private void FormLaporanpersiswa_Load_1(object sender, EventArgs e)
        {
            try
            {
                // resolve table(s) & columns first
                if (!ResolveTableNamesAndColumns())
                {
                    // user already informed inside resolve method
                    return;
                }

                HitungJumlahGender();
                LoadAllSiswa();
                SetPlaceholder();

                // mulai timer auto-refresh 5 detik
                refreshTimer = new System.Windows.Forms.Timer { Interval = 5000 };
                refreshTimer.Tick += RefreshTimer_Tick;
                refreshTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Jangan refresh jika user sedang mengetik di kotak pencarian
            if (txtcari.Focused) return;

            // panggil refresh aman (stop timer sementara untuk mencegah reentry)
            try
            {
                refreshTimer.Stop();
                RefreshDataPreserveSelectionAndFilter();
            }
            catch
            {
                // swallow
            }
            finally
            {
                // restart bila form belum disposed
                if (!this.IsDisposed)
                    refreshTimer.Start();
            }
        }

        /// <summary>
        /// Refresh data: hitung gender, load semua siswa, reapply filter, dan kembalikan selection bila memungkinkan.
        /// </summary>
        private void RefreshDataPreserveSelectionAndFilter()
        {
            try
            {
                string selectedNis = null;
                if (dataGridView2.CurrentRow != null && dataGridView2.Columns.Contains("NIS"))
                {
                    var v = dataGridView2.CurrentRow.Cells["NIS"].Value;
                    if (v != null) selectedNis = v.ToString();
                }

                // lakukan refresh data
                HitungJumlahGender();
                LoadAllSiswa();

                // reapply filter jika ada
                FilterData();

                // coba kembalikan selection berdasarkan NIS
                if (!string.IsNullOrEmpty(selectedNis) && dataGridView2.Rows.Count > 0 && dataGridView2.Columns.Contains("NIS"))
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        var row = dataGridView2.Rows[i];
                        var cellVal = row.Cells["NIS"].Value;
                        if (cellVal != null && cellVal.ToString() == selectedNis)
                        {
                            row.Selected = true;
                            dataGridView2.CurrentCell = row.Cells[0];
                            // usahakan scroll ke baris tersebut
                            try { dataGridView2.FirstDisplayedScrollingRowIndex = i; } catch { }
                            break;
                        }
                    }
                }
            }
            catch
            {
                // ignore to keep timer alive
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

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
    }
}
