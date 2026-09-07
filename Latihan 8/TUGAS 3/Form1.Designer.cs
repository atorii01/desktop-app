namespace TUGAS_3
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
            dtpTanggal1 = new DateTimePicker();
            dtpTanggal2 = new DateTimePicker();
            lblHasil = new Label();
            btnBandingkan = new Button();
            SuspendLayout();
            // 
            // dtpTanggal1
            // 
            dtpTanggal1.Location = new Point(235, 66);
            dtpTanggal1.Name = "dtpTanggal1";
            dtpTanggal1.Size = new Size(300, 31);
            dtpTanggal1.TabIndex = 0;
            // 
            // dtpTanggal2
            // 
            dtpTanggal2.Location = new Point(235, 106);
            dtpTanggal2.Name = "dtpTanggal2";
            dtpTanggal2.Size = new Size(300, 31);
            dtpTanggal2.TabIndex = 1;
            // 
            // lblHasil
            // 
            lblHasil.AutoSize = true;
            lblHasil.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHasil.Location = new Point(145, 234);
            lblHasil.Name = "lblHasil";
            lblHasil.Size = new Size(0, 28);
            lblHasil.TabIndex = 4;
            // 
            // btnBandingkan
            // 
            btnBandingkan.Location = new Point(235, 146);
            btnBandingkan.Name = "btnBandingkan";
            btnBandingkan.Size = new Size(300, 37);
            btnBandingkan.TabIndex = 5;
            btnBandingkan.Text = "BANDINGKAN";
            btnBandingkan.UseVisualStyleBackColor = true;
            btnBandingkan.Click += btnBandingkan_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBandingkan);
            Controls.Add(lblHasil);
            Controls.Add(dtpTanggal2);
            Controls.Add(dtpTanggal1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpTanggal1;
        private DateTimePicker dtpTanggal2;
        private Label lblHasil;
        private Button btnBandingkan;
    }
}
