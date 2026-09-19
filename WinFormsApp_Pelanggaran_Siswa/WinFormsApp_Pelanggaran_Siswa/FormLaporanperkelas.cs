using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormLaporanperkelas : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private readonly BindingSource bs = new BindingSource();
        private readonly string placeholderCari = "Cari siswa...";
        private readonly string defaultKelasText = "Pilih Kelas~";

        // Timer refresh 5 detik
        private System.Windows.Forms.Timer refreshTimer;

        public FormLaporanperkelas()
        {
            InitializeComponent();

            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
            txtcari.Enter += (s, e) => RemovePlaceholder();
            txtcari.Leave += (s, e) => SetPlaceholder();
            txtcari.TextChanged += (s, e) => FilterData();
            cbKelas.SelectedIndexChanged += cbKelas_SelectedIndexChanged;

            this.Load += FormLaporanperkelas_Load_1;
            this.FormClosing += FormLaporanperkelas_FormClosing;

            InitializeRefreshTimer();
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // 5 detik
            };
            refreshTimer.Tick += RefreshTimer_Tick;
            // Jangan start di sini jika ingin start setelah user memilih kelas — 
            // saya start di Load supaya selalu aktif.
            refreshTimer.Start();
        }

        private void FormLaporanperkelas_FormClosing(object sender, FormClosingEventArgs e)
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
            try
            {
                // jika belum memilih kelas yang valid, tidak perlu refresh
                if (cbKelas.SelectedItem == null) return;
                string kelas = cbKelas.SelectedItem.ToString();
                if (kelas == defaultKelasText) return;

                // ambil filter (jika placeholder aktif, anggap kosong)
                string filter = string.Empty;
                if (!(txtcari.ForeColor == Color.Gray) && !string.IsNullOrWhiteSpace(txtcari.Text))
                    filter = txtcari.Text.Trim();

                // simpan seleksi & posisi tampilan agar tidak mengganggu user
                string selectedNIS = null;
                int firstDisplayed = -1;

                if (dataGridView2 != null && dataGridView2.Rows.Count > 0)
                {
                    try
                    {
                        if (dataGridView2.SelectedRows.Count > 0)
                        {
                            var cell = dataGridView2.SelectedRows[0].Cells["nis"];
                            if (cell != null) selectedNIS = (cell.Value ?? "").ToString();
                        }

                        try { firstDisplayed = dataGridView2.FirstDisplayedScrollingRowIndex; } catch { firstDisplayed = -1; }
                    }
                    catch { /* ignore */ }
                }

                // Jalankan load pada thread UI bila perlu
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => LoadListSiswa(kelas, filter)));
                }
                else
                {
                    LoadListSiswa(kelas, filter);
                }

                // restore selection & scroll
                if (!string.IsNullOrEmpty(selectedNIS) && dataGridView2.Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            var cell = dataGridView2.Rows[i].Cells["nis"];
                            if (cell != null && (cell.Value ?? "").ToString() == selectedNIS)
                            {
                                dataGridView2.ClearSelection();
                                dataGridView2.Rows[i].Selected = true;
                                dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];
                                try { dataGridView2.FirstDisplayedScrollingRowIndex = Math.Max(0, i - 2); } catch { }
                                break;
                            }
                        }
                    }
                    catch { /* ignore restore errors */ }
                }
                else if (firstDisplayed >= 0 && dataGridView2.Rows.Count > 0)
                {
                    try
                    {
                        dataGridView2.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayed, Math.Max(0, dataGridView2.Rows.Count - 1));
                    }
                    catch { }
                }
            }
            catch
            {
                // jangan crash timer
            }
        }

        private void FormLaporanperkelas_Load_1(object sender, EventArgs e)
        {
            LoadKelasCombo();
            SetPlaceholder();
            // DataGridView akan kosong saat form pertama kali dimuat
        }

        private void LoadKelasCombo()
        {
            cbKelas.Items.Clear();
            cbKelas.Items.Add(defaultKelasText); // Tambahkan item default
            cbKelas.Items.AddRange(new string[]
            {
                "X - RPL",
                "X - AKL",
                "X - DKV",
                "X - BR1",
                "X - BR2",
                "X - BD",
                "X - MP1",
                "X - MP2",
                "X - TKJ",
                "X - TKR"
            });
            cbKelas.SelectedItem = defaultKelasText; // Atur item default terpilih
        }

        private void LoadListSiswa(string kelas, string filter = "")
        {
            if (kelas == defaultKelasText)
            {
                dataGridView2.DataSource = null; // Kosongkan DataGridView
                lbllaki.Text = "0";
                lblperempuan.Text = "0";
                return;
            }

            try
            {
                DataTable dt = new DataTable();
                using (var conn = Konn.GetConn())
                {
                    conn.Open();

                    string sql = @"
                        SELECT s.nis, s.nama, s.jenis_kelamin, s.kelas, s.wali_kelas,
                               s.total_point, s.status,
                               (SELECT COUNT(*) FROM pelanggaran p WHERE p.nis = s.nis) as jumlah_kasus
                        FROM siswa s
                        WHERE s.kelas = @kelas";

                    if (!string.IsNullOrWhiteSpace(filter))
                        sql += " AND (s.nis LIKE @f OR s.nama LIKE @f OR s.wali_kelas LIKE @f)";

                    using (var da = new SqlDataAdapter(sql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@kelas", kelas);
                        if (!string.IsNullOrWhiteSpace(filter))
                            da.SelectCommand.Parameters.AddWithValue("@f", "%" + filter + "%");

                        da.Fill(dt);
                    }
                }

                bs.DataSource = dt;
                dataGridView2.DataSource = bs;

                // Styling grid
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.RowTemplate.Height = 28;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Mengatur teks header
                if (dataGridView2.Columns["nis"] is not null) dataGridView2.Columns["nis"].HeaderText = "NIS";
                if (dataGridView2.Columns["nama"] is not null) dataGridView2.Columns["nama"].HeaderText = "Nama";
                if (dataGridView2.Columns["jenis_kelamin"] is not null) dataGridView2.Columns["jenis_kelamin"].HeaderText = "Jenis Kelamin";
                if (dataGridView2.Columns["kelas"] is not null) dataGridView2.Columns["kelas"].HeaderText = "Kelas";
                if (dataGridView2.Columns["wali_kelas"] is not null) dataGridView2.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                if (dataGridView2.Columns["total_point"] is not null) dataGridView2.Columns["total_point"].HeaderText = "Total Point";
                if (dataGridView2.Columns["status"] is not null) dataGridView2.Columns["status"].HeaderText = "Status";
                if (dataGridView2.Columns["jumlah_kasus"] is not null) dataGridView2.Columns["jumlah_kasus"].HeaderText = "Jumlah Kasus";

                HitungJumlahGenderPerKelas(kelas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load siswa perkelas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HitungJumlahGenderPerKelas(string kelas)
        {
            try
            {
                using (var conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT jenis_kelamin, COUNT(*) as jumlah FROM siswa WHERE kelas = @kelas GROUP BY jenis_kelamin";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kelas", kelas);
                        using (var dr = cmd.ExecuteReader())
                        {
                            int laki = 0, perempuan = 0;
                            while (dr.Read())
                            {
                                string jk = dr["jenis_kelamin"].ToString();
                                int jml = Convert.ToInt32(dr["jumlah"]);
                                if (jk == "L") laki = jml;
                                else if (jk == "P") perempuan = jml;
                            }
                            if (lbllaki is not null) lbllaki.Text = $"{laki}";
                            if (lblperempuan is not null) lblperempuan.Text = $"{perempuan}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hitung gender perkelas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            if (txtcari.ForeColor == Color.Gray || cbKelas.SelectedItem?.ToString() == defaultKelasText) return;
            string kelas = cbKelas.SelectedItem.ToString();
            string filter = txtcari.Text.Trim();

            LoadListSiswa(kelas, filter);
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
                txtcari.Text = "";
                txtcari.ForeColor = Color.Black;
            }
        }

        private void cbKelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKelas.SelectedItem is not null)
            {
                string kelas = cbKelas.SelectedItem.ToString();
                LoadListSiswa(kelas);
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (sender is not DataGridView dgv || dgv.DataSource == null) return;

                if (!dgv.Columns.Contains("total_point")) return;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["total_point"].Value is not null && int.TryParse(row.Cells["total_point"].Value.ToString(), out int point))
                    {
                        row.DefaultCellStyle.BackColor = point switch
                        {
                            > 100 => Color.LightGray,
                            > 50 => Color.LightCoral,
                            > 25 => Color.Yellow,
                            _ => Color.LightGreen
                        };
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
                // Mencegah error crash
            }
        }

        // Metode-metode sort yang dipanggil dari tombol
        private void btnnis_Click(object sender, EventArgs e)
        {
            if (bs.DataSource is DataTable dt)
            {
                dt.DefaultView.Sort = "nis ASC";
                dataGridView2.DataSource = dt.DefaultView;
            }
        }

        private void btntotalpoint_Click(object sender, EventArgs e)
        {
            if (bs.DataSource is DataTable dt)
            {
                dt.DefaultView.Sort = "total_point DESC";
                dataGridView2.DataSource = dt.DefaultView;
            }
        }
    }
}
