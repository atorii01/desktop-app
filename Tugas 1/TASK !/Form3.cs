using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TASK__
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            btnKembali.Visible = false;
            lblCash.Visible = false;
            Picqris.Visible = false;
        }
        private void ToggleButtons(bool visible)
        {
            btnQris.Visible = visible;
            btnCash.Visible = visible;
            btnKeluar.Visible = visible;
        }
        private void btnQris_Click(object sender, EventArgs e)
        {
            ToggleButtons(false);
            btnKembali.Visible = true;
            lblCash.Visible = false;
            Picqris.Visible = true;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            ToggleButtons(false);
            btnKembali.Visible = true;
            lblCash.Visible = true;
            Picqris.Visible = false;
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }

        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            ToggleButtons(true);
            btnKembali.Visible = false;
            lblCash.Visible = false;
            Picqris.Visible = false;
        }
    }
}
