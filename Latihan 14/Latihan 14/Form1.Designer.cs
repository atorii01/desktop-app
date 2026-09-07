namespace Latihan_14
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtRadius = new TextBox();
            txtTinggi = new TextBox();
            txtPanjang = new TextBox();
            txtLebar = new TextBox();
            txtLuasBangun = new TextBox();
            btnHitung = new Button();
            cmbBangun = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 57);
            label1.Name = "label1";
            label1.Size = new Size(200, 25);
            label1.TabIndex = 0;
            label1.Text = "Pilih Salah Satu Bangun:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 141);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 1;
            label2.Text = "1. Lingkaran";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 141);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 2;
            label3.Text = "2. Jajar Genjang";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(615, 141);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 3;
            label4.Text = "3. Layang-Layang";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 225);
            label5.Name = "label5";
            label5.Size = new Size(65, 25);
            label5.TabIndex = 4;
            label5.Text = "Radius";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(63, 295);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 5;
            label6.Text = "Tinggi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(395, 225);
            label7.Name = "label7";
            label7.Size = new Size(74, 25);
            label7.TabIndex = 6;
            label7.Text = "Panjang";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(395, 295);
            label8.Name = "label8";
            label8.Size = new Size(55, 25);
            label8.TabIndex = 7;
            label8.Text = "Lebar";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(63, 396);
            label9.Name = "label9";
            label9.Size = new Size(112, 25);
            label9.TabIndex = 8;
            label9.Text = "Luas Bangun";
            // 
            // txtRadius
            // 
            txtRadius.Location = new Point(174, 222);
            txtRadius.Name = "txtRadius";
            txtRadius.Size = new Size(150, 31);
            txtRadius.TabIndex = 10;
            // 
            // txtTinggi
            // 
            txtTinggi.Location = new Point(174, 292);
            txtTinggi.Name = "txtTinggi";
            txtTinggi.Size = new Size(150, 31);
            txtTinggi.TabIndex = 11;
            // 
            // txtPanjang
            // 
            txtPanjang.Location = new Point(526, 222);
            txtPanjang.Name = "txtPanjang";
            txtPanjang.Size = new Size(150, 31);
            txtPanjang.TabIndex = 12;
            // 
            // txtLebar
            // 
            txtLebar.Location = new Point(526, 292);
            txtLebar.Name = "txtLebar";
            txtLebar.Size = new Size(150, 31);
            txtLebar.TabIndex = 13;
            // 
            // txtLuasBangun
            // 
            txtLuasBangun.Location = new Point(181, 393);
            txtLuasBangun.Name = "txtLuasBangun";
            txtLuasBangun.Size = new Size(584, 31);
            txtLuasBangun.TabIndex = 14;
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(63, 343);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(702, 34);
            btnHitung.TabIndex = 15;
            btnHitung.Text = "Hitung Luas Bangun";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // cmbBangun
            // 
            cmbBangun.FormattingEnabled = true;
            cmbBangun.Location = new Point(278, 54);
            cmbBangun.Name = "cmbBangun";
            cmbBangun.Size = new Size(201, 33);
            cmbBangun.TabIndex = 16;
            cmbBangun.SelectedIndexChanged += cmbBangun_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbBangun);
            Controls.Add(btnHitung);
            Controls.Add(txtLuasBangun);
            Controls.Add(txtLebar);
            Controls.Add(txtPanjang);
            Controls.Add(txtTinggi);
            Controls.Add(txtRadius);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Hitung Luas Bangun";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtRadius;
        private TextBox txtTinggi;
        private TextBox txtPanjang;
        private TextBox txtLebar;
        private TextBox txtLuasBangun;
        private Button btnHitung;
        private ComboBox cmbBangun;
    }
}
