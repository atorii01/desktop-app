namespace Data_Gaji_karyawan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbNama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDepartemen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHariBekerja = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGaji = new System.Windows.Forms.TextBox();
            this.tbCari = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnPerbarui = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLibur = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(503, 285);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbNama
            // 
            this.tbNama.Location = new System.Drawing.Point(548, 144);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(178, 26);
            this.tbNama.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Departemen";
            // 
            // tbDepartemen
            // 
            this.tbDepartemen.Location = new System.Drawing.Point(548, 208);
            this.tbDepartemen.Name = "tbDepartemen";
            this.tbDepartemen.Size = new System.Drawing.Size(178, 26);
            this.tbDepartemen.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(742, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hari Bekerja";
            // 
            // tbHariBekerja
            // 
            this.tbHariBekerja.Location = new System.Drawing.Point(732, 144);
            this.tbHariBekerja.Name = "tbHariBekerja";
            this.tbHariBekerja.Size = new System.Drawing.Size(170, 26);
            this.tbHariBekerja.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(742, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gaji";
            // 
            // tbGaji
            // 
            this.tbGaji.Location = new System.Drawing.Point(732, 208);
            this.tbGaji.Name = "tbGaji";
            this.tbGaji.Size = new System.Drawing.Size(170, 26);
            this.tbGaji.TabIndex = 8;
            // 
            // tbCari
            // 
            this.tbCari.Location = new System.Drawing.Point(54, 12);
            this.tbCari.Name = "tbCari";
            this.tbCari.Size = new System.Drawing.Size(447, 26);
            this.tbCari.TabIndex = 10;
            this.tbCari.TextChanged += new System.EventHandler(this.tbCari_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "ID";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(548, 92);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(178, 26);
            this.tbId.TabIndex = 12;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(521, 277);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(123, 37);
            this.btnSimpan.TabIndex = 14;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnPerbarui
            // 
            this.btnPerbarui.Location = new System.Drawing.Point(650, 277);
            this.btnPerbarui.Name = "btnPerbarui";
            this.btnPerbarui.Size = new System.Drawing.Size(123, 37);
            this.btnPerbarui.TabIndex = 15;
            this.btnPerbarui.Text = "Perbarui";
            this.btnPerbarui.UseVisualStyleBackColor = true;
            this.btnPerbarui.Click += new System.EventHandler(this.btnPerbarui_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(779, 277);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(123, 37);
            this.btnHapus.TabIndex = 16;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(742, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Libur";
            // 
            // tbLibur
            // 
            this.tbLibur.Location = new System.Drawing.Point(732, 92);
            this.tbLibur.Name = "tbLibur";
            this.tbLibur.Size = new System.Drawing.Size(170, 26);
            this.tbLibur.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 354);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLibur);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnPerbarui);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbCari);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbGaji);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHariBekerja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDepartemen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNama);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Data Gaji Karyawan";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDepartemen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHariBekerja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGaji;
        private System.Windows.Forms.TextBox tbCari;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnPerbarui;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLibur;
    }
}

