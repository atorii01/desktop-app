namespace Latihan_15
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
            lblJurusanCocok = new Label();
            label5 = new Label();
            btnTentukan = new Button();
            cbxMinat = new ComboBox();
            txtMatematika = new TextBox();
            txtIPA = new TextBox();
            txtBahasaInggris = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 52);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 0;
            label1.Text = "Minat :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 111);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 1;
            label2.Text = "Nilai Matematika :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 171);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 2;
            label3.Text = "Nilai IPA :";
            // 
            // lblJurusanCocok
            // 
            lblJurusanCocok.AutoSize = true;
            lblJurusanCocok.Location = new Point(71, 371);
            lblJurusanCocok.Name = "lblJurusanCocok";
            lblJurusanCocok.Size = new Size(178, 25);
            lblJurusanCocok.TabIndex = 3;
            lblJurusanCocok.Text = "Jurusan Yang Cocok :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 222);
            label5.Name = "label5";
            label5.Size = new Size(118, 25);
            label5.TabIndex = 4;
            label5.Text = "Nilai B.Inggis:";
            // 
            // btnTentukan
            // 
            btnTentukan.Location = new Point(71, 276);
            btnTentukan.Name = "btnTentukan";
            btnTentukan.Size = new Size(499, 69);
            btnTentukan.TabIndex = 5;
            btnTentukan.Text = "Tentukan Jurusan";
            btnTentukan.UseVisualStyleBackColor = true;
            btnTentukan.Click += btnTentukan_Click;
            // 
            // cbxMinat
            // 
            cbxMinat.FormattingEnabled = true;
            cbxMinat.Items.AddRange(new object[] { "Teknologi", "Bisnis", "Seni" });
            cbxMinat.Location = new Point(233, 49);
            cbxMinat.Name = "cbxMinat";
            cbxMinat.Size = new Size(337, 33);
            cbxMinat.TabIndex = 6;
            // 
            // txtMatematika
            // 
            txtMatematika.Location = new Point(233, 108);
            txtMatematika.Name = "txtMatematika";
            txtMatematika.Size = new Size(337, 31);
            txtMatematika.TabIndex = 7;
            // 
            // txtIPA
            // 
            txtIPA.Location = new Point(233, 168);
            txtIPA.Name = "txtIPA";
            txtIPA.Size = new Size(337, 31);
            txtIPA.TabIndex = 8;
            // 
            // txtBahasaInggris
            // 
            txtBahasaInggris.Location = new Point(233, 219);
            txtBahasaInggris.Name = "txtBahasaInggris";
            txtBahasaInggris.Size = new Size(337, 31);
            txtBahasaInggris.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 450);
            Controls.Add(txtBahasaInggris);
            Controls.Add(txtIPA);
            Controls.Add(txtMatematika);
            Controls.Add(cbxMinat);
            Controls.Add(btnTentukan);
            Controls.Add(label5);
            Controls.Add(lblJurusanCocok);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Penentuan Jurusan SMK";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblJurusanCocok;
        private Label label5;
        private Button btnTentukan;
        private ComboBox cbxMinat;
        private TextBox txtMatematika;
        private TextBox txtIPA;
        private TextBox txtBahasaInggris;
    }
}
