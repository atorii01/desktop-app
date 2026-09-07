using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Helpers;

namespace LKS
{
    public partial class AdminQuestionsForm : Form
    {
        public AdminQuestionsForm()
        {
            InitializeComponent();
        }

        private void AdminQuestionsForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

    private void LoadSubjects()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, name FROM subjects";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbSubject.DataSource = dt;
                cbSubject.DisplayMember = "name";
                cbSubject.ValueMember = "id";
            }
        }

        // ================= LOAD QUESTIONS =================
        private void LoadQuestions(int subjectId)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        q.id,
                        q.question AS Question,
                        q.option_a AS OptionA,
                        q.option_b AS OptionB,
                        q.option_c AS OptionC,
                        q.option_d AS OptionD,
                        q.correct_answer AS CorrectAnswer
                    FROM questions q
                    WHERE q.subject_id = @sid
                ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sid", subjectId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvQuestions.DataSource = dt;

                // TAMBAH BUTTON EDIT & DELETE (SEKALI AJA)
                if (!dgvQuestions.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.Name = "Edit";
                    editBtn.Text = "✎";
                    editBtn.UseColumnTextForButtonValue = true;
                    dgvQuestions.Columns.Add(editBtn);

                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "🗑";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvQuestions.Columns.Add(deleteBtn);
                }
            }
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubject.SelectedValue == null) return;
            LoadQuestions(Convert.ToInt32(cbSubject.SelectedValue));
        }

        private void dgvQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int questionId = Convert.ToInt32(
                dgvQuestions.Rows[e.RowIndex].Cells["id"].Value
            );

            // EDIT
            if (dgvQuestions.Columns[e.ColumnIndex].Name == "Edit")
            {
                new AddEditQuestionForm(
                    questionId,
                    Convert.ToInt32(cbSubject.SelectedValue)
                ).ShowDialog();

                LoadQuestions(Convert.ToInt32(cbSubject.SelectedValue));
            }

            // DELETE
            if (dgvQuestions.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show(
                    "Are you sure you want to delete the question?",
                    "Confirm",
                    MessageBoxButtons.YesNo
                ) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM questions WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", questionId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadQuestions(Convert.ToInt32(cbSubject.SelectedValue));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddEditQuestionForm(
                0,
                Convert.ToInt32(cbSubject.SelectedValue)
            ).ShowDialog();

            LoadQuestions(Convert.ToInt32(cbSubject.SelectedValue));
        }
    }
}
