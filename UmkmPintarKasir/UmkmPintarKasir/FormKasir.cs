using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using UmkmPintarKasir.Data;

namespace UmkmPintarKasir
{
    public partial class FormKasir : Form
    {
        // ================= MODEL =================
        private class DetailItem
        {
            public int IdProduk { get; set; }
            public string KodeProduk { get; set; }
            public string NamaProduk { get; set; }
            public int Qty { get; set; }
            public string Satuan { get; set; }
            public decimal HargaSatuan { get; set; }
            public decimal Subtotal => Qty * HargaSatuan;
        }

        private List<DetailItem> _listDetail = new List<DetailItem>();
        private decimal _tarifPph = 0.005m;

        // ================= STRUK =================
        private PrintDocument _printDocument;
        private string _strukNoNota;
        private DateTime _strukTanggal;
        private decimal _strukTotalBersih;
        private decimal _strukBayar;
        private decimal _strukKembalian;
        private List<DetailItem> _strukDetail = new List<DetailItem>();

        public FormKasir()
        {
            InitializeComponent();

            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;

            Load += FormKasir_Load;
            btnTambah.Click += BtnTambah_Click;
            txtKode.KeyDown += TxtKode_KeyDown;
            dgvProduk.CellClick += DgvProduk_CellClick;
            txtBayar.TextChanged += TxtBayar_TextChanged;

            dgvDetail.CellFormatting += Grid_CellFormatting;
            dgvProduk.CellFormatting += Grid_CellFormatting;
        }

        // ================= HELPER =================
        private string Rp(decimal v)
        {
            return "Rp " + v.ToString("N0");
        }

        private decimal ParseRp(string t)
        {
            if (string.IsNullOrWhiteSpace(t)) return 0;
            return decimal.Parse(
                t.Replace("Rp", "")
                 .Replace(".", "")
                 .Replace(",", "")
                 .Trim()
            );
        }

        // ================= LOAD =================
        private void FormKasir_Load(object sender, EventArgs e)
        {
            cmbMetode.SelectedIndex = 0;
            lblTanggal.Text = "Tanggal: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            LoadProfilUmkm();
            GenerateNoNota();
            SetupGridDetail();
            LoadGridProduk();
            RefreshGridDetail();
            HitungTotal();
        }

        // ================= PROFIL =================
        private void LoadProfilUmkm()
        {
            var dt = DbConnectionHelper.ExecuteQuery(
                "SELECT nama_toko, tarif_pph FROM umkm_profil LIMIT 1");

            lblNamaToko.Text = dt.Rows.Count > 0
                ? dt.Rows[0]["nama_toko"].ToString()
                : "TOKO";

            _tarifPph = dt.Rows.Count > 0
                ? Convert.ToDecimal(dt.Rows[0]["tarif_pph"])
                : 0.005m;
        }

        // ================= NOTA =================
        private void GenerateNoNota()
        {
            int count = Convert.ToInt32(
                DbConnectionHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM penjualan_header WHERE tgl_transaksi::date = CURRENT_DATE"));

            lblNoNota.Text = "Nota: KSR-" +
                DateTime.Now.ToString("yyyyMMdd") + "-" +
                (count + 1).ToString("D4");
        }

        // ================= GRID DETAIL =================
        private void SetupGridDetail()
        {
            dgvDetail.AutoGenerateColumns = false;
            dgvDetail.Columns.Clear();

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Kode",
                DataPropertyName = "KodeProduk"
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Produk",
                DataPropertyName = "NamaProduk",
                Width = 200
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qty",
                DataPropertyName = "QtyDisplay"
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Harga",
                DataPropertyName = "HargaSatuan"
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal"
            });
        }

        private void RefreshGridDetail()
        {
            dgvDetail.DataSource = null;
            dgvDetail.DataSource = _listDetail.Select(x => new
            {
                x.KodeProduk,
                x.NamaProduk,
                QtyDisplay = $"{x.Qty} {x.Satuan}",
                x.HargaSatuan,
                x.Subtotal
            }).ToList();
        }

        // ================= GRID PRODUK =================
        private void LoadGridProduk()
        {
            dgvProduk.DataSource = DbConnectionHelper.ExecuteQuery(
                @"SELECT id_produk, kode_produk, nama_produk, harga_jual, stok, satuan
                  FROM produk
                  WHERE is_active = TRUE");
        }

        // ================= FORMAT GRID =================
        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            string col = dgv.Columns[e.ColumnIndex].Name;

            if (col == "harga_jual" || dgv.Columns[e.ColumnIndex].HeaderText == "Harga"
                || dgv.Columns[e.ColumnIndex].HeaderText == "Subtotal")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = Rp(val);
                    e.FormattingApplied = true;
                }
            }
        }

        // ================= TAMBAH ITEM =================
        private void BtnTambah_Click(object sender, EventArgs e)
        {
            TambahDariKode(txtKode.Text.Trim());
            txtKode.Clear();
        }

        private void TxtKode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnTambah_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }

        private void DgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            TambahKeTransaksi(
                Convert.ToInt32(dgvProduk.Rows[e.RowIndex].Cells["id_produk"].Value));
        }

        private void TambahDariKode(string kode)
        {
            if (string.IsNullOrEmpty(kode)) return;

            var dt = DbConnectionHelper.ExecuteQuery(
                "SELECT id_produk FROM produk WHERE kode_produk=@k",
                new NpgsqlParameter("@k", kode));

            if (dt.Rows.Count == 0) return;
            TambahKeTransaksi(Convert.ToInt32(dt.Rows[0]["id_produk"]));
        }

        private void TambahKeTransaksi(int id)
        {
            var dt = DbConnectionHelper.ExecuteQuery(
                @"SELECT id_produk, kode_produk, nama_produk, harga_jual, satuan
                  FROM produk WHERE id_produk=@i",
                new NpgsqlParameter("@i", id));

            if (dt.Rows.Count == 0) return;

            var row = dt.Rows[0];
            var ex = _listDetail.FirstOrDefault(x => x.IdProduk == id);

            if (ex != null)
                ex.Qty++;
            else
                _listDetail.Add(new DetailItem
                {
                    IdProduk = id,
                    KodeProduk = row["kode_produk"].ToString(),
                    NamaProduk = row["nama_produk"].ToString(),
                    Qty = 1,
                    Satuan = row["satuan"].ToString(),
                    HargaSatuan = Convert.ToDecimal(row["harga_jual"])
                });

            RefreshGridDetail();
            HitungTotal();
        }

        // ================= HITUNG =================
        private void HitungTotal()
        {
            decimal bruto = _listDetail.Sum(x => x.Subtotal);
            decimal diskon = ParseRp(txtDiskon.Text);
            decimal bersih = Math.Max(0, bruto - diskon);
            decimal pph = bersih * _tarifPph;

            txtTotalBruto.Text = Rp(bruto);
            txtTotalBersih.Text = Rp(bersih);
            txtPph.Text = Rp(pph);

            TxtBayar_TextChanged(null, null);
        }

        private void TxtBayar_TextChanged(object sender, EventArgs e)
        {
            decimal bayar = ParseRp(txtBayar.Text);
            decimal bersih = ParseRp(txtTotalBersih.Text);
            txtKembali.Text = Rp(Math.Max(0, bayar - bersih));
        }

        // ================= SIMPAN & CETAK =================
        private void btnSimpan_Click_1(object sender, EventArgs e)
        {
            if (_listDetail.Count == 0)
            {
                MessageBox.Show("Belum ada item.");
                return;
            }

            decimal bayar = ParseRp(txtBayar.Text);
            decimal bersih = ParseRp(txtTotalBersih.Text);

            if (bayar < bersih)
            {
                MessageBox.Show("Bayar kurang.");
                return;
            }

            _strukNoNota = lblNoNota.Text;
            _strukTanggal = DateTime.Now;
            _strukTotalBersih = bersih;
            _strukBayar = bayar;
            _strukKembalian = bayar - bersih;
            _strukDetail = _listDetail.ToList();

            using (PrintPreviewDialog pp = new PrintPreviewDialog())
            {
                pp.Document = _printDocument;
                pp.ShowDialog();
            }

            btnBatal_Click_1(null, null);
        }

        // ================= BATAL =================
        private void btnBatal_Click_1(object sender, EventArgs e)
        {
            _listDetail.Clear();
            RefreshGridDetail();
            txtDiskon.Text = "Rp 0";
            txtBayar.Text = "Rp 0";
            txtKembali.Text = "Rp 0";
            HitungTotal();
            GenerateNoNota();
        }

        // ================= CETAK STRUK =================
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font f = new Font("Segoe UI", 9);
            float y = 10;

            e.Graphics.DrawString(lblNamaToko.Text,
                new Font("Segoe UI", 10, FontStyle.Bold),
                Brushes.Black, 10, y);

            y += 20;
            e.Graphics.DrawString(_strukNoNota, f, Brushes.Black, 10, y);
            y += 20;

            foreach (var i in _strukDetail)
            {
                e.Graphics.DrawString(
                    $"{i.NamaProduk} {i.Qty} {i.Satuan}  {Rp(i.Subtotal)}",
                    f, Brushes.Black, 10, y);
                y += 18;
            }

            y += 10;
            e.Graphics.DrawString($"TOTAL: {Rp(_strukTotalBersih)}", f, Brushes.Black, 10, y);
        }
    }
}
