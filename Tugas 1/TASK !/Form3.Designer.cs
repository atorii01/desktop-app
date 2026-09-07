namespace TASK__
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            pictureBox1 = new PictureBox();
            btnQris = new Button();
            btnCash = new Button();
            btnKembali = new Button();
            btnKeluar = new Button();
            Picqris = new PictureBox();
            lblCash = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Picqris).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Info;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-706, -20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1804, 136);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnQris
            // 
            btnQris.BackColor = Color.MistyRose;
            btnQris.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            btnQris.Location = new Point(80, 142);
            btnQris.Name = "btnQris";
            btnQris.Size = new Size(230, 81);
            btnQris.TabIndex = 13;
            btnQris.Text = "Qris";
            btnQris.UseVisualStyleBackColor = false;
            btnQris.Click += btnQris_Click;
            // 
            // btnCash
            // 
            btnCash.BackColor = Color.MistyRose;
            btnCash.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            btnCash.Location = new Point(80, 245);
            btnCash.Name = "btnCash";
            btnCash.Size = new Size(230, 81);
            btnCash.TabIndex = 14;
            btnCash.Text = "Cash";
            btnCash.UseVisualStyleBackColor = false;
            btnCash.Click += btnCash_Click;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.MistyRose;
            btnKembali.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            btnKembali.Location = new Point(249, 431);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(133, 49);
            btnKembali.TabIndex = 15;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click_1;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.MistyRose;
            btnKeluar.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            btnKeluar.Location = new Point(80, 344);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(230, 81);
            btnKeluar.TabIndex = 16;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // Picqris
            // 
            Picqris.BackgroundImage = (Image)resources.GetObject("Picqris.BackgroundImage");
            Picqris.Image = (Image)resources.GetObject("Picqris.Image");
            Picqris.Location = new Point(28, 132);
            Picqris.Name = "Picqris";
            Picqris.Size = new Size(326, 293);
            Picqris.SizeMode = PictureBoxSizeMode.StretchImage;
            Picqris.TabIndex = 17;
            Picqris.TabStop = false;
            // 
            // lblCash
            // 
            lblCash.AutoSize = true;
            lblCash.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            lblCash.Location = new Point(66, 226);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(244, 30);
            lblCash.TabIndex = 18;
            lblCash.Text = "Silakan Bayar DiKasir";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(406, 506);
            Controls.Add(lblCash);
            Controls.Add(Picqris);
            Controls.Add(btnKeluar);
            Controls.Add(btnKembali);
            Controls.Add(btnCash);
            Controls.Add(btnQris);
            Controls.Add(pictureBox1);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Picqris).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnQris;
        private Button btnCash;
        private Button btnKembali;
        private Button btnKeluar;
        private PictureBox Picqris;
        private Label lblCash;
    }
}