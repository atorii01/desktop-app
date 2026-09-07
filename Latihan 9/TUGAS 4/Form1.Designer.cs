namespace TUGAS_4
{
    partial class FormLogin
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
            txtUsername = new TextBox();
            groupBox1 = new GroupBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(92, 67);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(232, 34);
            txtUsername.TabIndex = 0;
            txtUsername.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(69, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(435, 324);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "SIGN IN";
            groupBox1.UseWaitCursor = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(152, 231);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.UseWaitCursor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(92, 140);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(232, 34);
            txtPassword.TabIndex = 1;
            txtPassword.UseWaitCursor = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 460);
            Controls.Add(groupBox1);
            Name = "FormLogin";
            Text = "FormLogin";
            UseWaitCursor = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsername;
        private GroupBox groupBox1;
        private Button btnLogin;
        private TextBox txtPassword;
    }
}
