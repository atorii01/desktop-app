using LoginDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormUserGuru : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private string selectedKode = null;
        private readonly string placeholderCari = "cari guru";
        private BindingSource bs = new BindingSource();

        // cache daftar role yang valid (diisi saat load)
        private List<string> allowedRolesCache = new List<string>();

        // alias mapping: input -> nilai yang akan disimpan ke DB (sekarang mengarah ke "guru bk")
        private readonly Dictionary<string, string> roleAliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "guru bk", "guru bk" },
            { "guru-bk", "guru bk" },
            { "guru_bk", "guru bk" },
            { "bk", "guru bk" },
            { "gurubk", "guru bk" },
            { "guru bk ", "guru bk" },
            { " GURU BK", "guru bk" }
        };

        // tooltip untuk menjelaskan kenapa kontrol disabled
        private readonly ToolTip _roleToolTip = new ToolTip() { ShowAlways = true };

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

            // jika tidak ditemukan, coba cari control type secara rekursif
            foreach (Control root in this.Controls)
            {
                var found = FindControlRecursive(root, ctrlType);
                if (found != null) return found;
            }

            // fallback: return null
            return null;
        }

        private Control FindControlRecursive(Control parent, Type ctrlType)
        {
            if (parent == null) return null;
            if (parent.GetType() == ctrlType) return parent;
            foreach (Control c in parent.Controls)
            {
                var f = FindControlRecursive(c, ctrlType);
                if (f != null) return f;
            }
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
            foreach (Control root in this.Controls)
            {
                var found = FindControlByNameContainsRecursive(root, "role", typeof(ComboBox));
                if (found != null) return found;
            }
            // terakhir, cari combo apapun
            foreach (Control root in this.Controls)
            {
                var found = FindControlRecursive(root, typeof(ComboBox));
                if (found != null) return found;
            }
            return null;
        }

        private Control FindControlByNameContainsRecursive(Control parent, string keyword, Type ctrlType)
        {
            if (parent == null) return null;
            if (parent.GetType() == ctrlType && parent.Name != null && parent.Name.ToLower().Contains(keyword.ToLower())) return parent;
            foreach (Control c in parent.Controls)
            {
                var f = FindControlByNameContainsRecursive(c, keyword, ctrlType);
                if (f != null) return f;
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
            // fallback: find first textbox recursively
            foreach (Control root in this.Controls)
            {
                var found = FindControlRecursive(root, typeof(TextBox));
                if (found != null) return found;
            }
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
            // ambil daftar role yang valid dari DB (constraint IN / quoted values) atau DISTINCT role
            allowedRolesCache = GetAllowedRolesFromDatabase();

            // jika tidak berhasil ambil dari DB, fallback ke: admin & guru bk
            if (allowedRolesCache == null || allowedRolesCache.Count == 0)
            {
                allowedRolesCache = new List<string> { "admin", "guru bk" };
            }

            // siapkan combo role jika ada
            var roleCtrl = FindRoleControl();
            if (roleCtrl is ComboBox cb)
            {
                cb.Items.Clear();
                foreach (var r in allowedRolesCache) cb.Items.Add(r);
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

            // apply role permissions: disable text & buttons if not admin
            ApplyRolePermissions();
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
                    if (idx >= 0) cb.SelectedIndex = idx;
                    else
                    {
                        // jika role di DB tidak ada di allowed list, tambahkan supaya tampil (tapi tetap dianggap non-valid saat simpan)
                        if (!cb.Items.Contains(roleVal)) cb.Items.Add(roleVal);
                        cb.Text = roleVal;
                    }
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
            // jika bukan admin, tolak (tambahan keamanan jika tombol tidak sengaja enabled)
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            if (!IsUserAdminFromMdi(mdi))
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                string missing = "";
                if (string.IsNullOrWhiteSpace(nama)) missing += "Nama, ";
                if (string.IsNullOrWhiteSpace(pass)) missing += "Password, ";
                if (string.IsNullOrWhiteSpace(role)) missing += "Role, ";
                if (missing.EndsWith(", ")) missing = missing.Substring(0, missing.Length - 2);
                MessageBox.Show($"Lengkapi field berikut: {missing}", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // normalisasi role (mapping alias -> stored value)
            string roleToStore = NormalizeRole(role);

            // validasi role terhadap daftar yang diizinkan
            if (!IsRoleAllowed(roleToStore))
            {
                string allowed = string.Join(", ", allowedRolesCache);
                MessageBox.Show($"Role '{role}' tidak diizinkan oleh aturan database.\nPilih role yang valid: {allowed}", "Role tidak valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.Parameters.AddWithValue("@role", roleToStore);
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
            // jika bukan admin, tolak
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            if (!IsUserAdminFromMdi(mdi))
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            // normalisasi role (mapping alias -> stored value)
            string roleToStore = NormalizeRole(role);

            // validasi role terhadap daftar yang diizinkan
            if (!IsRoleAllowed(roleToStore))
            {
                string allowed = string.Join(", ", allowedRolesCache);
                MessageBox.Show($"Role '{role}' tidak diizinkan oleh aturan database.\nPilih role yang valid: {allowed}", "Role tidak valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.Parameters.AddWithValue("@role", roleToStore);
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
            // jika bukan admin, tolak
            var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
            if (!IsUserAdminFromMdi(mdi))
            {
                MessageBox.Show("Akses ditolak. Anda bukan admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        // ===== helper untuk ambil daftar role dari DB =====
        private List<string> GetAllowedRolesFromDatabase()
        {
            // 1) coba ambil dari CHECK constraints definisi
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = @"
                        SELECT definition
                        FROM sys.check_constraints
                        WHERE parent_object_id = OBJECT_ID('dbo.guru')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string def = dr["definition"]?.ToString() ?? "";
                            var roles = ParseRolesFromConstraintDefinition(def);
                            if (roles != null && roles.Count > 0) return roles;
                        }
                    }

                    // 2) kalau tidak ada constraint yang mudah di-parse, ambil DISTINCT role dari tabel
                    var distinct = GetDistinctRolesFromTable(conn);
                    if (distinct != null && distinct.Count > 0) return distinct;
                }
            }
            catch
            {
                // ignore, fallback ke default di luar
            }

            return new List<string>();
        }

        private List<string> ParseRolesFromConstraintDefinition(string def)
        {
            if (string.IsNullOrWhiteSpace(def)) return new List<string>();

            // Pertama: coba cari pattern IN (...)  -> ambil items di dalam ()
            var mIn = Regex.Match(def, @"IN\s*\(\s*([^\)]+)\)", RegexOptions.IgnoreCase);
            if (mIn.Success)
            {
                string inside = mIn.Groups[1].Value;
                var matches = Regex.Matches(inside, @"'([^']+)'");
                var list = matches.Cast<Match>().Select(x => x.Groups[1].Value.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
                if (list.Count > 0) return list;
            }

            // Kedua: fallback: ambil semua token yang di-quote dalam definisi (bisa karena OR checks)
            var allQuoted = Regex.Matches(def, @"'([^']+)'");
            var arr = allQuoted.Cast<Match>().Select(x => x.Groups[1].Value.Trim()).Where(s => !string.IsNullOrEmpty(s)).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            return arr;
        }

        private List<string> GetDistinctRolesFromTable(SqlConnection conn)
        {
            try
            {
                var list = new List<string>();
                string sql = "SELECT DISTINCT role FROM dbo.guru WHERE role IS NOT NULL AND LTRIM(RTRIM(role))<>''";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(dr.GetString(0).Trim());
                    }
                }
                return list;
            }
            catch
            {
                return new List<string>();
            }
        }

        private bool IsRoleAllowed(string role)
        {
            if (string.IsNullOrWhiteSpace(role)) return false;
            return allowedRolesCache.Any(r => string.Equals(r, role, StringComparison.OrdinalIgnoreCase));
        }

        // ===== helper normalize role (alias -> allowed role) =====
        private string NormalizeRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role)) return role;
            var r = role.Trim();

            // cek alias mapping dulu (menjadi "guru bk" jika cocok)
            if (roleAliases.TryGetValue(r, out var mapped)) return mapped;

            // coba normalisasi spasi/punctuation lalu cek mapping
            var normalized = Regex.Replace(r.ToLowerInvariant(), @"[\s\-_]+", " ").Trim();
            if (roleAliases.TryGetValue(normalized, out var mapped2)) return mapped2;

            // jika role persis cocok salah satu allowedRolesCache, kembalikan versi dari cache (preserve casing)
            var found = allowedRolesCache.FirstOrDefault(x => string.Equals(x, r, StringComparison.OrdinalIgnoreCase));
            if (found != null) return found;

            // juga coba match setelah normalisasi spasi
            found = allowedRolesCache.FirstOrDefault(x => string.Equals(x, normalized, StringComparison.OrdinalIgnoreCase));
            if (found != null) return found;

            // fallback: kembalikan trimmed input (tidak diubah)
            return r;
        }

        // ===== role/permission helpers to disable controls if not admin =====
        private bool IsUserAdminFromMdi(FormMDI mdi)
        {
            if (mdi == null) return false;

            try
            {
                // cek label lblrole bila ada
                var ctrl = mdi.Controls.Find("lblrole", true).FirstOrDefault() as Label;
                if (ctrl != null)
                {
                    var roleText = ctrl.Text?.Trim() ?? "";
                    if (roleText.IndexOf("admin", StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }

                // coba baca field currentUserRole via reflection jika ada
                var field = mdi.GetType().GetField("currentUserRole", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (field != null)
                {
                    var val = field.GetValue(mdi) as string;
                    if (!string.IsNullOrEmpty(val) && val.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }
            catch
            {
                // ignore
            }

            return false;
        }

        private void ApplyRolePermissions()
        {
            try
            {
                var mdi = Application.OpenForms.OfType<FormMDI>().FirstOrDefault();
                bool isAdmin = IsUserAdminFromMdi(mdi);

                // List tombol yang berhubungan dengan mutasi data (disable jika bukan admin)
                string[] buttonNames = new[] { "btntambah", "btnEdit", "btnUpdate", "btnhapus", "btnbatal" };
                foreach (var bn in buttonNames)
                {
                    var arr = this.Controls.Find(bn, true);
                    if (arr.Length > 0 && arr[0] is Button btn)
                    {
                        btn.Enabled = isAdmin;
                        if (!isAdmin)
                        {
                            _roleToolTip.SetToolTip(btn, "Anda bukan admin");
                            btn.Cursor = Cursors.No;
                        }
                        else
                        {
                            _roleToolTip.SetToolTip(btn, null);
                            btn.Cursor = Cursors.Default;
                        }
                    }
                }

                // Textbox / input fields: disable (Enabled=false) jika bukan admin
                string[] textNames = new[] { "txtKodeGuru", "txtKodeUser", "txtKode", "txtNama", "txtNamaGuru", "txtnotelp", "txtPassword", "txtPass" };
                foreach (var tn in textNames)
                {
                    var arr = this.Controls.Find(tn, true);
                    if (arr.Length > 0)
                    {
                        var c = arr[0];
                        // untuk TextBox set Enabled false agar terlihat disabled
                        if (c is TextBox tb)
                        {
                            tb.Enabled = isAdmin;
                            if (!isAdmin) _roleToolTip.SetToolTip(tb, "Anda bukan admin");
                            else _roleToolTip.SetToolTip(tb, null);
                        }
                        else
                        {
                            c.Enabled = isAdmin;
                            if (!isAdmin) _roleToolTip.SetToolTip(c, "Anda bukan admin");
                            else _roleToolTip.SetToolTip(c, null);
                        }
                    }
                }

                // role control
                var roleCtrl = FindRoleControl();
                if (roleCtrl != null)
                {
                    roleCtrl.Enabled = isAdmin;
                    if (!isAdmin) _roleToolTip.SetToolTip(roleCtrl, "Anda bukan admin");
                    else _roleToolTip.SetToolTip(roleCtrl, null);
                }

                // Jika bukan admin, juga non-aktifkan tombol tambah pada toolbar / panel lain jika ada
                // (cari button dengan text "Tambah" sebagai fallback)
                var allButtons = this.Controls.Find("*", true).OfType<Button>();
                foreach (var btn in allButtons)
                {
                    if (btn.Text != null && btn.Text.ToLower().Contains("tambah"))
                    {
                        btn.Enabled = isAdmin;
                        if (!isAdmin) _roleToolTip.SetToolTip(btn, "Anda bukan admin");
                        else _roleToolTip.SetToolTip(btn, null);
                    }
                }
            }
            catch
            {
                // don't crash if permission application fails
            }
        }
    }
}
