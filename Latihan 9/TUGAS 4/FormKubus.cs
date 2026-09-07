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
    public partial class FormKubus : Form
    {
        public FormKubus()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try
            {
                double sisi = double.Parse(txtSisi.Text);
                double volume = Math.Pow(sisi, 3);
                lblHasil.Text = $"Volume Kubus: {volume} cm³";
            }
            catch
            {
                MessageBox.Show("Masukkan angka yang valid!");
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
            txtSisi.Clear();
            lblHasil.Text = "";
        }
    }
}
