namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormTambahPelanggaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTambahPelanggaran));
            label2 = new Label();
            pictureBox2 = new PictureBox();
            groupBox4 = new GroupBox();
            cbJenis = new ComboBox();
            txtKodeJenis = new TextBox();
            txtnilaiPoint = new TextBox();
            btnEdit = new Button();
            btnUpdate = new Button();
            btnhapus = new Button();
            btnbatal = new Button();
            btntambah = new Button();
            label9 = new Label();
            txtnotelp = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtcari = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            label1 = new Label();
            inputPelanggaranToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label4 = new Label();
            panel2 = new Panel();
            menuStrip3 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            perKelasToolStripMenuItem = new ToolStripMenuItem();
            suratPeringatanToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            butt = new ToolStripMenuItem();
            dataGuruToolStripMenuItem = new ToolStripMenuItem();
            jenisPelanggaranToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            transaksiToolStripMenuItem = new ToolStripMenuItem();
            button9 = new Button();
            btndashboard = new Button();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            menuStrip3.SuspendLayout();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
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
            groupBox4.Controls.Add(cbJenis);
            groupBox4.Controls.Add(txtKodeJenis);
            groupBox4.Controls.Add(txtnilaiPoint);
            groupBox4.Controls.Add(btnEdit);
            groupBox4.Controls.Add(btnUpdate);
            groupBox4.Controls.Add(btnhapus);
            groupBox4.Controls.Add(btnbatal);
            groupBox4.Controls.Add(btntambah);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(txtnotelp);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(527, 175);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1327, 335);
            groupBox4.TabIndex = 34;
            groupBox4.TabStop = false;
            // 
            // cbJenis
            // 
            cbJenis.FormattingEnabled = true;
            cbJenis.Items.AddRange(new object[] { "Ringan", "Sedang ", "Berat", "Sangat Berat" });
            cbJenis.Location = new Point(192, 179);
            cbJenis.Name = "cbJenis";
            cbJenis.Size = new Size(378, 33);
            cbJenis.TabIndex = 44;
            cbJenis.Text = "Pilih Jenis~";
            // 
            // txtKodeJenis
            // 
            txtKodeJenis.Enabled = false;
            txtKodeJenis.Location = new Point(193, 55);
            txtKodeJenis.Name = "txtKodeJenis";
            txtKodeJenis.ReadOnly = true;
            txtKodeJenis.Size = new Size(378, 31);
            txtKodeJenis.TabIndex = 43;
            // 
            // txtnilaiPoint
            // 
            txtnilaiPoint.Location = new Point(192, 249);
            txtnilaiPoint.Name = "txtnilaiPoint";
            txtnilaiPoint.Size = new Size(378, 31);
            txtnilaiPoint.TabIndex = 41;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(881, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(127, 62);
            btnEdit.TabIndex = 39;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(729, 223);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 65);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(1033, 226);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(133, 62);
            btnhapus.TabIndex = 37;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            // 
            // btnbatal
            // 
            btnbatal.Location = new Point(1192, 226);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(129, 62);
            btnbatal.TabIndex = 36;
            btnbatal.Text = "Batal";
            btnbatal.UseVisualStyleBackColor = true;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(594, 223);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(119, 65);
            btntambah.TabIndex = 35;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 245);
            label9.Name = "label9";
            label9.Size = new Size(170, 25);
            label9.TabIndex = 33;
            label9.Text = "Nilai Point               :";
            // 
            // txtnotelp
            // 
            txtnotelp.Location = new Point(192, 112);
            txtnotelp.Name = "txtnotelp";
            txtnotelp.Size = new Size(378, 31);
            txtnotelp.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 179);
            label8.Name = "label8";
            label8.Size = new Size(160, 25);
            label8.TabIndex = 31;
            label8.Text = "Jenis Pelanggaran :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 112);
            label7.Name = "label7";
            label7.Size = new Size(170, 25);
            label7.TabIndex = 28;
            label7.Text = "Nama Pelanggaran :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 55);
            label6.Name = "label6";
            label6.Size = new Size(169, 25);
            label6.TabIndex = 26;
            label6.Text = "Kode Jenis              :";
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(1285, 544);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 33;
           //xtcari.TextChanged += txtcari_TextChanged_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(537, 636);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1317, 469);
            dataGridView1.TabIndex = 28;
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
            groupBox2.TabIndex = 31;
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
            // inputPelanggaranToolStripMenuItem
            // 
            inputPelanggaranToolStripMenuItem.Name = "inputPelanggaranToolStripMenuItem";
            inputPelanggaranToolStripMenuItem.Size = new Size(330, 40);
            inputPelanggaranToolStripMenuItem.Text = "Input Pelanggaran";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, -22);
            panel1.Name = "panel1";
            panel1.Size = new Size(1919, 74);
            panel1.TabIndex = 29;
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
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(1738, 23);
            button1.Name = "button1";
            button1.Size = new Size(153, 43);
            button1.TabIndex = 0;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(480, 60);
            label4.Name = "label4";
            label4.Size = new Size(622, 96);
            label4.TabIndex = 32;
            label4.Text = "Data Pelanggaran";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(menuStrip3);
            panel2.Controls.Add(menuStrip1);
            panel2.Controls.Add(menuStrip2);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(btndashboard);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 420);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 772);
            panel2.TabIndex = 30;
            // 
            // menuStrip3
            // 
            menuStrip3.BackColor = Color.Transparent;
            menuStrip3.Dock = DockStyle.None;
            menuStrip3.ImageScalingSize = new Size(24, 24);
            menuStrip3.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip3.Location = new Point(14, 510);
            menuStrip3.Name = "menuStrip3";
            menuStrip3.RenderMode = ToolStripRenderMode.System;
            menuStrip3.Size = new Size(172, 40);
            menuStrip3.TabIndex = 32;
            menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.Transparent;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, perKelasToolStripMenuItem, suratPeringatanToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(164, 36);
            toolStripMenuItem1.Text = "📊 Laporan";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(309, 40);
            toolStripMenuItem2.Text = "Per Siswa";
            // 
            // perKelasToolStripMenuItem
            // 
            perKelasToolStripMenuItem.Name = "perKelasToolStripMenuItem";
            perKelasToolStripMenuItem.Size = new Size(309, 40);
            perKelasToolStripMenuItem.Text = "Per Kelas";
            // 
            // suratPeringatanToolStripMenuItem
            // 
            suratPeringatanToolStripMenuItem.Name = "suratPeringatanToolStripMenuItem";
            suratPeringatanToolStripMenuItem.Size = new Size(309, 40);
            suratPeringatanToolStripMenuItem.Text = "Surat Peringatan";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { masterDataToolStripMenuItem });
            menuStrip1.Location = new Point(2, 171);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(225, 40);
            menuStrip1.TabIndex = 30;
            menuStrip1.Text = "menuStrip1";
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { butt, dataGuruToolStripMenuItem, jenisPelanggaranToolStripMenuItem });
            masterDataToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(217, 36);
            masterDataToolStripMenuItem.Text = "📰 Master Data ";
            // 
            // butt
            // 
            butt.Name = "butt";
            butt.Size = new Size(325, 40);
            butt.Text = "Data Siswa";
            // 
            // dataGuruToolStripMenuItem
            // 
            dataGuruToolStripMenuItem.Name = "dataGuruToolStripMenuItem";
            dataGuruToolStripMenuItem.Size = new Size(325, 40);
            dataGuruToolStripMenuItem.Text = "Data Guru";
            // 
            // jenisPelanggaranToolStripMenuItem
            // 
            jenisPelanggaranToolStripMenuItem.Name = "jenisPelanggaranToolStripMenuItem";
            jenisPelanggaranToolStripMenuItem.Size = new Size(325, 40);
            jenisPelanggaranToolStripMenuItem.Text = "Jenis Pelanggaran";
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = Color.Transparent;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { transaksiToolStripMenuItem });
            menuStrip2.Location = new Point(14, 341);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.RenderMode = ToolStripRenderMode.System;
            menuStrip2.Size = new Size(184, 40);
            menuStrip2.TabIndex = 31;
            menuStrip2.Text = "menuStrip2";
            // 
            // transaksiToolStripMenuItem
            // 
            transaksiToolStripMenuItem.BackColor = Color.Transparent;
            transaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inputPelanggaranToolStripMenuItem });
            transaksiToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            transaksiToolStripMenuItem.Size = new Size(176, 36);
            transaksiToolStripMenuItem.Text = "\U0001f9fe Transaksi";
            // 
            // button9
            // 
            button9.BackColor = Color.Gainsboro;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button9.ImeMode = ImeMode.NoControl;
            button9.Location = new Point(11, 657);
            button9.Name = "button9";
            button9.Size = new Size(212, 45);
            button9.TabIndex = 24;
            button9.Text = "⚙ Pengaturan";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
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
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Location = new Point(325, 787);
            panel3.Name = "panel3";
            panel3.Size = new Size(1594, 49);
            panel3.TabIndex = 9;
            // 
            // FormTambahPelanggaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1170);
            Controls.Add(groupBox4);
            Controls.Add(txtcari);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(panel2);
            Name = "FormTambahPelanggaran";
            Text = "FormTambahPelanggaran";
            WindowState = FormWindowState.Maximized;
            Load += FormTambahPelanggaran_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private PictureBox pictureBox2;
        private GroupBox groupBox4;
        private Button btnEdit;
        private Button btnUpdate;
        private Button btnhapus;
        private Button btnbatal;
        private Button btntambah;
        private Label label9;
        private TextBox txtnotelp;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtcari;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Label label1;
        private ToolStripMenuItem inputPelanggaranToolStripMenuItem;
        private Panel panel1;
        private GroupBox groupBox3;
        private Label label3;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private Label label4;
        private Panel panel2;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem perKelasToolStripMenuItem;
        private ToolStripMenuItem suratPeringatanToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem butt;
        private ToolStripMenuItem dataGuruToolStripMenuItem;
        private ToolStripMenuItem jenisPelanggaranToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem transaksiToolStripMenuItem;
        private Button button9;
        private Button btndashboard;
        private Panel panel3;
        private TextBox txtnilaiPoint;
        private TextBox txtKodeJenis;
        private ComboBox cbJenis;
    }
}