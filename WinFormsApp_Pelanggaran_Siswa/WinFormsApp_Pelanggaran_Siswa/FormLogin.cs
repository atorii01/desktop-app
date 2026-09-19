using LoginDatabase;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormLogin : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;

        public bool IsLoggedIn { get; private set; } = false;
        public string LoggedInUserName { get; private set; }
        public string LoggedInUserRole { get; private set; }

        public event EventHandler LoginSucceeded;

        // Teks placeholder
        private const string placeholderKode = "Masukkan Kode Guru";
        private const string placeholderNama = "Masukkan Nama Guru";
        private const string placeholderPass = "Masukkan Password";

        public FormLogin()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = false; // Awalnya non-password char untuk placeholder

            // Inisialisasi event handler untuk placeholder
            this.Load += FormLogin_Load;

            // Wiring event handler untuk placeholder
            txtkodeguru.Enter += Txtkodeguru_Enter;
            txtkodeguru.Leave += Txtkodeguru_Leave;

            txtnamaguru.Enter += Txtnamaguru_Enter;
            txtnamaguru.Leave += Txtnamaguru_Leave;

            txtpassword.Enter += Txtpassword_Enter;
            txtpassword.Leave += Txtpassword_Leave;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtkodeguru, placeholderKode);
            SetPlaceholder(txtnamaguru, placeholderNama);
            SetPlaceholder(txtpassword, placeholderPass);
        }

        // --- Event Handlers untuk Placeholder ---
        private void Txtkodeguru_Enter(object sender, EventArgs e) => RemovePlaceholder(txtkodeguru, placeholderKode);
        private void Txtkodeguru_Leave(object sender, EventArgs e) => SetPlaceholder(txtkodeguru, placeholderKode);

        private void Txtnamaguru_Enter(object sender, EventArgs e) => RemovePlaceholder(txtnamaguru, placeholderNama);
        private void Txtnamaguru_Leave(object sender, EventArgs e) => SetPlaceholder(txtnamaguru, placeholderNama);

        private void Txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == placeholderPass)
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.Black;
                txtpassword.UseSystemPasswordChar = true;
            }
        }
        private void Txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                txtpassword.Text = placeholderPass;
                txtpassword.ForeColor = Color.Gray;
                txtpassword.UseSystemPasswordChar = false;
            }
        }

        // Metode helper untuk placeholder
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (textBox == txtpassword)
                {
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Ambil teks dari textbox, tapi periksa jika masih ada placeholder
            string kode = txtkodeguru.Text.Trim() == placeholderKode ? string.Empty : txtkodeguru.Text.Trim();
            string nama = txtnamaguru.Text.Trim() == placeholderNama ? string.Empty : txtnamaguru.Text.Trim();
            string pass = txtpassword.Text.Trim() == placeholderPass ? string.Empty : txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(kode) || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Semua field harus diisi.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = Konn.GetConn())
                {
                    conn.Open();

                    string query = "SELECT nama, role FROM guru WHERE kode_guru=@kode AND nama=@nama AND password=@pass";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", kode);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsLoggedIn = true;
                                LoggedInUserName = reader["nama"].ToString();
                                LoggedInUserRole = reader["role"].ToString();
                                MessageBox.Show("Login Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoginSucceeded?.Invoke(this, EventArgs.Empty);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                IsLoggedIn = false;
                                MessageBox.Show("User atau Password Tidak Sesuai", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}