using System;
using System.Windows.Forms;

namespace LKS
{
    public partial class AdminMainForm : Form
    {
        bool isCollapsed = false;
        public AdminMainForm()
        {
            InitializeComponent();
        }
        private void LoadForm(Form form)
        {
            panelContent.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new AdminDashboardForm());
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            LoadForm(new AdminQuestionsForm());
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            LoadForm(new AdminResultForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
               "Are you sure you want to logout?",
               "Confirm",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new Form1().Show();
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelSidebar.Width = 220;
                isCollapsed = false;
            }
            else
            {
                panelSidebar.Width = 60;
                isCollapsed = true;
            }
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
