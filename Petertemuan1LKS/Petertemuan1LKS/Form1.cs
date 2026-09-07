using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petertemuan1LKS
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
            txtEmail.Text = "kesyaaw@gmail.com";
            txtPassword.Text = "123";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var query = db.Users.Where(x => x.Email == txtEmail.Text && x.Password == txtPassword.Text).FirstOrDefault();
            if (query == null)
            {
                MessageBox.Show("“Your credentials invalid, please try again.");
                return;
            }
            if (query.IsActive == false)
            {
                MessageBox.Show("Your account is not active, please contact admin");
                return;
            }
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }

        private void lnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
            this.Hide();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShow.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.ShortcutsEnabled = false;
        }
    }
}
