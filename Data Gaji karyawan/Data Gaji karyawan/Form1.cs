using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Data_Gaji_karyawan
{
    public partial class Form1 : Form
    {
        private string connectionString =
       "Host=localhost;Port=5432;Database=DataGajiKaryawan;Username=postgres;Password=123";
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData(string kataKunci = "", string orderBy = "Id")
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT Id, Nama, Departemen, Hari, LIbur, Gaji FROM gaji_karyawan";
                    var parameters = new List<NpgsqlParameter>();

                    if (!string.IsNullOrWhiteSpace(kataKunci))
                    {
                        sql += @" WHERE Nama ILIKE @kata OR CAST(Id AS TEXT) ILIKE @kata OR Departemen ILIKE @kata OR CAST(Hari AS TEXT) ILIKE @kata OR Libur ILIKE @kata OR CAST(Gaji AS TEXT) ILIKE @kata ";
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

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbId.Text);
            string nama = tbNama.Text;
            string departemen = tbDepartemen.Text;
            decimal hari = Convert.ToDecimal(tbHariBekerja.Text);
            string libur = tbLibur.Text;
            decimal gaji = Convert.ToDecimal(tbGaji.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO gaji_karyawan (Id, Nama, Departemen, Hari, Libur, Gaji) VALUES (@Id, @Nama, @Departemen, @Hari, @Libur, @Gaji)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                        cmd.Parameters.AddWithValue("Nama", nama);
                        cmd.Parameters.AddWithValue("Departemen", departemen);
                        cmd.Parameters.AddWithValue("Hari", hari);
                        cmd.Parameters.AddWithValue("Libur", libur; 
                        cmd.Parameters.AddWithValue("Gaji", gaji);

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

            int id = Convert.ToInt32(tbId.Text);
            string namaBaru = tbNama.Text;
            string departemenBaru = tbDepartemen.Text;
            decimal hariBaru = Convert.ToDecimal(tbHariBekerja.Text);
            decimal gajiBaru = Convert.ToDecimal(tbGaji.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE gaji_karyawan SET Nama = @Nama, Departemen = @Departemen, Hari = @Hari, Gaji = @Gaji WHERE Id = @Id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Nama", namaBaru);
                        cmd.Parameters.AddWithValue("Departemen", departemenBaru);
                        cmd.Parameters.AddWithValue("Hari", hariBaru);
                        cmd.Parameters.AddWithValue("Gaji", gajiBaru);
                        cmd.Parameters.AddWithValue("Id", id);

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

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM gaji_karyawan WHERE Id = @Id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("Id", id);

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

                tbId.Text = row.Cells["Id"].Value.ToString();
                tbNama.Text = row.Cells["Nama"].Value.ToString();
                tbDepartemen.Text = row.Cells["Departemen"].Value.ToString();
                tbHariBekerja.Text = row.Cells["Hari"].Value.ToString();
                tbGaji.Text = row.Cells["Gaji"].Value.ToString();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            LoadData(tbCari.Text);
        }
    }
}
