using System;
using System.Data;
using System.Windows.Forms;
using UmkmPintarKasir.Data;

namespace UmkmPintarKasir
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // event handler tombol menu
            btnProfil.Click += BtnProfil_Click;
            btnMasterProduk.Click += BtnMasterProduk_Click;
            btnKasir.Click += BtnKasir_Click;
            btnLaporan.Click += BtnLaporan_Click;

            // kalau designer belum auto-wire, pastikan ini ada:
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Tanggal di header
            lblTanggal.Text = "Tanggal: " +
                DateTime.Now.ToString("dd MMM yyyy HH:mm");

            // Info user di subtitle (kalau pakai UserSession)
            if (!string.IsNullOrEmpty(UserSession.Username))
            {
                lblSubTitle.Text =
                    "Kasir Sederhana + Perhitungan PPh Final 0,5%  |  " +
                    "Login: " + UserSession.Username +
                    " (" + UserSession.Role + ")";
            }

            // Terapkan hak akses sesuai role
            ApplyHakAkses();

            // Load stok produk ke grid dashboard
            LoadStokProduk();
        }

        // ================= HAK AKSES ROLE =================
        private void ApplyHakAkses()
        {
            // Default: kalau belum ada role, anggap kasir minimal
            if (UserSession.Role == "OWNER")
            {
                btnProfil.Enabled = true;
                btnMasterProduk.Enabled = true;
                btnKasir.Enabled = true;
                btnLaporan.Enabled = true;
            }
            else if (UserSession.Role == "KASIR")
            {
                btnProfil.Enabled = false;
                btnMasterProduk.Enabled = false;
                btnLaporan.Enabled = false;
                btnKasir.Enabled = true; // hanya kasir
            }
            else
            {
                // fallback kalau role tidak dikenal
                btnProfil.Enabled = false;
                btnMasterProduk.Enabled = false;
                btnLaporan.Enabled = false;
                btnKasir.Enabled = true;
            }
        }

        // ================= LOAD GRID STOK =================
        private void LoadStokProduk()
        {
            string sql = @"
                SELECT
                    kode_produk AS ""Kode"",
                    nama_produk AS ""Nama"",
                    stok AS ""Stok"",
                    harga_jual AS ""Harga""
                FROM produk
                WHERE is_active = TRUE
                ORDER BY nama_produk;
            ";

            DataTable dt = DbConnectionHelper.ExecuteQuery(sql);

            dgvStok.DataSource = dt;

            if (dgvStok.Columns.Contains("Kode"))
                dgvStok.Columns["Kode"].Width = 80;

            if (dgvStok.Columns.Contains("Nama"))
                dgvStok.Columns["Nama"].Width = 260;

            if (dgvStok.Columns.Contains("Stok"))
                dgvStok.Columns["Stok"].Width = 70;

            if (dgvStok.Columns.Contains("Harga"))
            {
                dgvStok.Columns["Harga"].Width = 90;
                dgvStok.Columns["Harga"].DefaultCellStyle.Format = "N0";
            }

            dgvStok.RowHeadersVisible = false;
            dgvStok.ReadOnly = true;
            dgvStok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ================= MENU BUTTON ACTION =================
        private void BtnProfil_Click(object sender, EventArgs e)
        {
            // proteksi tambahan (jaga-jaga kalau button enabled karena bug)
            if (UserSession.Role != "OWNER")
            {
                MessageBox.Show("Akses hanya untuk OWNER.");
                return;
            }

            using (var f = new FormProfilUmkm())
            {
                f.ShowDialog();
            }
        }

        private void BtnMasterProduk_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "OWNER")
            {
                MessageBox.Show("Akses hanya untuk OWNER.");
                return;
            }

            using (var f = new FormMasterProduk())
            {
                f.ShowDialog();
            }

            // habis update master produk, refresh stok
            LoadStokProduk();
        }

        private void BtnKasir_Click(object sender, EventArgs e)
        {
            using (var f = new FormKasir())
            {
                f.ShowDialog();
            }

            // refresh stok setelah kembali dari kasir
            LoadStokProduk();
        }

        private void BtnLaporan_Click(object sender, EventArgs e)
        {
            if (UserSession.Role != "OWNER")
            {
                MessageBox.Show("Akses hanya untuk OWNER.");
                return;
            }

            using (var f = new FormLaporan())
            {
                f.ShowDialog();
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
