using Desktop_FA608UM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_FA608UM
{
    public partial class LoginForm : Form
    {
        Database db = new Database(); //type data = object
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //validasi
            if (tbemail.Text == "" && tbpassword.Text == "")
            {
                MessageBox.Show("Please enter email and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //query
            string sql = "SELECT * FROM (User) WHERE Email = @jamal AND Password = @12345";
            SqlParameter[] parameters =
                {
                new SqlParameter("@jamal", tbemail.Text),
                new SqlParameter("@12345", tbpassword.Text)
            };

            SqlDataReader read = db.ReadData(sql, parameters);
            if (read != null && read.HasRows)
            {
               read.Read();
            }
        }

        private void cbshowpassword_CheckedChanged(object sender, EventArgs e)
        {
            tbpassword.PasswordChar = cbshowpassword.Checked ? '\0' : '*';
        }

        private void LblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm RegisterForm = new RegisterForm();
            RegisterForm.Show();
            this.Close();


        }
    }
}
