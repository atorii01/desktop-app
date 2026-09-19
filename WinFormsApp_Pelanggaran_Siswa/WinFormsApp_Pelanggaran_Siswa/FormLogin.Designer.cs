namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            groupBox1 = new GroupBox();
            btnCancel = new Button();
            label2 = new Label();
            btnLogin = new Button();
            txtnamaguru = new TextBox();
            txtpassword = new TextBox();
            txtkodeguru = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtnamaguru);
            groupBox1.Controls.Add(txtpassword);
            groupBox1.Controls.Add(txtkodeguru);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(400, 263);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(651, 419);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Salmon;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(493, 333);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(123, 44);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 258);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 7;
            label2.Text = "Profile";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightGreen;
            btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(228, 333);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(123, 44);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtnamaguru
            // 
            txtnamaguru.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtnamaguru.Location = new Point(228, 191);
            txtnamaguru.Name = "txtnamaguru";
            txtnamaguru.Size = new Size(388, 37);
            txtnamaguru.TabIndex = 5;
            // 
            // txtpassword
            // 
            txtpassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(228, 274);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(388, 37);
            txtpassword.TabIndex = 4;
            // 
            // txtkodeguru
            // 
            txtkodeguru.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtkodeguru.Location = new Point(228, 107);
            txtkodeguru.Name = "txtkodeguru";
            txtkodeguru.Size = new Size(388, 37);
            txtkodeguru.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(109, 27);
            label1.Name = "label1";
            label1.Size = new Size(438, 38);
            label1.TabIndex = 2;
            label1.Text = "Login Sistem Pelanggaran Siswa";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(28, 97);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 158);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 1155);
            Controls.Add(groupBox1);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label label2;
        private Button btnLogin;
        private TextBox txtnamaguru;
        private TextBox txtpassword;
        private TextBox txtkodeguru;
        private Label label1;
        private Button btnCancel;
    }
}