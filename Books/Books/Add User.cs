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
    public partial class Add_User : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext(); 
        public event Action LoadUsers;
        public Add_User()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = new user();
            user.id = txtUser.Text;
            user.name_user = txtName.Text;
            user.birthdate = dateTimePicker1.Value;
            user.email = txtEmail.Text;
            user.password_user = txtPassword.Text;
            user.roles_id = db.roles.FirstOrDefault(x => x.title == cbRole.Text).id;
            user.status_user = "Active";
            db.users.InsertOnSubmit(user);
            db.SubmitChanges();
            MessageBox.Show("User added successfully!");
            this.Close();   
            LoadUsers.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_User_Load(object sender, EventArgs e)
        {

        }
    }
}
