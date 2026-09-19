namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormLaporanpersiswa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLaporanpersiswa));
            txtcari = new TextBox();
            groupBox4 = new GroupBox();
            btntotalpoint = new Button();
            btnnis = new Button();
            label5 = new Label();
            label4 = new Label();
            groupBox5 = new GroupBox();
            label7 = new Label();
            lblperempuan = new Label();
            pictureBox4 = new PictureBox();
            groupBox6 = new GroupBox();
            label8 = new Label();
            lbllaki = new Label();
            pictureBox3 = new PictureBox();
            label13 = new Label();
            pictureBox10 = new PictureBox();
            label12 = new Label();
            pictureBox9 = new PictureBox();
            label6 = new Label();
            pictureBox5 = new PictureBox();
            dataGridView2 = new DataGridView();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
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
            // groupBox4
            // 
            groupBox4.Controls.Add(btntotalpoint);
            groupBox4.Controls.Add(btnnis);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(txtcari);
            groupBox4.Location = new Point(73, 191);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1317, 114);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Enter += groupBox4_Enter;
            // 
            // btntotalpoint
            // 
            btntotalpoint.BackColor = SystemColors.ActiveCaption;
            btntotalpoint.Font = new Font("Constantia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btntotalpoint.ForeColor = SystemColors.ControlLightLight;
            btntotalpoint.Location = new Point(500, 37);
            btntotalpoint.Name = "btntotalpoint";
            btntotalpoint.Size = new Size(161, 53);
            btntotalpoint.TabIndex = 25;
            btntotalpoint.Text = "Total Point";
            btntotalpoint.UseVisualStyleBackColor = false;
            btntotalpoint.Click += btntotalpoint_Click;
            // 
            // btnnis
            // 
            btnnis.BackColor = SystemColors.ActiveCaption;
            btnnis.Font = new Font("Constantia", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnnis.ForeColor = SystemColors.ControlLightLight;
            btnnis.Location = new Point(303, 37);
            btnnis.Name = "btnnis";
            btnnis.Size = new Size(161, 53);
            btnnis.TabIndex = 24;
            btnnis.Text = "NIS";
            btnnis.UseVisualStyleBackColor = false;
            btnnis.Click += btnnis_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 51);
            label5.Name = "label5";
            label5.Size = new Size(250, 30);
            label5.TabIndex = 4;
            label5.Text = "Urutkan Berdasarkan  :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(12, 41);
            label4.Name = "label4";
            label4.Size = new Size(517, 96);
            label4.TabIndex = 22;
            label4.Text = "Laporan/Siswa";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(lblperempuan);
            groupBox5.Controls.Add(pictureBox4);
            groupBox5.FlatStyle = FlatStyle.Popup;
            groupBox5.Location = new Point(532, 17);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(354, 168);
            groupBox5.TabIndex = 25;
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
            groupBox6.Location = new Point(974, 17);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(354, 168);
            groupBox6.TabIndex = 26;
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
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F);
            label13.ImeMode = ImeMode.NoControl;
            label13.Location = new Point(467, 968);
            label13.Name = "label13";
            label13.Size = new Size(41, 28);
            label13.TabIndex = 32;
            label13.Text = "DO";
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = SystemColors.ButtonShadow;
            pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            pictureBox10.ImeMode = ImeMode.NoControl;
            pictureBox10.Location = new Point(410, 968);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(42, 32);
            pictureBox10.TabIndex = 31;
            pictureBox10.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.ImeMode = ImeMode.NoControl;
            label12.Location = new Point(283, 968);
            label12.Name = "label12";
            label12.Size = new Size(103, 28);
            label12.TabIndex = 30;
            label12.Text = "≥ 50 Point";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Crimson;
            pictureBox9.BorderStyle = BorderStyle.FixedSingle;
            pictureBox9.ImeMode = ImeMode.NoControl;
            pictureBox9.Location = new Point(235, 968);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(42, 32);
            pictureBox9.TabIndex = 29;
            pictureBox9.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(105, 968);
            label6.Name = "label6";
            label6.Size = new Size(103, 28);
            label6.TabIndex = 28;
            label6.Text = "≥ 25 Point";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Gold;
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox5.ImeMode = ImeMode.NoControl;
            pictureBox5.Location = new Point(57, 968);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(42, 32);
            pictureBox5.TabIndex = 27;
            pictureBox5.TabStop = false;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(53, 328);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1317, 618);
            dataGridView2.TabIndex = 33;
            // 
            // FormLaporanpersiswa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 1170);
            Controls.Add(dataGridView2);
            Controls.Add(label13);
            Controls.Add(pictureBox10);
            Controls.Add(label12);
            Controls.Add(pictureBox9);
            Controls.Add(label6);
            Controls.Add(pictureBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(label4);
            Name = "FormLaporanpersiswa";
            Text = "FormLaporanpersiswa";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtcari;
        private GroupBox groupBox4;
        private Button btntotalpoint;
        private Button btnnis;
        private Label label5;
        private Label label4;
        private GroupBox groupBox5;
        private Label label7;
        private Label lblperempuan;
        private PictureBox pictureBox4;
        private GroupBox groupBox6;
        private Label label8;
        private Label lbllaki;
        private PictureBox pictureBox3;
        private Label label13;
        private PictureBox pictureBox10;
        private Label label12;
        private PictureBox pictureBox9;
        private Label label6;
        private PictureBox pictureBox5;
        private DataGridView dataGridView2;
    }
}