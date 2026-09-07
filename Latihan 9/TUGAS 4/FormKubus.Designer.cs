namespace TUGAS_4
{
    partial class FormKubus
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
            btnKembali = new Button();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            txtSisi = new TextBox();
            lblHasil = new Label();
            label2 = new Label();
            label1 = new Label();
            btnHitung = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(581, 382);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(112, 34);
            btnKembali.TabIndex = 0;
            btnKembali.Text = "Back";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(txtSisi);
            groupBox1.Controls.Add(lblHasil);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnHitung);
            groupBox1.Location = new Point(58, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(680, 313);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "CALCULATOR";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(405, 256);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 7;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtSisi
            // 
            txtSisi.Location = new Point(323, 74);
            txtSisi.Name = "txtSisi";
            txtSisi.Size = new Size(150, 31);
            txtSisi.TabIndex = 6;
            // 
            // lblHasil
            // 
            lblHasil.AutoSize = true;
            lblHasil.Location = new Point(367, 158);
            lblHasil.Name = "lblHasil";
            lblHasil.Size = new Size(0, 25);
            lblHasil.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 77);
            label2.Name = "label2";
            label2.Size = new Size(38, 25);
            label2.TabIndex = 4;
            label2.Text = "Sisi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 158);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 3;
            label1.Text = "Hasil";
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(523, 256);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(112, 34);
            btnHitung.TabIndex = 2;
            btnHitung.Text = "=";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // FormKubus
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(btnKembali);
            Name = "FormKubus";
            Text = "FormKubus";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnKembali;
        private GroupBox groupBox1;
        private TextBox txtSisi;
        private Label lblHasil;
        private Label label2;
        private Label label1;
        private Button btnHitung;
        private Button btnClear;
    }
}