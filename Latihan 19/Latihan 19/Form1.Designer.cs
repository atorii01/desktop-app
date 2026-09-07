namespace Latihan_19
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox = new ListBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            rdbPerHari = new RadioButton();
            rdbPerMinggu = new RadioButton();
            rdbPerBulan = new RadioButton();
            rdbPerTahun = new RadioButton();
            btnHitung = new Button();
            btnClear = new Button();
            txtHasil = new TextBox();
            txtBunga = new TextBox();
            label2 = new Label();
            txtJumlahTahun = new TextBox();
            label3 = new Label();
            txtInvestasi = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 25;
            listBox.Location = new Point(451, 67);
            listBox.Name = "listBox";
            listBox.Size = new Size(337, 454);
            listBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 69);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 1;
            label1.Text = "Investasi :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbPerHari);
            groupBox1.Controls.Add(rdbPerMinggu);
            groupBox1.Controls.Add(rdbPerBulan);
            groupBox1.Controls.Add(rdbPerTahun);
            groupBox1.Location = new Point(20, 307);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(425, 216);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bunga Dibayarkan :";
            // 
            // rdbPerHari
            // 
            rdbPerHari.AutoSize = true;
            rdbPerHari.Location = new Point(220, 133);
            rdbPerHari.Name = "rdbPerHari";
            rdbPerHari.Size = new Size(98, 29);
            rdbPerHari.TabIndex = 3;
            rdbPerHari.TabStop = true;
            rdbPerHari.Text = "Per Hari";
            rdbPerHari.UseVisualStyleBackColor = true;
            rdbPerHari.CheckedChanged += rdbPerHari_CheckedChanged;
            // 
            // rdbPerMinggu
            // 
            rdbPerMinggu.AutoSize = true;
            rdbPerMinggu.Location = new Point(220, 49);
            rdbPerMinggu.Name = "rdbPerMinggu";
            rdbPerMinggu.Size = new Size(128, 29);
            rdbPerMinggu.TabIndex = 2;
            rdbPerMinggu.TabStop = true;
            rdbPerMinggu.Text = "Per Minggu";
            rdbPerMinggu.UseVisualStyleBackColor = true;
            rdbPerMinggu.CheckedChanged += rdbPerMinggu_CheckedChanged;
            // 
            // rdbPerBulan
            // 
            rdbPerBulan.AutoSize = true;
            rdbPerBulan.Location = new Point(34, 133);
            rdbPerBulan.Name = "rdbPerBulan";
            rdbPerBulan.Size = new Size(109, 29);
            rdbPerBulan.TabIndex = 1;
            rdbPerBulan.TabStop = true;
            rdbPerBulan.Text = "Per Bulan";
            rdbPerBulan.UseVisualStyleBackColor = true;
            rdbPerBulan.CheckedChanged += rdbPerBulan_CheckedChanged;
            // 
            // rdbPerTahun
            // 
            rdbPerTahun.AutoSize = true;
            rdbPerTahun.Location = new Point(34, 49);
            rdbPerTahun.Name = "rdbPerTahun";
            rdbPerTahun.Size = new Size(112, 29);
            rdbPerTahun.TabIndex = 0;
            rdbPerTahun.TabStop = true;
            rdbPerTahun.Text = "Per Tahun";
            rdbPerTahun.UseVisualStyleBackColor = true;
            rdbPerTahun.CheckedChanged += rdbPerTahun_CheckedChanged;
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(20, 542);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(397, 69);
            btnHitung.TabIndex = 3;
            btnHitung.Text = "Hitung";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(423, 542);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(365, 69);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtHasil
            // 
            txtHasil.Enabled = false;
            txtHasil.Location = new Point(12, 12);
            txtHasil.Name = "txtHasil";
            txtHasil.ReadOnly = true;
            txtHasil.Size = new Size(776, 31);
            txtHasil.TabIndex = 5;
            // 
            // txtBunga
            // 
            txtBunga.Location = new Point(20, 165);
            txtBunga.Name = "txtBunga";
            txtBunga.Size = new Size(425, 31);
            txtBunga.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 137);
            label2.Name = "label2";
            label2.Size = new Size(155, 25);
            label2.TabIndex = 6;
            label2.Text = "Bunga (dalam %) :";
            // 
            // txtJumlahTahun
            // 
            txtJumlahTahun.Location = new Point(20, 233);
            txtJumlahTahun.Name = "txtJumlahTahun";
            txtJumlahTahun.Size = new Size(425, 31);
            txtJumlahTahun.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 205);
            label3.Name = "label3";
            label3.Size = new Size(126, 25);
            label3.TabIndex = 8;
            label3.Text = "Berapa Tahun :";
            // 
            // txtInvestasi
            // 
            txtInvestasi.Location = new Point(20, 97);
            txtInvestasi.Name = "txtInvestasi";
            txtInvestasi.Size = new Size(425, 31);
            txtInvestasi.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 619);
            Controls.Add(txtInvestasi);
            Controls.Add(txtJumlahTahun);
            Controls.Add(label3);
            Controls.Add(txtBunga);
            Controls.Add(label2);
            Controls.Add(txtHasil);
            Controls.Add(btnClear);
            Controls.Add(btnHitung);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(listBox);
            Name = "Form1";
            Text = "Aplikasi Penghitungan Bunga Dengan For Loop";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rdbPerHari;
        private RadioButton rdbPerMinggu;
        private RadioButton rdbPerBulan;
        private RadioButton rdbPerTahun;
        private Button btnHitung;
        private Button btnClear;
        private TextBox txtHasil;
        private TextBox txtBunga;
        private Label label2;
        private TextBox txtJumlahTahun;
        private Label label3;
        private TextBox txtInvestasi;
    }
}
