using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Login : Form
    {
        int percobaanLogin = 0;
        const int batasLogin = 3;
        public Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUsername = txtUsername.Text.Trim();
            string inputPassword = txtPassword.Text;
            string filePath = "users.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Belum ada akun terdaftar.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool usernameDitemukan = false;
            string statusLogin = "";

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string savedUsername = parts[0];
                string savedPassword = parts[1];

                if (savedUsername == inputUsername)
                {
                    usernameDitemukan = true;

                    if (savedPassword == inputPassword)
                    {
                        statusLogin = "sukses";
                    }
                    else
                    {
                        statusLogin = "password_salah";
                    }

                    break; // berhenti setelah username ditemukan
                }
            }

            // Gunakan switch-case untuk tanggapan login
            switch (statusLogin)
            {
                case "sukses":
                    MessageBox.Show("Login berhasil!");
                    this.Hide();
                    new FormPelanggara().Show();
                    break;

                case "password_salah":
                    MessageBox.Show("Password salah. Silakan coba lagi.");
                    break;

                default:
                    if (!usernameDitemukan)
                        MessageBox.Show("Username tidak ditemukan.");
                    break;
            }

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void Clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void Daftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Daftar().Show();
        }
    }
}
