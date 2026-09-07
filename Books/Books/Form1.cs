using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }
        private void loaddgv()
        {
            var query = db.users.Select(x => new
            {
                x. name_user,
                x. id,
                x.status_user,
                Age = DateTime.Now.Year - x.birthdate.Year,
                x.role.title,
                x.email
            }).ToList();
            dgvuser.DataSource = query;
        }
        private void dgvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddgv();
            dgvuser.AutoGenerateColumns = false;
        }

        private void dgvuser_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvuser.Rows[e.RowIndex].Cells["Column1"].Value.ToString() == "Inactive")
            {
                dgvuser.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgvuser.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_User add_User = new Add_User();
            add_User.ShowDialog();
        }

        private void btnDeactive_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvuser.SelectedRows;
            if (selectedRows.Count == 0) return;

            var idCell = selectedRows[0].Cells["Column2"].Value;
            string id = idCell?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            var userEntity = db.users.FirstOrDefault(x => x.id == id);
            if (userEntity != null)
            {
                userEntity.status_user = "Inactive";
                db.SubmitChanges();
                loaddgv();
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvuser.SelectedRows;
            if (selectedRows.Count == 0) return;

            var cell = selectedRows[0].Cells["Column2"].Value;
            string id = cell?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            var user = db.users.FirstOrDefault(x => x.id == id);
            if (user != null)
            {
                user.status_user = "Active";
                db.SubmitChanges();
                loaddgv();
            }
        }
    }
}
