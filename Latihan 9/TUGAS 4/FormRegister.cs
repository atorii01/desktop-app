using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUGAS_4
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Konfirmasi password tidak cocok.");
                return;
            }

            // Simpan data ke database atau file (belum diimplementasikan)
            MessageBox.Show("Pendaftaran berhasil!");
            this.Close();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome();
            home.Show();
            this.Close();
        }
    }
}
