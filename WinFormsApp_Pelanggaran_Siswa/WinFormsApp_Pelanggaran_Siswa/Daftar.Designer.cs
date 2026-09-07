namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class Daftar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daftar));
            chkShowPassword = new CheckBox();
            btnRegister = new Button();
            Clear = new LinkLabel();
            Login = new LinkLabel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            pictureBox2 = new PictureBox();
            txtConfirm = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(509, 362);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(22, 21);
            chkShowPassword.TabIndex = 21;
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(206, 502);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(296, 49);
            btnRegister.TabIndex = 20;
            btnRegister.Text = "Daftar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // Clear
            // 
            Clear.AutoSize = true;
            Clear.Location = new Point(429, 474);
            Clear.Name = "Clear";
            Clear.Size = new Size(63, 25);
            Clear.TabIndex = 19;
            Clear.TabStop = true;
            Clear.Text = "Hapus";
            Clear.LinkClicked += Clear_LinkClicked;
            // 
            // Login
            // 
            Login.AutoSize = true;
            Login.Location = new Point(411, 554);
            Login.Name = "Login";
            Login.Size = new Size(64, 25);
            Login.TabIndex = 18;
            Login.TabStop = true;
            Login.Text = "Masuk";
            Login.LinkClicked += Login_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(236, 554);
            label3.Name = "label3";
            label3.Size = new Size(169, 25);
            label3.TabIndex = 17;
            label3.Text = "Sudah Punya Akun?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 328);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 16;
            label2.Text = "Sandi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 258);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 15;
            label1.Text = "Nama";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(207, 356);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(296, 31);
            txtPassword.TabIndex = 14;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(207, 286);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(296, 31);
            txtUsername.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.ImeMode = ImeMode.NoControl;
            pictureBox2.Location = new Point(207, 37);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(296, 211);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(206, 428);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(296, 31);
            txtConfirm.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(207, 400);
            label4.Name = "label4";
            label4.Size = new Size(145, 25);
            label4.TabIndex = 23;
            label4.Text = "Konfirmasi Sandi";
            // 
            // Daftar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 656);
            Controls.Add(label4);
            Controls.Add(txtConfirm);
            Controls.Add(chkShowPassword);
            Controls.Add(btnRegister);
            Controls.Add(Clear);
            Controls.Add(Login);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox2);
            Name = "Daftar";
            Text = "Daftar";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkShowPassword;
        private Button btnRegister;
        private LinkLabel Clear;
        private LinkLabel Login;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private PictureBox pictureBox2;
        private TextBox txtConfirm;
        private Label label4;
    }
}