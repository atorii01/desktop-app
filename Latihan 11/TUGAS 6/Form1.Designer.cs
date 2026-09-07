namespace TUGAS_6
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
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            btnHitung = new Button();
            label1 = new Label();
            txtBayar = new TextBox();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(32, 29);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(227, 29);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Pembelian obat-Obatan";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(32, 80);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(172, 29);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Pemeriksaan Gigi";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(32, 126);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(181, 29);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Pemeriksaan Mata";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(32, 175);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(231, 29);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "Pemeriksaan Labotarium";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // btnHitung
            // 
            btnHitung.Location = new Point(32, 246);
            btnHitung.Name = "btnHitung";
            btnHitung.Size = new Size(447, 107);
            btnHitung.TabIndex = 4;
            btnHitung.Text = "Hitung Biaya";
            btnHitung.UseVisualStyleBackColor = true;
            btnHitung.Click += btnHitung_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 365);
            label1.Name = "label1";
            label1.Size = new Size(180, 25);
            label1.TabIndex = 5;
            label1.Text = "Total Biaya Kesehatan";
            // 
            // txtBayar
            // 
            txtBayar.Location = new Point(32, 393);
            txtBayar.Name = "txtBayar";
            txtBayar.Size = new Size(447, 31);
            txtBayar.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 450);
            Controls.Add(txtBayar);
            Controls.Add(label1);
            Controls.Add(btnHitung);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Name = "Form1";
            Text = "Menu Kesehatan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Button btnHitung;
        private Label label1;
        private TextBox txtBayar;
    }
}
