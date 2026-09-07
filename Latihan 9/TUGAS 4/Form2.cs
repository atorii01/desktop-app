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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnKubus_Click(object sender, EventArgs e)
        {
            FormKubus kubus = new FormKubus();
            kubus.Show();
            this.Hide();
        }

        private void btnTabung_Click(object sender, EventArgs e)
        {
            FormTabung tabung = new FormTabung();
            tabung.Show();
            this.Hide();

        }

        private void btnBalok_Click(object sender, EventArgs e)
        {
            FormBalok balok = new FormBalok();
            balok.Show();
            this.Hide();

        }

        private void btnLimas_Click(object sender, EventArgs e)
        {
            FormLimas limas = new FormLimas();
            limas.Show();
            this.Hide();
        }

        private void btnKerucut_Click(object sender, EventArgs e)
        {
            FormKerucut kerucut = new FormKerucut();
            kerucut.Show();
            this.Hide();

        }

        private void btnBola_Click(object sender, EventArgs e)
        {
            FormKerucut kerucut = new FormKerucut();
            kerucut.Show();
            this.Hide();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }
    }
}
