namespace crud_nilai
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
            btn_delete = new Button();
            btn_update = new Button();
            btn_tambah = new Button();
            nis = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNIS = new TextBox();
            txtNama = new TextBox();
            txtMapel = new TextBox();
            txtNilai = new TextBox();
            txtKeterangan = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(841, 239);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(163, 37);
            btn_delete.TabIndex = 0;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += button1_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(655, 239);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(163, 37);
            btn_update.TabIndex = 1;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Click += btn_update_Click;
            // 
            // btn_tambah
            // 
            btn_tambah.Location = new Point(461, 239);
            btn_tambah.Name = "btn_tambah";
            btn_tambah.Size = new Size(163, 37);
            btn_tambah.TabIndex = 2;
            btn_tambah.Text = "Tambah";
            btn_tambah.UseVisualStyleBackColor = true;
            btn_tambah.Click += button3_Click;
            // 
            // nis
            // 
            nis.AutoSize = true;
            nis.Location = new Point(86, 73);
            nis.Name = "nis";
            nis.Size = new Size(34, 25);
            nis.TabIndex = 4;
            nis.Text = "nis";
            nis.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 170);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 5;
            label2.Text = "nama";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(477, 73);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 6;
            label3.Text = "mapel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(477, 160);
            label4.Name = "label4";
            label4.Size = new Size(43, 25);
            label4.TabIndex = 7;
            label4.Text = "nilai";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(810, 124);
            label5.Name = "label5";
            label5.Size = new Size(100, 25);
            label5.TabIndex = 8;
            label5.Text = "keterangan";
            label5.Click += label5_Click;
            // 
            // txtNIS
            // 
            txtNIS.Location = new Point(168, 73);
            txtNIS.Name = "txtNIS";
            txtNIS.Size = new Size(287, 31);
            txtNIS.TabIndex = 9;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(168, 164);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(287, 31);
            txtNama.TabIndex = 10;
            // 
            // txtMapel
            // 
            txtMapel.Location = new Point(542, 73);
            txtMapel.Name = "txtMapel";
            txtMapel.Size = new Size(287, 31);
            txtMapel.TabIndex = 11;
            // 
            // txtNilai
            // 
            txtNilai.Location = new Point(542, 160);
            txtNilai.Name = "txtNilai";
            txtNilai.Size = new Size(287, 31);
            txtNilai.TabIndex = 12;
            // 
            // txtKeterangan
            // 
            txtKeterangan.Location = new Point(916, 121);
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.Size = new Size(249, 31);
            txtKeterangan.TabIndex = 13;
            txtKeterangan.TextChanged += textBox5_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(80, 327);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1023, 323);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 703);
            Controls.Add(dataGridView1);
            Controls.Add(txtKeterangan);
            Controls.Add(txtNilai);
            Controls.Add(txtMapel);
            Controls.Add(txtNama);
            Controls.Add(txtNIS);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nis);
            Controls.Add(btn_tambah);
            Controls.Add(btn_update);
            Controls.Add(btn_delete);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_delete;
        private Button btn_update;
        private Button btn_tambah;
        private Label nis;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNIS;
        private TextBox txtNama;
        private TextBox txtMapel;
        private TextBox txtNilai;
        private TextBox txtKeterangan;
        private DataGridView dataGridView1;
    }
}
