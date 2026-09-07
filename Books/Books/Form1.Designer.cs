namespace Books
{
    partial class Form1
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
            this.dgvuser = new System.Windows.Forms.DataGridView();
            this.user_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeactive = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvuser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvuser
            // 
            this.dgvuser.AllowUserToAddRows = false;
            this.dgvuser.AllowUserToDeleteRows = false;
            this.dgvuser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvuser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_Name,
            this.Column1,
            this.Column2,
            this.Age,
            this.User_role,
            this.email_address});
            this.dgvuser.Location = new System.Drawing.Point(12, 30);
            this.dgvuser.Name = "dgvuser";
            this.dgvuser.ReadOnly = true;
            this.dgvuser.RowHeadersWidth = 62;
            this.dgvuser.RowTemplate.Height = 28;
            this.dgvuser.Size = new System.Drawing.Size(1756, 422);
            this.dgvuser.TabIndex = 0;
            this.dgvuser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvuser_CellContentClick);
            this.dgvuser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvuser_CellContentClick);
            this.dgvuser.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvuser_RowPrePaint);
            // 
            // user_Name
            // 
            this.user_Name.DataPropertyName = "name_user";
            this.user_Name.HeaderText = "Name";
            this.user_Name.MinimumWidth = 8;
            this.user_Name.Name = "user_Name";
            this.user_Name.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "status_user";
            this.Column1.HeaderText = "status user";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "id";
            this.Column2.HeaderText = "id";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.MinimumWidth = 8;
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // User_role
            // 
            this.User_role.DataPropertyName = "title";
            this.User_role.HeaderText = "User Role";
            this.User_role.MinimumWidth = 8;
            this.User_role.Name = "User_role";
            this.User_role.ReadOnly = true;
            // 
            // email_address
            // 
            this.email_address.DataPropertyName = "email";
            this.email_address.HeaderText = "Email Address";
            this.email_address.MinimumWidth = 8;
            this.email_address.Name = "email_address";
            this.email_address.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 470);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(233, 66);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add User";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeactive
            // 
            this.btnDeactive.Location = new System.Drawing.Point(251, 470);
            this.btnDeactive.Name = "btnDeactive";
            this.btnDeactive.Size = new System.Drawing.Size(233, 66);
            this.btnDeactive.TabIndex = 3;
            this.btnDeactive.Text = "deactive";
            this.btnDeactive.UseVisualStyleBackColor = true;
            this.btnDeactive.Click += new System.EventHandler(this.btnDeactive_Click);
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(490, 470);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(233, 66);
            this.btnActive.TabIndex = 4;
            this.btnActive.Text = "Active";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 894);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnDeactive);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvuser);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvuser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_role;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_address;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeactive;
        private System.Windows.Forms.Button btnActive;
    }
}

