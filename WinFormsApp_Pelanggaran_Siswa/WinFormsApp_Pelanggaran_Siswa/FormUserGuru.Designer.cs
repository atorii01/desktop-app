namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class FormUserGuru
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
            txtcari = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox4 = new GroupBox();
            cbRole = new ComboBox();
            txtKodeGuru = new TextBox();
            txtPassword = new TextBox();
            btnEdit = new Button();
            btnUpdate = new Button();
            btnhapus = new Button();
            btnbatal = new Button();
            btntambah = new Button();
            label9 = new Label();
            txtNama = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(819, 518);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 40;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(71, 600);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1317, 419);
            dataGridView1.TabIndex = 35;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cbRole);
            groupBox4.Controls.Add(txtKodeGuru);
            groupBox4.Controls.Add(txtPassword);
            groupBox4.Controls.Add(btnEdit);
            groupBox4.Controls.Add(btnUpdate);
            groupBox4.Controls.Add(btnhapus);
            groupBox4.Controls.Add(btnbatal);
            groupBox4.Controls.Add(btntambah);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(txtNama);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(61, 152);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1327, 335);
            groupBox4.TabIndex = 41;
            groupBox4.TabStop = false;
            groupBox4.Enter += groupBox4_Enter;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Admin", "Guru BK" });
            cbRole.Location = new Point(192, 245);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(378, 33);
            cbRole.TabIndex = 45;
            cbRole.Text = "Pilih Role~";
            // 
            // txtKodeGuru
            // 
            txtKodeGuru.Enabled = false;
            txtKodeGuru.Location = new Point(193, 55);
            txtKodeGuru.Name = "txtKodeGuru";
            txtKodeGuru.ReadOnly = true;
            txtKodeGuru.Size = new Size(378, 31);
            txtKodeGuru.TabIndex = 43;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(192, 179);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(378, 31);
            txtPassword.TabIndex = 41;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(881, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(127, 62);
            btnEdit.TabIndex = 39;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(729, 223);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 65);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(1033, 226);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(133, 62);
            btnhapus.TabIndex = 37;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // btnbatal
            // 
            btnbatal.Location = new Point(1192, 226);
            btnbatal.Name = "btnbatal";
            btnbatal.Size = new Size(129, 62);
            btnbatal.TabIndex = 36;
            btnbatal.Text = "Batal";
            btnbatal.UseVisualStyleBackColor = true;
            btnbatal.Click += btnbatal_Click;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(594, 223);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(119, 65);
            btntambah.TabIndex = 35;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            btntambah.Click += btntambah_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 245);
            label9.Name = "label9";
            label9.Size = new Size(160, 25);
            label9.TabIndex = 33;
            label9.Text = "Role                      :";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(192, 112);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(378, 31);
            txtNama.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 179);
            label8.Name = "label8";
            label8.Size = new Size(162, 25);
            label8.TabIndex = 31;
            label8.Text = "Password Akun     :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 112);
            label7.Name = "label7";
            label7.Size = new Size(166, 25);
            label7.TabIndex = 28;
            label7.Text = "Nama Guru            :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 55);
            label6.Name = "label6";
            label6.Size = new Size(170, 25);
            label6.TabIndex = 26;
            label6.Text = "Kode Guru              :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(61, 23);
            label4.Name = "label4";
            label4.Size = new Size(375, 96);
            label4.TabIndex = 39;
            label4.Text = "Data Guru";
            // 
            // FormUserGuru
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1458, 1107);
            Controls.Add(txtcari);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox4);
            Controls.Add(label4);
            Name = "FormUserGuru";
            Text = "FormUserGuru";
            Load += FormUserGuru_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtcari;
        private DataGridView dataGridView1;
        private GroupBox groupBox4;
        private TextBox txtKodeGuru;
        private TextBox txtPassword;
        private Button btnEdit;
        private Button btnUpdate;
        private Button btnhapus;
        private Button btnbatal;
        private Button btntambah;
        private Label label9;
        private TextBox txtNama;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private ComboBox cbRole;
    }
}