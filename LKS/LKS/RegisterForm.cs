using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Helpers;

namespace LKS
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // VALIDASI FIELD KOSONG
            if (txtFullName.Text == "" ||
                txtEmail.Text == "" ||
                txtPassword.Text == "" ||
                txtBirthDate.Text.Contains("_") ||
                (!rbMale.Checked && !rbFemale.Checked))
            {
                MessageBox.Show("All field must be filled!");
                return;
            }

            // VALIDASI EMAIL
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format!");
                return;
            }

            // VALIDASI TANGGAL
            DateTime birthDate;
            if (!DateTime.TryParse(txtBirthDate.Text, out birthDate))
            {
                MessageBox.Show("Invalid birth date!");
                return;
            }

            string gender = rbMale.Checked ? "Male" : "Female";

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // CEK EMAIL SUDAH TERDAFTAR
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Email already registered!");
                        return;
                    }

                    // INSERT DATA USER
                    string insertQuery = @"
                        INSERT INTO users
                        (fullname, email, password, gender, birthdate, role, is_active)
                        VALUES
                        (@fn, @em, @pw, @gd, @bd, 'Student', 0)
                    ";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@fn", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@em", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@pw", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@gd", gender);
                    cmd.Parameters.AddWithValue("@bd", birthDate);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Registration successfully, admin will activate your account soon."
                    );

                    this.Hide();
                    new Form1().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}