namespace Tugas_2_Remake
{
    partial class Fom3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fom3));
            btnEkonomi = new Button();
            btnBisnis = new Button();
            btnEksekutif = new Button();
            panelKursi = new Panel();
            picEksekutif = new PictureBox();
            picBisnis = new PictureBox();
            picEkonomi = new PictureBox();
            label1 = new Label();
            txtNama = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtKTP = new TextBox();
            label5 = new Label();
            txtHP = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            btnSimpan = new Button();
            grpPilihkursi = new GroupBox();
            cmbKursi = new ComboBox();
            cmbBaris = new ComboBox();
            groupBox3 = new GroupBox();
            rbBalita = new RadioButton();
            rbDewasa = new RadioButton();
            groupBox4 = new GroupBox();
            dtpTanggal = new DateTimePicker();
            cmbAsal = new ComboBox();
            label6 = new Label();
            groupBox5 = new GroupBox();
            cmbTujuan = new ComboBox();
            label7 = new Label();
            btnClear = new Button();
            btnMenu = new Button();
            btnLanjut = new Button();
            panelKursi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEksekutif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBisnis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEkonomi).BeginInit();
            groupBox1.SuspendLayout();
            grpPilihkursi.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // btnEkonomi
            // 
            btnEkonomi.BackColor = Color.Transparent;
            btnEkonomi.BackgroundImageLayout = ImageLayout.None;
            btnEkonomi.FlatStyle = FlatStyle.Popup;
            btnEkonomi.Location = new Point(999, 73);
            btnEkonomi.Name = "btnEkonomi";
            btnEkonomi.Size = new Size(112, 34);
            btnEkonomi.TabIndex = 0;
            btnEkonomi.Text = "EKONOMI";
            btnEkonomi.UseVisualStyleBackColor = false;
            btnEkonomi.Click += btnEkonomi_Click;
            // 
            // btnBisnis
            // 
            btnBisnis.BackColor = Color.Transparent;
            btnBisnis.FlatStyle = FlatStyle.Popup;
            btnBisnis.Location = new Point(1110, 73);
            btnBisnis.Name = "btnBisnis";
            btnBisnis.Size = new Size(112, 34);
            btnBisnis.TabIndex = 1;
            btnBisnis.Text = "BISNIS";
            btnBisnis.UseVisualStyleBackColor = false;
            btnBisnis.Click += btnBisnis_Click;
            // 
            // btnEksekutif
            // 
            btnEksekutif.BackColor = Color.Transparent;
            btnEksekutif.FlatStyle = FlatStyle.Popup;
            btnEksekutif.Location = new Point(1221, 73);
            btnEksekutif.Name = "btnEksekutif";
            btnEksekutif.Size = new Size(112, 34);
            btnEksekutif.TabIndex = 2;
            btnEksekutif.Text = "EKSEKUTIF";
            btnEksekutif.UseVisualStyleBackColor = false;
            btnEksekutif.Click += btnEksekutif_Click;
            // 
            // panelKursi
            // 
            panelKursi.Controls.Add(picEksekutif);
            panelKursi.Controls.Add(picBisnis);
            panelKursi.Controls.Add(picEkonomi);
            panelKursi.Controls.Add(label1);
            panelKursi.Location = new Point(958, 147);
            panelKursi.Name = "panelKursi";
            panelKursi.Size = new Size(342, 836);
            panelKursi.TabIndex = 4;
            // 
            // picEksekutif
            // 
            picEksekutif.BackColor = Color.Transparent;
            picEksekutif.BackgroundImage = (Image)resources.GetObject("picEksekutif.BackgroundImage");
            picEksekutif.BackgroundImageLayout = ImageLayout.Stretch;
            picEksekutif.Location = new Point(63, 33);
            picEksekutif.Name = "picEksekutif";
            picEksekutif.Size = new Size(207, 787);
            picEksekutif.SizeMode = PictureBoxSizeMode.StretchImage;
            picEksekutif.TabIndex = 7;
            picEksekutif.TabStop = false;
            // 
            // picBisnis
            // 
            picBisnis.BackColor = Color.Transparent;
            picBisnis.BackgroundImage = (Image)resources.GetObject("picBisnis.BackgroundImage");
            picBisnis.BackgroundImageLayout = ImageLayout.Stretch;
            picBisnis.Location = new Point(63, 33);
            picBisnis.Name = "picBisnis";
            picBisnis.Size = new Size(207, 787);
            picBisnis.SizeMode = PictureBoxSizeMode.StretchImage;
            picBisnis.TabIndex = 6;
            picBisnis.TabStop = false;
            // 
            // picEkonomi
            // 
            picEkonomi.Image = (Image)resources.GetObject("picEkonomi.Image");
            picEkonomi.Location = new Point(63, 33);
            picEkonomi.Name = "picEkonomi";
            picEkonomi.Size = new Size(207, 787);
            picEkonomi.SizeMode = PictureBoxSizeMode.StretchImage;
            picEkonomi.TabIndex = 5;
            picEkonomi.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 0);
            label1.Name = "label1";
            label1.Size = new Size(258, 30);
            label1.TabIndex = 4;
            label1.Text = "Contoh Tempat Duduk :";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(159, 44);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(331, 34);
            txtNama.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 41);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 6;
            label2.Text = "Nama Lengkap :";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtKTP);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtHP);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNama);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(76, 180);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(496, 240);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data Perorang";
            // 
            // txtKTP
            // 
            txtKTP.Location = new Point(159, 182);
            txtKTP.Name = "txtKTP";
            txtKTP.Size = new Size(331, 34);
            txtKTP.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(6, 185);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 11;
            label5.Text = "NO KTP :";
            // 
            // txtHP
            // 
            txtHP.Location = new Point(159, 136);
            txtHP.Name = "txtHP";
            txtHP.Size = new Size(331, 34);
            txtHP.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(6, 139);
            label4.Name = "label4";
            label4.Size = new Size(80, 25);
            label4.TabIndex = 9;
            label4.Text = "NO HP :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(159, 90);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(331, 34);
            txtEmail.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 93);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 7;
            label3.Text = "Email :";
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.DodgerBlue;
            btnSimpan.FlatStyle = FlatStyle.Popup;
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(264, 858);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(369, 34);
            btnSimpan.TabIndex = 13;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // grpPilihkursi
            // 
            grpPilihkursi.BackColor = Color.Transparent;
            grpPilihkursi.Controls.Add(cmbKursi);
            grpPilihkursi.Controls.Add(cmbBaris);
            grpPilihkursi.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPilihkursi.ForeColor = Color.White;
            grpPilihkursi.Location = new Point(606, 180);
            grpPilihkursi.Name = "grpPilihkursi";
            grpPilihkursi.Size = new Size(244, 178);
            grpPilihkursi.TabIndex = 8;
            grpPilihkursi.TabStop = false;
            grpPilihkursi.Text = "Pilih Kursi";
            // 
            // cmbKursi
            // 
            cmbKursi.FormattingEnabled = true;
            cmbKursi.Location = new Point(6, 114);
            cmbKursi.Name = "cmbKursi";
            cmbKursi.Size = new Size(232, 36);
            cmbKursi.TabIndex = 1;
            // 
            // cmbBaris
            // 
            cmbBaris.FormattingEnabled = true;
            cmbBaris.Location = new Point(6, 48);
            cmbBaris.Name = "cmbBaris";
            cmbBaris.Size = new Size(232, 36);
            cmbBaris.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(rbBalita);
            groupBox3.Controls.Add(rbDewasa);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(606, 435);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(244, 148);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Kategori Usia";
            // 
            // rbBalita
            // 
            rbBalita.AutoSize = true;
            rbBalita.Location = new Point(6, 80);
            rbBalita.Name = "rbBalita";
            rbBalita.Size = new Size(92, 32);
            rbBalita.TabIndex = 1;
            rbBalita.TabStop = true;
            rbBalita.Text = "Balita";
            rbBalita.UseVisualStyleBackColor = true;
            // 
            // rbDewasa
            // 
            rbDewasa.AutoSize = true;
            rbDewasa.Location = new Point(6, 42);
            rbDewasa.Name = "rbDewasa";
            rbDewasa.Size = new Size(110, 32);
            rbDewasa.TabIndex = 0;
            rbDewasa.TabStop = true;
            rbDewasa.Text = "Dewasa";
            rbDewasa.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(dtpTanggal);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(76, 433);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(496, 150);
            groupBox4.TabIndex = 15;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tanggal Keberangkatan";
            // 
            // dtpTanggal
            // 
            dtpTanggal.Location = new Point(70, 64);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(362, 34);
            dtpTanggal.TabIndex = 0;
            // 
            // cmbAsal
            // 
            cmbAsal.FormattingEnabled = true;
            cmbAsal.Location = new Point(220, 63);
            cmbAsal.Name = "cmbAsal";
            cmbAsal.Size = new Size(270, 36);
            cmbAsal.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(6, 69);
            label6.Name = "label6";
            label6.Size = new Size(193, 25);
            label6.TabIndex = 13;
            label6.Text = "Asal Keberangkatan :";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.Transparent;
            groupBox5.Controls.Add(cmbTujuan);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(cmbAsal);
            groupBox5.Controls.Add(label6);
            groupBox5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(76, 626);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(496, 217);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Rute Kereta";
            // 
            // cmbTujuan
            // 
            cmbTujuan.FormattingEnabled = true;
            cmbTujuan.Location = new Point(220, 110);
            cmbTujuan.Name = "cmbTujuan";
            cmbTujuan.Size = new Size(270, 36);
            cmbTujuan.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(6, 110);
            label7.Name = "label7";
            label7.Size = new Size(215, 25);
            label7.TabIndex = 14;
            label7.Text = "Tujuan Keberangkatan :";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DodgerBlue;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(606, 689);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(244, 34);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.DodgerBlue;
            btnMenu.FlatStyle = FlatStyle.Popup;
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(606, 738);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(244, 34);
            btnMenu.TabIndex = 17;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnLanjut
            // 
            btnLanjut.BackColor = Color.DodgerBlue;
            btnLanjut.FlatStyle = FlatStyle.Popup;
            btnLanjut.ForeColor = Color.White;
            btnLanjut.Location = new Point(606, 789);
            btnLanjut.Name = "btnLanjut";
            btnLanjut.Size = new Size(244, 34);
            btnLanjut.TabIndex = 18;
            btnLanjut.Text = "Lanjut";
            btnLanjut.UseVisualStyleBackColor = false;
            btnLanjut.Click += btnLanjut_Click;
            // 
            // Fom3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1335, 1009);
            Controls.Add(btnLanjut);
            Controls.Add(btnMenu);
            Controls.Add(btnClear);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(btnSimpan);
            Controls.Add(grpPilihkursi);
            Controls.Add(groupBox1);
            Controls.Add(panelKursi);
            Controls.Add(btnEksekutif);
            Controls.Add(btnBisnis);
            Controls.Add(btnEkonomi);
            Name = "Fom3";
            Text = "Form3";
            panelKursi.ResumeLayout(false);
            panelKursi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEksekutif).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBisnis).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEkonomi).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpPilihkursi.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEkonomi;
        private Button btnBisnis;
        private Button btnEksekutif;
        private Panel panelKursi;
        private Label label1;
        private PictureBox picEkonomi;
        private PictureBox picBisnis;
        private PictureBox picEksekutif;
        private TextBox txtNama;
        private Label label2;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox txtKTP;
        private Label label5;
        private TextBox txtHP;
        private Label label4;
        private TextBox txtEmail;
        private Button btnSimpan;
        private GroupBox grpPilihkursi;
        private GroupBox groupBox3;
        private RadioButton rbBalita;
        private RadioButton rbDewasa;
        private ComboBox cmbKursi;
        private ComboBox cmbBaris;
        private GroupBox groupBox4;
        private Label label6;
        private ComboBox cmbAsal;
        private GroupBox groupBox5;
        private DateTimePicker dtpTanggal;
        private ComboBox cmbTujuan;
        private Label label7;
        private Button btnClear;
        private Button btnMenu;
        private Button btnLanjut;
    }
}