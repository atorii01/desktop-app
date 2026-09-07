using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRUD_Praktek
{
    public partial class Form1 : Form
    {
        private string connectionString =
        "Host=localhost;Port=5432;Database=AplikasiCrudDB;Username=postgres;Password=123";
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData(string kataKunci = "")
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT id, nama_produk, harga FROM produk";
                    var parameters = new List<NpgsqlParameter>();

                    if (!string.IsNullOrWhiteSpace(kataKunci))
                    {
                        sql += " WHERE nama_produk ILIKE @kata OR CAST(harga AS TEXT) ILIKE @kata";
                        parameters.Add(new NpgsqlParameter("kata", "%" + kataKunci + "%"));
                    }

                    sql += " ORDER BY id";

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

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadData();
            TampilkanGrafikHarga();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text;
            decimal harga = Convert.ToDecimal(txtHarga.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO produk (nama_produk, harga) VALUES (@nama, @harga)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nama", nama);
                        cmd.Parameters.AddWithValue("harga", harga);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil disimpan!");

                        LoadData();
                        TampilkanGrafikHarga();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan data: " + ex.Message);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            string namaBaru = txtNama.Text;
            decimal hargaBaru = Convert.ToDecimal(txtHarga.Text);

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE produk SET nama_produk = @nama, harga = @harga WHERE id = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nama", namaBaru);
                        cmd.Parameters.AddWithValue("harga", hargaBaru);
                        cmd.Parameters.AddWithValue("id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil diubah!");

                        LoadData();
                        TampilkanGrafikHarga();
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

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM produk WHERE id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("id", id);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data berhasil dihapus!");

                            LoadData();
                            TampilkanGrafikHarga();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtId.Text = row.Cells["id"].Value.ToString();
                txtNama.Text = row.Cells["nama_produk"].Value.ToString();
                txtHarga.Text = row.Cells["harga"].Value.ToString();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtCari.Text);
            TampilkanGrafikHarga();
        }
        public void TampilkanGrafikHarga()
        {
            chartProduk.Series.Clear();
            chartProduk.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Title = "Harga Produk";
            chartArea.AxisX.Title = "Nama Produk";
            chartProduk.ChartAreas.Add(chartArea);

            Series series = new Series("Harga Produk");
            series.ChartType = SeriesChartType.Bar;

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT nama_produk, harga FROM produk ORDER BY harga DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nama = reader.GetString(0);
                            decimal harga = reader.GetDecimal(1);

                            series.Points.AddXY(nama, harga);
                        }
                    }

                    chartProduk.Series.Add(series);
                    chartProduk.Titles.Clear();
                    chartProduk.Titles.Add("Perbandingan Harga Produk");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat grafik: " + ex.Message);
                }
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            // Buka dialog untuk memilih lokasi penyimpanan file
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "DataProdukExport.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Gunakan StringBuilder untuk membangun konten CSV
                    StringBuilder sb = new StringBuilder();

                    // 1. Tambahkan Header Kolom (nama_produk, harga)
                    // Asumsi: Kita hanya ingin mengekspor kolom yang terlihat
                    // dan tidak menggunakan kolom 'id' jika disembunyikan.
                    // Loop melalui DataGridViewColumnCollection
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        // Tambahkan nama kolom, dipisahkan oleh koma
                        sb.Append(dataGridView1.Columns[i].HeaderText);
                        if (i < dataGridView1.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.AppendLine(); // Baris baru untuk data

                    // 2. Tambahkan Data Baris
                    // Loop melalui semua baris di DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Lewati baris header atau baris kosong (jika ada)
                        if (row.IsNewRow) continue;

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            // Ambil nilai sel dan pastikan tidak ada koma dalam nilai (atau ganti dengan kutipan)
                            string cellValue = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";

                            // Cara sederhana: masukkan nilai dalam tanda kutip untuk menangani koma di dalam data
                            sb.Append($"\"{cellValue.Replace("\"", "\"\"")}\"");
                            if (i < dataGridView1.Columns.Count - 1)
                            {
                                sb.Append(",");
                            }
                        }
                        sb.AppendLine(); // Baris baru untuk baris data berikutnya
                    }

                    // 3. Tulis konten ke file
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Data berhasil diexport ke CSV!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal export data ke CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            // Buka dialog untuk memilih lokasi penyimpanan file
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "DataProdukExport.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // --- LOGIKA PDF (Konsep dengan iText 7 sebagai contoh) ---
                    using (var writer = new PdfWriter(sfd.FileName))
                    using (var pdf = new PdfDocument(writer))
                    using (var document = new Document(pdf))
                    {
                        // 1. Tambahkan Judul
                        document.Add(new Paragraph("Laporan Data Produk").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(16));
                        document.Add(new Paragraph("")); // Baris kosong

                        // 2. Buat Tabel
                        // Hitung jumlah kolom di DataGridView
                        int colCount = dataGridView1.Columns.Count;
                        Table table = new Table(colCount); 
                        table.SetWidth(iText.Layout.Properties.UnitValue.CreatePercentValue(100)); // Lebar 100%

                        // 3. Tambahkan Header Tabel
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            table.AddHeaderCell(new Cell().Add(new Paragraph(col.HeaderText)));
                        }

                        // 4. Tambahkan Data Baris
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue; 

                            for (int i = 0; i < colCount; i++)
                            {
                                string cellValue = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                                table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                            }
                        }

                        // 5. Tambahkan tabel ke dokumen
                        document.Add(table);
                    }
                   
                    // --- AKHIR LOGIKA PDF ---

                    // Ganti bagian di atas dengan implementasi library PDF Anda yang sebenarnya
                    MessageBox.Show("Data berhasil diexport ke PDF! (Memerlukan library eksternal)", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal export data ke PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
