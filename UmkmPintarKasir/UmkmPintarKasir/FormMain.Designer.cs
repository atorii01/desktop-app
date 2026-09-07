using Guna.UI2.WinForms;

namespace UmkmPintarKasir
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTanggal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnProfil = new Guna.UI2.WinForms.Guna2Button();
            this.btnMasterProduk = new Guna.UI2.WinForms.Guna2Button();
            this.btnKasir = new Guna.UI2.WinForms.Guna2Button();
            this.btnLaporan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvStok = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStok)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Controls.Add(this.lblTanggal);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1300, 110);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(379, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "APLIKASI UMKM PINTAR";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubTitle.Location = new System.Drawing.Point(14, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(3, 2);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = null;
            // 
            // lblTanggal
            // 
            this.lblTanggal.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTanggal.ForeColor = System.Drawing.Color.White;
            this.lblTanggal.Location = new System.Drawing.Point(900, 40);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(80, 25);
            this.lblTanggal.TabIndex = 2;
            this.lblTanggal.Text = "Tanggal: -";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnProfil);
            this.panelMenu.Controls.Add(this.btnMasterProduk);
            this.panelMenu.Controls.Add(this.btnKasir);
            this.panelMenu.Controls.Add(this.btnLaporan);
            this.panelMenu.Controls.Add(this.dgvStok);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.FillColor = System.Drawing.Color.WhiteSmoke;
            this.panelMenu.Location = new System.Drawing.Point(0, 110);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1300, 640);
            this.panelMenu.TabIndex = 0;
            // 
            // btnProfil
            // 
            this.btnProfil.BorderRadius = 10;
            this.btnProfil.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnProfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfil.ForeColor = System.Drawing.Color.White;
            this.btnProfil.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnProfil.Location = new System.Drawing.Point(80, 80);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(220, 90);
            this.btnProfil.TabIndex = 0;
            this.btnProfil.Text = "Profil UMKM";
            // 
            // btnMasterProduk
            // 
            this.btnMasterProduk.BorderRadius = 10;
            this.btnMasterProduk.FillColor = this.btnProfil.FillColor;
            this.btnMasterProduk.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnMasterProduk.ForeColor = System.Drawing.Color.White;
            this.btnMasterProduk.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnMasterProduk.Location = new System.Drawing.Point(360, 80);
            this.btnMasterProduk.Name = "btnMasterProduk";
            this.btnMasterProduk.Size = new System.Drawing.Size(220, 90);
            this.btnMasterProduk.TabIndex = 1;
            this.btnMasterProduk.Text = "Master Produk";
            // 
            // btnKasir
            // 
            this.btnKasir.BorderRadius = 10;
            this.btnKasir.FillColor = this.btnProfil.FillColor;
            this.btnKasir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnKasir.ForeColor = System.Drawing.Color.White;
            this.btnKasir.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnKasir.Location = new System.Drawing.Point(80, 210);
            this.btnKasir.Name = "btnKasir";
            this.btnKasir.Size = new System.Drawing.Size(220, 90);
            this.btnKasir.TabIndex = 2;
            this.btnKasir.Text = "Kasir";
            // 
            // btnLaporan
            // 
            this.btnLaporan.BorderRadius = 10;
            this.btnLaporan.FillColor = this.btnProfil.FillColor;
            this.btnLaporan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnLaporan.ForeColor = System.Drawing.Color.White;
            this.btnLaporan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnLaporan.Location = new System.Drawing.Point(360, 210);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(220, 90);
            this.btnLaporan.TabIndex = 3;
            this.btnLaporan.Text = "Laporan Omzet";
            // 
            // dgvStok
            // 
            this.dgvStok.AllowUserToAddRows = false;
            this.dgvStok.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvStok.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStok.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStok.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStok.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStok.Location = new System.Drawing.Point(660, 40);
            this.dgvStok.Name = "dgvStok";
            this.dgvStok.ReadOnly = true;
            this.dgvStok.RowHeadersVisible = false;
            this.dgvStok.RowHeadersWidth = 51;
            this.dgvStok.Size = new System.Drawing.Size(600, 570);
            this.dgvStok.TabIndex = 4;
            this.dgvStok.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvStok.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStok.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStok.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStok.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStok.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStok.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStok.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvStok.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStok.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvStok.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStok.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStok.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvStok.ThemeStyle.ReadOnly = true;
            this.dgvStok.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStok.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStok.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvStok.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStok.ThemeStyle.RowsStyle.Height = 22;
            this.dgvStok.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStok.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(1300, 750);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UMKM PINTAR - Dashboard";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel panelHeader;
        private Guna2HtmlLabel lblTitle;
        private Guna2HtmlLabel lblTanggal;

        private Guna2Panel panelMenu;
        private Guna2Button btnProfil;
        private Guna2Button btnMasterProduk;
        private Guna2Button btnKasir;
        private Guna2Button btnLaporan;

        private Guna2DataGridView dgvStok;
        private Guna2HtmlLabel lblSubTitle;
    }
}
