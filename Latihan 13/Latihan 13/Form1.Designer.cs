namespace Latihan_13
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
            label1 = new Label();
            label2 = new Label();
            btnTampilkan = new Button();
            txtNoHari = new TextBox();
            txtHari = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtHari);
            groupBox1.Controls.Add(txtNoHari);
            groupBox1.Controls.Add(btnTampilkan);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(36, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 228);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pilih Hari";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 59);
            label1.Name = "label1";
            label1.Size = new Size(247, 25);
            label1.TabIndex = 0;
            label1.Text = "Masukkan Nomor Hari (1-7) : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 179);
            label2.Name = "label2";
            label2.Size = new Size(53, 25);
            label2.TabIndex = 1;
            label2.Text = "Hari :";
            // 
            // btnTampilkan
            // 
            btnTampilkan.Location = new Point(23, 114);
            btnTampilkan.Name = "btnTampilkan";
            btnTampilkan.Size = new Size(419, 34);
            btnTampilkan.TabIndex = 2;
            btnTampilkan.Text = "Tampilkan Hari";
            btnTampilkan.UseVisualStyleBackColor = true;
            btnTampilkan.Click += btnTampilkan_Click;
            // 
            // txtNoHari
            // 
            txtNoHari.Location = new Point(276, 56);
            txtNoHari.Name = "txtNoHari";
            txtNoHari.Size = new Size(166, 31);
            txtNoHari.TabIndex = 3;
            // 
            // txtHari
            // 
            txtHari.Location = new Point(88, 176);
            txtHari.Name = "txtHari";
            txtHari.Size = new Size(354, 31);
            txtHari.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 312);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Pemilihan Hari";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnTampilkan;
        private Label label2;
        private Label label1;
        private TextBox txtHari;
        private TextBox txtNoHari;
    }
}
