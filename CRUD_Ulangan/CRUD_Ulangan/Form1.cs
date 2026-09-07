using System;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRUD_Ulangan
{
    public partial class Form1 : Form
    {
        private string connectionString =
            "Host=localhost;port=5432;Database=datakaryawan;Username=postgres;Password=123";

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
                    string sql = @"
                        SELECT Id, Nama, Departemen, Hari,
                        CASE 
                            WHEN Hari >= 20 THEN 5000000 + ((Hari - 20) * 100000)
                            ELSE 0
                        END AS Gaji,
                        CASE 
                            WHEN Hari = 20 THEN 'Regular'
                            WHEN Hari > 20 THEN 'Lembur'
                            ELSE 'Tidak Valid'
                        END AS Libur
                        FROM gaji_karyawan";

                    var parameters = new List<NpgsqlParameter>();

                    if (!string.IsNullOrWhiteSpace(kataKunci))
                    {
                        sql += @" WHERE Nama ILIKE @kata 
                                  OR CAST(Id AS TEXT) ILIKE @kata 
                                  OR Departemen ILIKE @kata 
                                  OR CAST(Hari AS TEXT) ILIKE @kata";
                        parameters.Add(new NpgsqlParameter("kata", "%" + kataKunci + "%"));
                    }

                    sql += $" ORDER BY {orderBy}";

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
            int hari = Convert.ToInt32(tbHariBekerja.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO gaji_karyawan (Id, Nama, Departemen, Hari) VALUES (@Id, @Nama, @Departemen, @Hari)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Id", id);
                        cmd.Parameters.AddWithValue("Nama", nama);
                        cmd.Parameters.AddWithValue("Departemen", departemen);
                        cmd.Parameters.AddWithValue("Hari", hari);

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
            int hariBaru = Convert.ToInt32(tbHariBekerjaz.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE gaji_karyawan SET Nama=@Nama, Departemen=@Departemen, Hari=@Hari WHERE Id=@Id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("Nama", namaBaru);
                        cmd.Parameters.AddWithValue("Departemen", departemenBaru);
                        cmd.Parameters.AddWithValue("Hari", hariBaru);
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
                        string sql = "DELETE FROM gaji_karyawan WHERE Id=@Id";

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

                label1.Text = row.Cells["Id"].Value.ToString();
                label3.Text = row.Cells["Nama"].Value.ToString();
                label2.Text = row.Cells["Departemen"].Value.ToString();
                label4.Text = row.Cells["Hari"].Value.ToString();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            LoadData(tbCari.Text);
        }
    }
}