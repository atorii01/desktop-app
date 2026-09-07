using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormUserGuru : Form
    {
        private readonly Koneksi Konn = new Koneksi();
        private string selectedKode = null;
        private readonly string placeholderCari = "cari guru";
        private BindingSource bs = new BindingSource();

        public FormUserGuru()
        {
            InitializeComponent();

            this.Load += FormUserGuru_Load;

            // placeholder txtcari
            var tc = FindControlByPossibleNames(typeof(TextBox), "txtcari");
            if (tc is TextBox tct)
            {
                tct.ForeColor = Color.Gray;
                tct.Text = placeholderCari;
                tct.GotFocus += Txtcari_GotFocus;
                tct.LostFocus += Txtcari_LostFocus;
                tct.TextChanged += Txtcari_TextChanged;
            }

            // grid event
            var dgv = FindControlByPossibleNames(typeof(DataGridView), "dataGridView1") as DataGridView;
            if (dgv != null) dgv.CellClick += dataGridView1_CellClick;

            // tombol (try beberapa kemungkinan name)
            WireButton("btntambah", btntambah_Click);
            WireButton("btnEdit", btnEdit_Click);
            WireButton("btnUpdate", btnUpdate_Click);
            WireButton("btnhapus", btnhapus_Click);
            WireButton("btnbatal", btnbatal_Click);
            WireButton("btndashboard", btndashboard_Click);
        }

        #region helper find/wire
        private Control FindControlByPossibleNames(Type ctrlType, params string[] names)
        {
            // coba nama-nama spesifik dulu
            foreach (var n in names)
            {
                var arr = this.Controls.Find(n, true);
                if (arr.Length > 0) return arr[0];
            }

            // jika tidak ditemukan, coba cari control type yang mengandung kata kunci (role/nama/password)
            string typeName = ctrlType.Name.ToLower();
            foreach (Control c in this.Controls.Cast<Control>().SelectMany(x => x.Controls.Cast<Control>()))
            {
                if (c.GetType() == ctrlType) return c;
            }

            // fallback: return null
            return null;
        }

        private void WireButton(string name, EventHandler handler)
        {
            var btn = FindControlByPossibleNames(typeof(Button), name) as Button;
            if (btn != null) btn.Click += handler;
        }

        private string GetValueFromPossibleNames(params string[] names)
        {
            foreach (var n in names)
            {
                var arr = this.Controls.Find(n, true);
                if (arr.Length == 0) continue;
                var c = arr[0];
                if (c is TextBox tb) return tb.Text;
                if (c is ComboBox cb) return cb.Text;
                // other controls with Text property
                return c.Text;
            }

            // fallback: try to find any TextBox containing 'nama'/'pass'/'role'
            foreach (Control c in this.Controls.Find("", true))
            {
                // won't be reached because Find with empty string returns nothing; keep for completeness
            }

            return "";
        }

        private Control FindRoleControl()
        {
            var c = this.Controls.Find("cmbRole", true).FirstOrDefault();
            if (c != null) return c;
            c = this.Controls.Find("cbRole", true).FirstOrDefault();
            if (c != null) return c;
            c = this.Controls.Find("role", true).FirstOrDefault();
            if (c != null) return c;
            // coba cari ComboBox yang memiliki "role" di Name (case-insensitive)
            foreach (Control ctrl in this.Controls.Find("", true))
            {
                if (ctrl is ComboBox && ctrl.Name.ToLower().Contains("role")) return ctrl;
            }
            // terakhir, cari combo apapun
            foreach (Control ctrl in this.Controls.Find("", true))
            {
                if (ctrl is ComboBox) return ctrl;
            }
            return null;
        }

        private Control FindTextControl(params string[] names)
        {
            foreach (var n in names)
            {
                var arr = this.Controls.Find(n, true);
                if (arr.Length > 0) return arr[0];
            }
            // fallback: find first textbox
            var tbs = this.Controls.Find("", true).Where(c => c is TextBox).ToArray();
            if (tbs.Length > 0) return tbs[0];
            return null;
        }
        #endregion

        #region txtcari placeholder
        private void Txtcari_GotFocus(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt != null && txt.Text == placeholderCari)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void Txtcari_LostFocus(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = placeholderCari;
                txt.ForeColor = Color.Gray;
            }
        }

        private void Txtcari_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt == null) return;
            if (txt.Text == placeholderCari) return;

            string keyword = txt.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(keyword))
                bs.RemoveFilter();
            else
                bs.Filter = $"kode_guru LIKE '%{keyword}%' OR nama LIKE '%{keyword}%' OR role LIKE '%{keyword}%'";
        }
        #endregion

        private void FormUserGuru_Load(object sender, EventArgs e)
        {
            // siapkan combo role jika ada
            var roleCtrl = FindRoleControl();
            if (roleCtrl is ComboBox cb)
            {
                if (cb.Items.Count == 0)
                {
                    cb.Items.Add("admin");
                    cb.Items.Add("guru bk");
                }
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            LoadGrid();
            SetInitialButtonState();

            var kodeCtrl = FindTextControl("txtKodeGuru", "txtKodeUser", "txtKode");
            if (kodeCtrl is TextBox tbKode)
            {
                tbKode.Text = GetNextKodePreview();
                tbKode.ReadOnly = true;
            }
        }

        private void SetInitialButtonState()
        {
            var addBtn = FindControlByPossibleNames(typeof(Button), "btntambah") as Button;
            var editBtn = FindControlByPossibleNames(typeof(Button), "btnEdit") as Button;
            var updBtn = FindControlByPossibleNames(typeof(Button), "btnUpdate") as Button;
            var delBtn = FindControlByPossibleNames(typeof(Button), "btnhapus") as Button;

            if (addBtn != null) addBtn.Enabled = true;
            if (editBtn != null) editBtn.Enabled = false;
            if (updBtn != null) updBtn.Enabled = false;
            if (delBtn != null) delBtn.Enabled = false;
        }

        private string GetNextKodePreview()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(kode_guru, 3, 10) AS INT)), 0) FROM dbo.guru";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int maxNum = Convert.ToInt32(cmd.ExecuteScalar());
                        return "GR" + (maxNum + 1).ToString("D3");
                    }
                }
            }
            catch
            {
                return "GR001";
            }
        }

        private void LoadGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"SELECT kode_guru, nama, role, status, created_at FROM dbo.guru ORDER BY created_at DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }
                }

                foreach (DataRow r in dt.Rows)
                    for (int c = 0; c < dt.Columns.Count; c++)
                        if (r.IsNull(c)) r[c] = "";

                bs.DataSource = dt;
                var dgv = FindControlByPossibleNames(typeof(DataGridView), "dataGridView1") as DataGridView;
                if (dgv != null)
                {
                    dgv.DataSource = bs;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv.RowTemplate.Height = 26;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load guru: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = sender as DataGridView;
                if (dgv == null || e.RowIndex < 0) return;
                var row = dgv.Rows[e.RowIndex];

                selectedKode = GetCellStringSafe(row, "kode_guru");
                SetTextToControlIfFound("txtKodeGuru", selectedKode);

                SetTextToControlIfFound("txtNama", GetCellStringSafe(row, "nama"));
                SetTextToControlIfFound("txtPassword", ""); // kosongkan password textbox
                var roleVal = GetCellStringSafe(row, "role");
                var roleCtrl = FindRoleControl();
                if (roleCtrl is ComboBox cb)
                {
                    int idx = -1;
                    for (int i = 0; i < cb.Items.Count; i++)
                    {
                        if (cb.Items[i].ToString().Equals(roleVal, StringComparison.OrdinalIgnoreCase)) { idx = i; break; }
                    }
                    cb.SelectedIndex = idx;
                    if (idx == -1) cb.Text = roleVal;
                }
                else if (roleCtrl != null)
                {
                    roleCtrl.Text = roleVal;
                }

                // tombol state
                var addBtn = FindControlByPossibleNames(typeof(Button), "btntambah") as Button;
                var editBtn = FindControlByPossibleNames(typeof(Button), "btnEdit") as Button;
                var updBtn = FindControlByPossibleNames(typeof(Button), "btnUpdate") as Button;
                var delBtn = FindControlByPossibleNames(typeof(Button), "btnhapus") as Button;

                if (addBtn != null) addBtn.Enabled = false;
                if (editBtn != null) editBtn.Enabled = true;
                if (updBtn != null) updBtn.Enabled = true;
                if (delBtn != null) delBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal pilih baris: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellStringSafe(DataGridViewRow row, string colName)
        {
            if (row == null) return "";
            if (!row.DataGridView.Columns.Contains(colName)) return "";
            var cell = row.Cells[colName];
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value) return "";
            return cell.Value.ToString();
        }

        private void SetTextToControlIfFound(string controlName, string text)
        {
            var arr = this.Controls.Find(controlName, true);
            if (arr.Length > 0)
            {
                var c = arr[0];
                if (c is TextBox tb) tb.Text = text;
                else c.Text = text;
                return;
            }
            // fallback: try some common alternates
            var alt = this.Controls.Find(controlName.Replace("txt", "txt"), true);
            if (alt.Length > 0) alt[0].Text = text;
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            // ambil values dari kontrol dengan beberapa kemungkinan nama
            string kode = GetTextBoxText("txtKodeGuru", "txtKodeUser", "txtKode");
            if (string.IsNullOrWhiteSpace(kode))
                kode = GetNextKodePreview();

            string nama = GetTextBoxText("txtNama", "txtnotelp", "txtNamaGuru", "txtName").Trim();
            string pass = GetTextBoxText("txtPassword", "txtPass", "password").Trim();

            string role = "";
            var roleCtrl = FindRoleControl();
            if (roleCtrl is ComboBox cb) role = cb.Text.Trim();
            else if (roleCtrl != null) role = roleCtrl.Text.Trim();
            else role = GetTextBoxText("cmbRole", "cbRole", "role").Trim();

            // validasi minimal untuk tambah: nama, password, role
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(role))
            {
                // buat pesan spesifik supaya user tahu field mana yang kosong
                string missing = "";
                if (string.IsNullOrWhiteSpace(nama)) missing += "Nama, ";
                if (string.IsNullOrWhiteSpace(pass)) missing += "Password, ";
                if (string.IsNullOrWhiteSpace(role)) missing += "Role, ";
                if (missing.EndsWith(", ")) missing = missing.Substring(0, missing.Length - 2);
                MessageBox.Show($"Lengkapi field berikut: {missing}", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "INSERT INTO dbo.guru (kode_guru, nama, password, role) VALUES (@kode,@nama,@pass,@role)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", kode);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data guru berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTextBoxText(params string[] possibleNames)
        {
            foreach (var n in possibleNames)
            {
                var arr = this.Controls.Find(n, true);
                if (arr.Length == 0) continue;
                var c = arr[0];
                if (c is TextBox tb) return tb.Text;
                return c.Text;
            }
            return "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedKode))
            {
                MessageBox.Show("Pilih guru dulu dari tabel.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var updBtn = FindControlByPossibleNames(typeof(Button), "btnUpdate") as Button;
            var addBtn = FindControlByPossibleNames(typeof(Button), "btntambah") as Button;
            if (updBtn != null) updBtn.Enabled = true;
            if (addBtn != null) addBtn.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string kode = GetTextBoxText("txtKodeGuru", "txtKodeUser", "txtKode");
            string nama = GetTextBoxText("txtNama", "txtnotelp", "txtNamaGuru").Trim();
            string pass = GetTextBoxText("txtPassword", "txtPass", "password").Trim();

            string role = "";
            var roleCtrl = FindRoleControl();
            if (roleCtrl is ComboBox cb) role = cb.Text.Trim();
            else if (roleCtrl != null) role = roleCtrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(kode))
            {
                MessageBox.Show("Pilih guru dulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Nama dan Role wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql;
                    if (!string.IsNullOrWhiteSpace(pass))
                        sql = "UPDATE dbo.guru SET nama=@nama, password=@pass, role=@role WHERE kode_guru=@kode";
                    else
                        sql = "UPDATE dbo.guru SET nama=@nama, role=@role WHERE kode_guru=@kode";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@kode", kode);
                        if (!string.IsNullOrWhiteSpace(pass)) cmd.Parameters.AddWithValue("@pass", pass);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows <= 0)
                        {
                            MessageBox.Show("Update gagal, kode tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Data guru berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            string kode = GetTextBoxText("txtKodeGuru", "txtKodeUser", "txtKode");
            if (string.IsNullOrWhiteSpace(kode)) { MessageBox.Show("Pilih guru dulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Yakin hapus guru ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "DELETE FROM dbo.guru WHERE kode_guru=@kode";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", kode);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows <= 0)
                        {
                            MessageBox.Show("Hapus gagal, kode tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Data guru dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearForm();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Gagal hapus: data ini sedang dipakai (constraint FK).", "Constraint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbatal_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetInitialButtonState();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            var f = new Formsiswa();
            f.Show();
            this.Hide();
        }

        private void ClearForm()
        {
            selectedKode = null;
            var kodeCtrl = FindTextControl("txtKodeGuru", "txtKodeUser", "txtKode");
            if (kodeCtrl is TextBox tb) tb.Text = GetNextKodePreview();
            SetTextToControlIfFound("txtNama", "");
            SetTextToControlIfFound("txtPassword", "");
            var roleCtrl = FindRoleControl();
            if (roleCtrl is ComboBox cb) cb.SelectedIndex = -1;
            else if (roleCtrl != null) roleCtrl.Text = "";
        }

        private void btnDataSiswa_Click(object sender, EventArgs e)
        {
            Formsiswa form = new Formsiswa();
            form.Show();
            this.Hide();
        }

        private void btnJenisPelanggaran_Click(object sender, EventArgs e)
        {
            Formjenispelanggaran form = new Formjenispelanggaran();
            form.Show();
            this.Hide();
        }

        private void btnInputPelanggaran_Click(object sender, EventArgs e)
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

        private void btnPengaturan_Click(object sender, EventArgs e)
        {
            Pengaturan form = new Pengaturan();
            form.Show();
            this.Hide();
        }

        private void btndashboard_Click_1(object sender, EventArgs e)
        {
            FormPelanggara form = new FormPelanggara();
            form.Show();
            this.Hide();
        }
    }
}
