using LoginDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class Formtambahsiswa : Form
    {
        private Koneksi Konn = new Koneksi();

        // mapping kelas -> wali (ubah sesuai data nyata)
        private readonly Dictionary<string, string> WaliPerKelas = new Dictionary<string, string>
        {
            { "X - RPL", "Pak Agus" },
            { "X - AKL", "Bu Siti" },
            { "X - DKV", "Pak Budi" },
            { "X - BR1", "Bu Rina" },
            { "X - BR2", "Pak Joko" },
            { "X - BD",  "Bu Lina" },
            { "X - MP1", "Pak Anton" },
            { "X - MP2", "Bu Maya" },
            { "X - TKJ", "Pak Ahmad" },
            { "X - TKR", "Pak Zul" }
        };

        private int selectedRowIndex = -1;
        private string currentWalas = ""; // walas yg akan dipakai saat insert/update

        public Formtambahsiswa()
        {
            InitializeComponent();

            // hookup event jika control ada
            this.Load += Formtambahsiswa_Load;
            if (this.Controls.Find("cbkelas", true).Length > 0)
                cbkelas.SelectedIndexChanged += cbkelas_SelectedIndexChanged;

            if (this.Controls.Find("txtcari", true).Length > 0)
                txtcari.TextChanged += txtcari_TextChanged;

            if (this.Controls.Find("dataGridView1", true).Length > 0)
                dataGridView1.CellClick += dataGridView1_CellClick;

            if (this.Controls.Find("btntambah", true).Length > 0)
                btntambah.Click += btntambah_Click;

            if (this.Controls.Find("btnEdit", true).Length > 0)
                btnEdit.Click += btnEdit_Click;

            if (this.Controls.Find("btnUpdate", true).Length > 0)
                btnUpdate.Click += btnUpdate_Click;

            if (this.Controls.Find("btnhapus", true).Length > 0)
                btnhapus.Click += btnhapus_Click;

            if (this.Controls.Find("btnbatal", true).Length > 0)
                btnbatal.Click += btnbatal_Click;
        }

        private void Formtambahsiswa_Load(object sender, EventArgs e)
        {
            // isi combobox kelas (jika ada)
            if (this.Controls.Find("cbkelas", true).Length > 0)
            {
                cbkelas.Items.Clear();
                cbkelas.Items.AddRange(new object[] {
                    "X - RPL","X - AKL","X - DKV","X - BR1","X - BR2",
                    "X - BD","X - MP1","X - MP2","X - TKJ","X - TKR"
                });
                if (cbkelas.Items.Count > 0) cbkelas.SelectedIndex = 0;
            }

            // set walas awal berdasarkan kelas terpilih (jika cbkelas ada)
            SetWalasForSelectedClass();

            // generate NIS berikutnya (jika txtnis ada)
            if (this.Controls.Find("txtnis", true).Length > 0)
                txtnis.Text = GenerateNextNis();

            // load grid (jika ada)
            if (this.Controls.Find("dataGridView1", true).Length > 0)
                LoadData();

            SetInitialButtonState();
        }

        private void SetInitialButtonState()
        {
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = true;
            if (this.Controls.Find("btnEdit", true).Length > 0) btnEdit.Enabled = false;
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = false;
            if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = false;
        }

        /// <summary>
        /// Jika ada control txtwalas atau lblWalas maka set teksnya.
        /// Simpan juga ke currentWalas variable.
        /// </summary>
        private void SetWalasForSelectedClass()
        {
            string kelas = "";
            if (this.Controls.Find("cbkelas", true).Length > 0)
                kelas = cbkelas.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(kelas) && WaliPerKelas.ContainsKey(kelas))
                currentWalas = WaliPerKelas[kelas];
            else
                currentWalas = string.Empty;

            // jika ada textbox txtwalas, isi
            var tb = this.Controls.Find("txtwalas", true).FirstOrDefault() as TextBox;
            if (tb != null)
            {
                tb.Text = currentWalas;
                return;
            }

            // jika ada label lblWalas, isi
            var lbl = this.Controls.Find("lblWalas", true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.Text = currentWalas;
            }
        }

        /// <summary>
        /// Generate NIS, mulai dari 18001.
        /// </summary>
        private string GenerateNextNis()
        {
            const int START_NIS = 2023001;
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT ISNULL(MAX(TRY_CAST(nis AS INT)), 0) AS maxNis FROM siswa";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object val = cmd.ExecuteScalar();
                        int maxNis = Convert.ToInt32(val);
                        int candidate = maxNis + 1;
                        int next = Math.Max(candidate, START_NIS);
                        return next.ToString();
                    }
                }
            }
            catch
            {
                return START_NIS.ToString();
            }
        }

        /// <summary>
        /// Ambil text value dari control jika ada, else default ""
        /// </summary>
        private string GetControlText(string name)
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls.Length == 0) return "";
            if (ctrls[0] is TextBox tb) return tb.Text;
            if (ctrls[0] is Label lbl) return lbl.Text;
            return "";
        }

        /// <summary>
        /// Jika control ada, set text.
        /// </summary>
        private void SetControlTextIfExists(string name, string text)
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls.Length == 0) return;
            if (ctrls[0] is TextBox tb) tb.Text = text;
            if (ctrls[0] is Label lbl) lbl.Text = text;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, ISNULL(total_point,0) AS total_point, ISNULL(status,'') AS status
                FROM siswa
                ORDER BY nama";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        var dgvControls = this.Controls.Find("dataGridView1", true);
                        if (dgvControls.Length > 0 && dgvControls[0] is DataGridView dgv)
                        {
                            dgv.DataSource = dt;
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgv.MultiSelect = false;
                            dgv.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

                            // header friendly & formatting
                            if (dgv.Columns.Contains("nis")) dgv.Columns["nis"].HeaderText = "NIS";
                            if (dgv.Columns.Contains("nama")) dgv.Columns["nama"].HeaderText = "Nama";
                            if (dgv.Columns.Contains("jenis_kelamin")) dgv.Columns["jenis_kelamin"].HeaderText = "JK";
                            if (dgv.Columns.Contains("kelas")) dgv.Columns["kelas"].HeaderText = "Kelas";
                            if (dgv.Columns.Contains("wali_kelas")) dgv.Columns["wali_kelas"].HeaderText = "Wali Kelas";
                            if (dgv.Columns.Contains("no_telp")) dgv.Columns["no_telp"].HeaderText = "No. Telp";
                            if (dgv.Columns.Contains("total_point"))
                            {
                                dgv.Columns["total_point"].HeaderText = "Point";
                                dgv.Columns["total_point"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                dgv.Columns["total_point"].ReadOnly = true; // jangan edit di grid
                                dgv.Columns["total_point"].Width = 80;
                            }
                            if (dgv.Columns.Contains("status"))
                            {
                                dgv.Columns["status"].HeaderText = "Status";
                                dgv.Columns["status"].Width = 80;
                            }

                            // Pastikan urutan kolom: nis, nama, JK, kelas, wali_kelas, no_telp, total_point, status
                            int idx = 0;
                            if (dgv.Columns.Contains("nis")) dgv.Columns["nis"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("nama")) dgv.Columns["nama"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("jenis_kelamin")) dgv.Columns["jenis_kelamin"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("kelas")) dgv.Columns["kelas"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("wali_kelas")) dgv.Columns["wali_kelas"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("no_telp")) dgv.Columns["no_telp"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("total_point")) dgv.Columns["total_point"].DisplayIndex = idx++;
                            if (dgv.Columns.Contains("status")) dgv.Columns["status"].DisplayIndex = idx++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchData(string keyword)
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        SELECT nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, total_point
                        FROM siswa
                        WHERE nis LIKE @q OR nama LIKE @q OR kelas LIKE @q OR wali_kelas LIKE @q
                        ORDER BY nama";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + keyword + "%");
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            var dgvControls = this.Controls.Find("dataGridView1", true);
                            if (dgvControls.Length > 0 && dgvControls[0] is DataGridView dgv)
                                dgv.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal cari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers ----------------------------------------------------

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            string q = GetControlText("txtcari").Trim();
            if (string.IsNullOrWhiteSpace(q))
                LoadData();
            else
                SearchData(q);
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set currentWalas & isi control jika ada
            SetWalasForSelectedClass();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedRowIndex = e.RowIndex;

            var dgv = this.Controls.Find("dataGridView1", true)[0] as DataGridView;
            var row = dgv.Rows[e.RowIndex];

            // isi field jika control ada
            SetControlTextIfExists("txtnis", row.Cells["nis"].Value?.ToString() ?? "");
            SetControlTextIfExists("txtnama", row.Cells["nama"].Value?.ToString() ?? "");

            string jk = row.Cells["jenis_kelamin"].Value?.ToString() ?? "";
            if (this.Controls.Find("rblaki", true).Length > 0 && this.Controls.Find("rbpr", true).Length > 0)
            {
                if (!string.IsNullOrEmpty(jk) && jk.ToLower().StartsWith("l"))
                    (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked = true;
                else
                    (this.Controls.Find("rbpr", true)[0] as RadioButton).Checked = true;
            }

            string kelasVal = row.Cells["kelas"].Value?.ToString() ?? "";
            if (this.Controls.Find("cbkelas", true).Length > 0 && cbkelas.Items.Contains(kelasVal))
                cbkelas.SelectedItem = kelasVal;

            // update currentWalas (pakai value dari grid jika ada)
            currentWalas = row.Cells["wali_kelas"].Value?.ToString() ?? currentWalas;
            SetControlTextIfExists("txtwalas", currentWalas);
            SetControlTextIfExists("lblWalas", currentWalas);

            SetControlTextIfExists("txtnotelp", row.Cells["no_telp"].Value?.ToString() ?? "");

            // tombol
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;
            if (this.Controls.Find("btnEdit", true).Length > 0) btnEdit.Enabled = true;
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = false;
            if (this.Controls.Find("btnhapus", true).Length > 0) btnhapus.Enabled = true;
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            string nis = GetControlText("txtnis").Trim();
            string nama = GetControlText("txtnama").Trim();

            // jika tidak ada nama/nilai, validasi ringan
            if (string.IsNullOrWhiteSpace(nis) || string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("NIS dan Nama wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string jk = "";
            if (this.Controls.Find("rblaki", true).Length > 0 && (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked) jk = "L";
            else jk = "P";

            string kelas = this.Controls.Find("cbkelas", true).Length > 0 ? cbkelas.SelectedItem?.ToString() ?? "" : "";
            // gunakan currentWalas (mapping dari combo) jika tidak ada kolom/txt
            string walasToUse = currentWalas;

            string notelp = GetControlText("txtnotelp");

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO siswa (nis, nama, jenis_kelamin, kelas, wali_kelas, no_telp, total_point, status, created_at)
                        VALUES (@nis, @nama, @jk, @kelas, @walas, @notelp, 0, 'aktif', GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nis", nis);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@jk", jk);
                        cmd.Parameters.AddWithValue("@kelas", kelas);
                        cmd.Parameters.AddWithValue("@walas", walasToUse);
                        cmd.Parameters.AddWithValue("@notelp", notelp);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Siswa berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // reset form: generate next nis jika ada control
                if (this.Controls.Find("txtnis", true).Length > 0)
                    SetControlTextIfExists("txtnis", GenerateNextNis());

                SetControlTextIfExists("txtnama", "");
                SetControlTextIfExists("txtnotelp", "");
                if (this.Controls.Find("rblaki", true).Length > 0) (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked = true;

                // reload grid
                if (this.Controls.Find("dataGridView1", true).Length > 0) LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah siswa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Pilih baris yang akan diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.Controls.Find("btnUpdate", true).Length > 0) btnUpdate.Enabled = true;
            if (this.Controls.Find("btntambah", true).Length > 0) btntambah.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nis = GetControlText("txtnis").Trim();
            string nama = GetControlText("txtnama").Trim();

            string jk = "";
            if (this.Controls.Find("rblaki", true).Length > 0 && (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked) jk = "L";
            else jk = "P";

            string kelas = this.Controls.Find("cbkelas", true).Length > 0 ? cbkelas.SelectedItem?.ToString() ?? "" : "";
            string walasToUse = currentWalas;
            string notelp = GetControlText("txtnotelp");

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE siswa
                        SET nama = @nama,
                            jenis_kelamin = @jk,
                            kelas = @kelas,
                            wali_kelas = @walas,
                            no_telp = @notelp
                        WHERE nis = @nis";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@jk", jk);
                        cmd.Parameters.AddWithValue("@kelas", kelas);
                        cmd.Parameters.AddWithValue("@walas", walasToUse);
                        cmd.Parameters.AddWithValue("@notelp", notelp);
                        cmd.Parameters.AddWithValue("@nis", nis);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            MessageBox.Show("Data siswa diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Update gagal (NIS tidak ditemukan).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // refresh UI
                if (this.Controls.Find("dataGridView1", true).Length > 0) LoadData();
                selectedRowIndex = -1;
                SetInitialButtonState();
                if (this.Controls.Find("txtnis", true).Length > 0)
                    SetControlTextIfExists("txtnis", GenerateNextNis());
                SetControlTextIfExists("txtnama", "");
                SetControlTextIfExists("txtnotelp", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Pilih baris yang akan dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nis = GetControlText("txtnis").Trim();
            var conf = MessageBox.Show($"Hapus siswa dengan NIS {nis} ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conf != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "DELETE FROM siswa WHERE nis = @nis";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nis", nis);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            MessageBox.Show("Siswa dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Hapus gagal (NIS tidak ditemukan).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (this.Controls.Find("dataGridView1", true).Length > 0) LoadData();
                selectedRowIndex = -1;
                SetInitialButtonState();
                if (this.Controls.Find("txtnis", true).Length > 0)
                    SetControlTextIfExists("txtnis", GenerateNextNis());
                SetControlTextIfExists("txtnama", "");
                SetControlTextIfExists("txtnotelp", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            selectedRowIndex = -1;
            SetInitialButtonState();
            if (this.Controls.Find("txtnis", true).Length > 0)
                SetControlTextIfExists("txtnis", GenerateNextNis());
            SetControlTextIfExists("txtnama", "");
            if (this.Controls.Find("rblaki", true).Length > 0) (this.Controls.Find("rblaki", true)[0] as RadioButton).Checked = true;
            if (this.Controls.Find("cbkelas", true).Length > 0) cbkelas.SelectedIndex = 0;
            SetWalasForSelectedClass();
            SetControlTextIfExists("txtnotelp", "");
        }

        // sisa event kosong dari Designer kalau ada
        private void txtnis_TextChanged(object sender, EventArgs e) { }
        private void txtnama_TextChanged(object sender, EventArgs e) { }
        private void rblaki_CheckedChanged(object sender, EventArgs e) { }
        private void rbpr_CheckedChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Formtambahsiswa_Load_1(object sender, EventArgs e)
        {

        }

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            Pengaturan form = new Pengaturan();
            form.Show();
            this.Hide();
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

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
