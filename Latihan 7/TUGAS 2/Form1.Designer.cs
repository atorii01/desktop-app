namespace TUGAS_2
{
    partial class Calculator
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
            txtAngka1 = new TextBox();
            txtAngka2 = new TextBox();
            txtHasil = new TextBox();
            richHistory = new RichTextBox();
            label1 = new Label();
            btnResult = new Button();
            lblEquals = new Label();
            comboOperasi = new ComboBox();
            btnClear = new Button();
            btnClose = new Button();
            btnCelarHistory = new Button();
            SuspendLayout();
            // 
            // txtAngka1
            // 
            txtAngka1.Location = new Point(12, 29);
            txtAngka1.Name = "txtAngka1";
            txtAngka1.Size = new Size(150, 31);
            txtAngka1.TabIndex = 0;
            // 
            // txtAngka2
            // 
            txtAngka2.Location = new Point(315, 29);
            txtAngka2.Name = "txtAngka2";
            txtAngka2.Size = new Size(150, 31);
            txtAngka2.TabIndex = 1;
            // 
            // txtHasil
            // 
            txtHasil.Location = new Point(606, 29);
            txtHasil.Name = "txtHasil";
            txtHasil.Size = new Size(150, 31);
            txtHasil.TabIndex = 2;
            // 
            // richHistory
            // 
            richHistory.Location = new Point(13, 127);
            richHistory.Name = "richHistory";
            richHistory.Size = new Size(542, 160);
            richHistory.TabIndex = 3;
            richHistory.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 99);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 4;
            label1.Text = "History";
            // 
            // btnResult
            // 
            btnResult.Location = new Point(619, 142);
            btnResult.Name = "btnResult";
            btnResult.Size = new Size(112, 34);
            btnResult.TabIndex = 5;
            btnResult.Text = "Result";
            btnResult.UseVisualStyleBackColor = true;
            // 
            // lblEquals
            // 
            lblEquals.AutoSize = true;
            lblEquals.Location = new Point(530, 37);
            lblEquals.Name = "lblEquals";
            lblEquals.Size = new Size(24, 25);
            lblEquals.TabIndex = 6;
            lblEquals.Text = "=";
            // 
            // comboOperasi
            // 
            comboOperasi.Location = new Point(178, 29);
            comboOperasi.Name = "comboOperasi";
            comboOperasi.Size = new Size(121, 33);
            comboOperasi.TabIndex = 10;
            comboOperasi.SelectedIndexChanged += comboOperasi_SelectedIndexChanged;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(619, 182);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear ";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(619, 222);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnCelarHistory
            // 
            btnCelarHistory.Location = new Point(365, 87);
            btnCelarHistory.Name = "btnCelarHistory";
            btnCelarHistory.Size = new Size(189, 34);
            btnCelarHistory.TabIndex = 11;
            btnCelarHistory.Text = "Clear History";
            btnCelarHistory.UseVisualStyleBackColor = true;
            btnCelarHistory.Click += btnCelarHistory_Click;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 299);
            Controls.Add(btnCelarHistory);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(comboOperasi);
            Controls.Add(lblEquals);
            Controls.Add(btnResult);
            Controls.Add(label1);
            Controls.Add(richHistory);
            Controls.Add(txtHasil);
            Controls.Add(txtAngka2);
            Controls.Add(txtAngka1);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAngka1;
        private TextBox txtAngka2;
        private TextBox txtHasil;
        private RichTextBox richHistory;
        private Label label1;
        private Button btnResult;
        private Label lblEquals;
        private ComboBox comboOperasi;
        private Button btnClear;
        private Button btnClose;
        private Button btnCelarHistory;
    }
}
