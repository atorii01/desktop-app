namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormSp
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
            dataGridView1 = new DataGridView();
            btncetak = new Button();
            groupBox1 = new GroupBox();
            btnhapus = new Button();
            txtnis = new TextBox();
            txtNoSurat = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cbJenisSP = new ComboBox();
            cbStatus = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(39, 354);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1408, 611);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btncetak
            // 
            btncetak.BackColor = Color.PaleGreen;
            btncetak.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncetak.Location = new Point(1062, 28);
            btncetak.Name = "btncetak";
            btncetak.Size = new Size(161, 54);
            btncetak.TabIndex = 1;
            btncetak.Text = "Cetak";
            btncetak.UseVisualStyleBackColor = false;
            btncetak.Click += btncetak_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnhapus);
            groupBox1.Controls.Add(txtnis);
            groupBox1.Controls.Add(txtNoSurat);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btncetak);
            groupBox1.Controls.Add(cbJenisSP);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(39, 161);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1406, 158);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnhapus
            // 
            btnhapus.BackColor = Color.Salmon;
            btnhapus.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnhapus.Location = new Point(1062, 98);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(161, 54);
            btnhapus.TabIndex = 8;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = false;
            btnhapus.Click += btnhapus_Click;
            // 
            // txtnis
            // 
            txtnis.Enabled = false;
            txtnis.Location = new Point(711, 38);
            txtnis.Name = "txtnis";
            txtnis.Size = new Size(305, 29);
            txtnis.TabIndex = 7;
            // 
            // txtNoSurat
            // 
            txtNoSurat.Enabled = false;
            txtNoSurat.Location = new Point(711, 113);
            txtNoSurat.Name = "txtNoSurat";
            txtNoSurat.Size = new Size(305, 29);
            txtNoSurat.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 98);
            label2.Name = "label2";
            label2.Size = new Size(255, 29);
            label2.TabIndex = 5;
            label2.Text = "Jenis Surat Peringatan :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(227, 29);
            label1.TabIndex = 4;
            label1.Text = "Status                        :";
            // 
            // cbJenisSP
            // 
            cbJenisSP.FormattingEnabled = true;
            cbJenisSP.Items.AddRange(new object[] { "SP1", "SP2", "SP3" });
            cbJenisSP.Location = new Point(292, 98);
            cbJenisSP.Name = "cbJenisSP";
            cbJenisSP.Size = new Size(324, 30);
            cbJenisSP.TabIndex = 3;
            cbJenisSP.Text = "Pilih Jenis SP~";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Pending", "Tercetak" });
            cbStatus.Location = new Point(292, 36);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(324, 30);
            cbStatus.TabIndex = 2;
            cbStatus.Text = "Pilih Status~";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label3.Location = new Point(39, 36);
            label3.Name = "label3";
            label3.Size = new Size(871, 96);
            label3.TabIndex = 3;
            label3.Text = "Laporan Surat Peringatan";
            // 
            // FormSp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1829, 1010);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "FormSp";
            Text = "FormSp";
            Load += FormSp_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btncetak;
        private GroupBox groupBox1;
        private TextBox txtNoSurat;
        private Label label2;
        private Label label1;
        private ComboBox cbJenisSP;
        private ComboBox cbStatus;
        private TextBox txtnis;
        private Label label3;
        private Button btnhapus;
    }
}