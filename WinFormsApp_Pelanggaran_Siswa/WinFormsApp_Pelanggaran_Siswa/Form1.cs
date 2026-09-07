                    using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormPelanggara : Form
    {
        private Koneksi Konn = new Koneksi();

        public FormPelanggara()
        {
            InitializeComponent();

            // Event DataGridView
            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;

            // Panggil load data saat Form sudah siap (Load event)
            this.Load += FormPelanggara_Load;
        }

        private void FormPelanggara_Load(object sender, EventArgs e)
        {
            LoadTopPelanggar();
        }

        private void LoadTopPelanggar()
        {
            try
            {
                if (dataGridView2 == null) return;

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();

                    // Top 20 siswa berdasarkan total_point
                    string queryTop = @"
                        SELECT TOP 20
                            nis, nama, kelas, total_point
                        FROM siswa
                        ORDER BY total_point DESC;";
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryTop, conn))
                    {
                        da.Fill(dt);
                    }

                    // normalize null/DBNULL
                    foreach (DataRow r in dt.Rows)
                    {
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            if (r.IsNull(c) || string.IsNullOrWhiteSpace(r[c].ToString()))
                                r[c] = "";
                        }
                    }

                    dataGridView2.DataSource = dt;

                    // Styling
                    dataGridView2.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView2.MultiSelect = false;
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.RowTemplate.Height = 30;

                    if (dataGridView2.Columns["nis"] != null) dataGridView2.Columns["nis"].HeaderText = "NIS";
                    if (dataGridView2.Columns["nama"] != null) dataGridView2.Columns["nama"].HeaderText = "Nama";
                    if (dataGridView2.Columns["kelas"] != null) dataGridView2.Columns["kelas"].HeaderText = "Kelas";
                    if (dataGridView2.Columns["total_point"] != null) dataGridView2.Columns["total_point"].HeaderText = "Point";

                    // pastikan sel kosong terlihat kosong
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                            {
                                cell.Value = "";
                                cell.Style.BackColor = Color.White;
                                cell.Style.ForeColor = Color.Black;
                            }
                            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }

                    // Jumlah siswa aktif
                    string sqlCountSiswa = "SELECT COUNT(*) FROM siswa WHERE status = 'aktif'";
                    using (SqlCommand cmd = new SqlCommand(sqlCountSiswa, conn))
                    {
                        object val = cmd.ExecuteScalar();
                        if (label6 != null) label6.Text = Convert.ToInt32(val).ToString();
                    }

                    // Jumlah pelanggaran hari ini
                    string sqlCountToday = "SELECT COUNT(*) FROM pelanggaran WHERE CAST(created_at AS DATE) = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(sqlCountToday, conn))
                    {
                        object val = cmd.ExecuteScalar();
                        if (label9 != null) label9.Text = Convert.ToInt32(val).ToString();
                    }

                    // Nama siswa dengan pelanggaran terbanyak
                    string sqlTopSiswa = @"
                        SELECT TOP 1 s.nama, COUNT(p.id_pelanggaran) AS jumlah
                        FROM pelanggaran p
                        JOIN siswa s ON s.nis = p.nis
                        GROUP BY s.nama
                        ORDER BY jumlah DESC;";
                    using (SqlCommand cmd = new SqlCommand(sqlTopSiswa, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (lblpointtertinggi != null)
                                lblpointtertinggi.Text = reader["nama"]?.ToString() ?? "";
                        }
                        else
                        {
                            if (lblpointtertinggi != null)
                                lblpointtertinggi.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                bool hasPoint = dataGridView2.Columns.Contains("total_point");

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            cell.Value = "";
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                        }
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (hasPoint)
                    {
                        var cellValue = row.Cells["total_point"].Value;
                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int point))
                        {
                            if (point < 25) row.DefaultCellStyle.BackColor = Color.LightGreen;
                            else if (point < 50) row.DefaultCellStyle.BackColor = Color.Yellow;
                            else if (point < 100) row.DefaultCellStyle.BackColor = Color.LightCoral;
                            else row.DefaultCellStyle.BackColor = Color.LightGray;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch { /* jangan ganggu UX */ }
        }

        private void btnDatasiswa_Click(object sender, EventArgs e)
        {
            Formsiswa form = new Formsiswa();
            form.Show();
            this.Hide();
        }

        private void btnDataguru_Click(object sender, EventArgs e)
        {
            FormUserGuru form = new FormUserGuru();
            form.Show();
            this.Hide();
        }

        private void btnJenispelanggaran_Click(object sender, EventArgs e)
        {
            Formjenispelanggaran form = new Formjenispelanggaran();
            form.Show();
            this.Hide();
        }

        private void btnInputpelanggaran_Click(object sender, EventArgs e)
        {
            FormInputPelanggaran form = new FormInputPelanggaran();
            form.Show();
            this.Hide();
        }

        private void btnPersiswa_Click(object sender, EventArgs e)
        {
            FormLaporanpersiswa form = new FormLaporanpersiswa();
            form.Show();
            this.Hide();
        }

        private void btnPerkelas_Click(object sender, EventArgs e)
        {
            FormLaporanperkelas form = new FormLaporanperkelas();
            form.Show();
            this.Hide();
        }

        private void btnSuratperingatan_Click(object sender, EventArgs e)
        {
            SuratPeringatan form = new SuratPeringatan();
            form.Show();
            this.Hide();
        }

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            Pengaturan form = new Pengaturan();
            form.Show();
            this.Hide();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
