using Desktop_FA608UM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace Desktop_FA608UM
{
    public partial class RegisterForm : Form
    {   
        Database db = new Database();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) || 
                string.IsNullOrWhiteSpace(tbEmail.Text) || 
                (!RbMale.Checked && !RbFemale.Checked) || 
                string.IsNullOrWhiteSpace(tbPassword.Text) ||
                string.IsNullOrWhiteSpace(tbConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(tbBirthday.Text))

            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "SELECT COUNT(1) FROM [USER] WHERE Email = @email.com";
            SqlParameter[] parameters =
            {
                new SqlParameter("@email.com", tbEmail.Text)
            };
            SqlDataReader read = db.ReadData(sql, parameters);
            int ada = 0;
            if (read != null)
            {
                read.Read();
                ada = read.GetInt32(0);
            }

            if(ada > 0)
            {
                MessageBox.Show("Email already registered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DateTime birthDate;
            bool isValidate = DateTime.TryParseExact(tbBirthday.Text, "DD/MM//YYYY", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out birthDate);
            if (!isValidate)
            {
                MessageBox.Show("Invalid date format for Birthday", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            catch
            {
                string gender = RbMale.Checked ? "1" : "2";
                string role = "2";
                string insertQuerry = "INSERT INTO [USER] (Fullname, Email, Role, gender, Birthday, Password, IsActive) VALUE (@fullname, @email, @role, @gender, @birthday, @password, 0)";
                SqlParameter[] insertParameters =
                {
                    new SqlParameter("@fullname", tbName.Text),
                    new SqlParameter("@email", tbEmail.Text),
                    new SqlParameter("@role", role),
                    new SqlParameter("@gender", gender),
                    new SqlParameter("@birthday", tbBirthday.Text),
                    new SqlParameter("@password", tbPassword.Text),
                };

                int result = db.executeData(insertQuerry, insertParameters);
                if (result > 0)
                {
                    MessageBox.Show("Registration successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
