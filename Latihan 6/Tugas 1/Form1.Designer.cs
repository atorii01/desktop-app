namespace Tugas_1
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            dateTanggalLahir = new DateTimePicker();
            txtAlamat = new RichTextBox();
            comboAgama = new ComboBox();
            comboJenisKelamin = new ComboBox();
            comboTempatLahir = new ComboBox();
            txtEmail = new TextBox();
            txtNama = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            btnSubmit = new Button();
            txtNoKTP = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNoKTP);
            groupBox1.Controls.Add(dateTanggalLahir);
            groupBox1.Controls.Add(txtAlamat);
            groupBox1.Controls.Add(comboAgama);
            groupBox1.Controls.Add(comboJenisKelamin);
            groupBox1.Controls.Add(comboTempatLahir);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtNama);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(873, 690);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "BIODATA SISWA/I";
            // 
            // dateTanggalLahir
            // 
            dateTanggalLahir.Font = new Font("Calibri", 8F, FontStyle.Bold);
            dateTanggalLahir.Location = new Point(549, 190);
            dateTanggalLahir.Name = "dateTanggalLahir";
            dateTanggalLahir.Size = new Size(300, 27);
            dateTanggalLahir.TabIndex = 20;
            // 
            // txtAlamat
            // 
            txtAlamat.Font = new Font("Calibri", 8F, FontStyle.Bold);
            txtAlamat.Location = new Point(267, 455);
            txtAlamat.Name = "txtAlamat";
            txtAlamat.Size = new Size(582, 214);
            txtAlamat.TabIndex = 19;
            txtAlamat.Text = "";
            // 
            // comboAgama
            // 
            comboAgama.Font = new Font("Calibri", 8F, FontStyle.Bold);
            comboAgama.FormattingEnabled = true;
            comboAgama.Location = new Point(267, 318);
            comboAgama.Name = "comboAgama";
            comboAgama.Size = new Size(271, 27);
            comboAgama.TabIndex = 18;
            // 
            // comboJenisKelamin
            // 
            comboJenisKelamin.Font = new Font("Calibri", 8F, FontStyle.Bold);
            comboJenisKelamin.FormattingEnabled = true;
            comboJenisKelamin.Location = new Point(267, 255);
            comboJenisKelamin.Name = "comboJenisKelamin";
            comboJenisKelamin.Size = new Size(271, 27);
            comboJenisKelamin.TabIndex = 17;
            // 
            // comboTempatLahir
            // 
            comboTempatLahir.Font = new Font("Calibri", 8F, FontStyle.Bold);
            comboTempatLahir.FormattingEnabled = true;
            comboTempatLahir.Location = new Point(267, 190);
            comboTempatLahir.Name = "comboTempatLahir";
            comboTempatLahir.Size = new Size(271, 27);
            comboTempatLahir.TabIndex = 16;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Calibri", 8F, FontStyle.Bold);
            txtEmail.Location = new Point(267, 379);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(582, 27);
            txtEmail.TabIndex = 15;
            // 
            // txtNama
            // 
            txtNama.Font = new Font("Calibri", 8F, FontStyle.Bold);
            txtNama.Location = new Point(267, 132);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(582, 27);
            txtNama.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label7.Location = new Point(34, 455);
            label7.Name = "label7";
            label7.Size = new Size(67, 19);
            label7.TabIndex = 8;
            label7.Text = "ALAMAT";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label6.Location = new Point(34, 379);
            label6.Name = "label6";
            label6.Size = new Size(52, 19);
            label6.TabIndex = 7;
            label6.Text = "EMAIL";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label5.Location = new Point(34, 318);
            label5.Name = "label5";
            label5.Size = new Size(63, 19);
            label5.TabIndex = 6;
            label5.Text = "AGAMA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label4.Location = new Point(34, 255);
            label4.Name = "label4";
            label4.Size = new Size(112, 19);
            label4.TabIndex = 5;
            label4.Text = "JENIS KELAMIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label2.Location = new Point(34, 132);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 4;
            label2.Text = "NAMA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label1.Location = new Point(34, 73);
            label1.Name = "label1";
            label1.Size = new Size(62, 19);
            label1.TabIndex = 3;
            label1.Text = "NO-KTP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 8F, FontStyle.Bold);
            label3.Location = new Point(34, 190);
            label3.Name = "label3";
            label3.Size = new Size(32, 19);
            label3.TabIndex = 2;
            label3.Text = "TTL";
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(749, 708);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtNoKTP
            // 
            txtNoKTP.Font = new Font("Calibri", 8F, FontStyle.Bold);
            txtNoKTP.Location = new Point(267, 73);
            txtNoKTP.Name = "txtNoKTP";
            txtNoKTP.Size = new Size(582, 27);
            txtNoKTP.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 747);
            Controls.Add(btnSubmit);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private DateTimePicker dateTanggalLahir;
        private RichTextBox txtAlamat;
        private ComboBox comboAgama;
        private ComboBox comboJenisKelamin;
        private ComboBox comboTempatLahir;
        private TextBox txtEmail;
        private TextBox txtNama;
        private Button btnSubmit;
        private TextBox txtNoKTP;
    }
}
