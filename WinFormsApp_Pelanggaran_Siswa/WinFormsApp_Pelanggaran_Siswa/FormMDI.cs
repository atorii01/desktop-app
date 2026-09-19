using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormMDI : Form
    {
        private FormLogin frmlogin;
        private string currentUser; // nama user
        private string currentUserRole; // role user

        // --- tambahkan property/public helper ini ---
        public string CurrentUserRole => currentUserRole ?? string.Empty;

        /// <summary>
        /// Cek apakah user memiliki role tertentu (case-insensitive, partial match).
        /// Gunakan "admin" untuk cek admin.
        /// </summary>
        public bool IsInRole(string role)
        {
            if (string.IsNullOrWhiteSpace(currentUserRole) || string.IsNullOrWhiteSpace(role))
                return false;
            return currentUserRole.IndexOf(role, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public FormMDI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            btnLogin.Click += btnLogin_Click;
            btnlogout.Click += btnlogout_Click;
            btnexit.Click += btnexit_Click;

            // Daftarkan event handler Click untuk setiap tombol menu
            btndashboard.Click += btndashboard_Click;
            btndatasiswa.Click += btndatasiswa_Click;
            btnjenispelanggaran.Click += btnjenispelanggaran_Click;
            btnuserguru.Click += btnuserguru_Click;
            btninputpelanggaran.Click += btninputpelanggaran_Click;
            btnperkelas.Click += btnperkelas_Click;
            btnpersiswa.Click += btnpersiswa_Click;
            btnSuratperingatan.Click += btnSuratperingatan_Click;
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            MenuTerkunci();
            btnLogin.PerformClick();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmlogin == null || !frmlogin.IsLoggedIn)
            {
                MenuTerkunci();
            }
            frmlogin = null;
        }

        /// <summary>
        /// Event handler saat login berhasil - buka menu dan tampilkan FormPelanggara
        /// </summary>
        private void Frmlogin_LoginSucceeded(object sender, EventArgs e)
        {
            if (sender is FormLogin loginForm)
            {
                // Simpan nama dan role user yang login
                currentUser = loginForm.LoggedInUserName;
                currentUserRole = loginForm.LoggedInUserRole;

                // Tampilkan nama user di FormMDI
                lblhalo.Text = $"Halo, {currentUser}";
                lblrole.Text = $"{currentUserRole}";

                // Buka semua menu
                MenuTerbuka();

                // Pastikan form login ditutup setelah berhasil
                if (!loginForm.IsDisposed)
                {
                    loginForm.Close();
                }

                // OTOMATIS BUKA DASHBOARD (FormPelanggara) setelah login
                OpenDashboardAfterLogin();
            }
        }

        /// <summary>
        /// Membuka FormPelanggara (Dashboard) otomatis setelah login berhasil
        /// </summary>
        private void OpenDashboardAfterLogin()
        {
            try
            {
                // Set warna button dashboard sebagai aktif
                SetButtonColors(btndashboard);

                // Buka FormPelanggara sebagai MDI child
                ShowMdiChildForm(typeof(FormPelanggara));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuka dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetButtonColors(Button clickedButton)
        {
            Button[] buttons = new Button[] { btndashboard, btndatasiswa, btnjenispelanggaran, btnuserguru,
                                            btninputpelanggaran, btnperkelas, btnpersiswa, btnSuratperingatan };

            foreach (var button in buttons)
            {
                if (button == clickedButton)
                {
                    button.ForeColor = Color.Blue;
                }
                else
                {
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            SetButtonColors(btndashboard);
            ShowMdiChildForm(typeof(FormPelanggara));
        }

        private void btndatasiswa_Click(object sender, EventArgs e)
        {
            SetButtonColors(btndatasiswa);
            ShowMdiChildForm(typeof(Formsiswa));
        }

        private void btnjenispelanggaran_Click(object sender, EventArgs e)
        {
            SetButtonColors(btnjenispelanggaran);
            ShowMdiChildForm(typeof(Formjenispelanggaran));
        }

        private void btnuserguru_Click(object sender, EventArgs e)
        {
            SetButtonColors(btnuserguru);
            ShowMdiChildForm(typeof(FormUserGuru));
        }

        private void btninputpelanggaran_Click(object sender, EventArgs e)
        {
            SetButtonColors(btninputpelanggaran);
            ShowMdiChildForm(typeof(FormInputPelanggaran));
        }

        private void btnperkelas_Click(object sender, EventArgs e)
        {
            SetButtonColors(btnperkelas);
            ShowMdiChildForm(typeof(FormLaporanperkelas));
        }

        private void btnpersiswa_Click(object sender, EventArgs e)
        {
            SetButtonColors(btnpersiswa);
            ShowMdiChildForm(typeof(FormLaporanpersiswa));
        }

        private void btnSuratperingatan_Click(object sender, EventArgs e)
        {
            SetButtonColors(btnSuratperingatan);
            ShowMdiChildForm(typeof(FormSp));
        }

        public void MenuTerkunci()
        {
            Button[] buttons = new Button[] { btndatasiswa, btnjenispelanggaran, btndashboard, btnuserguru,
                                            btninputpelanggaran, btnlogout, btnperkelas, btnpersiswa, btnSuratperingatan };

            foreach (var button in buttons)
            {
                button.Enabled = false;
                button.ForeColor = Color.Black;
            }

            btnexit.Enabled = true;
            btnLogin.Enabled = true;
            lblhalo.Text = "Selamat Datang"; // Mengatur ulang label halo
            lblrole.Text = ""; // Mengatur ulang label role
        }

        public void MenuTerbuka()
        {
            Button[] buttons = new Button[] { btndatasiswa, btnjenispelanggaran, btndashboard, btnuserguru,
                                            btninputpelanggaran, btnlogout, btnperkelas, btnpersiswa, btnSuratperingatan };

            foreach (var button in buttons)
            {
                button.Enabled = true;
            }

            btnexit.Enabled = true;
            btnLogin.Enabled = false;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            // Tutup semua MDI child form sebelum logout
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            MenuTerkunci();
            MessageBox.Show("Anda Telah Logout", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLogin.PerformClick();
        }

        private void ShowMdiChildForm(Type formType)
        {
            // Cek apakah form sudah dibuka
            var child = this.MdiChildren.FirstOrDefault(f => f.GetType() == formType);
            if (child == null)
            {
                // Buat instance form baru
                child = (Form)Activator.CreateInstance(formType);
                child.MdiParent = this;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                child.Show();
            }
            else
            {
                // Jika sudah ada, bawa ke depan
                child.BringToFront();
                child.WindowState = FormWindowState.Normal;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var existing = this.MdiChildren.OfType<FormLogin>().FirstOrDefault();
            if (existing != null)
            {
                existing.BringToFront();
                existing.Activate();
                return;
            }

            frmlogin = new FormLogin();
            frmlogin.MdiParent = this;
            frmlogin.FormClosed += frmLogin_FormClosed;
            frmlogin.LoginSucceeded += Frmlogin_LoginSucceeded;
            frmlogin.FormBorderStyle = FormBorderStyle.None;
            frmlogin.Dock = DockStyle.Fill;
            frmlogin.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblhalo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}