using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Maleke_
{
    public partial class Users : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext(); 
        public Users()
        {
            InitializeComponent();
            LoadData();
        }
        private void GenerateUserCode()
        {
            string year = DateTime.Now.ToString("yy");

            var lastUser = db.Users
                .Where(u => u.UserCode.Contains("USR-" + year))
                .OrderByDescending(u => u.UserCode)
                .FirstOrDefault();

            int number = 1;

            if (lastUser != null)
            {
                string lastNumber = lastUser.UserCode.Substring(7, 2);
                number = int.Parse(lastNumber) + 1;
            }

            txtUsercode.Text = "USR-" + year + "-" + number.ToString("D2");
            txtUsercode.Enabled = false;
        }
        private bool ValidateInput()
        {
            if (txtName.Text.Length < 3 || txtName.Text.Length > 25)
            {
                MessageBox.Show("Name must be between 3 and 25 characters");
                return false;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Password must be filled");
                return false;
            }

            return true;
        }
        private void ClearForm()
        {
            txtName.Clear();
            txtPassword.Clear();
            GenerateUserCode();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = db.Users.ToList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtUsercode.Text = row.Cells["UserCode"].Value.ToString();
                txtName.Text = row.Cells["UserName"].Value.ToString();
                txtPassword.Text = row.Cells["UserPassword"].Value.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            User user = new User();
            user.UserCode = txtUsercode.Text;
            user.UserName = txtName.Text;
            user.UserPassword = txtPassword.Text;

            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();

            MessageBox.Show("Data saved successfully");

            LoadData();
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var user = db.Users.FirstOrDefault(u => u.UserCode == txtUsercode.Text);

            if (user != null)
            {
                user.UserName = txtName.Text;
                user.UserPassword = txtPassword.Text;

                db.SubmitChanges();

                MessageBox.Show("Data updated successfully");
                LoadData();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var user = db.Users.FirstOrDefault(u => u.UserCode == txtUsercode.Text);

            if (user != null)
            {
                db.Users.DeleteOnSubmit(user);
                db.SubmitChanges();

                MessageBox.Show("Data deleted successfully");
                LoadData();
                ClearForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
