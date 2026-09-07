using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hovlibrary
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        int id;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void LoadDgv()
        {
            dgvMember.Columns.Clear();
            dgvMember.DataSource = db.Members.Select(x => new
            {
                ID = x.id,
                Name = x.name,
                Phone = x.phone_number,
                Email = x.email,
                Address = x.address,
                Cityofbirth = x.city_of_birth,
                Dateofbirth = x.date_of_birth,
                Gender = x.gender
            }).ToList();

            DataGridViewButtonColumn dgv = new DataGridViewButtonColumn();
            dgv.Name = "Edit";
            dgv.HeaderText = "";
            dgv.Text = "Edit";
            dgv.UseColumnTextForButtonValue = true;
            dgvMember.Columns.Add(dgv);
        }

        private void EnableTrue(bool enable)
        {
            txtName.Enabled = enable;
            txtPhone.Enabled = enable;
            txtEmail.Enabled = enable;
            txtAddress.Enabled = enable;
            txtCityofbirth.Enabled = enable;
            dateTimePicker1.Enabled = enable;
            rdMale.Enabled = enable;
            rdFemale.Enabled = enable;
            btnSave.Enabled = enable;
        }

        private void clearField()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtCityofbirth.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            rdMale.Checked = false;
            rdFemale.Checked = false;
        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            EnableTrue(false);
            
            id = Convert.ToInt32(dgvMember.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = dgvMember.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = dgvMember.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvMember.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dgvMember.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCityofbirth.Text = dgvMember.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dgvMember.Rows[e.RowIndex].Cells[6].Value);
            if (dgvMember.Rows[e.RowIndex].Cells[7].Value.ToString() == "Male") rdMale.Checked = true;
            else rdFemale.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var query = db.Members.FirstOrDefault(x => x.id.Equals(id));
            query.name = txtName.Text;
            query.phone_number = txtPhone.Text;
            query.email = txtEmail.Text;
            query.address = txtAddress.Text;
            query.city_of_birth = txtCityofbirth.Text;
            query.date_of_birth = dateTimePicker1.Value;
            if(rdMale.Checked == true) query.gender = "Male";
            else query.gender = "Female";

            db.SubmitChanges();
            MessageBox.Show("update Berhasil!!");
            clearField();
            EnableTrue(false);
            LoadDgv();
        }

        private void btnMbook_Click(object sender, EventArgs e)
        {
            MasterBook masterBook = new MasterBook();
            masterBook.ShowDialog();

        }
    }
}
