using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace UmkmPintarKasir
{
    partial class FormMasterProduk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMasterProduk));
            this.lblHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblKode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNama = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHarga = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStok = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSatuan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIdProduk = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtKode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNama = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHarga = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtStok = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSatuan = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkAktif = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnBaru = new Guna.UI2.WinForms.Guna2Button();
            this.btnSimpan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHapus = new Guna.UI2.WinForms.Guna2Button();
            this.btnTutup = new Guna.UI2.WinForms.Guna2Button();
            this.dgvProduk = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(223, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "MASTER PRODUK";
            // 
            // lblKode
            // 
            this.lblKode.BackColor = System.Drawing.Color.Transparent;
            this.lblKode.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKode.Location = new System.Drawing.Point(20, 60);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(82, 20);
            this.lblKode.TabIndex = 1;
            this.lblKode.Text = "Kode Produk";
            // 
            // lblNama
            // 
            this.lblNama.BackColor = System.Drawing.Color.Transparent;
            this.lblNama.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.Location = new System.Drawing.Point(20, 95);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(86, 20);
            this.lblNama.TabIndex = 2;
            this.lblNama.Text = "Nama Produk";
            // 
            // lblHarga
            // 
            this.lblHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblHarga.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHarga.Location = new System.Drawing.Point(20, 130);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(65, 20);
            this.lblHarga.TabIndex = 3;
            this.lblHarga.Text = "Harga Jual";
            // 
            // lblStok
            // 
            this.lblStok.BackColor = System.Drawing.Color.Transparent;
            this.lblStok.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStok.Location = new System.Drawing.Point(20, 165);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(30, 20);
            this.lblStok.TabIndex = 4;
            this.lblStok.Text = "Stok";
            // 
            // lblSatuan
            // 
            this.lblSatuan.BackColor = System.Drawing.Color.Transparent;
            this.lblSatuan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatuan.Location = new System.Drawing.Point(20, 200);
            this.lblSatuan.Name = "lblSatuan";
            this.lblSatuan.Size = new System.Drawing.Size(45, 20);
            this.lblSatuan.TabIndex = 5;
            this.lblSatuan.Text = "Satuan";
            // 
            // lblIdProduk
            // 
            this.lblIdProduk.BackColor = System.Drawing.Color.Transparent;
            this.lblIdProduk.Location = new System.Drawing.Point(20, 230);
            this.lblIdProduk.Name = "lblIdProduk";
            this.lblIdProduk.Size = new System.Drawing.Size(0, 0);
            this.lblIdProduk.TabIndex = 17;
            this.lblIdProduk.Text = null;
            this.lblIdProduk.Visible = false;
            // 
            // txtKode
            // 
            this.txtKode.BorderRadius = 5;
            this.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKode.DefaultText = "";
            this.txtKode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKode.Location = new System.Drawing.Point(140, 55);
            this.txtKode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKode.Name = "txtKode";
            this.txtKode.PlaceholderText = "";
            this.txtKode.SelectedText = "";
            this.txtKode.Size = new System.Drawing.Size(200, 30);
            this.txtKode.TabIndex = 6;
            // 
            // txtNama
            // 
            this.txtNama.BorderRadius = 5;
            this.txtNama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNama.DefaultText = "";
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNama.Location = new System.Drawing.Point(140, 90);
            this.txtNama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNama.Name = "txtNama";
            this.txtNama.PlaceholderText = "";
            this.txtNama.SelectedText = "";
            this.txtNama.Size = new System.Drawing.Size(300, 30);
            this.txtNama.TabIndex = 7;
            // 
            // txtHarga
            // 
            this.txtHarga.BorderRadius = 5;
            this.txtHarga.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHarga.DefaultText = "";
            this.txtHarga.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHarga.Location = new System.Drawing.Point(140, 125);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.PlaceholderText = "";
            this.txtHarga.SelectedText = "";
            this.txtHarga.Size = new System.Drawing.Size(200, 30);
            this.txtHarga.TabIndex = 8;
            // 
            // txtStok
            // 
            this.txtStok.BorderRadius = 5;
            this.txtStok.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStok.DefaultText = "";
            this.txtStok.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStok.Location = new System.Drawing.Point(140, 160);
            this.txtStok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStok.Name = "txtStok";
            this.txtStok.PlaceholderText = "";
            this.txtStok.SelectedText = "";
            this.txtStok.Size = new System.Drawing.Size(100, 30);
            this.txtStok.TabIndex = 9;
            // 
            // txtSatuan
            // 
            this.txtSatuan.BorderRadius = 5;
            this.txtSatuan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSatuan.DefaultText = "";
            this.txtSatuan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSatuan.Location = new System.Drawing.Point(140, 195);
            this.txtSatuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.PlaceholderText = "";
            this.txtSatuan.SelectedText = "";
            this.txtSatuan.Size = new System.Drawing.Size(100, 30);
            this.txtSatuan.TabIndex = 10;
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Checked = true;
            this.chkAktif.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.chkAktif.CheckedState.BorderRadius = 0;
            this.chkAktif.CheckedState.BorderThickness = 0;
            this.chkAktif.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.chkAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAktif.Location = new System.Drawing.Point(260, 198);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new System.Drawing.Size(66, 27);
            this.chkAktif.TabIndex = 11;
            this.chkAktif.Text = "Aktif";
            this.chkAktif.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.chkAktif.UncheckedState.BorderRadius = 0;
            this.chkAktif.UncheckedState.BorderThickness = 0;
            this.chkAktif.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // btnBaru
            // 
            this.btnBaru.BorderRadius = 8;
            this.btnBaru.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnBaru.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnBaru.ForeColor = System.Drawing.Color.White;
            this.btnBaru.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnBaru.Location = new System.Drawing.Point(500, 136);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(90, 35);
            this.btnBaru.TabIndex = 12;
            this.btnBaru.Text = "Clear";
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click_1);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BorderRadius = 8;
            this.btnSimpan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnSimpan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnSimpan.Location = new System.Drawing.Point(500, 55);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(90, 35);
            this.btnSimpan.TabIndex = 13;
            this.btnSimpan.Text = "Simpan";
            // 
            // btnHapus
            // 
            this.btnHapus.BorderRadius = 8;
            this.btnHapus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnHapus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnHapus.Location = new System.Drawing.Point(500, 95);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(90, 35);
            this.btnHapus.TabIndex = 14;
            this.btnHapus.Text = "Hapus";
            // 
            // btnTutup
            // 
            this.btnTutup.BorderRadius = 8;
            this.btnTutup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnTutup.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnTutup.Location = new System.Drawing.Point(500, 177);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(90, 35);
            this.btnTutup.TabIndex = 15;
            this.btnTutup.Text = "Tutup";
            // 
            // dgvProduk
            // 
            this.dgvProduk.AllowUserToAddRows = false;
            this.dgvProduk.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.dgvProduk.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduk.ColumnHeadersHeight = 28;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduk.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduk.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduk.Location = new System.Drawing.Point(20, 250);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersVisible = false;
            this.dgvProduk.RowHeadersWidth = 51;
            this.dgvProduk.Size = new System.Drawing.Size(850, 250);
            this.dgvProduk.TabIndex = 16;
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
            this.dgvProduk.ThemeStyle.HeaderStyle.Height = 28;
            this.dgvProduk.ThemeStyle.ReadOnly = true;
            this.dgvProduk.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduk.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProduk.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduk.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProduk.ThemeStyle.RowsStyle.Height = 22;
            this.dgvProduk.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduk.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FormMasterProduk
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.lblStok);
            this.Controls.Add(this.lblSatuan);
            this.Controls.Add(this.lblIdProduk);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.chkAktif);
            this.Controls.Add(this.btnBaru);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.dgvProduk);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMasterProduk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Produk";
            this.Load += new System.EventHandler(this.FormMasterProduk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna2HtmlLabel lblHeader;
        private Guna2HtmlLabel lblKode;
        private Guna2HtmlLabel lblNama;
        private Guna2HtmlLabel lblHarga;
        private Guna2HtmlLabel lblStok;
        private Guna2HtmlLabel lblSatuan;
        private Guna2HtmlLabel lblIdProduk;

        private Guna2TextBox txtKode;
        private Guna2TextBox txtNama;
        private Guna2TextBox txtHarga;
        private Guna2TextBox txtStok;
        private Guna2TextBox txtSatuan;

        private Guna2CheckBox chkAktif;

        private Guna2Button btnBaru;
        private Guna2Button btnSimpan;
        private Guna2Button btnHapus;
        private Guna2Button btnTutup;

        private Guna2DataGridView dgvProduk;
    }
}
