namespace Latihan_1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtAngka1 = new TextBox();
            txtAngka2 = new TextBox();
            txtHasil = new TextBox();
            tblJumlah = new Button();
            tblKurang = new Button();
            tblBagi = new Button();
            tblClear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 60);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "Angka 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 129);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "Angka 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 200);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 2;
            label3.Text = "Hasil";
            // 
            // txtAngka1
            // 
            txtAngka1.Location = new Point(296, 69);
            txtAngka1.Name = "txtAngka1";
            txtAngka1.Size = new Size(150, 31);
            txtAngka1.TabIndex = 3;
            // 
            // txtAngka2
            // 
            txtAngka2.Location = new Point(296, 129);
            txtAngka2.Name = "txtAngka2";
            txtAngka2.Size = new Size(150, 31);
            txtAngka2.TabIndex = 4;
            // 
            // txtHasil
            // 
            txtHasil.Location = new Point(296, 200);
            txtHasil.Name = "txtHasil";
            txtHasil.Size = new Size(150, 31);
            txtHasil.TabIndex = 5;
            // 
            // tblJumlah
            // 
            tblJumlah.Location = new Point(53, 354);
            tblJumlah.Name = "tblJumlah";
            tblJumlah.Size = new Size(112, 34);
            tblJumlah.TabIndex = 6;
            tblJumlah.Text = "+";
            tblJumlah.UseVisualStyleBackColor = true;
            tblJumlah.Click += tblJumlah_Click;
            // 
            // tblKurang
            // 
            tblKurang.Location = new Point(171, 354);
            tblKurang.Name = "tblKurang";
            tblKurang.Size = new Size(112, 34);
            tblKurang.TabIndex = 7;
            tblKurang.Text = "-";
            tblKurang.UseVisualStyleBackColor = true;
            tblKurang.Click += tblKurang_Click;
            // 
            // tblBagi
            // 
            tblBagi.Location = new Point(289, 354);
            tblBagi.Name = "tblBagi";
            tblBagi.Size = new Size(112, 34);
            tblBagi.TabIndex = 8;
            tblBagi.Text = "/";
            tblBagi.UseVisualStyleBackColor = true;
            tblBagi.Click += tblBagi_Click;
            // 
            // tblClear
            // 
            tblClear.Location = new Point(407, 354);
            tblClear.Name = "tblClear";
            tblClear.Size = new Size(112, 34);
            tblClear.TabIndex = 9;
            tblClear.Text = "C";
            tblClear.UseVisualStyleBackColor = true;
            tblClear.Click += tblClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblClear);
            Controls.Add(tblBagi);
            Controls.Add(tblKurang);
            Controls.Add(tblJumlah);
            Controls.Add(txtHasil);
            Controls.Add(txtAngka2);
            Controls.Add(txtAngka1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Hitung Volume";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtAngka1;
        private TextBox txtAngka2;
        private TextBox txtHasil;
        private Button tblJumlah;
        private Button tblKurang;
        private Button tblBagi;
        private Button tblClear;
    }
}
