namespace Latihan_3
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
            txtRerata = new TextBox();
            txtNilai3 = new TextBox();
            txtNilai2 = new TextBox();
            txtNilai1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tblHitung = new Button();
            tblClear = new Button();
            tblClose = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRerata);
            groupBox1.Controls.Add(txtNilai3);
            groupBox1.Controls.Add(txtNilai2);
            groupBox1.Controls.Add(txtNilai1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(37, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(575, 363);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menghitung Nilai Rerata";
            // 
            // txtRerata
            // 
            txtRerata.Location = new Point(313, 305);
            txtRerata.Name = "txtRerata";
            txtRerata.Size = new Size(150, 31);
            txtRerata.TabIndex = 7;
            // 
            // txtNilai3
            // 
            txtNilai3.Location = new Point(313, 222);
            txtNilai3.Name = "txtNilai3";
            txtNilai3.Size = new Size(150, 31);
            txtNilai3.TabIndex = 6;
            // 
            // txtNilai2
            // 
            txtNilai2.Location = new Point(313, 126);
            txtNilai2.Name = "txtNilai2";
            txtNilai2.Size = new Size(150, 31);
            txtNilai2.TabIndex = 5;
            // 
            // txtNilai1
            // 
            txtNilai1.Location = new Point(313, 45);
            txtNilai1.Name = "txtNilai1";
            txtNilai1.Size = new Size(150, 31);
            txtNilai1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 305);
            label4.Name = "label4";
            label4.Size = new Size(61, 25);
            label4.TabIndex = 3;
            label4.Text = "Rerata";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 225);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 2;
            label3.Text = "Nilai Agama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 132);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 1;
            label2.Text = "Nilai Bahasa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 45);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 0;
            label1.Text = "Nilai Matematika";
            // 
            // tblHitung
            // 
            tblHitung.Location = new Point(179, 395);
            tblHitung.Name = "tblHitung";
            tblHitung.Size = new Size(112, 34);
            tblHitung.TabIndex = 1;
            tblHitung.Text = "Hitung";
            tblHitung.UseVisualStyleBackColor = true;
            tblHitung.Click += tblHitung_Click;
            // 
            // tblClear
            // 
            tblClear.Location = new Point(297, 395);
            tblClear.Name = "tblClear";
            tblClear.Size = new Size(112, 34);
            tblClear.TabIndex = 2;
            tblClear.Text = "Clear";
            tblClear.UseVisualStyleBackColor = true;
            tblClear.Click += tblClear_Click;
            // 
            // tblClose
            // 
            tblClose.Location = new Point(415, 395);
            tblClose.Name = "tblClose";
            tblClose.Size = new Size(112, 34);
            tblClose.TabIndex = 3;
            tblClose.Text = "Close";
            tblClose.UseVisualStyleBackColor = true;
            tblClose.Click += tblClose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private TextBox txtRerata;
        private TextBox txtNilai3;
        private TextBox txtNilai2;
        private TextBox txtNilai1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button tblHitung;
        private Button tblClear;
        private Button tblClose;
    }
}
