namespace Latihan_17
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
            txtAngka = new TextBox();
            txtKali = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            listBox = new ListBox();
            SuspendLayout();
            // 
            // txtAngka
            // 
            txtAngka.Location = new Point(12, 52);
            txtAngka.Name = "txtAngka";
            txtAngka.Size = new Size(159, 31);
            txtAngka.TabIndex = 0;
            // 
            // txtKali
            // 
            txtKali.Location = new Point(10, 123);
            txtKali.Name = "txtKali";
            txtKali.Size = new Size(159, 31);
            txtKali.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(157, 25);
            label1.TabIndex = 3;
            label1.Text = "Masukkan Angka :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(159, 25);
            label2.TabIndex = 4;
            label2.Text = "Dikalikan Dengan :";
            // 
            // button1
            // 
            button1.Location = new Point(12, 160);
            button1.Name = "button1";
            button1.Size = new Size(159, 48);
            button1.TabIndex = 5;
            button1.Text = "Jalankan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 214);
            button2.Name = "button2";
            button2.Size = new Size(159, 46);
            button2.TabIndex = 6;
            button2.Text = "Bersihkan";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 266);
            button3.Name = "button3";
            button3.Size = new Size(159, 51);
            button3.TabIndex = 7;
            button3.Text = "Keluar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 25;
            listBox.Location = new Point(177, 24);
            listBox.Name = "listBox";
            listBox.Size = new Size(236, 304);
            listBox.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 329);
            Controls.Add(listBox);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtKali);
            Controls.Add(txtAngka);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAngka;
        private TextBox txtKali;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private ListBox listBox;
    }
}
