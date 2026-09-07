namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormLaporanperkelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLaporanperkelas));
            lbllaki = new Label();
            menuStrip3 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            btnPersiswa = new ToolStripMenuItem();
            btnPerkelas = new ToolStripMenuItem();
            btnSuratperingatan = new ToolStripMenuItem();
            btnPengaturan = new Button();
            menuStrip1 = new MenuStrip();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            btnDataSiswa = new ToolStripMenuItem();
            btnDataGuru = new ToolStripMenuItem();
            btnJenisPelanggaran = new ToolStripMenuItem();
            panel2 = new Panel();
            menuStrip2 = new MenuStrip();
            transaksiToolStripMenuItem = new ToolStripMenuItem();
            btnInputpelanggaran = new ToolStripMenuItem();
            btndashboard = new Button();
            panel3 = new Panel();
            groupBox5 = new GroupBox();
            label7 = new Label();
            lblperempuan = new Label();
            pictureBox4 = new PictureBox();
            groupBox6 = new GroupBox();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            label4 = new Label();
            txtcari = new TextBox();
            groupBox4 = new GroupBox();
            cbKelas = new ComboBox();
            btntotalpoint = new Button();
            btnnis = new Button();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            label13 = new Label();
            pictureBox10 = new PictureBox();
            label12 = new Label();
            pictureBox9 = new PictureBox();
            label6 = new Label();
            pictureBox5 = new PictureBox();
            btnKeluar = new Button();
            menuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip2.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // lbllaki
            // 
            lbllaki.AutoSize = true;
            lbllaki.Font = new Font("Segoe UI Semibold", 25F, FontStyle.Bold);
            lbllaki.ImeMode = ImeMode.NoControl;
            lbllaki.Location = new Point(147, 53);
            lbllaki.Name = "lbllaki";
            lbllaki.Size = new Size(138, 67);
            lbllaki.TabIndex = 4;
            lbllaki.Text = "label";
            // 
            // menuStrip3
            // 
            menuStrip3.BackColor = Color.Transparent;
            menuStrip3.Dock = DockStyle.None;
            menuStrip3.ImageScalingSize = new Size(24, 24);
            menuStrip3.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip3.Location = new Point(23, 508);
            menuStrip3.Name = "menuStrip3";
            menuStrip3.RenderMode = ToolStripRenderMode.System;
            menuStrip3.Size = new Size(172, 40);
            menuStrip3.TabIndex = 32;
            menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.Transparent;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { btnPersiswa, btnPerkelas, btnSuratperingatan });
            toolStripMenuItem1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem1.ForeColor = SystemColors.Highlight;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(164, 36);
            toolStripMenuItem1.Text = "📊 Laporan";
            // 
            // btnPersiswa
            // 
            btnPersiswa.Font = new Font("Segoe UI", 11F);
            btnPersiswa.Name = "btnPersiswa";
            btnPersiswa.Size = new Size(275, 40);
            btnPersiswa.Text = "Per Siswa";
            btnPersiswa.Click += btnPersiswa_Click;
            // 
            // btnPerkelas
            // 
            btnPerkelas.Name = "btnPerkelas";
            btnPerkelas.Size = new Size(275, 40);
            btnPerkelas.Text = "Per Kelas";
            // 
            // btnSuratperingatan
            // 
            btnSuratperingatan.Font = new Font("Segoe UI", 11F);
            btnSuratperingatan.Name = "btnSuratperingatan";
            btnSuratperingatan.Size = new Size(275, 40);
            btnSuratperingatan.Text = "Surat Peringatan";
            btnSuratperingatan.Click += btnSuratperingatan_Click;
            // 
            // btnPengaturan
            // 
            btnPengaturan.BackColor = Color.Gainsboro;
            btnPengaturan.FlatAppearance.BorderSize = 0;
            btnPengaturan.FlatStyle = FlatStyle.Flat;
            btnPengaturan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPengaturan.ImeMode = ImeMode.NoControl;
            btnPengaturan.Location = new Point(11, 657);
            btnPengaturan.Name = "btnPengaturan";
            btnPengaturan.Size = new Size(212, 45);
            btnPengaturan.TabIndex = 24;
            btnPengaturan.Text = "⚙️ Pengaturan";
            btnPengaturan.TextAlign = ContentAlignment.MiddleLeft;
            btnPengaturan.UseVisualStyleBackColor = false;
            btnPengaturan.Click += btnPengaturan_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { masterDataToolStripMenuItem });
            menuStrip1.Location = new Point(11, 169);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(225, 40);
            menuStrip1.TabIndex = 30;
            menuStrip1.Text = "menuStrip1";
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnDataSiswa, btnDataGuru, btnJenisPelanggaran });
            masterDataToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(217, 36);
            masterDataToolStripMenuItem.Text = "📰 Master Data ";
            // 
            // btnDataSiswa
            // 
            btnDataSiswa.Font = new Font("Segoe UI", 11F);
            btnDataSiswa.Name = "btnDataSiswa";
            btnDataSiswa.Size = new Size(288, 38);
            btnDataSiswa.Text = "Data Siswa";
            btnDataSiswa.Click += btnDataSiswa_Click;
            // 
            // btnDataGuru
            // 
            btnDataGuru.Font = new Font("Segoe UI", 11F);
            btnDataGuru.Name = "btnDataGuru";
            btnDataGuru.Size = new Size(288, 38);
            btnDataGuru.Text = "Data Guru";
            btnDataGuru.Click += btnDataGuru_Click;
            // 
            // btnJenisPelanggaran
            // 
            btnJenisPelanggaran.Font = new Font("Segoe UI", 11F);
            btnJenisPelanggaran.Name = "btnJenisPelanggaran";
            btnJenisPelanggaran.Size = new Size(288, 38);
            btnJenisPelanggaran.Text = "Jenis Pelanggaran";
            btnJenisPelanggaran.Click += btnJenisPelanggaran_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(menuStrip3);
            panel2.Controls.Add(btnPengaturan);
            panel2.Controls.Add(menuStrip1);
            panel2.Controls.Add(menuStrip2);
            panel2.Controls.Add(btndashboard);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 420);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 772);
            panel2.TabIndex = 29;
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = Color.Transparent;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { transaksiToolStripMenuItem });
            menuStrip2.Location = new Point(23, 339);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.RenderMode = ToolStripRenderMode.System;
            menuStrip2.Size = new Size(184, 40);
            menuStrip2.TabIndex = 31;
            menuStrip2.Text = "menuStrip2";
            // 
            // transaksiToolStripMenuItem
            // 
            transaksiToolStripMenuItem.BackColor = Color.Transparent;
            transaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnInputpelanggaran });
            transaksiToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            transaksiToolStripMenuItem.Size = new Size(176, 36);
            transaksiToolStripMenuItem.Text = "\U0001f9fe Transaksi";
            // 
            // btnInputpelanggaran
            // 
            btnInputpelanggaran.Font = new Font("Segoe UI", 11F);
            btnInputpelanggaran.Name = "btnInputpelanggaran";
            btnInputpelanggaran.Size = new Size(292, 38);
            btnInputpelanggaran.Text = "Input Pelanggaran";
            btnInputpelanggaran.Click += btnInputpelanggaran_Click;
            // 
            // btndashboard
            // 
            btndashboard.BackColor = Color.Gainsboro;
            btndashboard.FlatAppearance.BorderSize = 0;
            btndashboard.FlatStyle = FlatStyle.Flat;
            btndashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btndashboard.ImeMode = ImeMode.NoControl;
            btndashboard.Location = new Point(11, 24);
            btndashboard.Name = "btndashboard";
            btndashboard.Size = new Size(338, 53);
            btndashboard.TabIndex = 10;
            btndashboard.Text = "⬛ DashBoard";
            btndashboard.TextAlign = ContentAlignment.BottomLeft;
            btndashboard.UseVisualStyleBackColor = false;
            btndashboard.Click += btndashboard_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Location = new Point(325, 787);
            panel3.Name = "panel3";
            panel3.Size = new Size(1594, 49);
            panel3.TabIndex = 9;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(lblperempuan);
            groupBox5.Controls.Add(pictureBox4);
            groupBox5.FlatStyle = FlatStyle.Popup;
            groupBox5.Location = new Point(1003, 58);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(354, 168);
            groupBox5.TabIndex = 33;
            groupBox5.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(116, 120);
            label7.Name = "label7";
            label7.Size = new Size(229, 28);
            label7.TabIndex = 4;
            label7.Text = "Jumlah Siswa Perempuan";
            // 
            // lblperempuan
            // 
            lblperempuan.AutoSize = true;
            lblperempuan.Font = new Font("Segoe UI Semibold", 25F, FontStyle.Bold);
            lblperempuan.ImeMode = ImeMode.NoControl;
            lblperempuan.Location = new Point(147, 53);
            lblperempuan.Name = "lblperempuan";
            lblperempuan.Size = new Size(138, 67);
            lblperempuan.TabIndex = 4;
            lblperempuan.Text = "label";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.ImeMode = ImeMode.NoControl;
            pictureBox4.Location = new Point(15, 40);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(95, 90);
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(lbllaki);
            groupBox6.Controls.Add(pictureBox3);
            groupBox6.FlatStyle = FlatStyle.Popup;
            groupBox6.Location = new Point(1445, 58);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(354, 168);
            groupBox6.TabIndex = 34;
            groupBox6.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.ImeMode = ImeMode.NoControl;
            label8.Location = new Point(147, 120);
            label8.Name = "label8";
            label8.Size = new Size(203, 28);
            label8.TabIndex = 4;
            label8.Text = "Jumlah Siswa Laki-laki";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.ImeMode = ImeMode.NoControl;
            pictureBox3.Location = new Point(15, 40);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(95, 90);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(113, 313);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(537, 514);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1317, 577);
            dataGridView2.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(483, 82);
            label4.Name = "label4";
            label4.Size = new Size(505, 96);
            label4.TabIndex = 31;
            label4.Text = "Laporan/Kelas";
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(1285, 420);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 3;
            txtcari.TextChanged += txtcari_TextChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cbKelas);
            groupBox4.Controls.Add(btntotalpoint);
            groupBox4.Controls.Add(btnnis);
            groupBox4.Controls.Add(label5);
            groupBox4.Location = new Point(537, 273);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1317, 114);
            groupBox4.TabIndex = 32;
            groupBox4.TabStop = false;
            // 
            // cbKelas
            // 
            cbKelas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbKelas.FormattingEnabled = true;
            cbKelas.Items.AddRange(new object[] { "X - RPL", "X - AKL", "X - DKV", "X - BR1", "X - BR2", "X - BD", "X - MP1", "X - MP2", "X - TKJ", "X - TKR" });
            cbKelas.Location = new Point(782, 47);
            cbKelas.Name = "cbKelas";
            cbKelas.Size = new Size(498, 36);
            cbKelas.TabIndex = 26;
            cbKelas.Text = "Pilih Kelas~";
            cbKelas.SelectedIndexChanged += cbKelas_SelectedIndexChanged;
            // 
            // btntotalpoint
            // 
            btntotalpoint.Location = new Point(466, 37);
            btntotalpoint.Name = "btntotalpoint";
            btntotalpoint.Size = new Size(161, 53);
            btntotalpoint.TabIndex = 25;
            btntotalpoint.Text = "Total Point";
            btntotalpoint.UseVisualStyleBackColor = true;
            btntotalpoint.Click += btntotalpoint_Click;
            // 
            // btnnis
            // 
            btnnis.Location = new Point(303, 37);
            btnnis.Name = "btnnis";
            btnnis.Size = new Size(112, 53);
            btnnis.TabIndex = 24;
            btnnis.Text = "NIS";
            btnnis.UseVisualStyleBackColor = true;
            btnnis.Click += btnnis_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 51);
            label5.Name = "label5";
            label5.Size = new Size(237, 30);
            label5.TabIndex = 4;
            label5.Text = "Urutkan Berdasarkan  :";
            // 
            // pictureBox1
            // 
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(3, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 75);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(300, 150);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Location = new Point(0, 54);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(413, 369);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(83, 266);
            label1.Name = "label1";
            label1.Size = new Size(222, 45);
            label1.TabIndex = 1;
            label1.Text = "halo, pak jsbd";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.ImeMode = ImeMode.NoControl;
            pictureBox2.Location = new Point(54, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(296, 211);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(785, 23);
            label3.Name = "label3";
            label3.Size = new Size(405, 32);
            label3.TabIndex = 3;
            label3.Text = "Sistem Informasi Pelanggaran Siswa";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(btnKeluar);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(0, -22);
            panel1.Name = "panel1";
            panel1.Size = new Size(1919, 74);
            panel1.TabIndex = 28;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(0, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(319, 258);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F);
            label13.ImeMode = ImeMode.NoControl;
            label13.Location = new Point(953, 1118);
            label13.Name = "label13";
            label13.Size = new Size(41, 28);
            label13.TabIndex = 40;
            label13.Text = "DO";
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = SystemColors.ButtonShadow;
            pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            pictureBox10.ImeMode = ImeMode.NoControl;
            pictureBox10.Location = new Point(896, 1118);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(42, 32);
            pictureBox10.TabIndex = 39;
            pictureBox10.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.ImeMode = ImeMode.NoControl;
            label12.Location = new Point(769, 1118);
            label12.Name = "label12";
            label12.Size = new Size(103, 28);
            label12.TabIndex = 38;
            label12.Text = "≥ 50 Point";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Crimson;
            pictureBox9.BorderStyle = BorderStyle.FixedSingle;
            pictureBox9.ImeMode = ImeMode.NoControl;
            pictureBox9.Location = new Point(721, 1118);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(42, 32);
            pictureBox9.TabIndex = 37;
            pictureBox9.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(591, 1118);
            label6.Name = "label6";
            label6.Size = new Size(103, 28);
            label6.TabIndex = 36;
            label6.Text = "≥ 25 Point";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Gold;
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox5.ImeMode = ImeMode.NoControl;
            pictureBox5.Location = new Point(543, 1118);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(42, 32);
            pictureBox5.TabIndex = 35;
            pictureBox5.TabStop = false;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.LightGray;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.ImeMode = ImeMode.NoControl;
            btnKeluar.Location = new Point(1753, 31);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(153, 43);
            btnKeluar.TabIndex = 1;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = false;
            // 
            // FormLaporanperkelas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1170);
            Controls.Add(label13);
            Controls.Add(pictureBox10);
            Controls.Add(label12);
            Controls.Add(pictureBox9);
            Controls.Add(label6);
            Controls.Add(pictureBox5);
            Controls.Add(panel2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(txtcari);
            Controls.Add(dataGridView2);
            Controls.Add(label4);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Name = "FormLaporanperkelas";
            Text = "FormLaporanperkelas";
            WindowState = FormWindowState.Maximized;
            menuStrip3.ResumeLayout(false);
            menuStrip3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbllaki;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem btnPersiswa;
        private ToolStripMenuItem btnPerkelas;
        private ToolStripMenuItem btnSuratperingatan;
        private Button btnPengaturan;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem btnDataSiswa;
        private ToolStripMenuItem btnDataGuru;
        private ToolStripMenuItem btnJenisPelanggaran;
        private Panel panel2;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem transaksiToolStripMenuItem;
        private ToolStripMenuItem btnInputpelanggaran;
        private Button btndashboard;
        private Panel panel3;
        private GroupBox groupBox5;
        private Label label7;
        private Label lblperempuan;
        private PictureBox pictureBox4;
        private GroupBox groupBox6;
        private Label label8;
        private PictureBox pictureBox3;
        private Label label2;
        private DataGridView dataGridView2;
        private Label label4;
        private TextBox txtcari;
        private GroupBox groupBox4;
        private Button btntotalpoint;
        private Button btnnis;
        private Label label5;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label3;
        private Panel panel1;
        private GroupBox groupBox1;
        private Button button1;
        private ComboBox cbKelas;
        private Label label13;
        private PictureBox pictureBox10;
        private Label label12;
        private PictureBox pictureBox9;
        private Label label6;
        private PictureBox pictureBox5;
        private Button btnKeluar;
    }
}