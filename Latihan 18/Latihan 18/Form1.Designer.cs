namespace Latihan_18
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
            label1 = new Label();
            btnLemparDadu = new Button();
            btnClear = new Button();
            btnClose = new Button();
            listBox = new ListBox();
            cbDadu = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 86);
            label1.Name = "label1";
            label1.Size = new Size(17, 25);
            label1.TabIndex = 0;
            label1.Text = " ";
            // 
            // btnLemparDadu
            // 
            btnLemparDadu.Location = new Point(12, 12);
            btnLemparDadu.Name = "btnLemparDadu";
            btnLemparDadu.Size = new Size(477, 54);
            btnLemparDadu.TabIndex = 2;
            btnLemparDadu.Text = "btnLemparDadu";
            btnLemparDadu.UseVisualStyleBackColor = true;
            btnLemparDadu.Click += btnLemparDadu_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(23, 388);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(228, 54);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(257, 388);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(228, 54);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 25;
            listBox.Location = new Point(12, 153);
            listBox.Name = "listBox";
            listBox.Size = new Size(472, 229);
            listBox.TabIndex = 5;
            // 
            // cbDadu
            // 
            cbDadu.FormattingEnabled = true;
            cbDadu.Location = new Point(12, 114);
            cbDadu.Name = "cbDadu";
            cbDadu.Size = new Size(472, 33);
            cbDadu.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(196, 25);
            label2.TabIndex = 7;
            label2.Text = "Pilih Maksimal Double :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 450);
            Controls.Add(label2);
            Controls.Add(cbDadu);
            Controls.Add(listBox);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnLemparDadu);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLemparDadu;
        private Button btnClear;
        private Button btnClose;
        private ListBox listBox;
        private ComboBox cbDadu;
        private Label label2;
    }
}
