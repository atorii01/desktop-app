using System;
using MySql.Data.MySqlClient;
using Helpers;
using System.Windows.Forms;

namespace LKS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // VALIDASI KOSONG
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("All field must be filled!");
                return;
            }

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT * FROM users 
                                     WHERE email = @email 
                                     AND password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    // CEK EMAIL & PASSWORD
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Your credentials invalid, please try again.");
                        return;
                    }

                    reader.Read();

                    // CEK IS ACTIVE
                    if (reader.GetInt32("is_active") == 0)
                    {
                        MessageBox.Show("Your account is not active, please contact admin.");
                        return;
                    }

                    string role = reader.GetString("role");

                    // PINDAH FORM
                    this.Hide();

                    if (role == "Admin")
                    {
                        new AdminMainForm().Show();
                    }
                    else
                    {
                        new StudentMainForm().Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new RegisterForm().Show();
        }
    }
}
