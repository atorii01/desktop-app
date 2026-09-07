using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petertemuan1LKS
{
    public partial class Form3 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form3()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtFullname.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtRetype.Text) ||
                string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }
            if (txtPassword.Text != txtRetype.Text)
            {
                MessageBox.Show("Password and Confirm Password must be the same.");
                return false;
            }
            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Please enter a complete birth date.");
                return false;
            }
            return true;
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email tidak valid.");
                return;
            }

            if (!DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                MessageBox.Show("Birth Date must be in the format dd/MM/yyyy.");
                return;
            }

            var user = new User
            {
                FullName = txtFullname.Text,
                Email = txtEmail.Text,
                Role = '2',
                Gender = rbMale.Checked ? '1' : '2',
                BirthDate = birthDate,
                IsActive = false,
                Password = txtPassword.Text
            };

            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
            MessageBox.Show("Berhasil Disimpan!");

            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }
    }
}
