using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Formjenispelanggaran : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private readonly string placeholderCari = "cari data";
        private BindingSource bs = new BindingSource();

        // auto-refresh timer (sama seperti Formsiswa)
        private System.Windows.Forms.Timer refreshTimer;

        // tooltip untuk memberi tahu user bila tombol disabled karena bukan admin
        private readonly ToolTip _roleToolTip = new ToolTip() { ShowAlways = true };

        public Formjenispelanggaran()
        {
            InitializeComponent();

            // Pasang event DataGridView jika sudah ada
            if (dataGridView2 != null)
            {
                dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
                dataGridView2.CellClick += dataGridView2_CellClick;
            }

            // Placeholder txtcari
            if (txtcari != null)
            {
                txtcari.ForeColor = Color.Gray;
                txtcari.Text = placeholderCari;
                txtcari.GotFocus += Txtcari_GotFocus;
                txtcari.LostFocus += Txtcari_LostFocus;
                txtcari.TextChanged += Txtcari_TextChanged;
            }

            this.Load += Formjenispelanggaran_Load;
        }

        private void Formjenispelanggaran_Load(object sender, EventArgs e)
        {
            LoadJenisPelanggaran();

            // terapkan hak akses (disable tombol jika bukan admin)
            ApplyRolePermissions();

            // mulai timer auto-refresh (3 detik) - jangan ganggu saat mengetik
            InitializeRefreshTimer();
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // jika user sedang fokus mengetik pencarian jangan refresh
                if (txtcari != null && txtcari.Focused) return;

                // safe-invoke
                if (this.InvokeRequired)
                    this.Invoke(new Action(LoadJenisPelanggaran));
                else
                    LoadJenisPelanggaran();
            }
            catch
            {
                // swallow errors supaya timer tetap jalan
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

        #region Placeholder txtcari
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

        private void Txtcari_TextChanged(object sender, EventArgs e)
        {
            if (txtcari.Text == placeholderCari) return;

            string keyword = txtcari.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword))
            {
                if (bs.DataSource != null) bs.RemoveFilter(); // reset filter
            }
            else
            {
                try
                {
                    // aman: kalau kolom tidak ada filter akan melempar, kita tangani
                    bs.Filter = $"kode_jenis LIKE '%{keyword}%' OR nama_pelanggaran LIKE '%{keyword}%' OR jenis LIKE '%{keyword}%'";
                }
                catch
                {
                    // ignore filter errors (mis. kolom berubah)
                }
            }
        }
        #endregion

        private void LoadJenisPelanggaran()
        {
            if (dataGridView2 == null) return;

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string query = @"
                        SELECT id_jenis,
                               kode_jenis,
                               nama_pelanggaran,
                               ISNULL(point,0) AS point,
                               ISNULL(jenis,'') AS jenis
                        FROM dbo.jenis_pelanggaran
                        ORDER BY kode_jenis ASC";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.Fill(dt);
                    }
                }

                // Normalisasi DBNull
                foreach (DataRow r in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        if (r.IsNull(col)) r[col] = col.DataType == typeof(int) ? 0 : string.Empty;
                }

                // Simpan posisi selection agar user tidak kehilangan baris saat auto-refresh
                string selectedId = null;
                if (dataGridView2.CurrentRow != null && dataGridView2.Columns.Contains("id_jenis"))
                {
                    var v = dataGridView2.CurrentRow.Cells["id_jenis"].Value;
                    if (v != null) selectedId = v.ToString();
                }

                bs.DataSource = dt;
                dataGridView2.DataSource = bs;

                // Styling
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.RowTemplate.Height = 28;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.ColumnHeadersDefaultCellStyle.Font =
                    new Font(dataGridView2.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                // Friendly headers
                if (dataGridView2.Columns.Contains("id_jenis")) dataGridView2.Columns["id_jenis"].HeaderText = "ID";
                if (dataGridView2.Columns.Contains("kode_jenis")) dataGridView2.Columns["kode_jenis"].HeaderText = "Kode";
                if (dataGridView2.Columns.Contains("nama_pelanggaran")) dataGridView2.Columns["nama_pelanggaran"].HeaderText = "Nama Peringatan";
                if (dataGridView2.Columns.Contains("point")) dataGridView2.Columns["point"].HeaderText = "Point";
                if (dataGridView2.Columns.Contains("jenis")) dataGridView2.Columns["jenis"].HeaderText = "Jenis";

                // Numeric columns read-only
                if (dataGridView2.Columns.Contains("id_jenis")) dataGridView2.Columns["id_jenis"].ReadOnly = true;
                if (dataGridView2.Columns.Contains("point")) dataGridView2.Columns["point"].ReadOnly = true;

                NormalizeEmptyCellsToVisible();

                // Baris pertama tebal
                if (dataGridView2.Rows.Count > 0)
                    dataGridView2.Rows[0].DefaultCellStyle.Font = new Font(dataGridView2.DefaultCellStyle.Font, FontStyle.Bold);

                // kembalikan selection jika memungkinkan
                if (!string.IsNullOrEmpty(selectedId) && dataGridView2.Rows.Count > 0 && dataGridView2.Columns.Contains("id_jenis"))
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        var cellVal = dataGridView2.Rows[i].Cells["id_jenis"].Value;
                        if (cellVal != null && cellVal.ToString() == selectedId)
                        {
                            try
                            {
                                dataGridView2.Rows[i].Selected = true;
                                dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];
                                dataGridView2.FirstDisplayedScrollingRowIndex = i;
                            }
                            catch { }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // jangan spam MessageBox saat auto-refresh, tampilkan sekali saja
                // untuk kesederhanaan tetap tampil (bisa diganti logging)
                MessageBox.Show("Error load data jenis pelanggaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            NormalizeEmptyCellsToVisible();
        }

        private void NormalizeEmptyCellsToVisible()
        {
            if (dataGridView2 == null) return;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                for (int ci = 0; ci < row.Cells.Count; ci++)
                {
                    var cell = row.Cells[ci];
                    if (cell.Value == DBNull.Value || cell.Value == null)
                        cell.Value = (cell.OwningColumn.Name.ToLower() == "id_jenis" || cell.OwningColumn.Name.ToLower() == "point") ? 0 : string.Empty;

                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2 == null || e.RowIndex < 0) return;
            var row = dataGridView2.Rows[e.RowIndex];

            int id = 0;
            if (dataGridView2.Columns.Contains("id_jenis"))
                int.TryParse(row.Cells["id_jenis"].Value?.ToString(), out id);

            string nama = "";
            if (dataGridView2.Columns.Contains("nama_pelanggaran"))
                nama = row.Cells["nama_pelanggaran"].Value?.ToString() ?? "";
        }

        // Tombol tambah - cek role dulu
        private void button6_Click(object sender, EventArgs e)
        {
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            bool isAdmin = IsUserAdminFromMdi(mdi);
            if (!isAdmin)
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTambahPelanggaran(mdi);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            bool isAdmin = IsUserAdminFromMdi(mdi);
            if (!isAdmin)
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTambahPelanggaran(mdi);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            bool isAdmin = IsUserAdminFromMdi(mdi);
            if (!isAdmin)
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTambahPelanggaran(mdi);
        }

        private void OpenTambahPelanggaran(FormMDI mdi)
        {
            if (mdi != null)
            {
                var existing = mdi.MdiChildren.OfType<FormTambahPelanggaran>().FirstOrDefault();
                if (existing == null || existing.IsDisposed)
                {
                    var form = new FormTambahPelanggaran();
                    form.MdiParent = mdi;      // pastikan parent adalah FormMDI
                    form.FormBorderStyle = FormBorderStyle.None; // opsional
                    form.Dock = DockStyle.Fill;
                    form.Show();
                }
                else
                {
                    existing.BringToFront();
                    if (existing.WindowState == FormWindowState.Minimized)
                        existing.WindowState = FormWindowState.Normal;
                    existing.Focus();
                }
            }
            else
            {
                // fallback: tampil modal bila FormMDI tidak ditemukan
                var form = new FormTambahPelanggaran();
                form.ShowDialog();
            }
        }

        // ---------------- Role check helpers ----------------
        private bool IsUserAdminFromMdi(FormMDI mdi)
        {
            if (mdi == null) return false;

            try
            {
                // cek label lblrole bila ada
                var ctrl = mdi.Controls.Find("lblrole", true).FirstOrDefault() as Label;
                if (ctrl != null)
                {
                    var roleText = ctrl.Text?.Trim() ?? "";
                    if (roleText.IndexOf("admin", StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }

                // coba baca field currentUserRole via reflection jika ada
                var field = mdi.GetType().GetField("currentUserRole", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (field != null)
                {
                    var val = field.GetValue(mdi) as string;
                    if (!string.IsNullOrEmpty(val) && val.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }
            catch
            {
                // ignore
            }

            return false;
        }

        private void ApplyRolePermissions()
        {
            try
            {
                var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
                bool isAdmin = IsUserAdminFromMdi(mdi);

                // tombol yang membuka form tambah (sesuaikan nama tombol bila berbeda)
                Button[] addButtons = new Button[] { button6, button10, button11 };

                foreach (var btn in addButtons)
                {
                    if (btn == null) continue;

                    btn.Enabled = isAdmin; // disable jika bukan admin

                    // set tooltip agar saat hover muncul pesan "Anda bukan admin"
                    if (!isAdmin)
                    {
                        _roleToolTip.SetToolTip(btn, "Anda bukan admin");
                        btn.Cursor = Cursors.No;
                    }
                    else
                    {
                        _roleToolTip.SetToolTip(btn, "Tambah Jenis Pelanggaran");
                        btn.Cursor = Cursors.Default;
                    }
                }
            }
            catch
            {
                // ignore agar fungsi tidak crash bila kontrol belum ada
            }
        }
    }
}
