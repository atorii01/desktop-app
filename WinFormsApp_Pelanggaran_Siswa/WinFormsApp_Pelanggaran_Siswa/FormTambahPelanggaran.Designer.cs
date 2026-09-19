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
            label4 = new Label();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            groupBox4.Location = new Point(96, 108);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1330, 337);
            groupBox4.TabIndex = 34;
            groupBox4.TabStop = false;
            // 
            // cbJenis
            // 
            cbJenis.Font = new Font("Constantia", 10F);
            cbJenis.FormattingEnabled = true;
            cbJenis.Items.AddRange(new object[] { "Ringan", "Sedang ", "Berat", "Sangat Berat" });
            cbJenis.Location = new Point(877, 55);
            cbJenis.Name = "cbJenis";
            cbJenis.Size = new Size(378, 32);
            cbJenis.TabIndex = 44;
            cbJenis.Text = "Pilih Jenis~";
            // 
            // txtKodeJenis
            // 
            txtKodeJenis.Enabled = false;
            txtKodeJenis.Font = new Font("Constantia", 10F);
            txtKodeJenis.Location = new Point(208, 57);
            txtKodeJenis.Name = "txtKodeJenis";
            txtKodeJenis.ReadOnly = true;
            txtKodeJenis.Size = new Size(378, 32);
            txtKodeJenis.TabIndex = 43;
            // 
            // txtnilaiPoint
            // 
            txtnilaiPoint.Font = new Font("Constantia", 10F);
            txtnilaiPoint.Location = new Point(877, 123);
            txtnilaiPoint.Name = "txtnilaiPoint";
            txtnilaiPoint.Size = new Size(378, 32);
            txtnilaiPoint.TabIndex = 41;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ActiveCaption;
            btnEdit.Font = new Font("Constantia", 10F);
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(446, 224);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(159, 65);
            btnEdit.TabIndex = 39;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ActiveCaption;
            btnUpdate.Font = new Font("Constantia", 10F);
            btnUpdate.ForeColor = SystemColors.ControlLightLight;
            btnUpdate.Location = new Point(235, 224);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(165, 65);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnhapus
            // 
            btnhapus.BackColor = SystemColors.ActiveCaption;
            btnhapus.Font = new Font("Constantia", 10F);
            btnhapus.ForeColor = SystemColors.ControlLightLight;
            btnhapus.Location = new Point(640, 227);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(145, 62);
            btnhapus.TabIndex = 37;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = false;
            // 
            // btnbatal
            // 
            btnbatal.BackColor = SystemColors.ActiveCaption;
            btnbatal.Font = new Font("Constantia", 10F);
            btnbatal.ForeColor = SystemColors.ControlLightLight;
            btnbatal.Location = new Point(826, 227);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(154, 62);
            btnbatal.TabIndex = 36;
            btnbatal.Text = "Batal";
            btnbatal.UseVisualStyleBackColor = false;
            // 
            // btntambah
            // 
            btntambah.BackColor = SystemColors.ActiveCaption;
            btntambah.Font = new Font("Constantia", 10F);
            btntambah.ForeColor = SystemColors.ControlLightLight;
            btntambah.Location = new Point(46, 224);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(156, 65);
            btntambah.TabIndex = 35;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Constantia", 10F);
            label9.Location = new Point(674, 123);
            label9.Name = "label9";
            label9.Size = new Size(185, 24);
            label9.TabIndex = 33;
            label9.Text = "Nilai Point               :";
            // 
            // txtnotelp
            // 
            txtnotelp.Font = new Font("Constantia", 10F);
            txtnotelp.Location = new Point(208, 109);
            txtnotelp.Name = "txtnotelp";
            txtnotelp.Size = new Size(378, 32);
            txtnotelp.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Constantia", 10F);
            label8.Location = new Point(674, 57);
            label8.Name = "label8";
            label8.Size = new Size(176, 24);
            label8.TabIndex = 31;
            label8.Text = "Jenis Pelanggaran :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Constantia", 10F);
            label7.Location = new Point(16, 112);
            label7.Name = "label7";
            label7.Size = new Size(186, 24);
            label7.TabIndex = 28;
            label7.Text = "Nama Pelanggaran :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Constantia", 10F);
            label6.Location = new Point(18, 55);
            label6.Name = "label6";
            label6.Size = new Size(177, 24);
            label6.TabIndex = 26;
            label6.Text = "Kode Jenis              :";
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(847, 479);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 33;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(96, 548);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1320, 471);
            dataGridView1.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(627, 96);
            label4.TabIndex = 32;
            label4.Text = "Jenis Pelanggaran";
            label4.Click += label4_Click;
            // 
            // FormTambahPelanggaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1518, 1114);
            Controls.Add(groupBox4);
            Controls.Add(txtcari);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Name = "FormTambahPelanggaran";
            Text = "FormTambahPelanggaran";
            Load += FormTambahPelanggaran_Load;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Label label4;
        private TextBox txtnilaiPoint;
        private TextBox txtKodeJenis;
        private ComboBox cbJenis;
    }
}