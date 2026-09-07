using System;
using System.ComponentModel;   // untuk LicenseManager
using System.Data;
using System.Windows.Forms;
using Npgsql;
using UmkmPintarKasir.Data;

namespace UmkmPintarKasir
{
    public partial class FormMasterProduk : Form
    {
        public FormMasterProduk()
        {
            InitializeComponent();

            // Event tombol
            btnBaru.Click += BtnBaru_Click;
            btnSimpan.Click += BtnSimpan_Click;
            btnHapus.Click += BtnHapus_Click;
            btnTutup.Click += BtnTutup_Click;

            // Event grid
            dgvProduk.CellClick += DgvProduk_CellClick;
        }

        // =========================================================
        //  HELPER NORMALISASI ANGKA
        // =========================================================
        private string NormalizeNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "0";

            return text
                .Replace(".", string.Empty)
                .Replace(",", string.Empty)
                .Trim();
        }

        // =========================================================
        //  LOAD FORM
        // =========================================================
        private void FormMasterProduk_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            ClearForm();
            LoadData();
        }

        // =========================================================
        //  LOAD DATA PRODUK
        // =========================================================
        private void LoadData()
        {
            try
            {
                string sql =
                    "SELECT id_produk, kode_produk, nama_produk, harga_jual, stok, satuan, is_active " +
                    "FROM produk ORDER BY nama_produk";

                DataTable dt = DbConnectionHelper.ExecuteQuery(sql);

                dgvProduk.DataSource = dt;

                if (dgvProduk.Columns.Contains("harga_jual"))
                {
                    dgvProduk.Columns["harga_jual"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data produk:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        //  CLEAR FORM
        // =========================================================
        private void ClearForm()
        {
            lblIdProduk.Text = string.Empty;
            txtKode.Text = string.Empty;
            txtNama.Text = string.Empty;
            txtHarga.Text = string.Empty;
            txtStok.Text = string.Empty;
            txtSatuan.Text = string.Empty;
            chkAktif.Checked = true;
            txtKode.Focus();
        }

        // =========================================================
        //  EVENT BUTTON
        // =========================================================
        private void BtnBaru_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKode.Text) ||
                string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Kode dan Nama wajib diisi.");
                return;
            }

            if (!decimal.TryParse(NormalizeNumber(txtHarga.Text), out decimal harga) ||
                !int.TryParse(NormalizeNumber(txtStok.Text), out int stok))
            {
                MessageBox.Show("Harga atau stok tidak valid.");
                return;
            }

            bool isBaru =
                string.IsNullOrWhiteSpace(lblIdProduk.Text) ||
                lblIdProduk.Text == "ID";

            if (isBaru)
            {
                SimpanBaru(harga, stok);
            }
            else
            {
                UpdateProduk(harga, stok);
            }
        }

        private void SimpanBaru(decimal harga, int stok)
        {
            try
            {
                string sqlInsert = @"
                    INSERT INTO produk
                        (kode_produk, nama_produk, harga_jual, stok, satuan, is_active)
                    VALUES
                        (@kode, @nama, @harga, @stok, @satuan, @aktif);
                ";

                NpgsqlParameter[] p = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@kode", txtKode.Text.Trim()),
                    new NpgsqlParameter("@nama", txtNama.Text.Trim()),
                    new NpgsqlParameter("@harga", harga),
                    new NpgsqlParameter("@stok", stok),
                    new NpgsqlParameter("@satuan", txtSatuan.Text.Trim()),
                    new NpgsqlParameter("@aktif", chkAktif.Checked)
                };

                int rows = DbConnectionHelper.ExecuteNonQuery(sqlInsert, p);

                if (rows > 0)
                {
                    MessageBox.Show("Data produk baru tersimpan.");
                    LoadData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang tersimpan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menyimpan produk baru:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateProduk(decimal harga, int stok)
        {
            if (string.IsNullOrEmpty(lblIdProduk.Text))
            {
                MessageBox.Show("ID produk kosong. Pilih data dari tabel terlebih dahulu.");
                return;
            }

            if (!int.TryParse(lblIdProduk.Text, out int idProduk))
            {
                MessageBox.Show("ID produk tidak valid.");
                return;
            }

            try
            {
                string sqlUpdate = @"
                    UPDATE produk SET
                        kode_produk = @kode,
                        nama_produk = @nama,
                        harga_jual = @harga,
                        stok = @stok,
                        satuan = @satuan,
                        is_active = @aktif,
                        updated_at = NOW()
                    WHERE id_produk = @id;
                ";

                NpgsqlParameter[] p = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@kode", txtKode.Text.Trim()),
                    new NpgsqlParameter("@nama", txtNama.Text.Trim()),
                    new NpgsqlParameter("@harga", harga),
                    new NpgsqlParameter("@stok", stok),
                    new NpgsqlParameter("@satuan", txtSatuan.Text.Trim()),
                    new NpgsqlParameter("@aktif", chkAktif.Checked),
                    new NpgsqlParameter("@id", idProduk)
                };

                int rows = DbConnectionHelper.ExecuteNonQuery(sqlUpdate, p);

                if (rows > 0)
                {
                    MessageBox.Show("Perubahan data produk tersimpan.");
                    LoadData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang ter-update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal meng-update produk:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIdProduk.Text))
            {
                MessageBox.Show("Pilih produk terlebih dahulu.");
                return;
            }

            if (!int.TryParse(lblIdProduk.Text, out int idProduk))
            {
                MessageBox.Show("ID produk tidak valid.");
                return;
            }

            // Konfirmasi ke user
            if (MessageBox.Show(
                    "Produk ini akan dihapus dari master.\n" +
                    "Semua detail penjualan yang memakai produk ini juga akan dihapus.\n\n" +
                    "Lanjutkan hapus?",
                    "Konfirmasi Hapus Produk",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                using (var conn = DbConnectionHelper.GetConnection())
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        // 1. Hapus semua detail penjualan yang refer ke produk ini
                        string sqlDeleteDetail = @"
                    DELETE FROM penjualan_detail
                    WHERE id_produk = @id;
                ";

                        using (var cmdDetail = new NpgsqlCommand(sqlDeleteDetail, conn, trans))
                        {
                            cmdDetail.Parameters.AddWithValue("@id", idProduk);
                            cmdDetail.ExecuteNonQuery();
                        }

                        // 2. Hapus produk di master
                        string sqlDeleteProduk = @"
                    DELETE FROM produk
                    WHERE id_produk = @id;
                ";

                        int rowsProduk;
                        using (var cmdProduk = new NpgsqlCommand(sqlDeleteProduk, conn, trans))
                        {
                            cmdProduk.Parameters.AddWithValue("@id", idProduk);
                            rowsProduk = cmdProduk.ExecuteNonQuery();
                        }

                        if (rowsProduk == 0)
                        {
                            trans.Rollback();
                            MessageBox.Show("Produk tidak ditemukan / tidak terhapus.");
                            return;
                        }

                        // 3. Commit transaksi
                        trans.Commit();
                    }
                }

                MessageBox.Show("Produk dan detail penjualan terkait berhasil dihapus.");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghapus produk:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void BtnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================================
        //  EVENT GRID: KLIK BARIS PRODUK
        // =========================================================
        private void DgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProduk.CurrentRow == null) return;

            try
            {
                DataGridViewRow r = dgvProduk.Rows[e.RowIndex];

                lblIdProduk.Text = Convert.ToString(r.Cells["id_produk"].Value);
                txtKode.Text = Convert.ToString(r.Cells["kode_produk"].Value);
                txtNama.Text = Convert.ToString(r.Cells["nama_produk"].Value);
                txtHarga.Text = Convert.ToString(r.Cells["harga_jual"].Value);
                txtStok.Text = Convert.ToString(r.Cells["stok"].Value);
                txtSatuan.Text = Convert.ToString(r.Cells["satuan"].Value);

                bool aktif = true;
                bool.TryParse(Convert.ToString(r.Cells["is_active"].Value), out aktif);
                chkAktif.Checked = aktif;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal membaca data baris:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBaru_Click_1(object sender, EventArgs e)
        {

        }
    }
}
