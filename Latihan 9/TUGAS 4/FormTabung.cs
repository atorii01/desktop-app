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
    public partial class FormTabung : Form
    {
        public FormTabung()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try
            {
                double r = double.Parse(txtJariJari.Text);
                double t = double.Parse(txtTinggi.Text);
                double volume = Math.PI * Math.Pow(r, 2) * t;

                lblHasil.Text = $"Volume Tabung: {volume:F2} cm³";
            }
            catch
            {
                MessageBox.Show("Masukkan angka yang valid untuk jari-jari dan tinggi!");
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
            txtJariJari.Clear();
            txtTinggi.Clear();
            lblHasil.Text = "";
        }
    }
}
