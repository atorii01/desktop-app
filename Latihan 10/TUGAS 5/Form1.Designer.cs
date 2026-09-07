namespace TUGAS_5
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
            Radio1 = new RadioButton();
            groupBox1 = new GroupBox();
            Radio4 = new RadioButton();
            Radio3 = new RadioButton();
            Radio2 = new RadioButton();
            tblhitung = new Button();
            txtpendaftaran = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Radio1
            // 
            Radio1.AutoSize = true;
            Radio1.Location = new Point(34, 67);
            Radio1.Name = "Radio1";
            Radio1.Size = new Size(175, 29);
            Radio1.TabIndex = 0;
            Radio1.TabStop = true;
            Radio1.Text = "Anak (<10 Tahun)";
            Radio1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Radio4);
            groupBox1.Controls.Add(Radio3);
            groupBox1.Controls.Add(Radio2);
            groupBox1.Controls.Add(Radio1);
            groupBox1.Location = new Point(36, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 275);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Usia";
            // 
            // Radio4
            // 
            Radio4.AutoSize = true;
            Radio4.Location = new Point(34, 212);
            Radio4.Name = "Radio4";
            Radio4.Size = new Size(185, 29);
            Radio4.TabIndex = 3;
            Radio4.TabStop = true;
            Radio4.Text = "Senior (>40 Tahun)";
            Radio4.UseVisualStyleBackColor = true;
            // 
            // Radio3
            // 
            Radio3.AutoSize = true;
            Radio3.Location = new Point(34, 163);
            Radio3.Name = "Radio3";
            Radio3.Size = new Size(211, 29);
            Radio3.TabIndex = 2;
            Radio3.TabStop = true;
            Radio3.Text = "Dewasa (18-40 Tahun)";
            Radio3.UseVisualStyleBackColor = true;
            // 
            // Radio2
            // 
            Radio2.AutoSize = true;
            Radio2.Location = new Point(34, 114);
            Radio2.Name = "Radio2";
            Radio2.Size = new Size(207, 29);
            Radio2.TabIndex = 1;
            Radio2.TabStop = true;
            Radio2.Text = "Remaja (10-18 Tahun)";
            Radio2.UseVisualStyleBackColor = true;
            // 
            // tblhitung
            // 
            tblhitung.Location = new Point(479, 91);
            tblhitung.Name = "tblhitung";
            tblhitung.Size = new Size(286, 109);
            tblhitung.TabIndex = 2;
            tblhitung.Text = "Tentukan Uang Pendaftaran";
            tblhitung.UseVisualStyleBackColor = true;
            tblhitung.Click += tblhitung_Click;
            // 
            // txtpendaftaran
            // 
            txtpendaftaran.Location = new Point(479, 289);
            txtpendaftaran.Name = "txtpendaftaran";
            txtpendaftaran.Size = new Size(286, 31);
            txtpendaftaran.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(479, 261);
            label1.Name = "label1";
            label1.Size = new Size(195, 25);
            label1.TabIndex = 4;
            label1.Text = "Total Uang Pendaftaran";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 379);
            Controls.Add(label1);
            Controls.Add(txtpendaftaran);
            Controls.Add(tblhitung);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Uang Pendaftaran";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton Radio1;
        private GroupBox groupBox1;
        private RadioButton Radio4;
        private RadioButton Radio3;
        private RadioButton Radio2;
        private Button tblhitung;
        private TextBox txtpendaftaran;
        private Label label1;
    }
}
