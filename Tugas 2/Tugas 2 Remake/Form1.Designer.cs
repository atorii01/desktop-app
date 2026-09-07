namespace Tugas_2_Remake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            Clear = new LinkLabel();
            label1 = new Label();
            Daftar = new LinkLabel();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(443, 425);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(294, 31);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(443, 487);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(294, 31);
            txtPassword.TabIndex = 1;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.Location = new Point(743, 497);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(22, 21);
            chkShowPassword.TabIndex = 2;
            chkShowPassword.TextAlign = ContentAlignment.MiddleCenter;
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(475, 563);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(242, 60);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Clear
            // 
            Clear.AutoSize = true;
            Clear.BackColor = Color.Transparent;
            Clear.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Clear.Location = new Point(661, 532);
            Clear.Name = "Clear";
            Clear.Size = new Size(56, 28);
            Clear.TabIndex = 4;
            Clear.TabStop = true;
            Clear.Text = "Clear";
            Clear.LinkClicked += Clear_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(486, 626);
            label1.Name = "label1";
            label1.Size = new Size(183, 28);
            label1.TabIndex = 5;
            label1.Text = "Belum Punya Akun?";
            // 
            // Daftar
            // 
            Daftar.AutoSize = true;
            Daftar.BackColor = Color.Transparent;
            Daftar.Font = new Font("Segoe UI", 10F);
            Daftar.Location = new Point(653, 626);
            Daftar.Name = "Daftar";
            Daftar.Size = new Size(66, 28);
            Daftar.TabIndex = 6;
            Daftar.TabStop = true;
            Daftar.Text = "Daftar";
            Daftar.LinkClicked += Daftar_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1178, 701);
            Controls.Add(Daftar);
            Controls.Add(label1);
            Controls.Add(Clear);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private LinkLabel Clear;
        private Label label1;
        private LinkLabel Daftar;
    }
}
