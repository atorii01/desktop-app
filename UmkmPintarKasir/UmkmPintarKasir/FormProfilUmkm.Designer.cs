using Guna.UI2.WinForms;

namespace UmkmPintarKasir
{
    partial class FormProfilUmkm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfilUmkm));
            this.lblHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNamaToko = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAlamat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNpwp = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblKontak = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTarif = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNamaToko = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAlamat = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNpwp = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtKontak = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTarif = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSimpan = new Guna.UI2.WinForms.Guna2Button();
            this.btnTutup = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.lblHeader.Location = new System.Drawing.Point(20, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(186, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "PROFIL UMKM";
            // 
            // lblNamaToko
            // 
            this.lblNamaToko.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaToko.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaToko.Location = new System.Drawing.Point(20, 70);
            this.lblNamaToko.Name = "lblNamaToko";
            this.lblNamaToko.Size = new System.Drawing.Size(72, 20);
            this.lblNamaToko.TabIndex = 1;
            this.lblNamaToko.Text = "Nama Toko";
            // 
            // lblAlamat
            // 
            this.lblAlamat.BackColor = System.Drawing.Color.Transparent;
            this.lblAlamat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlamat.Location = new System.Drawing.Point(20, 110);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(47, 20);
            this.lblAlamat.TabIndex = 2;
            this.lblAlamat.Text = "Alamat";
            // 
            // lblNpwp
            // 
            this.lblNpwp.BackColor = System.Drawing.Color.Transparent;
            this.lblNpwp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNpwp.Location = new System.Drawing.Point(20, 185);
            this.lblNpwp.Name = "lblNpwp";
            this.lblNpwp.Size = new System.Drawing.Size(108, 20);
            this.lblNpwp.TabIndex = 3;
            this.lblNpwp.Text = "NPWP (opsional)";
            // 
            // lblKontak
            // 
            this.lblKontak.BackColor = System.Drawing.Color.Transparent;
            this.lblKontak.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKontak.Location = new System.Drawing.Point(20, 225);
            this.lblKontak.Name = "lblKontak";
            this.lblKontak.Size = new System.Drawing.Size(46, 20);
            this.lblKontak.TabIndex = 4;
            this.lblKontak.Text = "Kontak";
            // 
            // lblTarif
            // 
            this.lblTarif.BackColor = System.Drawing.Color.Transparent;
            this.lblTarif.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarif.Location = new System.Drawing.Point(20, 265);
            this.lblTarif.Name = "lblTarif";
            this.lblTarif.Size = new System.Drawing.Size(178, 20);
            this.lblTarif.TabIndex = 5;
            this.lblTarif.Text = "Tarif PPh Final (0.5% = 0.005)";
            // 
            // txtNamaToko
            // 
            this.txtNamaToko.BorderRadius = 6;
            this.txtNamaToko.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaToko.DefaultText = "";
            this.txtNamaToko.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNamaToko.Location = new System.Drawing.Point(230, 65);
            this.txtNamaToko.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNamaToko.Name = "txtNamaToko";
            this.txtNamaToko.PlaceholderText = "";
            this.txtNamaToko.SelectedText = "";
            this.txtNamaToko.Size = new System.Drawing.Size(360, 32);
            this.txtNamaToko.TabIndex = 6;
            // 
            // txtAlamat
            // 
            this.txtAlamat.BorderRadius = 6;
            this.txtAlamat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAlamat.DefaultText = "";
            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAlamat.Location = new System.Drawing.Point(230, 105);
            this.txtAlamat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.PlaceholderText = "";
            this.txtAlamat.SelectedText = "";
            this.txtAlamat.Size = new System.Drawing.Size(360, 70);
            this.txtAlamat.TabIndex = 7;
            // 
            // txtNpwp
            // 
            this.txtNpwp.BorderRadius = 6;
            this.txtNpwp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNpwp.DefaultText = "";
            this.txtNpwp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNpwp.Location = new System.Drawing.Point(230, 180);
            this.txtNpwp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNpwp.Name = "txtNpwp";
            this.txtNpwp.PlaceholderText = "";
            this.txtNpwp.SelectedText = "";
            this.txtNpwp.Size = new System.Drawing.Size(360, 32);
            this.txtNpwp.TabIndex = 8;
            // 
            // txtKontak
            // 
            this.txtKontak.BorderRadius = 6;
            this.txtKontak.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKontak.DefaultText = "";
            this.txtKontak.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKontak.Location = new System.Drawing.Point(230, 220);
            this.txtKontak.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKontak.Name = "txtKontak";
            this.txtKontak.PlaceholderText = "";
            this.txtKontak.SelectedText = "";
            this.txtKontak.Size = new System.Drawing.Size(360, 32);
            this.txtKontak.TabIndex = 9;
            // 
            // txtTarif
            // 
            this.txtTarif.BorderRadius = 6;
            this.txtTarif.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTarif.DefaultText = "";
            this.txtTarif.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarif.Location = new System.Drawing.Point(231, 260);
            this.txtTarif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTarif.Name = "txtTarif";
            this.txtTarif.PlaceholderText = "0.005";
            this.txtTarif.SelectedText = "";
            this.txtTarif.Size = new System.Drawing.Size(120, 32);
            this.txtTarif.TabIndex = 10;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BorderRadius = 8;
            this.btnSimpan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnSimpan.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnSimpan.Location = new System.Drawing.Point(230, 315);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(130, 40);
            this.btnSimpan.TabIndex = 11;
            this.btnSimpan.Text = "Simpan";
            // 
            // btnTutup
            // 
            this.btnTutup.BorderRadius = 8;
            this.btnTutup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(88)))), ((int)(((byte)(156)))));
            this.btnTutup.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(108)))), ((int)(((byte)(203)))));
            this.btnTutup.Location = new System.Drawing.Point(370, 315);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(130, 40);
            this.btnTutup.TabIndex = 12;
            this.btnTutup.Text = "Tutup";
            // 
            // FormProfilUmkm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(650, 420);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblNamaToko);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.lblNpwp);
            this.Controls.Add(this.lblKontak);
            this.Controls.Add(this.lblTarif);
            this.Controls.Add(this.txtNamaToko);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNpwp);
            this.Controls.Add(this.txtKontak);
            this.Controls.Add(this.txtTarif);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnTutup);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormProfilUmkm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profil UMKM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna2HtmlLabel lblHeader;
        private Guna2HtmlLabel lblNamaToko;
        private Guna2HtmlLabel lblAlamat;
        private Guna2HtmlLabel lblNpwp;
        private Guna2HtmlLabel lblKontak;
        private Guna2HtmlLabel lblTarif;

        private Guna2TextBox txtNamaToko;
        private Guna2TextBox txtAlamat;
        private Guna2TextBox txtNpwp;
        private Guna2TextBox txtKontak;
        private Guna2TextBox txtTarif;

        private Guna2Button btnSimpan;
        private Guna2Button btnTutup;
    }
}
