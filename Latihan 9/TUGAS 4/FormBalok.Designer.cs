namespace TUGAS_4
{
    partial class FormBalok
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
            groupBox1 = new GroupBox();
            btnClear = new Button();
            lblHasil = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTinggi = new TextBox();
            txtLebar = new TextBox();
            txtPanjang = new TextBox();
            btnHitung = new Button();
            btnKembali = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(lblHasil);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTinggi);
            groupBox1.Controls.Add(txtLebar);
            groupBox1.Controls.Add(txtPanjang);
            groupBox1.Controls.Add(btnHitung);
            groupBox1.Location = new Point(61, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(687, 320);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "CALCULATOR";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(427, 268);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 9;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblHasil
            // 
            lblHasil.AutoSize = true;
            lblHasil.Location = new Point(409, 229);
            lblHasil.Name = "lblHasil";
            lblHasil.Size = new Size(0, 25);
            lblHasil.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 229);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 7;
            label4.Text = "Hasil";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(151, 171);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 6;
            label3.Text = "Tinggi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 105);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 5;
            label2.Text = "Lebar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 46);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 4;
            label1.Text = "Panjang";
            // 
            // txtTinggi
            // 
            txtTinggi.Location = new Point(375, 168);
            txtTinggi.Name = "txtTinggi";
            txtTinggi.Size = new Size(150, 31);
            txtTinggi.TabIndex = 3;
            // 
            // txtLebar
            // 
            txtLebar.Location = new Point(375, 102);
            txtLebar.Name = "txtLebar";
            txtLebar.Size = new Size(150, 31);
            txtLebar.TabIndex = 2;
            // 
            // txtPanjang
            // 
            txtPanjang.Location = new Point(375, 43);
            txtPanjang.Name = "txtPanjang";
            txtPanjang.Size = new Size(150, 31);
            txtPanjang.TabIndex = 1;
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(545, 268);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(112, 34);
            btnHitung.TabIndex = 0;
            btnHitung.Text = "=";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(606, 387);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(112, 34);
            btnKembali.TabIndex = 1;
            btnKembali.Text = "Back";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormBalok
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKembali);
            Controls.Add(groupBox1);
            Name = "FormBalok";
            Text = "FormBalok";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnHitung;
        private Button btnKembali;
        private Label lblHasil;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTinggi;
        private TextBox txtLebar;
        private TextBox txtPanjang;
        private Button btnClear;
    }
}