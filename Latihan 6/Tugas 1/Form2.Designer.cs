namespace Tugas_1
{
    partial class Form2
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
            lblAlamat = new Label();
            lblEmail = new Label();
            lblAgama = new Label();
            lblJenisKelamin = new Label();
            lblNama = new Label();
            lblNoKTP = new Label();
            lblTTL = new Label();
            groupBox1 = new GroupBox();
            label11 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblAlamat
            // 
            lblAlamat.AutoSize = true;
            lblAlamat.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblAlamat.Location = new Point(40, 476);
            lblAlamat.Name = "lblAlamat";
            lblAlamat.Size = new Size(67, 19);
            lblAlamat.TabIndex = 27;
            lblAlamat.Text = "ALAMAT";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblEmail.Location = new Point(40, 400);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 19);
            lblEmail.TabIndex = 26;
            lblEmail.Text = "EMAIL";
            // 
            // lblAgama
            // 
            lblAgama.AutoSize = true;
            lblAgama.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblAgama.Location = new Point(40, 339);
            lblAgama.Name = "lblAgama";
            lblAgama.Size = new Size(63, 19);
            lblAgama.TabIndex = 25;
            lblAgama.Text = "AGAMA";
            // 
            // lblJenisKelamin
            // 
            lblJenisKelamin.AutoSize = true;
            lblJenisKelamin.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblJenisKelamin.Location = new Point(40, 276);
            lblJenisKelamin.Name = "lblJenisKelamin";
            lblJenisKelamin.Size = new Size(112, 19);
            lblJenisKelamin.TabIndex = 24;
            lblJenisKelamin.Text = "JENIS KELAMIN";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblNama.Location = new Point(40, 153);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(54, 19);
            lblNama.TabIndex = 23;
            lblNama.Text = "NAMA";
            // 
            // lblNoKTP
            // 
            lblNoKTP.AutoSize = true;
            lblNoKTP.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblNoKTP.Location = new Point(40, 94);
            lblNoKTP.Name = "lblNoKTP";
            lblNoKTP.Size = new Size(62, 19);
            lblNoKTP.TabIndex = 22;
            lblNoKTP.Text = "NO-KTP";
            // 
            // lblTTL
            // 
            lblTTL.AutoSize = true;
            lblTTL.Font = new Font("Calibri", 8F, FontStyle.Bold);
            lblTTL.Location = new Point(40, 211);
            lblTTL.Name = "lblTTL";
            lblTTL.Size = new Size(32, 19);
            lblTTL.TabIndex = 21;
            lblTTL.Text = "TTL";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(lblTTL);
            groupBox1.Controls.Add(lblNoKTP);
            groupBox1.Controls.Add(lblNama);
            groupBox1.Controls.Add(lblJenisKelamin);
            groupBox1.Controls.Add(lblAgama);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(lblAlamat);
            groupBox1.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(914, 754);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hasil";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label11.Location = new Point(185, 276);
            label11.Name = "label11";
            label11.Size = new Size(0, 19);
            label11.TabIndex = 31;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 778);
            Controls.Add(groupBox1);
            Name = "Form2";
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblAlamat;
        private Label lblEmail;
        private Label lblAgama;
        private Label lblJenisKelamin;
        private Label lblNama;
        private Label lblNoKTP;
        private Label lblTTL;
        private GroupBox groupBox1;
        private Label label11;
    }
}