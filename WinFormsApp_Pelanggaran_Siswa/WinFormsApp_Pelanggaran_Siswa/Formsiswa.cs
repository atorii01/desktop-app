using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Formsiswa : Form
    {
        private Koneksi Konn = new Koneksi();

        public Formsiswa()
        {
            InitializeComponent();

            // hubungkan event
            txtcari.TextChanged += txtcari_TextChanged;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            this.Load += Formsiswa_Load;

            // jika tombol btnTambahPoint ada di Designer, hubungkan event
            if (this.Controls.Find("btnTambahPoint", true).Length > 0) ;

        }

        private void Formsiswa_Load(object sender, EventArgs e)
        {
            // placeholder
            txtcari.Text = "Cari";
            txtcari.ForeColor = Color.Gray;
            txtcari.Enter += (s, ev) =>
            {
                if (txtcari.Text == "Cari")
                {
                    txtcari.Text = "";
                    txtcari.ForeColor = Color.Black;
                }
            };
            txtcari.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtcari.Text))
                {
                    txtcari.Text = "Cari";
                    txtcari.ForeColor = Color.Gray;
                }
            };

            LoadData();
        }

        // Load semua siswa, URUT berdasarkan NIS secara numerik (misal 2023001, 2023002, ...)
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    // ORDER BY TRY_CAST(nis AS INT) agar urut numerik (bukan string)
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, ISNULL(total_point,0) AS total_point, ISNULL(status,'') AS status
                        FROM siswa
                        ORDER BY TRY_CAST(nis AS INT) ASC, nama";
                    using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }

                // styling DataGridView
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView2.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // header friendly & urutan kolom jika mau dipaksakan
                if (dataGridView2.Columns.Contains("nis")) dataGridView2.Columns["nis"].HeaderText = "NIS";
                if (dataGridView2.Columns.Contains("nama")) dataGridView2.Columns["nama"].HeaderText = "Nama";
                if (dataGridView2.Columns.Contains("jenis_kelamin")) dataGridView2.Columns["jenis_kelamin"].HeaderText = "JK";
                if (dataGridView2.Columns.Contains("kelas")) dataGridView2.Columns["kelas"].HeaderText = "Kelas";
                if (dataGridView2.Columns.Contains("wali_kelas")) dataGridView2.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                if (dataGridView2.Columns.Contains("no_telp")) dataGridView2.Columns["no_telp"].HeaderText = "No. Telp";
                if (dataGridView2.Columns.Contains("total_point")) dataGridView2.Columns["total_point"].HeaderText = "Point";
                if (dataGridView2.Columns.Contains("status")) dataGridView2.Columns["status"].HeaderText = "Status";

                // paksa urutan kolom: nis, nama, JK, kelas, wali_kelas, no_telp, total_point, status
                int idx = 0;
                if (dataGridView2.Columns.Contains("nis")) dataGridView2.Columns["nis"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("nama")) dataGridView2.Columns["nama"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("jenis_kelamin")) dataGridView2.Columns["jenis_kelamin"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("kelas")) dataGridView2.Columns["kelas"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("wali_kelas")) dataGridView2.Columns["wali_kelas"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("no_telp")) dataGridView2.Columns["no_telp"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("total_point")) dataGridView2.Columns["total_point"].DisplayIndex = idx++;
                if (dataGridView2.Columns.Contains("status")) dataGridView2.Columns["status"].DisplayIndex = idx++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Pencarian siswa, hasil juga diurutkan berdasarkan nis numerik
        private void SearchData(string keyword)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, ISNULL(total_point,0) AS total_point, ISNULL(status,'') AS status
                        FROM siswa
                        WHERE nis LIKE @q OR nama LIKE @q OR kelas LIKE @q OR wali_kelas LIKE @q
                        ORDER BY TRY_CAST(nis AS INT) ASC, nama";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + keyword + "%");
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }

                // maintain styling/headers after search
                if (dataGridView2.Columns.Contains("nis")) dataGridView2.Columns["nis"].HeaderText = "NIS";
                if (dataGridView2.Columns.Contains("nama")) dataGridView2.Columns["nama"].HeaderText = "Nama";
                if (dataGridView2.Columns.Contains("jenis_kelamin")) dataGridView2.Columns["jenis_kelamin"].HeaderText = "JK";
                if (dataGridView2.Columns.Contains("kelas")) dataGridView2.Columns["kelas"].HeaderText = "Kelas";
                if (dataGridView2.Columns.Contains("wali_kelas")) dataGridView2.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                if (dataGridView2.Columns.Contains("no_telp")) dataGridView2.Columns["no_telp"].HeaderText = "No. Telp";
                if (dataGridView2.Columns.Contains("total_point")) dataGridView2.Columns["total_point"].HeaderText = "Point";
                if (dataGridView2.Columns.Contains("status")) dataGridView2.Columns["status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal cari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            string q = txtcari.Text.Trim();
            if (string.IsNullOrWhiteSpace(q) || q == "Cari")
                LoadData();
            else
                SearchData(q);
        }

        // Double click -> tampil detail
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView2.Rows[e.RowIndex];

            string nis = row.Cells["nis"]?.Value?.ToString() ?? "";
            string nama = row.Cells["nama"]?.Value?.ToString() ?? "";
            string kelas = row.Cells["kelas"]?.Value?.ToString() ?? "";
            string walas = dataGridView2.Columns.Contains("wali_kelas") ? row.Cells["wali_kelas"]?.Value?.ToString() ?? "" : "";
            string notelp = dataGridView2.Columns.Contains("no_telp") ? row.Cells["no_telp"]?.Value?.ToString() ?? "" : "";
            string point = dataGridView2.Columns.Contains("total_point") ? row.Cells["total_point"]?.Value?.ToString() ?? "0" : "0";
            string status = dataGridView2.Columns.Contains("status") ? row.Cells["status"]?.Value?.ToString() ?? "" : "";

            MessageBox.Show(
                $"NIS: {nis}\nNama: {nama}\nKelas: {kelas}\nWali Kelas: {walas}\nNo. Telp: {notelp}\nPoint: {point}\nStatus: {status}",
                "Detail Siswa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Tambah point & auto-update status di DB
        private void button6_Click(object sender, EventArgs e)
        {
            Formtambahsiswa form = new Formtambahsiswa();
            form.Show();
            this.Hide();
        }
        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            Pengaturan form = new Pengaturan();
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

        private void btnInputperlanggaran_Click(object sender, EventArgs e)
        {
            FormInputPelanggaran form = new FormInputPelanggaran();
            form.Show();
            this.Hide();
        }

        private void btnpersiswa_Click(object sender, EventArgs e)
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

        private void btndashboard_Click(object sender, EventArgs e)
        {
            FormPelanggara form = new FormPelanggara();
            form.Show();
            this.Hide();
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            txtcari.Clear();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Formtambahsiswa form = new Formtambahsiswa();
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
