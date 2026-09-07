using Npgsql;
using System.Data;
namespace crud_nilai
{
    public partial class Form1 : Form
    {
        private string connectionString =
        "Host=localhost;Port=5432;Database=nilaiDB;Username=postgres;Password=123";

        public Form1()
        {

            InitializeComponent();
        }

        private void LoadData()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM nilaisiswa";

                using (var da = new NpgsqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO nilaisiswa (id_nis, nama_siswa, nama_mapel, nilai, keterangan) 
                         VALUES (@id, @nama, @mapel, @nilai, @ket)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtNIS.Text));
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@mapel", txtMapel.Text);
                    cmd.Parameters.AddWithValue("@nilai", decimal.Parse(txtNilai.Text));
                    cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan!");
                }
            }

            LoadData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"DELETE FROM nilaisiswa WHERE id_nis=@id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtNIS.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus!");
                }
            }

            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtNIS.Text = row.Cells["id_nis"].Value.ToString();
                txtNama.Text = row.Cells["nama_siswa"].Value.ToString();
                txtMapel.Text = row.Cells["nama_mapel"].Value.ToString();
                txtNilai.Text = row.Cells["nilai"].Value.ToString();
                txtKeterangan.Text = row.Cells["keterangan"].Value.ToString();
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE nilaisiswa 
                         SET nama_siswa=@nama, nama_mapel=@mapel, nilai=@nilai, keterangan=@ket
                         WHERE id_nis=@id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtNIS.Text));
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@mapel", txtMapel.Text);
                    cmd.Parameters.AddWithValue("@nilai", decimal.Parse(txtNilai.Text));
                    cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diupdate!");
                }
            }

            LoadData();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
