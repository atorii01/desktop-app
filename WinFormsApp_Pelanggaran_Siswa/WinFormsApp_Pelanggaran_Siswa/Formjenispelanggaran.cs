using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Formjenispelanggaran : Form
    {
        private readonly Koneksi Konn = new Koneksi();
        private readonly string placeholderCari = "cari data";
        private BindingSource bs = new BindingSource();

        public Formjenispelanggaran()
        {
            InitializeComponent();

            // Pasang event DataGridView
            if (dataGridView2 != null)
            {
                dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
                dataGridView2.CellClick += dataGridView2_CellClick;
            }

            // Placeholder txtcari
            if (txtcari != null)
            {
                txtcari.ForeColor = Color.Gray;
                txtcari.Text = placeholderCari;
                txtcari.GotFocus += Txtcari_GotFocus;
                txtcari.LostFocus += Txtcari_LostFocus;
                txtcari.TextChanged += Txtcari_TextChanged;
            }

            this.Load += (s, e) => LoadJenisPelanggaran();
        }

        #region Placeholder txtcari
        private void Txtcari_GotFocus(object sender, EventArgs e)
        {
            if (txtcari.Text == placeholderCari)
            {
                txtcari.Text = "";
                txtcari.ForeColor = Color.Black;
            }
        }

        private void Txtcari_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcari.Text))
            {
                txtcari.Text = placeholderCari;
                txtcari.ForeColor = Color.Gray;
            }
        }

        private void Txtcari_TextChanged(object sender, EventArgs e)
        {
            if (txtcari.Text == placeholderCari) return;

            string keyword = txtcari.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword))
            {
                bs.RemoveFilter(); // reset filter
            }
            else
            {
                bs.Filter = $"kode_jenis LIKE '%{keyword}%' OR nama_pelanggaran LIKE '%{keyword}%' OR jenis LIKE '%{keyword}%'";
            }
        }
        #endregion

        private void LoadJenisPelanggaran()
        {
            if (dataGridView2 == null) return;

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string query = @"
                        SELECT id_jenis,
                               kode_jenis,
                               nama_pelanggaran,
                               ISNULL(point,0) AS point,
                               ISNULL(jenis,'') AS jenis
                        FROM dbo.jenis_pelanggaran
                        ORDER BY kode_jenis ASC";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.Fill(dt);
                    }
                }

                // Normalisasi DBNull
                foreach (DataRow r in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        if (r.IsNull(col)) r[col] = col.DataType == typeof(int) ? 0 : string.Empty;
                }

                bs.DataSource = dt;
                dataGridView2.DataSource = bs;

                // Styling
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.RowTemplate.Height = 28;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.ColumnHeadersDefaultCellStyle.Font =
                    new Font(dataGridView2.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                // Friendly headers
                if (dataGridView2.Columns.Contains("id_jenis")) dataGridView2.Columns["id_jenis"].HeaderText = "ID";
                if (dataGridView2.Columns.Contains("kode_jenis")) dataGridView2.Columns["kode_jenis"].HeaderText = "Kode";
                if (dataGridView2.Columns.Contains("nama_pelanggaran")) dataGridView2.Columns["nama_pelanggaran"].HeaderText = "Nama Peringatan";
                if (dataGridView2.Columns.Contains("point")) dataGridView2.Columns["point"].HeaderText = "Point";
                if (dataGridView2.Columns.Contains("jenis")) dataGridView2.Columns["jenis"].HeaderText = "Jenis";

                // Numeric columns read-only
                if (dataGridView2.Columns.Contains("id_jenis")) dataGridView2.Columns["id_jenis"].ReadOnly = true;
                if (dataGridView2.Columns.Contains("point")) dataGridView2.Columns["point"].ReadOnly = true;

                NormalizeEmptyCellsToVisible();

                // Baris pertama tebal
                if (dataGridView2.Rows.Count > 0)
                    dataGridView2.Rows[0].DefaultCellStyle.Font = new Font(dataGridView2.DefaultCellStyle.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data jenis pelanggaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            NormalizeEmptyCellsToVisible();
        }

        private void NormalizeEmptyCellsToVisible()
        {
            if (dataGridView2 == null) return;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                for (int ci = 0; ci < row.Cells.Count; ci++)
                {
                    var cell = row.Cells[ci];
                    if (cell.Value == DBNull.Value || cell.Value == null)
                        cell.Value = (cell.OwningColumn.Name.ToLower() == "id_jenis" || cell.OwningColumn.Name.ToLower() == "point") ? 0 : string.Empty;

                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2 == null || e.RowIndex < 0) return;
            var row = dataGridView2.Rows[e.RowIndex];

            int id = 0;
            if (dataGridView2.Columns.Contains("id_jenis"))
                int.TryParse(row.Cells["id_jenis"].Value?.ToString(), out id);

            string nama = "";
            if (dataGridView2.Columns.Contains("nama_pelanggaran"))
                nama = row.Cells["nama_pelanggaran"].Value?.ToString() ?? "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormUserGuru form = new FormUserGuru();
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormTambahPelanggaran form = new FormTambahPelanggaran();
            form.Show();
            this.Hide();
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

        private void btninputPelanggaran_Click(object sender, EventArgs e)
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

        private void btnSuratPeringatan_Click(object sender, EventArgs e)
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
    }
}
