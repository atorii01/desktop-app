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
    public partial class Daftar : Form
    {
        string fileUser = "users.txt";
        public Daftar()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtConfirm.UseSystemPasswordChar = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan password tidak boleh kosong.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Password dan konfirmasi tidak cocok.");
                return;
            }

            // Cek apakah username sudah digunakan
            if (File.Exists(fileUser))
            {
                string[] lines = File.ReadAllLines(fileUser);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == username)
                    {
                        MessageBox.Show("Username sudah digunakan.");
                        return;
                    }
                }
            }

            // Simpan ke file
            using (StreamWriter sw = File.AppendText(fileUser))
            {
                sw.WriteLine($"{username},{password}");
            }

            MessageBox.Show("Registrasi berhasil!");
            this.Hide();
            new Login().Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !show;
            txtConfirm.UseSystemPasswordChar = !show;
        }

        private void Clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirm.Clear();
            chkShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirm.UseSystemPasswordChar = true;
        }

        private void Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
