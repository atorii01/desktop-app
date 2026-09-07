namespace TUGAS_4
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            btnTabung = new Button();
            btnBola = new Button();
            btnKerucut = new Button();
            btnKubus = new Button();
            btnBalok = new Button();
            btnLimas = new Button();
            groupBox1 = new GroupBox();
            btnBack = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnTabung
            // 
            btnTabung.Image = (Image)resources.GetObject("btnTabung.Image");
            btnTabung.Location = new Point(100, 199);
            btnTabung.Name = "btnTabung";
            btnTabung.Size = new Size(97, 115);
            btnTabung.TabIndex = 1;
            btnTabung.Text = "TABUNG";
            btnTabung.UseVisualStyleBackColor = true;
            btnTabung.Click += btnTabung_Click;
            // 
            // btnBola
            // 
            btnBola.Image = (Image)resources.GetObject("btnBola.Image");
            btnBola.Location = new Point(469, 333);
            btnBola.Name = "btnBola";
            btnBola.Size = new Size(127, 115);
            btnBola.TabIndex = 2;
            btnBola.Text = "BOLA";
            btnBola.UseVisualStyleBackColor = true;
            btnBola.Click += btnBola_Click;
            // 
            // btnKerucut
            // 
            btnKerucut.Image = (Image)resources.GetObject("btnKerucut.Image");
            btnKerucut.Location = new Point(484, 199);
            btnKerucut.Name = "btnKerucut";
            btnKerucut.Size = new Size(112, 111);
            btnKerucut.TabIndex = 3;
            btnKerucut.Text = "KERUCUT";
            btnKerucut.UseVisualStyleBackColor = true;
            btnKerucut.Click += btnKerucut_Click;
            // 
            // btnKubus
            // 
            btnKubus.AutoSize = true;
            btnKubus.ForeColor = SystemColors.ActiveCaptionText;
            btnKubus.Image = (Image)resources.GetObject("btnKubus.Image");
            btnKubus.Location = new Point(89, 37);
            btnKubus.Name = "btnKubus";
            btnKubus.Size = new Size(127, 115);
            btnKubus.TabIndex = 5;
            btnKubus.Text = "KUBUS";
            btnKubus.UseVisualStyleBackColor = true;
            btnKubus.Click += btnKubus_Click;
            // 
            // btnBalok
            // 
            btnBalok.Image = (Image)resources.GetObject("btnBalok.Image");
            btnBalok.Location = new Point(73, 349);
            btnBalok.Name = "btnBalok";
            btnBalok.Size = new Size(143, 69);
            btnBalok.TabIndex = 6;
            btnBalok.Text = "BALOK";
            btnBalok.UseVisualStyleBackColor = true;
            btnBalok.Click += btnBalok_Click;
            // 
            // btnLimas
            // 
            btnLimas.Image = (Image)resources.GetObject("btnLimas.Image");
            btnLimas.Location = new Point(469, 37);
            btnLimas.Name = "btnLimas";
            btnLimas.Size = new Size(127, 115);
            btnLimas.TabIndex = 7;
            btnLimas.Text = "LIMAS";
            btnLimas.UseVisualStyleBackColor = true;
            btnLimas.Click += btnLimas_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLimas);
            groupBox1.Controls.Add(btnBola);
            groupBox1.Controls.Add(btnKubus);
            groupBox1.Controls.Add(btnTabung);
            groupBox1.Controls.Add(btnBalok);
            groupBox1.Controls.Add(btnKerucut);
            groupBox1.Location = new Point(52, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(682, 471);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "CALCULATOR";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(600, 517);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 573);
            Controls.Add(btnBack);
            Controls.Add(groupBox1);
            Name = "FormMenu";
            Text = "FormMenu";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnTabung;
        private Button btnBola;
        private Button btnKerucut;
        private Button btnKubus;
        private Button btnBalok;
        private Button btnLimas;
        private GroupBox groupBox1;
        private Button btnBack;
    }
}