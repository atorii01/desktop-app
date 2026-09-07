using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using UmkmPintarKasir.Data;

namespace UmkmPintarKasir
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Username / Password wajib diisi.");
                return;
            }

            string sql = @"
                SELECT id_user, username, role 
                FROM app_users 
                WHERE username=@u
                  AND password=@p
                  AND is_active=TRUE";

            DataTable dt = DbConnectionHelper.ExecuteQuery(sql,
                new NpgsqlParameter("@u", user),
                new NpgsqlParameter("@p", pass));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Username atau password salah.");
                return;
            }

            // simpan session
            UserSession.IdUser = Convert.ToInt32(dt.Rows[0]["id_user"]);
            UserSession.Username = dt.Rows[0]["username"].ToString();
            UserSession.Role = dt.Rows[0]["role"].ToString();

            Hide();

            FormMain f = new FormMain();
            f.Show();

        }
    }
}
