namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class Formtambahsiswa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formtambahsiswa));
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            btnPengaturan = new Button();
            panel3 = new Panel();
            label4 = new Label();
            panel2 = new Panel();
            menuStrip3 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            btnpersiswa = new ToolStripMenuItem();
            btnPerkelas = new ToolStripMenuItem();
            btnSuratperingatan = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            btnDatasiswa = new ToolStripMenuItem();
            btnDataguru = new ToolStripMenuItem();
            btnJenispelanggaran = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            transaksiToolStripMenuItem = new ToolStripMenuItem();
            btnInputperlanggaran = new ToolStripMenuItem();
            btndashboard = new Button();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            txtnis = new TextBox();
            txtcari = new TextBox();
            groupBox4 = new GroupBox();
            pictureBox3 = new PictureBox();
            btnEdit = new Button();
            btnUpdate = new Button();
            btnhapus = new Button();
            btnbatal = new Button();
            btntambah = new Button();
            label9 = new Label();
            txtnotelp = new TextBox();
            cbkelas = new ComboBox();
            label8 = new Label();
            rbpr = new RadioButton();
            rblaki = new RadioButton();
            label7 = new Label();
            label6 = new Label();
            txtnama = new TextBox();
            btnKeluar = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            menuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
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
            panel1.TabIndex = 18;
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
            // pictureBox1
            // 
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(3, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 75);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Location = new Point(325, 787);
            panel3.Name = "panel3";
            panel3.Size = new Size(1594, 49);
            panel3.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(480, 60);
            label4.Name = "label4";
            label4.Size = new Size(395, 96);
            label4.TabIndex = 22;
            label4.Text = "Data Siswa";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(menuStrip3);
            panel2.Controls.Add(menuStrip1);
            panel2.Controls.Add(menuStrip2);
            panel2.Controls.Add(btndashboard);
            panel2.Controls.Add(btnPengaturan);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 420);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 772);
            panel2.TabIndex = 20;
            // 
            // menuStrip3
            // 
            menuStrip3.BackColor = Color.Transparent;
            menuStrip3.Dock = DockStyle.None;
            menuStrip3.ImageScalingSize = new Size(24, 24);
            menuStrip3.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip3.Location = new Point(23, 520);
            menuStrip3.Name = "menuStrip3";
            menuStrip3.RenderMode = ToolStripRenderMode.System;
            menuStrip3.Size = new Size(172, 40);
            menuStrip3.TabIndex = 36;
            menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.Transparent;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { btnpersiswa, btnPerkelas, btnSuratperingatan });
            toolStripMenuItem1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(164, 36);
            toolStripMenuItem1.Text = "📊 Laporan";
            // 
            // btnpersiswa
            // 
            btnpersiswa.Font = new Font("Segoe UI", 11F);
            btnpersiswa.Name = "btnpersiswa";
            btnpersiswa.Size = new Size(275, 38);
            btnpersiswa.Text = "Per Siswa";
            btnpersiswa.Click += btnpersiswa_Click;
            // 
            // btnPerkelas
            // 
            btnPerkelas.Font = new Font("Segoe UI", 11F);
            btnPerkelas.Name = "btnPerkelas";
            btnPerkelas.Size = new Size(275, 38);
            btnPerkelas.Text = "Per Kelas";
            btnPerkelas.Click += btnPerkelas_Click;
            // 
            // btnSuratperingatan
            // 
            btnSuratperingatan.Font = new Font("Segoe UI", 11F);
            btnSuratperingatan.Name = "btnSuratperingatan";
            btnSuratperingatan.Size = new Size(275, 38);
            btnSuratperingatan.Text = "Surat Peringatan";
            btnSuratperingatan.Click += btnSuratperingatan_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { masterDataToolStripMenuItem });
            menuStrip1.Location = new Point(11, 181);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(225, 40);
            menuStrip1.TabIndex = 34;
            menuStrip1.Text = "menuStrip1";
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnDatasiswa, btnDataguru, btnJenispelanggaran });
            masterDataToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            masterDataToolStripMenuItem.ForeColor = SystemColors.Highlight;
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(217, 36);
            masterDataToolStripMenuItem.Text = "📰 Master Data ";
            // 
            // btnDatasiswa
            // 
            btnDatasiswa.Name = "btnDatasiswa";
            btnDatasiswa.Size = new Size(288, 40);
            btnDatasiswa.Text = "Data Siswa";
            btnDatasiswa.Click += btnDatasiswa_Click;
            // 
            // btnDataguru
            // 
            btnDataguru.Font = new Font("Segoe UI", 11F);
            btnDataguru.Name = "btnDataguru";
            btnDataguru.Size = new Size(288, 40);
            btnDataguru.Text = "Data Guru";
            btnDataguru.Click += btnDataguru_Click;
            // 
            // btnJenispelanggaran
            // 
            btnJenispelanggaran.Font = new Font("Segoe UI", 11F);
            btnJenispelanggaran.Name = "btnJenispelanggaran";
            btnJenispelanggaran.Size = new Size(288, 40);
            btnJenispelanggaran.Text = "Jenis Pelanggaran";
            btnJenispelanggaran.Click += btnJenispelanggaran_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = Color.Transparent;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { transaksiToolStripMenuItem });
            menuStrip2.Location = new Point(23, 351);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.RenderMode = ToolStripRenderMode.System;
            menuStrip2.Size = new Size(184, 40);
            menuStrip2.TabIndex = 35;
            menuStrip2.Text = "menuStrip2";
            // 
            // transaksiToolStripMenuItem
            // 
            transaksiToolStripMenuItem.BackColor = Color.Transparent;
            transaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnInputperlanggaran });
            transaksiToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            transaksiToolStripMenuItem.Size = new Size(176, 36);
            transaksiToolStripMenuItem.Text = "\U0001f9fe Transaksi";
            // 
            // btnInputperlanggaran
            // 
            btnInputperlanggaran.Font = new Font("Segoe UI", 11F);
            btnInputperlanggaran.Name = "btnInputperlanggaran";
            btnInputperlanggaran.Size = new Size(292, 38);
            btnInputperlanggaran.Text = "Input Pelanggaran";
            btnInputperlanggaran.Click += btnInputperlanggaran_Click;
            // 
            // btndashboard
            // 
            btndashboard.BackColor = Color.Gainsboro;
            btndashboard.FlatAppearance.BorderSize = 0;
            btndashboard.FlatStyle = FlatStyle.Flat;
            btndashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btndashboard.ImeMode = ImeMode.NoControl;
            btndashboard.Location = new Point(11, 36);
            btndashboard.Name = "btndashboard";
            btndashboard.Size = new Size(338, 53);
            btndashboard.TabIndex = 33;
            btndashboard.Text = "⬛ DashBoard";
            btndashboard.TextAlign = ContentAlignment.BottomLeft;
            btndashboard.UseVisualStyleBackColor = false;
            btndashboard.Click += btndashboard_Click;
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
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Location = new Point(0, 49);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(413, 374);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(537, 636);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1317, 469);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 55);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 24;
            label5.Text = "NIS :";
            // 
            // txtnis
            // 
            txtnis.Enabled = false;
            txtnis.Location = new Point(132, 52);
            txtnis.Name = "txtnis";
            txtnis.ReadOnly = true;
            txtnis.Size = new Size(378, 31);
            txtnis.TabIndex = 25;
            txtnis.TextChanged += txtnis_TextChanged;
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(1285, 544);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 26;
            txtcari.TextChanged += txtcari_TextChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pictureBox3);
            groupBox4.Controls.Add(btnEdit);
            groupBox4.Controls.Add(btnUpdate);
            groupBox4.Controls.Add(btnhapus);
            groupBox4.Controls.Add(btnbatal);
            groupBox4.Controls.Add(btntambah);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(txtnotelp);
            groupBox4.Controls.Add(cbkelas);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(rbpr);
            groupBox4.Controls.Add(rblaki);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(txtnama);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(txtnis);
            groupBox4.Location = new Point(527, 175);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1327, 335);
            groupBox4.TabIndex = 27;
            groupBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(559, 52);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(699, 160);
            pictureBox3.TabIndex = 40;
            pictureBox3.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(837, 238);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(127, 62);
            btnEdit.TabIndex = 39;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(680, 237);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 65);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(999, 233);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(133, 62);
            btnhapus.TabIndex = 37;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnbatal
            // 
            btnbatal.Location = new Point(1162, 233);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(129, 62);
            btnbatal.TabIndex = 36;
            btnbatal.Text = "Batal";
            btnbatal.UseVisualStyleBackColor = true;
            btnbatal.Click += btnbatal_Click;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(529, 236);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(119, 65);
            btntambah.TabIndex = 35;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            btntambah.Click += btntambah_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(26, 270);
            label9.Name = "label9";
            label9.Size = new Size(101, 25);
            label9.TabIndex = 33;
            label9.Text = "No telpon :";
            // 
            // txtnotelp
            // 
            txtnotelp.Location = new Point(132, 270);
            txtnotelp.Name = "txtnotelp";
            txtnotelp.Size = new Size(378, 31);
            txtnotelp.TabIndex = 34;
            txtnotelp.TextChanged += textBox3_TextChanged;
            // 
            // cbkelas
            // 
            cbkelas.FormattingEnabled = true;
            cbkelas.Items.AddRange(new object[] { "X - RPL", "X - AKL", "X - DKV", "X - BR1", "X - BR2", "X - BD", "X - MP1", "X - MP2", "X - TKJ", "X - TKR" });
            cbkelas.Location = new Point(132, 223);
            cbkelas.Name = "cbkelas";
            cbkelas.Size = new Size(378, 33);
            cbkelas.TabIndex = 32;
            cbkelas.Text = "Pilih Kelas ~";
            cbkelas.SelectedIndexChanged += cbkelas_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 223);
            label8.Name = "label8";
            label8.Size = new Size(61, 25);
            label8.TabIndex = 31;
            label8.Text = "Kelas :";
            // 
            // rbpr
            // 
            rbpr.AutoSize = true;
            rbpr.Location = new Point(463, 172);
            rbpr.Name = "rbpr";
            rbpr.Size = new Size(47, 29);
            rbpr.TabIndex = 30;
            rbpr.TabStop = true;
            rbpr.Text = "P";
            rbpr.UseVisualStyleBackColor = true;
            rbpr.CheckedChanged += rbpr_CheckedChanged;
            // 
            // rblaki
            // 
            rblaki.AutoSize = true;
            rblaki.Location = new Point(172, 172);
            rblaki.Name = "rblaki";
            rblaki.Size = new Size(45, 29);
            rblaki.TabIndex = 29;
            rblaki.TabStop = true;
            rblaki.Text = "L";
            rblaki.UseVisualStyleBackColor = true;
            rblaki.CheckedChanged += rblaki_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 172);
            label7.Name = "label7";
            label7.Size = new Size(125, 25);
            label7.TabIndex = 28;
            label7.Text = "Jenis Kelamin :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 118);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 26;
            label6.Text = "Nama :";
            // 
            // txtnama
            // 
            txtnama.Location = new Point(132, 118);
            txtnama.Name = "txtnama";
            txtnama.Size = new Size(378, 31);
            txtnama.TabIndex = 27;
            txtnama.TextChanged += txtnama_TextChanged;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.LightGray;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.ImeMode = ImeMode.NoControl;
            btnKeluar.Location = new Point(1753, 23);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(153, 43);
            btnKeluar.TabIndex = 5;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // Formtambahsiswa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1170);
            Controls.Add(groupBox4);
            Controls.Add(txtcari);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(groupBox2);
            Name = "Formtambahsiswa";
            Text = "Formtambahsiswa";
            WindowState = FormWindowState.Maximized;
            Load += Formtambahsiswa_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip3.ResumeLayout(false);
            menuStrip3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private Label label3;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button btnPengaturan;
        private Panel panel3;
        private Label label4;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox txtnis;
        private TextBox txtcari;
        private GroupBox groupBox4;
        private Label label9;
        private TextBox txtnotelp;
        private ComboBox cbkelas;
        private Label label8;
        private RadioButton rbpr;
        private RadioButton rblaki;
        private Label label7;
        private Label label6;
        private TextBox txtnama;
        private Button btnEdit;
        private Button btnUpdate;
        private Button btnhapus;
        private Button btnbatal;
        private Button btntambah;
        private PictureBox pictureBox3;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem btnpersiswa;
        private ToolStripMenuItem btnPerkelas;
        private ToolStripMenuItem btnSuratperingatan;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem btnDatasiswa;
        private ToolStripMenuItem btnDataguru;
        private ToolStripMenuItem btnJenispelanggaran;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem transaksiToolStripMenuItem;
        private ToolStripMenuItem btnInputperlanggaran;
        private Button btndashboard;
        private Button btnKeluar;
    }
}