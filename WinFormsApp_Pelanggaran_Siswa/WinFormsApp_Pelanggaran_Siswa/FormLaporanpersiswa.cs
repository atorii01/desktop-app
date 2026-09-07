using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormLaporanpersiswa : Form
    {
        private readonly Koneksi Konn = new Koneksi();
        private BindingSource bs = new BindingSource();

        public FormLaporanpersiswa()
        {
            InitializeComponent();

            // Event pewarnaan grid
            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;

            // Placeholder event
            txtcari.Enter += (s, e) => RemovePlaceholder();
            txtcari.Leave += (s, e) => SetPlaceholder();

            this.Load += FormLaporanpersiswa_Load;
        }

        private void FormLaporanpersiswa_Load(object sender, EventArgs e)
        {
            HitungJumlahGender();
            LoadListSiswa();
            SetPlaceholder();
        }

        // ============================
        // == HITUNG JUMLAH GENDER  ==
        // ============================
        private void HitungJumlahGender()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT jenis_kelamin, COUNT(*) as jumlah FROM siswa GROUP BY jenis_kelamin";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int laki = 0, perempuan = 0;
                        while (dr.Read())
                        {
                            string jk = dr["jenis_kelamin"].ToString();
                            int jml = Convert.ToInt32(dr["jumlah"]);
                            if (jk == "L") laki = jml;
                            else if (jk == "P") perempuan = jml;
                        }
                        lbllaki.Text = $"{laki}";
                        lblperempuan.Text = $"{perempuan}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hitung gender: " + ex.Message);
            }
        }

        // ============================
        // == LOAD DATA SISWA        ==
        // ============================
        private void LoadListSiswa(string filter = "")
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();

                    string sql = @"
                        SELECT s.nis, s.nama, s.jenis_kelamin, s.kelas, s.wali_kelas, 
                               s.no_telp, s.total_point, s.status,
                               (SELECT COUNT(*) FROM pelanggaran p WHERE p.nis = s.nis) as jumlah_kasus
                        FROM siswa s";

                    if (!string.IsNullOrWhiteSpace(filter))
                        sql += " WHERE s.nis LIKE @f OR s.nama LIKE @f OR s.kelas LIKE @f OR s.wali_kelas LIKE @f";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(filter))
                            da.SelectCommand.Parameters.AddWithValue("@f", "%" + filter + "%");

                        da.Fill(dt);
                    }
                }

                bs.DataSource = dt;
                dataGridView2.DataSource = bs;

                // Styling dasar
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.RowTemplate.Height = 28;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load siswa: " + ex.Message);
            }
        }

        // ============================
        // == SORT BUTTONS           ==
        // ============================
        private void btnnis_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bs.DataSource;
            if (dt != null)
            {
                dt.DefaultView.Sort = "nis ASC";
                dataGridView2.DataSource = dt.DefaultView;
            }
        }

        private void btntotalpoint_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bs.DataSource;
            if (dt != null)
            {
                dt.DefaultView.Sort = "total_point DESC";
                dataGridView2.DataSource = dt.DefaultView;
            }
        }

        // ============================
        // == TEXTBOX CARI           ==
        // ============================
        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            // Jangan jalanin filter kalau placeholder aktif
            if (txtcari.ForeColor == Color.Gray) return;

            if (string.IsNullOrWhiteSpace(txtcari.Text))
                LoadListSiswa();
            else
                LoadListSiswa(txtcari.Text.Trim());
        }

        // Placeholder functions
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtcari.Text))
            {
                txtcari.Text = "Cari siswa...";
                txtcari.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder()
        {
            if (txtcari.Text == "Cari siswa...")
            {
                txtcari.Text = "";
                txtcari.ForeColor = Color.Black;
            }
        }

        // ============================
        // == DASHBOARD BUTTON       ==
        // ============================
        private void btndashboard_Click(object sender, EventArgs e)
        {
            FormPelanggara form = new FormPelanggara();
            form.Show();
            this.Hide();
        }

        // ============================
        // == DATA GRID COLORING     ==
        // ============================
        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                bool hasPoint = dataGridView2.Columns.Contains("total_point");

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Styling sel kosong
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                        }
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Pewarnaan baris berdasarkan total_point
                    if (hasPoint)
                    {
                        var cellValue = row.Cells["total_point"].Value;
                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int point))
                        {
                            if (point < 25)
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                            else if (point < 50)
                                row.DefaultCellStyle.BackColor = Color.Yellow;
                            else if (point < 100)
                                row.DefaultCellStyle.BackColor = Color.LightCoral;
                            else
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
            catch
            {
                // biar nggak crash kalau ada error kecil
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // opsional
        }

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            Pengaturan form = new Pengaturan();
            form.Show();
            this.Hide();
        }

        private void btnDataSiswa_Click(object sender, EventArgs e)
        {
            Formsiswa form = new Formsiswa();
            form.Show();
            this.Hide();
        }

        private void btnDataGuru_Click(object sender, EventArgs e)
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
    }
}
