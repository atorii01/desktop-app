namespace Latihan_2
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
            txtVolume = new TextBox();
            txtTinggi = new TextBox();
            txtLebar = new TextBox();
            txtPanjang = new TextBox();
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
            groupBox1.Controls.Add(txtVolume);
            groupBox1.Controls.Add(txtTinggi);
            groupBox1.Controls.Add(txtLebar);
            groupBox1.Controls.Add(txtPanjang);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(81, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(464, 326);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menghitung volume balok";
            // 
            // txtVolume
            // 
            txtVolume.Enabled = false;
            txtVolume.Location = new Point(261, 239);
            txtVolume.Name = "txtVolume";
            txtVolume.Size = new Size(150, 31);
            txtVolume.TabIndex = 7;
            // 
            // txtTinggi
            // 
            txtTinggi.Location = new Point(261, 169);
            txtTinggi.Name = "txtTinggi";
            txtTinggi.Size = new Size(150, 31);
            txtTinggi.TabIndex = 6;
            // 
            // txtLebar
            // 
            txtLebar.Location = new Point(261, 106);
            txtLebar.Name = "txtLebar";
            txtLebar.Size = new Size(150, 31);
            txtLebar.TabIndex = 5;
            // 
            // txtPanjang
            // 
            txtPanjang.Location = new Point(261, 49);
            txtPanjang.Name = "txtPanjang";
            txtPanjang.Size = new Size(150, 31);
            txtPanjang.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 239);
            label4.Name = "label4";
            label4.Size = new Size(72, 25);
            label4.TabIndex = 3;
            label4.Text = "Volume";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 172);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 2;
            label3.Text = "Tinggi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 106);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 1;
            label2.Text = "Lebar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 43);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 0;
            label1.Text = "Panjang";
            // 
            // tblHitung
            // 
            tblHitung.Location = new Point(160, 390);
            tblHitung.Name = "tblHitung";
            tblHitung.Size = new Size(112, 34);
            tblHitung.TabIndex = 1;
            tblHitung.Text = "Hitung";
            tblHitung.UseVisualStyleBackColor = true;
            tblHitung.Click += tblHitung_Click;
            // 
            // tblClear
            // 
            tblClear.Location = new Point(278, 390);
            tblClear.Name = "tblClear";
            tblClear.Size = new Size(112, 34);
            tblClear.TabIndex = 2;
            tblClear.Text = "Clear";
            tblClear.UseVisualStyleBackColor = true;
            tblClear.Click += tblClear_Click;
            // 
            // tblClose
            // 
            tblClose.Location = new Point(396, 390);
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
            Text = "Hitung Volume";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtVolume;
        private TextBox txtTinggi;
        private TextBox txtLebar;
        private TextBox txtPanjang;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button tblHitung;
        private Button tblClear;
        private Button tblClose;
    }
}
