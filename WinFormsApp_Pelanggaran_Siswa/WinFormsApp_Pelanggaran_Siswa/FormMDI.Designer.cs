namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMDI));
            label3 = new Label();
            label18 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnexit = new Button();
            btnSuratperingatan = new Button();
            btnperkelas = new Button();
            btnpersiswa = new Button();
            button8 = new Button();
            btninputpelanggaran = new Button();
            btntransaksi = new Button();
            btnuserguru = new Button();
            btnjenispelanggaran = new Button();
            btndatasiswa = new Button();
            btnMasterData = new Button();
            btnLogin = new Button();
            button9 = new Button();
            btndashboard = new Button();
            panel3 = new Panel();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            btnlogout = new Button();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            lblrole = new Label();
            lblhalo = new Label();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
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
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Gainsboro;
            label18.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label18.ImeMode = ImeMode.NoControl;
            label18.Location = new Point(1610, 1139);
            label18.Name = "label18";
            label18.Size = new Size(296, 25);
            label18.TabIndex = 20;
            label18.Text = "Aplikasi Pelanggaran Siswa v 1.0.01";
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
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(btnexit);
            panel2.Controls.Add(btnSuratperingatan);
            panel2.Controls.Add(btnperkelas);
            panel2.Controls.Add(btnpersiswa);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(btninputpelanggaran);
            panel2.Controls.Add(btntransaksi);
            panel2.Controls.Add(btnuserguru);
            panel2.Controls.Add(btnjenispelanggaran);
            panel2.Controls.Add(btndatasiswa);
            panel2.Controls.Add(btnMasterData);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(btndashboard);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 349);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 716);
            panel2.TabIndex = 13;
            // 
            // btnexit
            // 
            btnexit.BackColor = Color.LightGray;
            btnexit.BackgroundImageLayout = ImageLayout.None;
            btnexit.FlatStyle = FlatStyle.Flat;
            btnexit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnexit.Location = new Point(237, 661);
            btnexit.Name = "btnexit";
            btnexit.Size = new Size(151, 42);
            btnexit.TabIndex = 41;
            btnexit.Text = "Exit";
            btnexit.UseVisualStyleBackColor = false;
            btnexit.Click += btnexit_Click;
            // 
            // btnSuratperingatan
            // 
            btnSuratperingatan.BackColor = Color.Gainsboro;
            btnSuratperingatan.BackgroundImageLayout = ImageLayout.None;
            btnSuratperingatan.FlatAppearance.BorderSize = 0;
            btnSuratperingatan.FlatStyle = FlatStyle.Flat;
            btnSuratperingatan.Font = new Font("Segoe UI", 11F);
            btnSuratperingatan.Location = new Point(54, 566);
            btnSuratperingatan.Name = "btnSuratperingatan";
            btnSuratperingatan.Size = new Size(191, 50);
            btnSuratperingatan.TabIndex = 40;
            btnSuratperingatan.Text = "Surat Peringatan";
            btnSuratperingatan.UseVisualStyleBackColor = false;
            btnSuratperingatan.Click += btnSuratperingatan_Click;
            // 
            // btnperkelas
            // 
            btnperkelas.BackColor = Color.Gainsboro;
            btnperkelas.BackgroundImageLayout = ImageLayout.None;
            btnperkelas.FlatAppearance.BorderSize = 0;
            btnperkelas.FlatStyle = FlatStyle.Flat;
            btnperkelas.Font = new Font("Segoe UI", 11F);
            btnperkelas.Location = new Point(46, 523);
            btnperkelas.Name = "btnperkelas";
            btnperkelas.Size = new Size(159, 50);
            btnperkelas.TabIndex = 39;
            btnperkelas.Text = "Per Kelas";
            btnperkelas.UseVisualStyleBackColor = false;
            btnperkelas.Click += btnperkelas_Click;
            // 
            // btnpersiswa
            // 
            btnpersiswa.BackColor = Color.Gainsboro;
            btnpersiswa.BackgroundImageLayout = ImageLayout.None;
            btnpersiswa.FlatAppearance.BorderSize = 0;
            btnpersiswa.FlatStyle = FlatStyle.Flat;
            btnpersiswa.Font = new Font("Segoe UI", 11F);
            btnpersiswa.Location = new Point(44, 478);
            btnpersiswa.Name = "btnpersiswa";
            btnpersiswa.Size = new Size(159, 50);
            btnpersiswa.TabIndex = 38;
            btnpersiswa.Text = "Per Siswa";
            btnpersiswa.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Gainsboro;
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button8.Location = new Point(11, 422);
            button8.Name = "button8";
            button8.Size = new Size(205, 50);
            button8.TabIndex = 37;
            button8.Text = "📊 Laporan";
            button8.UseVisualStyleBackColor = false;
            // 
            // btninputpelanggaran
            // 
            btninputpelanggaran.BackColor = Color.Gainsboro;
            btninputpelanggaran.BackgroundImageLayout = ImageLayout.None;
            btninputpelanggaran.FlatAppearance.BorderSize = 0;
            btninputpelanggaran.FlatStyle = FlatStyle.Flat;
            btninputpelanggaran.Font = new Font("Segoe UI", 11F);
            btninputpelanggaran.Location = new Point(29, 366);
            btninputpelanggaran.Name = "btninputpelanggaran";
            btninputpelanggaran.Size = new Size(251, 50);
            btninputpelanggaran.TabIndex = 36;
            btninputpelanggaran.Text = "Input Pelanggaran";
            btninputpelanggaran.UseVisualStyleBackColor = false;
            // 
            // btntransaksi
            // 
            btntransaksi.BackColor = Color.Gainsboro;
            btntransaksi.BackgroundImageLayout = ImageLayout.None;
            btntransaksi.FlatAppearance.BorderSize = 0;
            btntransaksi.FlatStyle = FlatStyle.Flat;
            btntransaksi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btntransaksi.Location = new Point(6, 310);
            btntransaksi.Name = "btntransaksi";
            btntransaksi.Size = new Size(217, 50);
            btntransaksi.TabIndex = 35;
            btntransaksi.Text = "\U0001f9fe Transaksi";
            btntransaksi.UseVisualStyleBackColor = false;
            // 
            // btnuserguru
            // 
            btnuserguru.BackColor = Color.Gainsboro;
            btnuserguru.BackgroundImageLayout = ImageLayout.None;
            btnuserguru.FlatAppearance.BorderSize = 0;
            btnuserguru.FlatStyle = FlatStyle.Flat;
            btnuserguru.Font = new Font("Segoe UI", 11F);
            btnuserguru.Location = new Point(3, 248);
            btnuserguru.Name = "btnuserguru";
            btnuserguru.Size = new Size(202, 32);
            btnuserguru.TabIndex = 34;
            btnuserguru.Text = "User Guru";
            btnuserguru.UseVisualStyleBackColor = false;
            // 
            // btnjenispelanggaran
            // 
            btnjenispelanggaran.BackColor = Color.Gainsboro;
            btnjenispelanggaran.BackgroundImageLayout = ImageLayout.None;
            btnjenispelanggaran.FlatAppearance.BorderSize = 0;
            btnjenispelanggaran.FlatStyle = FlatStyle.Flat;
            btnjenispelanggaran.Font = new Font("Segoe UI", 11F);
            btnjenispelanggaran.Location = new Point(39, 208);
            btnjenispelanggaran.Name = "btnjenispelanggaran";
            btnjenispelanggaran.Size = new Size(204, 43);
            btnjenispelanggaran.TabIndex = 33;
            btnjenispelanggaran.Text = "Jenis Pelanggaran";
            btnjenispelanggaran.UseVisualStyleBackColor = false;
            // 
            // btndatasiswa
            // 
            btndatasiswa.BackColor = Color.Gainsboro;
            btndatasiswa.BackgroundImageLayout = ImageLayout.None;
            btndatasiswa.FlatAppearance.BorderSize = 0;
            btndatasiswa.FlatStyle = FlatStyle.Flat;
            btndatasiswa.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btndatasiswa.Location = new Point(29, 165);
            btndatasiswa.Name = "btndatasiswa";
            btndatasiswa.Size = new Size(160, 44);
            btndatasiswa.TabIndex = 32;
            btndatasiswa.Text = "Data Siswa";
            btndatasiswa.UseVisualStyleBackColor = false;
            // 
            // btnMasterData
            // 
            btnMasterData.BackColor = Color.Gainsboro;
            btnMasterData.BackgroundImageLayout = ImageLayout.None;
            btnMasterData.FlatAppearance.BorderSize = 0;
            btnMasterData.FlatStyle = FlatStyle.Flat;
            btnMasterData.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMasterData.Location = new Point(0, 112);
            btnMasterData.Name = "btnMasterData";
            btnMasterData.Size = new Size(222, 47);
            btnMasterData.TabIndex = 31;
            btnMasterData.Text = "📰Master Data ";
            btnMasterData.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightGray;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(38, 661);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(151, 42);
            btnLogin.TabIndex = 30;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.Gainsboro;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button9.ImeMode = ImeMode.NoControl;
            button9.Location = new Point(29, 610);
            button9.Name = "button9";
            button9.Size = new Size(212, 45);
            button9.TabIndex = 24;
            button9.Text = "⚙️ Pengaturan";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            // 
            // btndashboard
            // 
            btndashboard.BackColor = Color.Gainsboro;
            btndashboard.FlatAppearance.BorderSize = 0;
            btndashboard.FlatStyle = FlatStyle.Flat;
            btndashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btndashboard.ForeColor = SystemColors.Desktop;
            btndashboard.ImeMode = ImeMode.NoControl;
            btndashboard.Location = new Point(12, 31);
            btndashboard.Name = "btndashboard";
            btndashboard.Size = new Size(222, 53);
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
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnlogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1918, 74);
            panel1.TabIndex = 11;
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
            // btnlogout
            // 
            btnlogout.BackColor = Color.LightGray;
            btnlogout.FlatAppearance.BorderSize = 0;
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.ImeMode = ImeMode.NoControl;
            btnlogout.Location = new Point(1753, 12);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(153, 43);
            btnlogout.TabIndex = 0;
            btnlogout.Text = "Logout";
            btnlogout.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightGray;
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Location = new Point(0, 1139);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1918, 31);
            textBox1.TabIndex = 18;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(lblrole);
            groupBox2.Controls.Add(lblhalo);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(413, 374);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Enter += groupBox2_Enter;
            // 
            // lblrole
            // 
            lblrole.AutoSize = true;
            lblrole.ImeMode = ImeMode.NoControl;
            lblrole.Location = new Point(164, 308);
            lblrole.Name = "lblrole";
            lblrole.Size = new Size(59, 25);
            lblrole.TabIndex = 2;
            lblrole.Text = "label2";
            // 
            // lblhalo
            // 
            lblhalo.AutoSize = true;
            lblhalo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblhalo.ImeMode = ImeMode.NoControl;
            lblhalo.Location = new Point(89, 253);
            lblhalo.Name = "lblhalo";
            lblhalo.Size = new Size(100, 45);
            lblhalo.TabIndex = 1;
            lblhalo.Text = "halo, ";
            lblhalo.Click += lblhalo_Click;
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
            // panel5
            // 
            panel5.Controls.Add(groupBox2);
            panel5.Controls.Add(panel2);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 74);
            panel5.Name = "panel5";
            panel5.Size = new Size(413, 1065);
            panel5.TabIndex = 22;
            // 
            // FormMDI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1170);
            Controls.Add(panel5);
            Controls.Add(label18);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            IsMdiContainer = true;
            Name = "FormMDI";
            Text = "FormMDI";
            WindowState = FormWindowState.Maximized;
            Load += FormMDI_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label18;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button button9;
        private Panel panel3;
        private Panel panel1;
        private GroupBox groupBox1;
        private Button btnlogout;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private Label lblrole;
        private Label lblhalo;
        private PictureBox pictureBox2;
        private Panel panel5;
        private Button btnMasterData;
        private Button btndashboard;
        private Button btndatasiswa;
        private Button btnjenispelanggaran;
        private Button btnuserguru;
        private Button btninputpelanggaran;
        private Button btntransaksi;
        private Button button8;
        private Button btnSuratperingatan;
        private Button btnperkelas;
        private Button btnpersiswa;
        private Button btnexit;
        private Button btnLogin;
    }
}