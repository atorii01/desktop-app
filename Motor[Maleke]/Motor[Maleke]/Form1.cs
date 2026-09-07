using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Motor_Maleke_
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter user code and password");
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.UserCode == username);

            if (user == null)
            {
                MessageBox.Show("User not found");
                return;
            }

            if (user.UserPassword != password)
            {
                MessageBox.Show("Incorrect password");
                return;
            }

            MessageBox.Show("Login successful");

            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
            this.Hide();

        }
    }
}
