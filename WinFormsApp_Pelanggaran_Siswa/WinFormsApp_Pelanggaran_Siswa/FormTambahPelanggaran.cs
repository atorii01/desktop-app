using LoginDatabase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    public partial class FormTambahPelanggaran : Form
    {
        private readonly Koneksi Konn = Koneksi.Instance;
        private int selectedId = -1;
        private readonly string placeholderCari = "cari data";
        private BindingSource bs = new BindingSource();

        public FormTambahPelanggaran()
        {
            InitializeComponent();

            this.Load += FormTambahPelanggaran_Load;

            // Setup txtcari
            if (ControlExists("txtcari"))
            {
                txtcari.ForeColor = Color.Gray;
                txtcari.Text = placeholderCari;
                txtcari.GotFocus += Txtcari_GotFocus;
                txtcari.LostFocus += Txtcari_LostFocus;
                txtcari.TextChanged += Txtcari_TextChanged;
            }

            // Grid
            if (ControlExists("dataGridView1"))
                dataGridView1.CellClick += dataGridView1_CellClick;

            // Tombol
            if (ControlExists("btntambah")) btntambah.Click += btntambah_Click;
            if (ControlExists("btnEdit")) btnEdit.Click += btnEdit_Click;
            if (ControlExists("btnUpdate")) btnUpdate.Click += btnUpdate_Click;
            if (ControlExists("btnhapus")) btnhapus.Click += btnhapus_Click;
            if (ControlExists("btnbatal")) btnbatal.Click += btnbatal_Click;
     //       if (ControlExists("btndashboard")) btndashboard.Click += btndashboard_Click;
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
                bs.RemoveFilter();
            }
            else
            {
                bs.Filter = $"kode_jenis LIKE '%{keyword}%' OR nama_pelanggaran LIKE '%{keyword}%' OR jenis LIKE '%{keyword}%'";
            }
        }
        #endregion

        private bool ControlExists(string name) => this.Controls.Find(name, true).Length > 0;

        private void SetControlTextIfExists(string name, string text)
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls.Length == 0) return;
            if (ctrls[0] is TextBox tb) tb.Text = text;
            else ctrls[0].Text = text;
        }

        private string GetControlText(string name)
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls.Length == 0) return "";
            if (ctrls[0] is TextBox tb) return tb.Text;
            return ctrls[0].Text;
        }

        private void FormTambahPelanggaran_Load(object sender, EventArgs e)
        {
            LoadJenisMaster();
            LoadGrid();
            SetInitialButtonState();

            if (ControlExists("cbJenis")) cbJenis.DropDownStyle = ComboBoxStyle.DropDown;

            if (ControlExists("txtKodeJenis"))
                SetControlTextIfExists("txtKodeJenis", GetNextKodePreview());
        }

        private void SetInitialButtonState()
        {
            if (ControlExists("btntambah")) btntambah.Enabled = true;
            if (ControlExists("btnEdit")) btnEdit.Enabled = false;
            if (ControlExists("btnUpdate")) btnUpdate.Enabled = false;
            if (ControlExists("btnhapus")) btnhapus.Enabled = false;
        }

        private string GetNextKodePreview()
        {
            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT ISNULL(MAX(id_jenis), 0) FROM dbo.jenis_pelanggaran";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int maxId = Convert.ToInt32(cmd.ExecuteScalar());
                        return "J" + (maxId + 1).ToString("D3");
                    }
                }
            }
            catch
            {
                return "J001";
            }
        }

        private void LoadJenisMaster()
        {
            try
            {
                if (!ControlExists("cbJenis")) return;

                DataTable dt = new DataTable();
                dt.Columns.Add("jenis", typeof(string));
                string[] defaults = { "Ringan", "Sedang", "Berat", "Sangat Berat" };
                foreach (var j in defaults) dt.Rows.Add(j);

                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT jenis FROM dbo.jenis_pelanggaran WHERE jenis IS NOT NULL AND jenis<>''";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dbJenis = new DataTable();
                        da.Fill(dbJenis);
                        foreach (DataRow row in dbJenis.Rows)
                        {
                            string val = row["jenis"]?.ToString() ?? "";
                            if (!string.IsNullOrWhiteSpace(val) &&
                                !dt.AsEnumerable().Any(r => r["jenis"].ToString().Equals(val, StringComparison.OrdinalIgnoreCase)))
                            {
                                dt.Rows.Add(val);
                            }
                        }
                    }
                }

                cbJenis.DisplayMember = "jenis";
                cbJenis.ValueMember = "jenis";
                cbJenis.DataSource = dt;
                cbJenis.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load daftar jenis: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string sql = @"
                        SELECT id_jenis, kode_jenis, nama_pelanggaran, jenis, ISNULL(point,0) AS point, created_at
                        FROM dbo.jenis_pelanggaran
                        ORDER BY id_jenis DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }
                }

                foreach (DataRow r in dt.Rows)
                    for (int c = 0; c < dt.Columns.Count; c++)
                        if (r.IsNull(c)) r[c] = "";

                if (!ControlExists("dataGridView1")) return;

                bs.DataSource = dt;
                dataGridView1.DataSource = bs;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.RowTemplate.Height = 28;

                // friendly headers
                if (dataGridView1.Columns.Contains("id_jenis")) dataGridView1.Columns["id_jenis"].HeaderText = "ID";
                if (dataGridView1.Columns.Contains("kode_jenis")) dataGridView1.Columns["kode_jenis"].HeaderText = "Kode";
                if (dataGridView1.Columns.Contains("nama_pelanggaran")) dataGridView1.Columns["nama_pelanggaran"].HeaderText = "Nama Peringatan";
                if (dataGridView1.Columns.Contains("jenis")) dataGridView1.Columns["jenis"].HeaderText = "Jenis";
                if (dataGridView1.Columns.Contains("point")) dataGridView1.Columns["point"].HeaderText = "Point";
                if (dataGridView1.Columns.Contains("created_at")) dataGridView1.Columns["created_at"].HeaderText = "Dibuat";

                // style sel kosong
                foreach (DataGridViewRow row in dataGridView1.Rows)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load master jenis: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                var row = dataGridView1.Rows[e.RowIndex];

                string idStr = GetCellStringSafe(row, "id_jenis");
                string kode = GetCellStringSafe(row, "kode_jenis");
                string nama = GetCellStringSafe(row, "nama_pelanggaran");
                string jenis = GetCellStringSafe(row, "jenis");
                string pointStr = GetCellStringSafe(row, "point");

                selectedId = int.TryParse(idStr, out int idVal) ? idVal : -1;

                SetControlTextIfExists("txtid_jenis", selectedId > 0 ? selectedId.ToString() : "");
                SetControlTextIfExists("txtKodeJenis", kode);
                SetControlTextIfExists("txtnotelp", nama);
                SetControlTextIfExists("txtnilaiPoint", pointStr);

                if (ControlExists("cbJenis"))
                {
                    bool found = false;
                    for (int i = 0; i < cbJenis.Items.Count; i++)
                    {
                        var item = cbJenis.Items[i];
                        string itemText = item is DataRowView drv ? drv["jenis"].ToString() : item.ToString();
                        if (itemText.Equals(jenis, StringComparison.OrdinalIgnoreCase))
                        {
                            cbJenis.SelectedIndex = i;
                            found = true;
                            break;
                        }
                    }
                    if (!found) cbJenis.Text = jenis;
                }

                if (ControlExists("btntambah")) btntambah.Enabled = false;
                if (ControlExists("btnEdit")) btnEdit.Enabled = true;
                if (ControlExists("btnUpdate")) btnUpdate.Enabled = true;
                if (ControlExists("btnhapus")) btnhapus.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal pilih baris: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellStringSafe(DataGridViewRow row, string colName)
        {
            if (row == null || !dataGridView1.Columns.Contains(colName)) return "";
            var cell = row.Cells[colName];
            return (cell?.Value == null || cell.Value == DBNull.Value) ? "" : cell.Value.ToString();
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            string nama = GetControlText("txtnotelp").Trim();
            string jenis = ControlExists("cbJenis") ? cbJenis.Text.Trim() : "";
            int.TryParse(GetControlText("txtnilaiPoint").Trim(), out int point);

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Isi Nama Peringatan (txtnotelp).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            string insertSql = @"
                                INSERT INTO dbo.jenis_pelanggaran (kode_jenis, nama_pelanggaran, jenis, point, created_at)
                                VALUES (@kode, @nama, @jenis, @point, GETDATE());
                                SELECT SCOPE_IDENTITY();";
                            int newId;
                            using (SqlCommand cmd = new SqlCommand(insertSql, conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@kode", "");
                                cmd.Parameters.AddWithValue("@nama", nama);
                                cmd.Parameters.AddWithValue("@jenis", string.IsNullOrEmpty(jenis) ? (object)DBNull.Value : jenis);
                                cmd.Parameters.AddWithValue("@point", point);
                                object obj = cmd.ExecuteScalar();
                                newId = Convert.ToInt32(Convert.ToDecimal(obj));
                            }

                            string generatedKode = "J" + newId.ToString("D3");
                            using (SqlCommand cmd2 = new SqlCommand("UPDATE dbo.jenis_pelanggaran SET kode_jenis=@kode WHERE id_jenis=@id", conn, tr))
                            {
                                cmd2.Parameters.AddWithValue("@kode", generatedKode);
                                cmd2.Parameters.AddWithValue("@id", newId);
                                cmd2.ExecuteNonQuery();
                            }

                            tr.Commit();
                            MessageBox.Show($"Jenis pelanggaran ditambahkan. ID={newId}, Kode={generatedKode}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadJenisMaster();
                            LoadGrid();
                            ClearForm();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah jenis: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId <= 0) { MessageBox.Show("Pilih baris dulu."); return; }
            if (ControlExists("btnUpdate")) btnUpdate.Enabled = true;
            if (ControlExists("btntambah")) btntambah.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId <= 0) { MessageBox.Show("Pilih baris dulu."); return; }

            string nama = GetControlText("txtnotelp").Trim();
            string jenis = ControlExists("cbJenis") ? cbJenis.Text.Trim() : "";
            int.TryParse(GetControlText("txtnilaiPoint").Trim(), out int point);

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama tidak boleh kosong.");
                return;
            }

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    string sql = "UPDATE dbo.jenis_pelanggaran SET nama_pelanggaran=@nama, jenis=@jenis, point=@point WHERE id_jenis=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@jenis", string.IsNullOrEmpty(jenis) ? (object)DBNull.Value : jenis);
                        cmd.Parameters.AddWithValue("@point", point);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Data berhasil diupdate." : "Update gagal (id tidak ditemukan).");
                    }
                }

                LoadJenisMaster();
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
            if (selectedId <= 0) { MessageBox.Show("Pilih baris dulu."); return; }
            if (MessageBox.Show("Yakin hapus?", "Konfirmasi", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Konn.GetConn())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.jenis_pelanggaran WHERE id_jenis=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data dihapus.");
                LoadJenisMaster();
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
            var f = new FormPelanggara();
            f.Show();
            this.Hide();
        }

        private void ClearForm()
        {
            SetControlTextIfExists("txtid_jenis", "");
            if (ControlExists("txtKodeJenis"))
                SetControlTextIfExists("txtKodeJenis", GetNextKodePreview());
            SetControlTextIfExists("txtnotelp", "");
            SetControlTextIfExists("txtnilaiPoint", "");
            if (ControlExists("cbJenis")) cbJenis.SelectedIndex = -1;
            selectedId = -1;
            SetInitialButtonState();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
