namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class Formjenispelanggaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formjenispelanggaran));
            dataGridView2 = new DataGridView();
            txtcari = new TextBox();
            button11 = new Button();
            button10 = new Button();
            groupBox4 = new GroupBox();
            button6 = new Button();
            pictureBox1 = new PictureBox();
            groupBox3 = new GroupBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            btndashboard = new Button();
            panel3 = new Panel();
            btninputPelanggaran = new ToolStripMenuItem();
            transaksiToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            btnJenisPelanggaran = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            panel2 = new Panel();
            menuStrip3 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            btnPersiswa = new ToolStripMenuItem();
            btnPerkelas = new ToolStripMenuItem();
            btnSuratPeringatan = new ToolStripMenuItem();
            btnPengaturan = new Button();
            menuStrip1 = new MenuStrip();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            btnDataSiswa = new ToolStripMenuItem();
            btnDataGuru = new ToolStripMenuItem();
            btnKeluar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            menuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(537, 420);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1317, 671);
            dataGridView2.TabIndex = 18;
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(728, 32);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 3;
            // 
            // button11
            // 
            button11.Location = new Point(511, 30);
            button11.Name = "button11";
            button11.Size = new Size(172, 57);
            button11.TabIndex = 2;
            button11.Text = "Hapus";
            button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Location = new Point(300, 30);
            button10.Name = "button10";
            button10.Size = new Size(172, 57);
            button10.TabIndex = 1;
            button10.Text = "Edit";
            button10.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtcari);
            groupBox4.Controls.Add(button11);
            groupBox4.Controls.Add(button10);
            groupBox4.Controls.Add(button6);
            groupBox4.Location = new Point(537, 273);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1317, 114);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            // 
            // button6
            // 
            button6.Location = new Point(27, 30);
            button6.Name = "button6";
            button6.Size = new Size(234, 57);
            button6.TabIndex = 0;
            button6.Text = "Tambah";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
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
            panel1.TabIndex = 19;
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
            // btninputPelanggaran
            // 
            btninputPelanggaran.Font = new Font("Segoe UI", 11F);
            btninputPelanggaran.Name = "btninputPelanggaran";
            btninputPelanggaran.Size = new Size(292, 38);
            btninputPelanggaran.Text = "Input Pelanggaran";
            btninputPelanggaran.Click += btninputPelanggaran_Click;
            // 
            // transaksiToolStripMenuItem
            // 
            transaksiToolStripMenuItem.BackColor = Color.Transparent;
            transaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btninputPelanggaran });
            transaksiToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            transaksiToolStripMenuItem.Size = new Size(176, 36);
            transaksiToolStripMenuItem.Text = "\U0001f9fe Transaksi";
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
            // btnJenisPelanggaran
            // 
            btnJenisPelanggaran.Name = "btnJenisPelanggaran";
            btnJenisPelanggaran.Size = new Size(325, 40);
            btnJenisPelanggaran.Text = "Jenis Pelanggaran";
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
            groupBox2.TabIndex = 21;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(483, 82);
            label4.Name = "label4";
            label4.Size = new Size(627, 96);
            label4.TabIndex = 22;
            label4.Text = "Jenis Pelanggaran";
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
            panel2.TabIndex = 20;
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
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { btnPersiswa, btnPerkelas, btnSuratPeringatan });
            toolStripMenuItem1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(164, 36);
            toolStripMenuItem1.Text = "📊 Laporan";
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
            masterDataToolStripMenuItem.ForeColor = SystemColors.Highlight;
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(217, 36);
            masterDataToolStripMenuItem.Text = "📰 Master Data ";
            // 
            // btnDataSiswa
            // 
            btnDataSiswa.Font = new Font("Segoe UI", 11F);
            btnDataSiswa.Name = "btnDataSiswa";
            btnDataSiswa.Size = new Size(325, 40);
            btnDataSiswa.Text = "Data Siswa";
            btnDataSiswa.Click += btnDataSiswa_Click;
            // 
            // btnDataGuru
            // 
            btnDataGuru.Font = new Font("Segoe UI", 11F);
            btnDataGuru.Name = "btnDataGuru";
            btnDataGuru.Size = new Size(325, 40);
            btnDataGuru.Text = "Data Guru";
            btnDataGuru.Click += btnDataGuru_Click;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.LightGray;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.ImeMode = ImeMode.NoControl;
            btnKeluar.Location = new Point(1753, 34);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(153, 43);
            btnKeluar.TabIndex = 1;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = false;
            // 
            // Formjenispelanggaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1170);
            Controls.Add(dataGridView2);
            Controls.Add(groupBox4);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(panel2);
            Name = "Formjenispelanggaran";
            Text = "Formjenispelanggaran";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip3.ResumeLayout(false);
            menuStrip3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private TextBox txtcari;
        private Button button11;
        private Button button10;
        private GroupBox groupBox4;
        private Button button6;
        private Button button1;
        private PictureBox pictureBox1;
        private GroupBox groupBox3;
        private Label label3;
        private GroupBox groupBox1;
        private Panel panel1;
        private Button btndashboard;
        private Panel panel3;
        private ToolStripMenuItem btninputPelanggaran;
        private ToolStripMenuItem transaksiToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem btnJenisPelanggaran;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label4;
        private Panel panel2;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem btnPersiswa;
        private ToolStripMenuItem btnPerkelas;
        private ToolStripMenuItem btnSuratPeringatan;
        private Button btnPengaturan;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem btnDataSiswa;
        private ToolStripMenuItem btnDataGuru;
        private Button btnKeluar;
    }
}