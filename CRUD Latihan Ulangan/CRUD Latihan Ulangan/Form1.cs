using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Latihan_Ulangan
{
    public partial class Form1 : Form
    {
        private string connectionString =
        "Host=localhost;Port=5432;Database=NilaiRecapDB;Username=postgres;Password=123";

        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData(string kataKunci = "", string orderBy = "Nis")
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT Nis, Nama, Mata_Pelajaran, Nilai, Keterangan FROM nilai_siswa";
                    var parameters = new List<NpgsqlParameter>();

                    if (!string.IsNullOrWhiteSpace(kataKunci))
                    {
                        sql += @" WHERE Nama ILIKE @kata OR CAST(Nis AS TEXT) ILIKE @kata OR Mata_Pelajaran ILIKE @kata OR CAST(Nilai AS TEXT) ILIKE @kata OR Keterangan ILIKE @kata ";
                        parameters.Add(new NpgsqlParameter("kata", "%" + kataKunci + "%"));
                    }

                    sql += $" ORDER BY {orderBy}";  // fleksibel

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            int nis = Convert.ToInt32(tbNis.Text);
            string nama = tbNama.Text;
            string mataPelajaran = tbMataPelajaran.Text;
            decimal nilai = Convert.ToDecimal(tbNilai.Text);
            string keterangan = tbKeterangan.Text;

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO nilai_siswa (Nis, Nama, Mata_Pelajaran, Nilai, Keterangan) VALUES (@Nis, @Nama, @Mata_Pelajaran, @Nilai, @Keterangan)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Nis", nis);
                        cmd.Parameters.AddWithValue("Nama", nama);
                        cmd.Parameters.AddWithValue("Mata_Pelajaran", mataPelajaran);
                        cmd.Parameters.AddWithValue("Nilai", nilai);
                        cmd.Parameters.AddWithValue("Keterangan", keterangan);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil disimpan!");

                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan data: " + ex.Message);
                }
            }
        }

        private void btnPerbarui_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            int nis = Convert.ToInt32(tbNis.Text);
            string namaBaru = tbNama.Text;
            string mataPelajaranBaru = tbMataPelajaran.Text;
            decimal nilaiBaru = Convert.ToDecimal(tbNilai.Text);
            string keteranganBaru = tbKeterangan.Text;

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE nilai_siswa SET Nama = @Nama, Mata_Pelajaran = @Mata_Pelajaran, Nilai = @Nilai, Keterangan = @Keterangan WHERE Nis = @Nis";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Nama", namaBaru);
                        cmd.Parameters.AddWithValue("Mata_Pelajaran", mataPelajaranBaru);
                        cmd.Parameters.AddWithValue("Nilai", nilaiBaru);
                        cmd.Parameters.AddWithValue("Keterangan", keteranganBaru);
                        cmd.Parameters.AddWithValue("Nis", nis);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil diubah!");

                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah data: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            int nis = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Nis"].Value);

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM nilai_siswa WHERE Nis = @Nis";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("Nis", nis);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data berhasil dihapus!");

                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tbNis.Text = row.Cells["Nis"].Value.ToString();
                tbNama.Text = row.Cells["Nama"].Value.ToString();
                tbMataPelajaran.Text = row.Cells["Mata_Pelajaran"].Value.ToString();
                tbNilai.Text = row.Cells["Nilai"].Value.ToString();
                tbKeterangan.Text = row.Cells["Keterangan"].Value.ToString();
            }
        }
    }
}