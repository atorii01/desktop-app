using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Helpers;
namespace LKS
{
    public partial class AdminDashboardForm : Form
    {
        int selectedUserId = -1;
        int selectedIsActive = 0;
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadDateTime();
            LoadStudents();
            LoadTodayResults();
        }
        private void LoadDateTime()
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void LoadStudents()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        id,
                        fullname AS User,
                        gender AS Gender,
                        birthdate AS BirthDate,
                        is_active AS IsActive
                    FROM users
                    WHERE role = 'Student'
                ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                dgvStudents.DataSource = dt;

                // WARNA BARIS
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (Convert.ToInt32(row.Cells["IsActive"].Value) == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Salmon;
                    }
                }
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
            selectedUserId = Convert.ToInt32(row.Cells["id"].Value);
            selectedIsActive = Convert.ToInt32(row.Cells["IsActive"].Value);

            btnToggleActive.Enabled = true;
            btnToggleActive.Text = selectedIsActive == 1 ? "InActive" : "IsActive";
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) return;

            int newStatus = selectedIsActive == 1 ? 0 : 1;

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET is_active=@status WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", selectedUserId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User status updated.");
            btnToggleActive.Enabled = false;
            selectedUserId = -1;

            LoadStudents();
        }

        private void LoadTodayResults()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        u.fullname AS User,
                        s.name AS Subject,
                        r.date AS Date,
                        r.time_taken AS TimeTaken,
                        r.answered AS Answered,
                        r.unanswered AS Unanswered
                    FROM results r
                    JOIN users u ON r.user_id = u.id
                    JOIN subjects s ON r.subject_id = s.id
                    WHERE DATE(r.date) = CURDATE()
                ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);

                dgvResults.DataSource = dt;

                // WARNA ANSWERED / UNANSWERED
                foreach (DataGridViewRow row in dgvResults.Rows)
                {
                    int answered = Convert.ToInt32(row.Cells["Answered"].Value);
                    int unanswered = Convert.ToInt32(row.Cells["Unanswered"].Value);

                    row.Cells["Answered"].Style.BackColor = Color.ForestGreen;
                    row.Cells["Unanswered"].Style.BackColor = Color.Salmon;
                }
            }
        }
    }
}