namespace Tugas_2_Remake
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            Login = new LinkLabel();
            label1 = new Label();
            Clear = new LinkLabel();
            btnRegister = new Button();
            chkShowPassword = new CheckBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtConfirm = new TextBox();
            SuspendLayout();
            // 
            // Login
            // 
            Login.AutoSize = true;
            Login.BackColor = Color.Transparent;
            Login.Location = new Point(655, 562);
            Login.Name = "Login";
            Login.Size = new Size(63, 25);
            Login.TabIndex = 10;
            Login.TabStop = true;
            Login.Text = "LOGIN";
            Login.LinkClicked += Login_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(491, 562);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 9;
            label1.Text = "Sudah Punya Akun?";
            // 
            // Clear
            // 
            Clear.AutoSize = true;
            Clear.BackColor = Color.Transparent;
            Clear.Location = new Point(680, 474);
            Clear.Name = "Clear";
            Clear.Size = new Size(51, 25);
            Clear.TabIndex = 8;
            Clear.TabStop = true;
            Clear.Text = "Clear";
            Clear.LinkClicked += Clear_LinkClicked;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.MenuHighlight;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(481, 502);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(250, 57);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Location = new Point(752, 367);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(22, 21);
            chkShowPassword.TabIndex = 13;
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(450, 361);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(296, 31);
            txtPassword.TabIndex = 12;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(450, 305);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(296, 31);
            txtUsername.TabIndex = 11;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(450, 421);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(296, 31);
            txtConfirm.TabIndex = 14;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1178, 619);
            Controls.Add(txtConfirm);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(Login);
            Controls.Add(label1);
            Controls.Add(Clear);
            Controls.Add(btnRegister);
            Name = "Form2";
            Text = "SIGN UP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel Login;
        private Label label1;
        private LinkLabel Clear;
        private Button btnRegister;
        private CheckBox chkShowPassword;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtConfirm;
    }
}