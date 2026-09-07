using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Helpers;


namespace LKS
{
    public partial class AddEditQuestionForm : Form
    {
        int questionId;
        int subjectId;
        string imagePath = "";
        public AddEditQuestionForm(int qId, int sId)
        {
            InitializeComponent();
            questionId = qId;
            subjectId = sId;
        }

        private void AddEditQuestionForm_Load(object sender, EventArgs e)
        {
            if (questionId != 0)
                LoadData();
        }

        // ================= LOAD DATA =================
        private void LoadData()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM questions WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", questionId);

                MySqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    txtQuestion.Text = r["question"].ToString();
                    txtA.Text = r["option_a"].ToString();
                    txtB.Text = r["option_b"].ToString();
                    txtC.Text = r["option_c"].ToString();
                    txtD.Text = r["option_d"].ToString();

                    string correct = r["correct_answer"].ToString();

                    rbA.Checked = correct == "A";
                    rbB.Checked = correct == "B";
                    rbC.Checked = correct == "C";
                    rbD.Checked = correct == "D";

                    imagePath = r["question_image"].ToString();

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        picQuestion.ImageLocation = imagePath;
                }
            }
        }

        private void picQuestion_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                picQuestion.ImageLocation = imagePath;
            }
        }

        private void cbQuestionImage_CheckedChanged(object sender, EventArgs e)
        {
            picQuestion.Enabled = cbQuestionImage.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQuestion.Text == "" ||
                txtA.Text == "" ||
                txtB.Text == "" ||
                txtC.Text == "" ||
                txtD.Text == "" ||
                (!rbA.Checked && !rbB.Checked && !rbC.Checked && !rbD.Checked))
            {
                MessageBox.Show("All field must be filled!");
                return;
            }

            string correct =
                rbA.Checked ? "A" :
                rbB.Checked ? "B" :
                rbC.Checked ? "C" : "D";

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                if (questionId == 0)
                {
                    string insert = @"
                        INSERT INTO questions
                        (subject_id, question, option_a, option_b, option_c, option_d, correct_answer, question_image)
                        VALUES
                        (@sid,@q,@a,@b,@c,@d,@correct,@img)
                    ";

                    MySqlCommand cmd = new MySqlCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@sid", subjectId);
                    cmd.Parameters.AddWithValue("@q", txtQuestion.Text);
                    cmd.Parameters.AddWithValue("@a", txtA.Text);
                    cmd.Parameters.AddWithValue("@b", txtB.Text);
                    cmd.Parameters.AddWithValue("@c", txtC.Text);
                    cmd.Parameters.AddWithValue("@d", txtD.Text);
                    cmd.Parameters.AddWithValue("@correct", correct);
                    cmd.Parameters.AddWithValue("@img", imagePath);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string update = @"
                        UPDATE questions SET
                        question=@q,
                        option_a=@a,
                        option_b=@b,
                        option_c=@c,
                        option_d=@d,
                        correct_answer=@correct,
                        question_image=@img
                        WHERE id=@id
                    ";

                    MySqlCommand cmd = new MySqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@q", txtQuestion.Text);
                    cmd.Parameters.AddWithValue("@a", txtA.Text);
                    cmd.Parameters.AddWithValue("@b", txtB.Text);
                    cmd.Parameters.AddWithValue("@c", txtC.Text);
                    cmd.Parameters.AddWithValue("@d", txtD.Text);
                    cmd.Parameters.AddWithValue("@correct", correct);
                    cmd.Parameters.AddWithValue("@img", imagePath);
                    cmd.Parameters.AddWithValue("@id", questionId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Saved successfully!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
