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
            label4 = new Label();
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
            btnEkspor = new Button();
            btnimpor = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(35, 9);
            label4.Name = "label4";
            label4.Size = new Size(395, 96);
            label4.TabIndex = 22;
            label4.Text = "Data Siswa";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(84, 549);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1317, 487);
            dataGridView1.TabIndex = 4;
          //  dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Constantia", 10F);
            label5.Location = new Point(26, 55);
            label5.Name = "label5";
            label5.Size = new Size(52, 24);
            label5.TabIndex = 24;
            label5.Text = "NIS :";
            // 
            // txtnis
            // 
            txtnis.Enabled = false;
            txtnis.Font = new Font("Constantia", 10F);
            txtnis.Location = new Point(132, 52);
            txtnis.Name = "txtnis";
            txtnis.ReadOnly = true;
            txtnis.Size = new Size(378, 32);
            txtnis.TabIndex = 25;
         //   txtnis.TextChanged += txtnis_TextChanged;
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(842, 460);
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
            groupBox4.Location = new Point(76, 108);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1335, 335);
            groupBox4.TabIndex = 27;
            groupBox4.TabStop = false;
        //    groupBox4.Enter += groupBox4_Enter;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(559, 52);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(732, 160);
            pictureBox3.TabIndex = 40;
            pictureBox3.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ActiveCaption;
            btnEdit.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(870, 238);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(127, 62);
            btnEdit.TabIndex = 39;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ActiveCaption;
            btnUpdate.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = SystemColors.ControlLightLight;
            btnUpdate.Location = new Point(713, 237);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 65);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnhapus
            // 
            btnhapus.BackColor = SystemColors.ActiveCaption;
            btnhapus.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnhapus.ForeColor = SystemColors.ControlLightLight;
            btnhapus.Location = new Point(1014, 238);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(133, 62);
            btnhapus.TabIndex = 37;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = false;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnbatal
            // 
            btnbatal.BackColor = SystemColors.ActiveCaption;
            btnbatal.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnbatal.ForeColor = SystemColors.ControlLightLight;
            btnbatal.Location = new Point(1162, 240);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(129, 60);
            btnbatal.TabIndex = 36;
            btnbatal.Text = "Batal";
            btnbatal.UseVisualStyleBackColor = false;
            btnbatal.Click += btnbatal_Click;
            // 
            // btntambah
            // 
            btntambah.BackColor = SystemColors.ActiveCaption;
            btntambah.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btntambah.ForeColor = SystemColors.ControlLightLight;
            btntambah.Location = new Point(559, 236);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(122, 65);
            btntambah.TabIndex = 35;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = false;
            btntambah.Click += btntambah_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Constantia", 10F);
            label9.Location = new Point(26, 270);
            label9.Name = "label9";
            label9.Size = new Size(108, 24);
            label9.TabIndex = 33;
            label9.Text = "No telpon :";
            // 
            // txtnotelp
            // 
            txtnotelp.Font = new Font("Constantia", 10F);
            txtnotelp.Location = new Point(132, 270);
            txtnotelp.Name = "txtnotelp";
            txtnotelp.Size = new Size(378, 32);
            txtnotelp.TabIndex = 34;
       //     txtnotelp.TextChanged += textBox3_TextChanged;
            // 
            // cbkelas
            // 
            cbkelas.Font = new Font("Constantia", 10F);
            cbkelas.FormattingEnabled = true;
            cbkelas.Items.AddRange(new object[] { "X - RPL", "X - AKL", "X - DKV", "X - BR1", "X - BR2", "X - BD", "X - MP1", "X - MP2", "X - TKJ", "X - TKR" });
            cbkelas.Location = new Point(132, 223);
            cbkelas.Name = "cbkelas";
            cbkelas.Size = new Size(378, 32);
            cbkelas.TabIndex = 32;
            cbkelas.Text = "Pilih Kelas ~";
            cbkelas.SelectedIndexChanged += cbkelas_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Constantia", 10F);
            label8.Location = new Point(26, 223);
            label8.Name = "label8";
            label8.Size = new Size(67, 24);
            label8.TabIndex = 31;
            label8.Text = "Kelas :";
            // 
            // rbpr
            // 
            rbpr.AutoSize = true;
            rbpr.Font = new Font("Constantia", 9F);
            rbpr.Location = new Point(301, 174);
            rbpr.Name = "rbpr";
            rbpr.Size = new Size(45, 26);
            rbpr.TabIndex = 30;
            rbpr.TabStop = true;
            rbpr.Text = "P";
            rbpr.UseVisualStyleBackColor = true;
         //   rbpr.CheckedChanged += rbpr_CheckedChanged;
            // 
            // rblaki
            // 
            rblaki.AutoSize = true;
            rblaki.Font = new Font("Constantia", 10F);
            rblaki.Location = new Point(172, 172);
            rblaki.Name = "rblaki";
            rblaki.Size = new Size(46, 28);
            rblaki.TabIndex = 29;
            rblaki.TabStop = true;
            rblaki.Text = "L";
            rblaki.UseVisualStyleBackColor = true;
          //  rblaki.CheckedChanged += rblaki_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Constantia", 10F);
            label7.Location = new Point(26, 172);
            label7.Name = "label7";
            label7.Size = new Size(141, 24);
            label7.TabIndex = 28;
            label7.Text = "Jenis Kelamin :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Constantia", 10F);
            label6.Location = new Point(26, 118);
            label6.Name = "label6";
            label6.Size = new Size(72, 24);
            label6.TabIndex = 26;
            label6.Text = "Nama :";
            // 
            // txtnama
            // 
            txtnama.Font = new Font("Constantia", 10F);
            txtnama.Location = new Point(132, 118);
            txtnama.Name = "txtnama";
            txtnama.Size = new Size(378, 32);
            txtnama.TabIndex = 27;
        //    txtnama.TextChanged += txtnama_TextChanged;
            // 
            // btnEkspor
            // 
            btnEkspor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEkspor.Location = new Point(318, 476);
            btnEkspor.Name = "btnEkspor";
            btnEkspor.Size = new Size(121, 42);
            btnEkspor.TabIndex = 28;
            btnEkspor.Text = "Ekspor";
            btnEkspor.UseVisualStyleBackColor = true;
            btnEkspor.Click += btnEkspor_Click;
            // 
            // btnimpor
            // 
            btnimpor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnimpor.Location = new Point(518, 476);
            btnimpor.Name = "btnimpor";
            btnimpor.Size = new Size(121, 42);
            btnimpor.TabIndex = 29;
            btnimpor.Text = "Impor";
            btnimpor.UseVisualStyleBackColor = true;
            btnimpor.Click += btnimpor_Click;
            // 
            // Formtambahsiswa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1460, 1107);
            Controls.Add(btnimpor);
            Controls.Add(btnEkspor);
            Controls.Add(groupBox4);
            Controls.Add(txtcari);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Name = "Formtambahsiswa";
            Text = "Formtambahsiswa";
     //       Load += Formtambahsiswa_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
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
        private Button btnEkspor;
        private Button btnimpor;
    }
}