using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace UmkmPintarKasir
{
    partial class FormLaporan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FormLaporan));

            this.lblHeader = new Guna2HtmlLabel();
            this.tabControl1 = new Guna2TabControl();

            this.tabHarian = new TabPage();
            this.lblTanggalHarian = new Guna2HtmlLabel();
            this.dtpHarian = new Guna2DateTimePicker();
            this.btnTampilHarian = new Guna2Button();
            this.dgvHarian = new Guna2DataGridView();
            this.lblTotalOmzetHarian = new Guna2HtmlLabel();

            this.tabBulanan = new TabPage();
            this.lblBulan = new Guna2HtmlLabel();
            this.dtpBulanan = new Guna2DateTimePicker();
            this.btnTampilBulanan = new Guna2Button();
            this.dgvBulanan = new Guna2DataGridView();
            this.lblTotalOmzetBulanan = new Guna2HtmlLabel();

            this.tabControl1.SuspendLayout();
            this.tabHarian.SuspendLayout();
            this.tabBulanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHarian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBulanan)).BeginInit();
            this.SuspendLayout();

            // ================= HEADER =================
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(60, 70, 123);
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Text = "LAPORAN TRANSAKSI (FLAT VIEW)";

            // ================= TAB CONTROL =================
            this.tabControl1.Alignment = TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabHarian);
            this.tabControl1.Controls.Add(this.tabBulanan);
            this.tabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl1.Location = new System.Drawing.Point(20, 60);
            this.tabControl1.Size = new System.Drawing.Size(1060, 620);
            this.tabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(60, 70, 123);

            // ================= TAB HARIAN =================
            this.tabHarian.BackColor = System.Drawing.Color.White;
            this.tabHarian.Text = "Harian";

            this.lblTanggalHarian.Location = new System.Drawing.Point(20, 20);
            this.lblTanggalHarian.Text = "Tanggal";

            this.dtpHarian.CustomFormat = "dd/MM/yyyy";
            this.dtpHarian.Format = DateTimePickerFormat.Custom;
            this.dtpHarian.Location = new System.Drawing.Point(90, 16);
            this.dtpHarian.Size = new System.Drawing.Size(140, 30);

            this.btnTampilHarian.Text = "Tampil";
            this.btnTampilHarian.Location = new System.Drawing.Point(250, 16);
            this.btnTampilHarian.Size = new System.Drawing.Size(100, 30);

            SetupGrid(this.dgvHarian);
            this.dgvHarian.Location = new System.Drawing.Point(20, 60);
            this.dgvHarian.Size = new System.Drawing.Size(980, 430);

            this.lblTotalOmzetHarian.Location = new System.Drawing.Point(20, 510);
            this.lblTotalOmzetHarian.Text = "Total Omzet: Rp 0";

            this.tabHarian.Controls.AddRange(new Control[]
            {
                lblTanggalHarian, dtpHarian, btnTampilHarian,
                dgvHarian, lblTotalOmzetHarian
            });

            this.lblTotalPphHarian = new Guna2HtmlLabel();
            this.lblTotalPphHarian.Location = new System.Drawing.Point(250, 510);
            this.lblTotalPphHarian.Text = "Total PPh 0,5%: Rp 0";

            this.tabHarian.Controls.Add(this.lblTotalPphHarian);

            this.btnPrintHarian = new Guna2Button();
            this.btnPrintHarian.Text = "Print PDF";
            this.btnPrintHarian.Size = new System.Drawing.Size(100, 30);
            this.btnPrintHarian.Location = new System.Drawing.Point(360, 16);
            this.tabHarian.Controls.Add(this.btnPrintHarian);



            // ================= TAB BULANAN =================
            this.tabBulanan.BackColor = System.Drawing.Color.White;
            this.tabBulanan.Text = "Bulanan";



            this.lblBulan.Location = new System.Drawing.Point(20, 20);
            this.lblBulan.Text = "Bulan";

            this.dtpBulanan.CustomFormat = "MM/yyyy";
            this.dtpBulanan.Format = DateTimePickerFormat.Custom;
            this.dtpBulanan.ShowUpDown = true;
            this.dtpBulanan.Location = new System.Drawing.Point(90, 16);
            this.dtpBulanan.Size = new System.Drawing.Size(120, 30);

            this.btnTampilBulanan.Text = "Tampil";
            this.btnTampilBulanan.Location = new System.Drawing.Point(230, 16);
            this.btnTampilBulanan.Size = new System.Drawing.Size(100, 30);

            SetupGrid(this.dgvBulanan);
            this.dgvBulanan.Location = new System.Drawing.Point(20, 60);
            this.dgvBulanan.Size = new System.Drawing.Size(980, 430);

            this.lblTotalOmzetBulanan.Location = new System.Drawing.Point(20, 510);
            this.lblTotalOmzetBulanan.Text = "Total Omzet: Rp 0";

            this.tabBulanan.Controls.AddRange(new Control[]
            {
                lblBulan, dtpBulanan, btnTampilBulanan,
                dgvBulanan, lblTotalOmzetBulanan
            });

            this.lblTotalPphBulanan = new Guna2HtmlLabel();
            this.lblTotalPphBulanan.Location = new System.Drawing.Point(250, 510);
            this.lblTotalPphBulanan.Text = "Total PPh 0,5%: Rp 0";

            this.tabBulanan.Controls.Add(this.lblTotalPphBulanan);

            this.btnPrintBulanan = new Guna2Button();
            this.btnPrintBulanan.Text = "Print PDF";
            this.btnPrintBulanan.Size = new System.Drawing.Size(100, 30);
            this.btnPrintBulanan.Location = new System.Drawing.Point(340, 16);
            this.tabBulanan.Controls.Add(this.btnPrintBulanan);



            // ================= FORM =================
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Laporan Transaksi";

            this.tabControl1.ResumeLayout(false);
            this.tabHarian.ResumeLayout(false);
            this.tabBulanan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHarian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBulanan)).EndInit();
            this.ResumeLayout(false);
        }

        // ================= GRID STYLE (pgAdmin look) =================
        private void SetupGrid(Guna2DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        #endregion

        private Guna2HtmlLabel lblHeader;
        private Guna2TabControl tabControl1;

        private Guna.UI2.WinForms.Guna2Button btnPrintHarian;
        private Guna.UI2.WinForms.Guna2Button btnPrintBulanan;


        private TabPage tabHarian;
        private Guna2HtmlLabel lblTanggalHarian;
        private Guna2DateTimePicker dtpHarian;
        private Guna2Button btnTampilHarian;
        private Guna2DataGridView dgvHarian;
        private Guna2HtmlLabel lblTotalOmzetHarian;

        private Guna2HtmlLabel lblTotalPphHarian;
        private Guna2HtmlLabel lblTotalPphBulanan;


        private TabPage tabBulanan;
        private Guna2HtmlLabel lblBulan;
        private Guna2DateTimePicker dtpBulanan;
        private Guna2Button btnTampilBulanan;
        private Guna2DataGridView dgvBulanan;
        private Guna2HtmlLabel lblTotalOmzetBulanan;
    }
}
