using Guna.UI2.WinForms;

namespace UmkmPintarKasir
{
    partial class FormKasir
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKasir));
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNamaToko = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTanggal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNoNota = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblKode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtKode = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTambah = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvProduk = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnTambahGrid = new Guna.UI2.WinForms.Guna2Button();
            this.panelRingkasan = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalBruto = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTotalBruto = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiskon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtDiskon = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTotalBersih = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTotalBersih = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPph = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPph = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblInfoPajak = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelBayar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMetode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbMetode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblBayar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtBayar = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblKembalian = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtKembali = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSimpan = new Guna.UI2.WinForms.Guna2Button();
            this.btnBatal = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.panelRingkasan.SuspendLayout();
            this.panelBayar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblNamaToko);
            this.panelHeader.Controls.Add(this.lblTanggal);
            this.panelHeader.Controls.Add(this.lblNoNota);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1575, 90);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(379, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "APLIKASI UMKM PINTAR";
            // 
            // lblNamaToko
            // 
            this.lblNamaToko.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaToko.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNamaToko.Location = new System.Drawing.Point(20, 55);
            this.lblNamaToko.Name = "lblNamaToko";
            this.lblNamaToko.Size = new System.Drawing.Size(40, 18);
            this.lblNamaToko.TabIndex = 1;
            this.lblNamaToko.Text = "TOKO";
            // 
            // lblTanggal
            // 
            this.lblTanggal.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggal.ForeColor = System.Drawing.Color.White;
            this.lblTanggal.Location = new System.Drawing.Point(1000, 20);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(3, 2);
            this.lblTanggal.TabIndex = 2;
            this.lblTanggal.Text = null;
            // 
            // lblNoNota
            // 
            this.lblNoNota.BackColor = System.Drawing.Color.Transparent;
            this.lblNoNota.ForeColor = System.Drawing.Color.White;
            this.lblNoNota.Location = new System.Drawing.Point(1000, 45);
            this.lblNoNota.Name = "lblNoNota";
            this.lblNoNota.Size = new System.Drawing.Size(3, 2);
            this.lblNoNota.TabIndex = 3;
            this.lblNoNota.Text = null;
            // 
            // lblKode
            // 
            this.lblKode.BackColor = System.Drawing.Color.Transparent;
            this.lblKode.Location = new System.Drawing.Point(20, 100);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(81, 18);
            this.lblKode.TabIndex = 1;
            this.lblKode.Text = "Kode Produk";
            // 
            // txtKode
            // 
            this.txtKode.BorderRadius = 6;
            this.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKode.DefaultText = "";
            this.txtKode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKode.Location = new System.Drawing.Point(20, 125);
            this.txtKode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKode.Name = "txtKode";
            this.txtKode.PlaceholderText = "";
            this.txtKode.SelectedText = "";
            this.txtKode.Size = new System.Drawing.Size(260, 32);
            this.txtKode.TabIndex = 2;
            // 
            // btnTambah
            // 
            this.btnTambah.BorderRadius = 6;
            this.btnTambah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(290, 125);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(110, 32);
            this.btnTambah.TabIndex = 3;
            this.btnTambah.Text = "Tambah";
            // 
            // dgvDetail
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.GridColor = System.Drawing.Color.Silver;
            this.dgvDetail.Location = new System.Drawing.Point(20, 170);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.Size = new System.Drawing.Size(900, 348);
            this.dgvDetail.TabIndex = 4;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgvDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvDetail.ThemeStyle.ReadOnly = true;
            this.dgvDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetail.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvProduk
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvProduk.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProduk.ColumnHeadersHeight = 29;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduk.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProduk.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduk.Location = new System.Drawing.Point(20, 524);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersVisible = false;
            this.dgvProduk.RowHeadersWidth = 51;
            this.dgvProduk.Size = new System.Drawing.Size(900, 246);
            this.dgvProduk.TabIndex = 5;
            this.dgvProduk.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduk.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvProduk.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvProduk.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvProduk.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvProduk.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduk.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduk.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvProduk.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProduk.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduk.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProduk.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduk.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvProduk.ThemeStyle.ReadOnly = true;
            this.dgvProduk.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduk.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProduk.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduk.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProduk.ThemeStyle.RowsStyle.Height = 22;
            this.dgvProduk.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduk.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnTambahGrid
            // 
            this.btnTambahGrid.BorderRadius = 6;
            this.btnTambahGrid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTambahGrid.ForeColor = System.Drawing.Color.White;
            this.btnTambahGrid.Location = new System.Drawing.Point(940, 689);
            this.btnTambahGrid.Name = "btnTambahGrid";
            this.btnTambahGrid.Size = new System.Drawing.Size(180, 40);
            this.btnTambahGrid.TabIndex = 6;
            this.btnTambahGrid.Text = "+ Tambah Produk";

            // 
            // panelRingkasan
            // 
            this.panelRingkasan.BorderRadius = 20;
            this.panelRingkasan.Controls.Add(this.lblTotalBruto);
            this.panelRingkasan.Controls.Add(this.txtTotalBruto);
            this.panelRingkasan.Controls.Add(this.lblDiskon);
            this.panelRingkasan.Controls.Add(this.txtDiskon);
            this.panelRingkasan.Controls.Add(this.lblTotalBersih);
            this.panelRingkasan.Controls.Add(this.txtTotalBersih);
            this.panelRingkasan.Controls.Add(this.lblPph);
            this.panelRingkasan.Controls.Add(this.txtPph);
            this.panelRingkasan.Controls.Add(this.lblInfoPajak);
            this.panelRingkasan.FillColor = System.Drawing.Color.White;
            this.panelRingkasan.Location = new System.Drawing.Point(940, 170);
            this.panelRingkasan.Name = "panelRingkasan";
            this.panelRingkasan.Size = new System.Drawing.Size(454, 260);
            this.panelRingkasan.TabIndex = 7;
            // 
            // lblTotalBruto
            // 
            this.lblTotalBruto.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBruto.Location = new System.Drawing.Point(20, 24);
            this.lblTotalBruto.Name = "lblTotalBruto";
            this.lblTotalBruto.Size = new System.Drawing.Size(68, 18);
            this.lblTotalBruto.TabIndex = 0;
            this.lblTotalBruto.Text = "Total Bruto";
            // 
            // txtTotalBruto
            // 
            this.txtTotalBruto.BorderRadius = 10;
            this.txtTotalBruto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalBruto.DefaultText = "";
            this.txtTotalBruto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalBruto.Location = new System.Drawing.Point(210, 19);
            this.txtTotalBruto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalBruto.Name = "txtTotalBruto";
            this.txtTotalBruto.PlaceholderText = "";
            this.txtTotalBruto.ReadOnly = true;
            this.txtTotalBruto.SelectedText = "";
            this.txtTotalBruto.Size = new System.Drawing.Size(229, 48);
            this.txtTotalBruto.TabIndex = 1;
            // 
            // lblDiskon
            // 
            this.lblDiskon.BackColor = System.Drawing.Color.Transparent;
            this.lblDiskon.Location = new System.Drawing.Point(20, 82);
            this.lblDiskon.Name = "lblDiskon";
            this.lblDiskon.Size = new System.Drawing.Size(45, 18);
            this.lblDiskon.TabIndex = 2;
            this.lblDiskon.Text = "Diskon";
            // 
            // txtDiskon
            // 
            this.txtDiskon.BorderRadius = 10;
            this.txtDiskon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiskon.DefaultText = "";
            this.txtDiskon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiskon.Location = new System.Drawing.Point(210, 77);
            this.txtDiskon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiskon.Name = "txtDiskon";
            this.txtDiskon.PlaceholderText = "";
            this.txtDiskon.SelectedText = "";
            this.txtDiskon.Size = new System.Drawing.Size(229, 48);
            this.txtDiskon.TabIndex = 3;
            // 
            // lblTotalBersih
            // 
            this.lblTotalBersih.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBersih.Location = new System.Drawing.Point(20, 141);
            this.lblTotalBersih.Name = "lblTotalBersih";
            this.lblTotalBersih.Size = new System.Drawing.Size(75, 18);
            this.lblTotalBersih.TabIndex = 4;
            this.lblTotalBersih.Text = "Total Bersih";
            // 
            // txtTotalBersih
            // 
            this.txtTotalBersih.BorderRadius = 10;
            this.txtTotalBersih.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalBersih.DefaultText = "";
            this.txtTotalBersih.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalBersih.Location = new System.Drawing.Point(210, 136);
            this.txtTotalBersih.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalBersih.Name = "txtTotalBersih";
            this.txtTotalBersih.PlaceholderText = "";
            this.txtTotalBersih.ReadOnly = true;
            this.txtTotalBersih.SelectedText = "";
            this.txtTotalBersih.Size = new System.Drawing.Size(229, 48);
            this.txtTotalBersih.TabIndex = 5;
            // 
            // lblPph
            // 
            this.lblPph.BackColor = System.Drawing.Color.Transparent;
            this.lblPph.Location = new System.Drawing.Point(20, 201);
            this.lblPph.Name = "lblPph";
            this.lblPph.Size = new System.Drawing.Size(92, 18);
            this.lblPph.TabIndex = 6;
            this.lblPph.Text = "PPh Final 0,5%";
            // 
            // txtPph
            // 
            this.txtPph.BorderRadius = 10;
            this.txtPph.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPph.DefaultText = "";
            this.txtPph.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPph.Location = new System.Drawing.Point(210, 196);
            this.txtPph.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPph.Name = "txtPph";
            this.txtPph.PlaceholderText = "";
            this.txtPph.ReadOnly = true;
            this.txtPph.SelectedText = "";
            this.txtPph.Size = new System.Drawing.Size(229, 48);
            this.txtPph.TabIndex = 7;
            // 
            // lblInfoPajak
            // 
            // === lblInfoPajak (FIXED – JANGAN 0,0) ===
            this.lblInfoPajak.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoPajak.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInfoPajak.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoPajak.Location = new System.Drawing.Point(20, 5);
            this.lblInfoPajak.Name = "lblInfoPajak";
            this.lblInfoPajak.Size = new System.Drawing.Size(300, 15);
            this.lblInfoPajak.Text = "Estimasi PPh Final UMKM 0,5% (PP 23/2018)";

            // 
            // panelBayar
            // 
            this.panelBayar.BorderRadius = 20;
            this.panelBayar.Controls.Add(this.lblMetode);
            this.panelBayar.Controls.Add(this.cmbMetode);
            this.panelBayar.Controls.Add(this.lblBayar);
            this.panelBayar.Controls.Add(this.txtBayar);
            this.panelBayar.Controls.Add(this.lblKembalian);
            this.panelBayar.Controls.Add(this.txtKembali);
            this.panelBayar.Controls.Add(this.btnSimpan);
            this.panelBayar.Controls.Add(this.btnBatal);
            this.panelBayar.FillColor = System.Drawing.Color.White;
            this.panelBayar.Location = new System.Drawing.Point(940, 450);
            this.panelBayar.Name = "panelBayar";
            this.panelBayar.Size = new System.Drawing.Size(454, 220);
            this.panelBayar.TabIndex = 8;
            // 
            // lblMetode
            // 
            this.lblMetode.BackColor = System.Drawing.Color.Transparent;
            this.lblMetode.Location = new System.Drawing.Point(20, 20);
            this.lblMetode.Name = "lblMetode";
            this.lblMetode.Size = new System.Drawing.Size(88, 18);
            this.lblMetode.TabIndex = 0;
            this.lblMetode.Text = "Metode Bayar";
            // 
            // cmbMetode
            // 
            this.cmbMetode.BackColor = System.Drawing.Color.Transparent;
            this.cmbMetode.BorderRadius = 10;
            this.cmbMetode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMetode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetode.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMetode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMetode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMetode.ItemHeight = 30;
            this.cmbMetode.Items.AddRange(new object[] {
            "CASH",
            "QRIS",
            "TRANSFER"});
            this.cmbMetode.Location = new System.Drawing.Point(210, 15);
            this.cmbMetode.Name = "cmbMetode";
            this.cmbMetode.Size = new System.Drawing.Size(140, 36);
            this.cmbMetode.TabIndex = 1;
            // 
            // lblBayar
            // 
            this.lblBayar.BackColor = System.Drawing.Color.Transparent;
            this.lblBayar.Location = new System.Drawing.Point(20, 59);
            this.lblBayar.Name = "lblBayar";
            this.lblBayar.Size = new System.Drawing.Size(39, 18);
            this.lblBayar.TabIndex = 2;
            this.lblBayar.Text = "Bayar";
            // 
            // txtBayar
            // 
            this.txtBayar.BorderRadius = 10;
            this.txtBayar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBayar.DefaultText = "";
            this.txtBayar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBayar.Location = new System.Drawing.Point(210, 54);
            this.txtBayar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBayar.Name = "txtBayar";
            this.txtBayar.PlaceholderText = "";
            this.txtBayar.SelectedText = "";
            this.txtBayar.Size = new System.Drawing.Size(229, 48);
            this.txtBayar.TabIndex = 3;
            // 
            // lblKembalian
            // 
            this.lblKembalian.BackColor = System.Drawing.Color.Transparent;
            this.lblKembalian.Location = new System.Drawing.Point(20, 110);
            this.lblKembalian.Name = "lblKembalian";
            this.lblKembalian.Size = new System.Drawing.Size(67, 18);
            this.lblKembalian.TabIndex = 4;
            this.lblKembalian.Text = "Kembalian";
            // 
            // txtKembali
            // 
            this.txtKembali.BorderRadius = 10;
            this.txtKembali.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKembali.DefaultText = "";
            this.txtKembali.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKembali.Location = new System.Drawing.Point(210, 105);
            this.txtKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKembali.Name = "txtKembali";
            this.txtKembali.PlaceholderText = "";
            this.txtKembali.ReadOnly = true;
            this.txtKembali.SelectedText = "";
            this.txtKembali.Size = new System.Drawing.Size(229, 48);
            this.txtKembali.TabIndex = 5;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BorderRadius = 6;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(60, 160);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(150, 45);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan & Cetak";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click_1);
            // 
            // btnBatal
            // 
            this.btnBatal.BorderRadius = 6;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(216, 160);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(150, 45);
            this.btnBatal.TabIndex = 7;
            this.btnBatal.Text = "Batal";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click_1);
            // 
            // FormKasir
            // 
            this.ClientSize = new System.Drawing.Size(1575, 800);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.dgvProduk);
            this.Controls.Add(this.btnTambahGrid);
            this.Controls.Add(this.panelRingkasan);
            this.Controls.Add(this.panelBayar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKasir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UMKM PINTAR - Kasir";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.panelRingkasan.ResumeLayout(false);
            this.panelRingkasan.PerformLayout();
            this.panelBayar.ResumeLayout(false);
            this.panelBayar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna2Panel panelHeader;
        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblNamaToko;
        private Guna2HtmlLabel lblTanggal;
        private Guna2HtmlLabel lblNoNota;

        private Guna2HtmlLabel lblKode;
        private Guna2TextBox txtKode;
        private Guna2Button btnTambah;

        private Guna2DataGridView dgvDetail;

        private Guna2DataGridView dgvProduk;
        private Guna2Button btnTambahGrid;

        private Guna2Panel panelRingkasan;
        private Guna2HtmlLabel lblTotalBruto;
        private Guna2TextBox txtTotalBruto;
        private Guna2HtmlLabel lblDiskon;
        private Guna2TextBox txtDiskon;
        private Guna2HtmlLabel lblTotalBersih;
        private Guna2TextBox txtTotalBersih;
        private Guna2HtmlLabel lblPph;
        private Guna2TextBox txtPph;
        private Guna2HtmlLabel lblInfoPajak;

        private Guna2Panel panelBayar;
        private Guna2HtmlLabel lblMetode;
        private Guna2ComboBox cmbMetode;
        private Guna2HtmlLabel lblBayar;
        private Guna2TextBox txtBayar;
        private Guna2HtmlLabel lblKembalian;
        private Guna2TextBox txtKembali;
        private Guna2Button btnSimpan;
        private Guna2Button btnBatal;
    }
}
