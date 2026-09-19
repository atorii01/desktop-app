using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Formsiswa : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private System.Windows.Forms.Timer refreshTimer;

        // tooltip untuk memberi tahu user bila tombol disabled karena bukan admin
        private readonly ToolTip _roleToolTip = new ToolTip() { ShowAlways = true };

        // daftar kelas tetap (bisa diambil dari DB kalau nanti mau dinamis)
        private readonly string[] KELAS_LIST = new string[]
        {
            "X - RPL","X - AKL","X - DKV","X - BR1","X - BR2",
            "X - BD","X - MP1","X - MP2","X - TKJ","X - TKR"
        };

        public Formsiswa()
        {
            InitializeComponent();
            this.Load += Formsiswa_Load;
            InitializeRefreshTimer();
        }

        private void Formsiswa_Load(object sender, EventArgs e)
        {
            SetupDataGridView();

            // isi combobox kelas sebelum load data
            PopulateKelasCombo();

            LoadData(); // load semua data (default)

            // pastikan ApplyRolePermissions dipanggil setelah form & kontrol siap
            ApplyRolePermissions();

            // Placeholder untuk pencarian
            txtcari.Text = "Cari";
            txtcari.ForeColor = Color.Gray;
            txtcari.Enter += (s, ev) =>
            {
                if (txtcari.Text == "Cari")
                {
                    txtcari.Text = "";
                    txtcari.ForeColor = Color.Black;
                }
            };
            txtcari.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtcari.Text))
                {
                    txtcari.Text = "Cari";
                    txtcari.ForeColor = Color.Gray;
                }
            };
            txtcari.TextChanged += txtcari_TextChanged;

            // pastikan event cbKelas hooked (jika belum hooked di designer)
            cbKelas.SelectedIndexChanged -= cbKelas_SelectedIndexChanged;
            cbKelas.SelectedIndexChanged += cbKelas_SelectedIndexChanged;
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 3000 // refresh tiap 3 detik
            };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)(() => RefreshTimer_Tick(sender, e)));
                    return; // penting agar tidak dieksekusi dua kali
                }

                // di thread UI sekarang
                if (string.IsNullOrWhiteSpace(txtcari.Text) || txtcari.Text == "Cari")
                {
                    string kelas = GetSelectedKelasOrNull();
                    LoadData(kelas);
                }
            }
            catch
            {
                // abaikan error kecil agar timer tetap jalan
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }

        private void SetupDataGridView()
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;

            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
        }

        /// <summary>
        /// Isi combobox kelas dengan default "Pilih Kelas" + daftar kelas.
        /// </summary>
        private void PopulateKelasCombo()
        {
            try
            {
                cbKelas.Items.Clear();
                cbKelas.Items.Add("Pilih Kelas");
                foreach (var k in KELAS_LIST)
                    cbKelas.Items.Add(k);

                cbKelas.DropDownStyle = ComboBoxStyle.DropDownList;
                cbKelas.SelectedIndex = 0;
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Dapatkan nilai kelas yang terpilih, atau null jika default ("Pilih Kelas")
        /// </summary>
        /// <returns></returns>
        private string GetSelectedKelasOrNull()
        {
            if (cbKelas == null) return null;
            if (cbKelas.SelectedIndex <= 0) // 0 = "Pilih Kelas"
                return null;
            return cbKelas.SelectedItem?.ToString();
        }

        /// <summary>
        /// Load data siswa. Jika kelasFilter != null maka akan menampilkan hanya baris dengan kelas tersebut.
        /// </summary>
        private void LoadData(string kelasFilter = null)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();

                    // base SQL
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp,
                               ISNULL(total_point,0) AS total_point, ISNULL(status,'') AS status
                        FROM siswa
                        WHERE 1=1
                    ";

                    if (!string.IsNullOrEmpty(kelasFilter))
                    {
                        sql += " AND kelas = @kelas";
                    }

                    sql += " ORDER BY TRY_CAST(nis AS INT) ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(kelasFilter))
                            cmd.Parameters.AddWithValue("@kelas", kelasFilter);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }

                // Set header text
                if (dataGridView2.Columns["nis"] != null) dataGridView2.Columns["nis"].HeaderText = "NIS";
                if (dataGridView2.Columns["nama"] != null) dataGridView2.Columns["nama"].HeaderText = "Nama";
                if (dataGridView2.Columns["jenis_kelamin"] != null) dataGridView2.Columns["jenis_kelamin"].HeaderText = "JK";
                if (dataGridView2.Columns["kelas"] != null) dataGridView2.Columns["kelas"].HeaderText = "Kelas";
                if (dataGridView2.Columns["wali_kelas"] != null) dataGridView2.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                if (dataGridView2.Columns["no_telp"] != null) dataGridView2.Columns["no_telp"].HeaderText = "No. Telp";
                if (dataGridView2.Columns["total_point"] != null) dataGridView2.Columns["total_point"].HeaderText = "Point";
                if (dataGridView2.Columns["status"] != null) dataGridView2.Columns["status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data siswa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtcari.Text.Trim();
            string selectedKelas = GetSelectedKelasOrNull();

            if (string.IsNullOrWhiteSpace(keyword) || keyword == "Cari")
                LoadData(selectedKelas);
            else
                SearchData(keyword, selectedKelas);
        }

        /// <summary>
        /// Cari data dengan keyword (mencari di nis, nama, kelas, wali_kelas)
        /// Opsional: apply kelasFilter
        /// </summary>
        private void SearchData(string keyword, string kelasFilter = null)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp,
                               ISNULL(total_point,0) AS total_point, ISNULL(status,'') AS status
                        FROM siswa
                        WHERE (nis LIKE @q OR nama LIKE @q OR kelas LIKE @q OR wali_kelas LIKE @q)
                    ";

                    if (!string.IsNullOrEmpty(kelasFilter))
                    {
                        sql += " AND kelas = @kelas";
                    }

                    sql += " ORDER BY TRY_CAST(nis AS INT) ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + keyword + "%");
                        if (!string.IsNullOrEmpty(kelasFilter))
                            cmd.Parameters.AddWithValue("@kelas", kelasFilter);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal cari data: " + ex.Message);
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["total_point"].Value == null) continue;

                    if (int.TryParse(row.Cells["total_point"].Value.ToString(), out int point))
                    {
                        row.DefaultCellStyle.BackColor = point switch
                        {
                            > 100 => Color.LightGray,
                            > 50 => Color.LightCoral,
                            > 25 => Color.Khaki,
                            _ => Color.LightGreen
                        };
                    }
                }
            }
            catch { /* biar gak crash */ }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Safety check: jika bukan admin, block dan beri notifikasi.
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            bool isAdmin = IsUserAdminFromMdi(mdi);
            if (!isAdmin)
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Contoh: buka Formtambahsiswa sebagai MDI child di FormMDI (jika tersedia)
            if (mdi != null)
            {
                // Cek apakah form sudah terbuka di dalam MDI
                var existingForm = mdi.MdiChildren.OfType<Formtambahsiswa>().FirstOrDefault();

                if (existingForm == null || existingForm.IsDisposed)
                {
                    var form = new Formtambahsiswa
                    {
                        MdiParent = mdi,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };
                    form.Show();
                }
                else
                {
                    existingForm.BringToFront();
                    if (existingForm.WindowState == FormWindowState.Minimized)
                        existingForm.WindowState = FormWindowState.Normal;
                    existingForm.Focus();
                }
            }
            else
            {
                using (var form = new Formtambahsiswa())
                {
                    form.ShowDialog();
                }
            }
        }

        // button10_Click and button11_Click same logic as button6_Click
        private void button10_Click(object sender, EventArgs e) => button6_Click(sender, e);
        private void button11_Click(object sender, EventArgs e) => button6_Click(sender, e);

        /// <summary>
        /// Cek apakah user saat ini memiliki role admin berdasarkan informasi di FormMDI.
        /// </summary>
        private bool IsUserAdminFromMdi(FormMDI mdi)
        {
            if (mdi == null) return false;

            try
            {
                var ctrl = mdi.Controls.Find("lblrole", true).FirstOrDefault() as Label;
                if (ctrl != null)
                {
                    var roleText = ctrl.Text?.Trim() ?? "";
                    if (roleText.IndexOf("admin", StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }

                var prop = mdi.GetType().GetField("currentUserRole", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (prop != null)
                {
                    var val = prop.GetValue(mdi) as string;
                    if (!string.IsNullOrEmpty(val) && val.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void ApplyRolePermissions()
        {
            try
            {
                var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
                bool isAdmin = IsUserAdminFromMdi(mdi);

                Button[] addButtons = new Button[] { button6, button10, button11 };

                foreach (var btn in addButtons)
                {
                    if (btn == null) continue;

                    btn.Enabled = isAdmin;

                    if (!isAdmin)
                    {
                        _roleToolTip.SetToolTip(btn, "Anda bukan admin");
                        btn.Cursor = Cursors.No;
                    }
                    else
                    {
                        _roleToolTip.SetToolTip(btn, "Tambah Siswa");
                        btn.Cursor = Cursors.Default;
                    }
                }
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Event ketika combobox kelas berubah.
        /// Jika tidak ada kata kunci pencarian maka tinggal LoadData(kelas)
        /// jika ada pencarian maka SearchData(keyword, kelas)
        /// </summary>
        private void cbKelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedKelas = GetSelectedKelasOrNull();
                string keyword = txtcari.Text?.Trim();

                if (string.IsNullOrWhiteSpace(keyword) || keyword == "Cari")
                {
                    LoadData(selectedKelas);
                }
                else
                {
                    SearchData(keyword, selectedKelas);
                }
            }
            catch
            {
                // ignore
            }
        }
    }
}
