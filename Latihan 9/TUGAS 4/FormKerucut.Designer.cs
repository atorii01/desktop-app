namespace TUGAS_4
{
    partial class FormKerucut
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
            btnHitung = new Button();
            txtTinggi = new TextBox();
            txtJariJari = new TextBox();
            lblHasil = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnKembali = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnHitung);
            groupBox1.Controls.Add(txtTinggi);
            groupBox1.Controls.Add(txtJariJari);
            groupBox1.Controls.Add(lblHasil);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(66, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(680, 335);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "CALCULATOR";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(422, 279);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(540, 279);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(112, 34);
            btnHitung.TabIndex = 2;
            btnHitung.Text = "=";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // txtTinggi
            // 
            txtTinggi.Location = new Point(337, 118);
            txtTinggi.Name = "txtTinggi";
            txtTinggi.Size = new Size(150, 31);
            txtTinggi.TabIndex = 5;
            // 
            // txtJariJari
            // 
            txtJariJari.Location = new Point(337, 47);
            txtJariJari.Name = "txtJariJari";
            txtJariJari.Size = new Size(150, 31);
            txtJariJari.TabIndex = 4;
            // 
            // lblHasil
            // 
            lblHasil.AutoSize = true;
            lblHasil.Location = new Point(387, 201);
            lblHasil.Name = "lblHasil";
            lblHasil.Size = new Size(0, 25);
            lblHasil.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 201);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 2;
            label3.Text = "Hasil";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 124);
            label2.Name = "label2";
            label2.Size = new Size(61, 25);
            label2.TabIndex = 1;
            label2.Text = "Tinggi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 53);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 0;
            label1.Text = "Jari-Jari";
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(606, 394);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(112, 34);
            btnKembali.TabIndex = 1;
            btnKembali.Text = "Back";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormKerucut
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKembali);
            Controls.Add(groupBox1);
            Name = "FormKerucut";
            Text = "FormKerucut";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtTinggi;
        private TextBox txtJariJari;
        private Label lblHasil;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnHitung;
        private Button btnKembali;
        private Button btnClear;
    }
}