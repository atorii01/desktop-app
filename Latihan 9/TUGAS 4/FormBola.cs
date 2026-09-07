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
    public partial class FormBola : Form
    {
        public FormBola()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try
            {
                double r = double.Parse(txtJariJari.Text);
                double volume = (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);

                lblHasil.Text = $"Volume Bola: {volume:F2} cm³";
            }
            catch
            {
                MessageBox.Show("Masukkan angka yang valid untuk jari-jari!");
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
            lblHasil.Text = "";
        }
    }
}
