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
    public partial class FormLimas : Form
    {
        public FormLimas()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try
            {
                double panjang = double.Parse(txtPanjang.Text);
                double lebar = double.Parse(txtLebar.Text);
                double tinggi = double.Parse(txtTinggi.Text);

                double volume = (1.0 / 3.0) * panjang * lebar * tinggi;
                lblHasil.Text = $"Volume Limas: {volume:F2} cm³";
            }
            catch
            {
                MessageBox.Show("Masukkan angka yang valid untuk semua sisi!");
            }

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPanjang.Clear();
            txtLebar.Clear();
            txtTinggi.Clear();
            lblHasil.Text = "";

        }
    }
}
