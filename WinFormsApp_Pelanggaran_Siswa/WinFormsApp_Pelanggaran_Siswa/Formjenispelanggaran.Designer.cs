namespace WinFormsApp_Pelanggaran_Siswa
{
    partial class Formjenispelanggaran
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
            dataGridView2 = new DataGridView();
            txtcari = new TextBox();
            button11 = new Button();
            button10 = new Button();
            groupBox4 = new GroupBox();
            button6 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(95, 290);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1317, 671);
            dataGridView2.TabIndex = 18;
          //  dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // txtcari
            // 
            txtcari.BackColor = Color.Gainsboro;
            txtcari.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcari.Location = new Point(728, 32);
            txtcari.Name = "txtcari";
            txtcari.Size = new Size(569, 50);
            txtcari.TabIndex = 3;
            // 
            // button11
            // 
            button11.BackColor = Color.Red;
            button11.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = SystemColors.ControlLightLight;
            button11.Location = new Point(511, 30);
            button11.Name = "button11";
            button11.Size = new Size(172, 57);
            button11.TabIndex = 2;
            button11.Text = "Hapus";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.ControlDark;
            button10.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = SystemColors.ActiveCaptionText;
            button10.Location = new Point(300, 30);
            button10.Name = "button10";
            button10.Size = new Size(172, 57);
            button10.TabIndex = 1;
            button10.Text = "Edit";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtcari);
            groupBox4.Controls.Add(button11);
            groupBox4.Controls.Add(button10);
            groupBox4.Controls.Add(button6);
            groupBox4.Location = new Point(95, 139);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1306, 116);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
          //  groupBox4.Enter += groupBox4_Enter;
            // 
            // button6
            // 
            button6.BackColor = Color.LawnGreen;
            button6.Font = new Font("Constantia", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ActiveCaptionText;
            button6.Location = new Point(27, 30);
            button6.Name = "button6";
            button6.Size = new Size(234, 57);
            button6.TabIndex = 0;
            button6.Text = "Tambah";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(652, 96);
            label4.TabIndex = 22;
            label4.Text = "Jenis Pelanggaran";
        //    label4.Click += label4_Click;
            // 
            // Formjenispelanggaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 1020);
            Controls.Add(dataGridView2);
            Controls.Add(groupBox4);
            Controls.Add(label4);
            Name = "Formjenispelanggaran";
            Text = "Formjenispelanggaran";
            Load += Formjenispelanggaran_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private TextBox txtcari;
        private Button button11;
        private Button button10;
        private GroupBox groupBox4;
        private Button button6;
        private Label label4;
    }
}