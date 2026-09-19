namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class Formsiswa
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
            label4 = new Label();
            groupBox4 = new GroupBox();
            txtcari = new TextBox();
            button11 = new Button();
            button10 = new Button();
            button6 = new Button();
            dataGridView2 = new DataGridView();
            cbKelas = new ComboBox();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(22, 18);
            label4.Name = "label4";
            label4.Size = new Size(395, 96);
            label4.TabIndex = 16;
            label4.Text = "Data Siswa";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtcari);
            groupBox4.Controls.Add(button11);
            groupBox4.Controls.Add(button10);
            groupBox4.Controls.Add(button6);
            groupBox4.Location = new Point(89, 171);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1317, 114);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(728, 32);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 3;
            txtcari.TextChanged += txtcari_TextChanged;
            // 
            // button11
            // 
            button11.BackColor = Color.Red;
            button11.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = SystemColors.ControlLightLight;
            button11.Location = new Point(495, 30);
            button11.Name = "button11";
            button11.Size = new Size(188, 57);
            button11.TabIndex = 2;
            button11.Text = "Hapus";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.ControlDarkDark;
            button10.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = SystemColors.ControlLightLight;
            button10.Location = new Point(271, 30);
            button10.Name = "button10";
            button10.Size = new Size(201, 57);
            button10.TabIndex = 1;
            button10.Text = "Edit";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.MenuHighlight;
            button6.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Location = new Point(27, 30);
            button6.Name = "button6";
            button6.Size = new Size(215, 57);
            button6.TabIndex = 0;
            button6.Text = "Tambah";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(89, 362);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1317, 671);
            dataGridView2.TabIndex = 4;
            // 
            // cbKelas
            // 
            cbKelas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbKelas.FormattingEnabled = true;
            cbKelas.Location = new Point(817, 305);
            cbKelas.Name = "cbKelas";
            cbKelas.Size = new Size(589, 40);
            cbKelas.TabIndex = 18;
            cbKelas.SelectedIndexChanged += cbKelas_SelectedIndexChanged;
            // 
            // Formsiswa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 1090);
            Controls.Add(cbKelas);
            Controls.Add(dataGridView2);
            Controls.Add(groupBox4);
            Controls.Add(label4);
            Name = "Formsiswa";
            Text = "Formsiswa";
            Load += Formsiswa_Load;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private GroupBox groupBox4;
        private TextBox txtcari;
        private Button button11;
        private Button button10;
        private Button button6;
        private DataGridView dataGridView2;
        private ComboBox cbKelas;
    }
}