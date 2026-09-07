namespace TUGAS_4
{
    partial class FormLimas
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblHasil = new Label();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnHitung = new Button();
            txtTinggi = new TextBox();
            txtLebar = new TextBox();
            txtPanjang = new TextBox();
            btnKembali = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 62);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 0;
            label1.Text = "Panjang";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(101, 118);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 1;
            label2.Text = "Lebar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 175);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 2;
            label3.Text = "Tinggi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(101, 235);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 3;
            label4.Text = "Hasil";
            // 
            // lblHasil
            // 
            lblHasil.Location = new Point(389, 237);
            lblHasil.Name = "lblHasil";
            lblHasil.Size = new Size(100, 23);
            lblHasil.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnHitung);
            groupBox1.Controls.Add(txtTinggi);
            groupBox1.Controls.Add(txtLebar);
            groupBox1.Controls.Add(txtPanjang);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblHasil);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(38, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(544, 353);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "CALCULATOR";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(282, 294);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 10;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(400, 294);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(112, 34);
            btnHitung.TabIndex = 8;
            btnHitung.Text = "=";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // txtTinggi
            // 
            txtTinggi.Location = new Point(367, 169);
            txtTinggi.Name = "txtTinggi";
            txtTinggi.Size = new Size(150, 31);
            txtTinggi.TabIndex = 7;
            // 
            // txtLebar
            // 
            txtLebar.Location = new Point(367, 112);
            txtLebar.Name = "txtLebar";
            txtLebar.Size = new Size(150, 31);
            txtLebar.TabIndex = 6;
            // 
            // txtPanjang
            // 
            txtPanjang.Location = new Point(367, 56);
            txtPanjang.Name = "txtPanjang";
            txtPanjang.Size = new Size(150, 31);
            txtPanjang.TabIndex = 5;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(438, 386);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(112, 34);
            btnKembali.TabIndex = 6;
            btnKembali.Text = "Back";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormLimas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 450);
            Controls.Add(btnKembali);
            Controls.Add(groupBox1);
            Name = "FormLimas";
            Text = "FormLimas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblHasil;
        private GroupBox groupBox1;
        private Button btnHitung;
        private TextBox txtTinggi;
        private TextBox txtLebar;
        private TextBox txtPanjang;
        private Button btnKembali;
        private Button btnClear;
    }
}