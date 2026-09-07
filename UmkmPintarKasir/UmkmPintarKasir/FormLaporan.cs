using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using UmkmPintarKasir.Data;
using System.Drawing;
using System.Drawing.Printing;

namespace UmkmPintarKasir
{
    public partial class FormLaporan : Form
    {
        private PrintDocument _printDoc;
        private DataTable _printTable;
        private string _judul;
        private string _periode;

        public FormLaporan()
        {
            InitializeComponent();

            Load += FormLaporan_Load;
            btnTampilHarian.Click += BtnTampilHarian_Click;
            btnTampilBulanan.Click += BtnTampilBulanan_Click;

            btnPrintHarian.Click += BtnPrintHarian_Click;
            btnPrintBulanan.Click += BtnPrintBulanan_Click;

            _printDoc = new PrintDocument();
            _printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            dtpHarian.Value = DateTime.Today;
            dtpBulanan.Value = DateTime.Today;
        }

        // =========================
        // HARIAN
        // =========================
        private void BtnTampilHarian_Click(object sender, EventArgs e)
        {
            DateTime tgl = dtpHarian.Value.Date;

            string sql = @"
                SELECT
                    id_penjualan,
                    no_nota,
                    tgl_transaksi,
                    total_bruto,
                    diskon_total,
                    total_bersih,
                    pph_final_05,
                    metode_bayar
                FROM penjualan_header
                WHERE tgl_transaksi::date = @tgl
                ORDER BY tgl_transaksi
            ";

            DataTable dt = DbConnectionHelper.ExecuteQuery(
                sql,
                new NpgsqlParameter("@tgl", tgl));

            dgvHarian.DataSource = dt;
            FormatGrid(dgvHarian);
            HitungFooter(dt, lblTotalOmzetHarian, lblTotalPphHarian);
        }

        // =========================
        // BULANAN
        // =========================
        private void BtnTampilBulanan_Click(object sender, EventArgs e)
        {
            DateTime b = dtpBulanan.Value;
            DateTime first = new DateTime(b.Year, b.Month, 1);
            DateTime last = first.AddMonths(1).AddDays(-1);

            string sql = @"
                SELECT
                    id_penjualan,
                    no_nota,
                    tgl_transaksi,
                    total_bruto,
                    diskon_total,
                    total_bersih,
                    pph_final_05,
                    metode_bayar
                FROM penjualan_header
                WHERE tgl_transaksi::date BETWEEN @awal AND @akhir
                ORDER BY tgl_transaksi
            ";

            DataTable dt = DbConnectionHelper.ExecuteQuery(
                sql,
                new NpgsqlParameter("@awal", first),
                new NpgsqlParameter("@akhir", last));

            dgvBulanan.DataSource = dt;
            FormatGrid(dgvBulanan);
            HitungFooter(dt, lblTotalOmzetBulanan, lblTotalPphBulanan);
        }

        // =========================
        // FORMAT GRID (Rp Standard)
        // =========================
        private void FormatGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            SetRupiahFormat(dgv, "total_bruto");
            SetRupiahFormat(dgv, "diskon_total");
            SetRupiahFormat(dgv, "total_bersih");
            SetRupiahFormat(dgv, "pph_final_05");

            if (dgv.Columns.Contains("tgl_transaksi"))
                dgv.Columns["tgl_transaksi"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void SetRupiahFormat(DataGridView dgv, string col)
        {
            if (dgv.Columns.Contains(col))
            {
                dgv.Columns[col].DefaultCellStyle.Format = "N0";
                dgv.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[col].HeaderText = dgv.Columns[col].HeaderText.Replace("_", " ").ToUpper();

                dgv.CellFormatting += (s, e) =>
                {
                    if (dgv.Columns[e.ColumnIndex].Name == col && e.Value != null)
                    {
                        e.Value = "Rp " + Convert.ToDecimal(e.Value).ToString("N0");
                        e.FormattingApplied = true;
                    }
                };
            }
        }

        // =========================
        // FOOTER TOTAL
        // =========================
        private void HitungFooter(
            DataTable dt,
            Guna.UI2.WinForms.Guna2HtmlLabel lblOmzet,
            Guna.UI2.WinForms.Guna2HtmlLabel lblPph)
        {
            decimal omzet = 0;
            decimal pph = 0;

            foreach (DataRow r in dt.Rows)
            {
                if (r["total_bersih"] != DBNull.Value)
                    omzet += Convert.ToDecimal(r["total_bersih"]);

                if (r["pph_final_05"] != DBNull.Value)
                    pph += Convert.ToDecimal(r["pph_final_05"]);
            }

            lblOmzet.Text = "Total Omzet: Rp " + omzet.ToString("N0");
            lblPph.Text = "Total PPh 0,5%: Rp " + pph.ToString("N0");
        }

        // =========================
        // PRINT PDF
        // =========================
        private void BtnPrintHarian_Click(object sender, EventArgs e)
        {
            if (dgvHarian.DataSource == null) return;

            _printTable = (DataTable)dgvHarian.DataSource;
            _judul = "LAPORAN TRANSAKSI HARIAN";
            _periode = dtpHarian.Value.ToString("dd MMM yyyy");

            ShowPrintDialog();
        }

        private void BtnPrintBulanan_Click(object sender, EventArgs e)
        {
            if (dgvBulanan.DataSource == null) return;

            _printTable = (DataTable)dgvBulanan.DataSource;
            _judul = "LAPORAN TRANSAKSI BULANAN";
            _periode = dtpBulanan.Value.ToString("MMMM yyyy");

            ShowPrintDialog();
        }

        private void ShowPrintDialog()
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = _printDoc;

            if (dlg.ShowDialog() == DialogResult.OK)
                _printDoc.Print();
        }

        // =========================
        // DRAW PDF
        // =========================
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font title = new Font("Segoe UI", 14, FontStyle.Bold);
            Font header = new Font("Segoe UI", 9, FontStyle.Bold);
            Font cell = new Font("Segoe UI", 9);

            int x = 40;
            int y = 40;
            int rowH = 22;

            g.DrawString(_judul, title, Brushes.Black, x, y);
            y += 30;
            g.DrawString("Periode: " + _periode, cell, Brushes.Black, x, y);
            y += 30;

            foreach (DataColumn col in _printTable.Columns)
            {
                g.DrawString(col.ColumnName.Replace("_", " ").ToUpper(), header, Brushes.Black, x, y);
                x += 110;
            }

            y += rowH;

            foreach (DataRow row in _printTable.Rows)
            {
                x = 40;
                foreach (var val in row.ItemArray)
                {
                    if (decimal.TryParse(val?.ToString(), out decimal d))
                        g.DrawString("Rp " + d.ToString("N0"), cell, Brushes.Black, x, y);
                    else
                        g.DrawString(val?.ToString(), cell, Brushes.Black, x, y);

                    x += 110;
                }
                y += rowH;

                if (y > e.MarginBounds.Bottom - 50)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}
