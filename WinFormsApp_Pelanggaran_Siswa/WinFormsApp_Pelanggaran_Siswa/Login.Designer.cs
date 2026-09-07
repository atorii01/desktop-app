namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox2 = new PictureBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Daftar = new LinkLabel();
            Clear = new LinkLabel();
            btnLogin = new Button();
            chkShowPassword = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.ImeMode = ImeMode.NoControl;
            pictureBox2.Location = new Point(198, 44);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(296, 211);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(198, 293);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(296, 31);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(198, 363);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(296, 31);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 265);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 4;
            label1.Text = "Nama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 335);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 5;
            label2.Text = "Sandi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(228, 484);
            label3.Name = "label3";
            label3.Size = new Size(169, 25);
            label3.TabIndex = 6;
            label3.Text = "belum Punya Akun?";
            // 
            // Daftar
            // 
            Daftar.AutoSize = true;
            Daftar.Location = new Point(403, 484);
            Daftar.Name = "Daftar";
            Daftar.Size = new Size(61, 25);
            Daftar.TabIndex = 7;
            Daftar.TabStop = true;
            Daftar.Text = "Daftar";
            Daftar.LinkClicked += Daftar_LinkClicked;
            // 
            // Clear
            // 
            Clear.AutoSize = true;
            Clear.Location = new Point(421, 404);
            Clear.Name = "Clear";
            Clear.Size = new Size(63, 25);
            Clear.TabIndex = 8;
            Clear.TabStop = true;
            Clear.Text = "Hapus";
            Clear.LinkClicked += Clear_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(198, 432);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(296, 49);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Masuk";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(500, 369);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(22, 21);
            chkShowPassword.TabIndex = 11;
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(764, 656);
            Controls.Add(chkShowPassword);
            Controls.Add(btnLogin);
            Controls.Add(Clear);
            Controls.Add(Daftar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox2);
            Name = "Login";
            Text = "Masuk";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel Daftar;
        private LinkLabel Clear;
        private Button btnLogin;
        private CheckBox chkShowPassword;
    }
}