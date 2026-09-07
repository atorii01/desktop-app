namespace Latihan_4
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
            groupBox1 = new GroupBox();
            txtKeterangan = new TextBox();
            txtRerata = new TextBox();
            txtNilai3 = new TextBox();
            txtNilai2 = new TextBox();
            txtNilai1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tblHitung = new Button();
            tblClear = new Button();
            tblClose = new Button();
            tblSave = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtKeterangan);
            groupBox1.Controls.Add(txtRerata);
            groupBox1.Controls.Add(txtNilai3);
            groupBox1.Controls.Add(txtNilai2);
            groupBox1.Controls.Add(txtNilai1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(602, 365);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menghitung Nilai rerata";
            // 
            // txtKeterangan
            // 
            txtKeterangan.Enabled = false;
            txtKeterangan.Location = new Point(225, 313);
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.Size = new Size(334, 31);
            txtKeterangan.TabIndex = 9;
            // 
            // txtRerata
            // 
            txtRerata.Enabled = false;
            txtRerata.Location = new Point(225, 244);
            txtRerata.Name = "txtRerata";
            txtRerata.Size = new Size(150, 31);
            txtRerata.TabIndex = 8;
            // 
            // txtNilai3
            // 
            txtNilai3.Location = new Point(225, 171);
            txtNilai3.Name = "txtNilai3";
            txtNilai3.Size = new Size(150, 31);
            txtNilai3.TabIndex = 7;
            // 
            // txtNilai2
            // 
            txtNilai2.Location = new Point(225, 106);
            txtNilai2.Name = "txtNilai2";
            txtNilai2.Size = new Size(150, 31);
            txtNilai2.TabIndex = 6;
            // 
            // txtNilai1
            // 
            txtNilai1.Location = new Point(225, 48);
            txtNilai1.Name = "txtNilai1";
            txtNilai1.Size = new Size(150, 31);
            txtNilai1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 313);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 4;
            label5.Text = "Keterangan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 244);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 3;
            label4.Text = "Nilai Rerata";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 171);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 2;
            label3.Text = "Nilai Bahasa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 106);
            label2.Name = "label2";
            label2.Size = new Size(144, 25);
            label2.TabIndex = 1;
            label2.Text = "Nilai Matematika";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 39);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 0;
            label1.Text = "Nilai Agama";
            // 
            // tblHitung
            // 
            tblHitung.Location = new Point(98, 404);
            tblHitung.Name = "tblHitung";
            tblHitung.Size = new Size(112, 34);
            tblHitung.TabIndex = 1;
            tblHitung.Text = "Hitung";
            tblHitung.UseVisualStyleBackColor = true;
            tblHitung.Click += tblHitung_Click;
            // 
            // tblClear
            // 
            tblClear.Location = new Point(216, 404);
            tblClear.Name = "tblClear";
            tblClear.Size = new Size(112, 34);
            tblClear.TabIndex = 2;
            tblClear.Text = "Clear";
            tblClear.UseVisualStyleBackColor = true;
            tblClear.Click += tblClear_Click;
            // 
            // tblClose
            // 
            tblClose.Location = new Point(334, 404);
            tblClose.Name = "tblClose";
            tblClose.Size = new Size(112, 34);
            tblClose.TabIndex = 3;
            tblClose.Text = "Close";
            tblClose.UseVisualStyleBackColor = true;
            tblClose.Click += tblClose_Click;
            // 
            // tblSave
            // 
            tblSave.Location = new Point(452, 404);
            tblSave.Name = "tblSave";
            tblSave.Size = new Size(112, 34);
            tblSave.TabIndex = 4;
            tblSave.Text = "Save";
            tblSave.UseVisualStyleBackColor = true;
            tblSave.Click += tblSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblSave);
            Controls.Add(tblClose);
            Controls.Add(tblClear);
            Controls.Add(tblHitung);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Hitung Rerata";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtKeterangan;
        private TextBox txtRerata;
        private TextBox txtNilai3;
        private TextBox txtNilai2;
        private TextBox txtNilai1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button tblHitung;
        private Button tblClear;
        private Button tblClose;
        private Button tblSave;
    }
}
