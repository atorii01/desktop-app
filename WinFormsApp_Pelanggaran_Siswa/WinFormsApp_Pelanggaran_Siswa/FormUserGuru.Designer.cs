namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormUserGuru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserGuru));
            label3 = new Label();
            pictureBox1 = new PictureBox();
            txtcari = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            groupBox4 = new GroupBox();
            cbRole = new ComboBox();
            txtKodeGuru = new TextBox();
            txtPassword = new TextBox();
            btnEdit = new Button();
            btnUpdate = new Button();
            btnhapus = new Button();
            btnbatal = new Button();
            btntambah = new Button();
            label9 = new Label();
            txtNama = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnPengaturan = new Button();
            groupBox1 = new GroupBox();
            panel3 = new Panel();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            label4 = new Label();
            panel2 = new Panel();
            menuStrip4 = new MenuStrip();
            toolStripMenuItem3 = new ToolStripMenuItem();
            btnPersiswa = new ToolStripMenuItem();
            btnPerkelas = new ToolStripMenuItem();
            btnSuratPeringatan = new ToolStripMenuItem();
            btndashboard = new Button();
            menuStrip5 = new MenuStrip();
            toolStripMenuItem4 = new ToolStripMenuItem();
            btnDataSiswa = new ToolStripMenuItem();
            btnDataGuru = new ToolStripMenuItem();
            btnJenisPelanggaran = new ToolStripMenuItem();
            menuStrip6 = new MenuStrip();
            toolStripMenuItem5 = new ToolStripMenuItem();
            btnInputPelanggaran = new ToolStripMenuItem();
            btnKeluar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox4.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip4.SuspendLayout();
            menuStrip5.SuspendLayout();
            menuStrip6.SuspendLayout();
            SuspendLayout();
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
            // pictureBox1
            // 
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(3, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 75);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(1285, 544);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 40;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(537, 636);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1317, 469);
            dataGridView1.TabIndex = 35;
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
            groupBox2.TabIndex = 38;
            groupBox2.TabStop = false;
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
            // groupBox4
            // 
            groupBox4.Controls.Add(cbRole);
            groupBox4.Controls.Add(txtKodeGuru);
            groupBox4.Controls.Add(txtPassword);
            groupBox4.Controls.Add(btnEdit);
            groupBox4.Controls.Add(btnUpdate);
            groupBox4.Controls.Add(btnhapus);
            groupBox4.Controls.Add(btnbatal);
            groupBox4.Controls.Add(btntambah);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(txtNama);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(527, 175);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1327, 335);
            groupBox4.TabIndex = 41;
            groupBox4.TabStop = false;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Admin", "Guru BK" });
            cbRole.Location = new Point(194, 245);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(378, 33);
            cbRole.TabIndex = 44;
            cbRole.Text = "Pilih Role~";
            // 
            // txtKodeGuru
            // 
            txtKodeGuru.Enabled = false;
            txtKodeGuru.Location = new Point(193, 55);
            txtKodeGuru.Name = "txtKodeGuru";
            txtKodeGuru.ReadOnly = true;
            txtKodeGuru.Size = new Size(378, 31);
            txtKodeGuru.TabIndex = 43;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(192, 179);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(378, 31);
            txtPassword.TabIndex = 41;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(881, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(127, 62);
            btnEdit.TabIndex = 39;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(729, 223);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 65);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(1033, 226);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(133, 62);
            btnhapus.TabIndex = 37;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnbatal
            // 
            btnbatal.Location = new Point(1192, 226);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(129, 62);
            btnbatal.TabIndex = 36;
            btnbatal.Text = "Batal";
            btnbatal.UseVisualStyleBackColor = true;
            btnbatal.Click += btnbatal_Click;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(594, 223);
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
            label9.Location = new Point(18, 245);
            label9.Name = "label9";
            label9.Size = new Size(160, 25);
            label9.TabIndex = 33;
            label9.Text = "Role                      :";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(192, 112);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(378, 31);
            txtNama.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 179);
            label8.Name = "label8";
            label8.Size = new Size(162, 25);
            label8.TabIndex = 31;
            label8.Text = "Password Akun     :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 112);
            label7.Name = "label7";
            label7.Size = new Size(166, 25);
            label7.TabIndex = 28;
            label7.Text = "Nama Guru            :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 55);
            label6.Name = "label6";
            label6.Size = new Size(170, 25);
            label6.TabIndex = 26;
            label6.Text = "Kode Guru              :";
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
            btnPengaturan.Text = "⚙ Pengaturan";
            btnPengaturan.TextAlign = ContentAlignment.MiddleLeft;
            btnPengaturan.UseVisualStyleBackColor = false;
            btnPengaturan.Click += btnPengaturan_Click;
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
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Location = new Point(325, 787);
            panel3.Name = "panel3";
            panel3.Size = new Size(1594, 49);
            panel3.TabIndex = 9;
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
            panel1.TabIndex = 36;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(480, 60);
            label4.Name = "label4";
            label4.Size = new Size(375, 96);
            label4.TabIndex = 39;
            label4.Text = "Data Guru";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(menuStrip4);
            panel2.Controls.Add(btndashboard);
            panel2.Controls.Add(menuStrip5);
            panel2.Controls.Add(menuStrip6);
            panel2.Controls.Add(btnPengaturan);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 420);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 772);
            panel2.TabIndex = 37;
            // 
            // menuStrip4
            // 
            menuStrip4.BackColor = Color.Transparent;
            menuStrip4.Dock = DockStyle.None;
            menuStrip4.ImageScalingSize = new Size(24, 24);
            menuStrip4.Items.AddRange(new ToolStripItem[] { toolStripMenuItem3 });
            menuStrip4.Location = new Point(29, 501);
            menuStrip4.Name = "menuStrip4";
            menuStrip4.RenderMode = ToolStripRenderMode.System;
            menuStrip4.Size = new Size(172, 40);
            menuStrip4.TabIndex = 36;
            menuStrip4.Text = "menuStrip4";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.BackColor = Color.Transparent;
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { btnPersiswa, btnPerkelas, btnSuratPeringatan });
            toolStripMenuItem3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem3.ForeColor = SystemColors.ControlText;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(164, 36);
            toolStripMenuItem3.Text = "📊 Laporan";
            // 
            // btnPersiswa
            // 
            btnPersiswa.Font = new Font("Segoe UI", 11F);
            btnPersiswa.Name = "btnPersiswa";
            btnPersiswa.Size = new Size(275, 38);
            btnPersiswa.Text = "Per Siswa";
            btnPersiswa.Click += btnPersiswa_Click;
            // 
            // btnPerkelas
            // 
            btnPerkelas.Font = new Font("Segoe UI", 11F);
            btnPerkelas.Name = "btnPerkelas";
            btnPerkelas.Size = new Size(275, 38);
            btnPerkelas.Text = "Per Kelas";
            btnPerkelas.Click += btnPerkelas_Click;
            // 
            // btnSuratPeringatan
            // 
            btnSuratPeringatan.Font = new Font("Segoe UI", 11F);
            btnSuratPeringatan.Name = "btnSuratPeringatan";
            btnSuratPeringatan.Size = new Size(275, 38);
            btnSuratPeringatan.Text = "Surat Peringatan";
            btnSuratPeringatan.Click += btnSuratPeringatan_Click;
            // 
            // btndashboard
            // 
            btndashboard.BackColor = Color.Gainsboro;
            btndashboard.FlatAppearance.BorderSize = 0;
            btndashboard.FlatStyle = FlatStyle.Flat;
            btndashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btndashboard.ForeColor = SystemColors.ControlText;
            btndashboard.ImeMode = ImeMode.NoControl;
            btndashboard.Location = new Point(31, 36);
            btndashboard.Name = "btndashboard";
            btndashboard.Size = new Size(192, 53);
            btndashboard.TabIndex = 33;
            btndashboard.Text = "⬛ DashBoard";
            btndashboard.TextAlign = ContentAlignment.BottomLeft;
            btndashboard.UseVisualStyleBackColor = false;
            btndashboard.Click += btndashboard_Click_1;
            // 
            // menuStrip5
            // 
            menuStrip5.BackColor = Color.Transparent;
            menuStrip5.Dock = DockStyle.None;
            menuStrip5.ImageScalingSize = new Size(24, 24);
            menuStrip5.Items.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            menuStrip5.Location = new Point(17, 162);
            menuStrip5.Name = "menuStrip5";
            menuStrip5.RenderMode = ToolStripRenderMode.System;
            menuStrip5.Size = new Size(225, 40);
            menuStrip5.TabIndex = 34;
            menuStrip5.Text = "menuStrip5";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { btnDataSiswa, btnDataGuru, btnJenisPelanggaran });
            toolStripMenuItem4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem4.ForeColor = SystemColors.Highlight;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(217, 36);
            toolStripMenuItem4.Text = "📰 Master Data ";
            // 
            // btnDataSiswa
            // 
            btnDataSiswa.Font = new Font("Segoe UI", 11F);
            btnDataSiswa.Name = "btnDataSiswa";
            btnDataSiswa.Size = new Size(288, 40);
            btnDataSiswa.Text = "Data Siswa";
            btnDataSiswa.Click += btnDataSiswa_Click;
            // 
            // btnDataGuru
            // 
            btnDataGuru.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDataGuru.Name = "btnDataGuru";
            btnDataGuru.Size = new Size(288, 40);
            btnDataGuru.Text = "Data Guru";
            // 
            // btnJenisPelanggaran
            // 
            btnJenisPelanggaran.Font = new Font("Segoe UI", 11F);
            btnJenisPelanggaran.Name = "btnJenisPelanggaran";
            btnJenisPelanggaran.Size = new Size(288, 40);
            btnJenisPelanggaran.Text = "Jenis Pelanggaran";
            btnJenisPelanggaran.Click += btnJenisPelanggaran_Click;
            // 
            // menuStrip6
            // 
            menuStrip6.BackColor = Color.Transparent;
            menuStrip6.Dock = DockStyle.None;
            menuStrip6.ImageScalingSize = new Size(24, 24);
            menuStrip6.Items.AddRange(new ToolStripItem[] { toolStripMenuItem5 });
            menuStrip6.Location = new Point(29, 332);
            menuStrip6.Name = "menuStrip6";
            menuStrip6.RenderMode = ToolStripRenderMode.System;
            menuStrip6.Size = new Size(184, 40);
            menuStrip6.TabIndex = 35;
            menuStrip6.Text = "menuStrip6";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.BackColor = Color.Transparent;
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { btnInputPelanggaran });
            toolStripMenuItem5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(176, 36);
            toolStripMenuItem5.Text = "\U0001f9fe Transaksi";
            // 
            // btnInputPelanggaran
            // 
            btnInputPelanggaran.Font = new Font("Segoe UI", 11F);
            btnInputPelanggaran.Name = "btnInputPelanggaran";
            btnInputPelanggaran.Size = new Size(292, 38);
            btnInputPelanggaran.Text = "Input Pelanggaran";
            btnInputPelanggaran.Click += btnInputPelanggaran_Click;
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
            // FormUserGuru
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1170);
            Controls.Add(txtcari);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox4);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(panel2);
            Name = "FormUserGuru";
            Text = "FormUserGuru";
            WindowState = FormWindowState.Maximized;
            Load += FormUserGuru_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip4.ResumeLayout(false);
            menuStrip4.PerformLayout();
            menuStrip5.ResumeLayout(false);
            menuStrip5.PerformLayout();
            menuStrip6.ResumeLayout(false);
            menuStrip6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private PictureBox pictureBox1;
        private TextBox txtcari;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private Button button1;
        private GroupBox groupBox4;
        private ComboBox cbRole;
        private TextBox txtKodeGuru;
        private TextBox txtPassword;
        private Button btnEdit;
        private Button btnUpdate;
        private Button btnhapus;
        private Button btnbatal;
        private Button btntambah;
        private Label label9;
        private TextBox txtNama;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button btnPengaturan;
        private GroupBox groupBox1;
        private Panel panel3;
        private Panel panel1;
        private GroupBox groupBox3;
        private Label label4;
        private Panel panel2;
        private MenuStrip menuStrip4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem btnPersiswa;
        private ToolStripMenuItem btnPerkelas;
        private ToolStripMenuItem btnSuratPeringatan;
        private Button btndashboard;
        private MenuStrip menuStrip5;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem btnDataSiswa;
        private ToolStripMenuItem btnDataGuru;
        private ToolStripMenuItem btnJenisPelanggaran;
        private MenuStrip menuStrip6;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem btnInputPelanggaran;
        private Button btnKeluar;
    }
}