namespace Tugas_3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox = new PictureBox();
            btnGacha = new Button();
            listBox = new ListBox();
            btnMinus10 = new Button();
            lblTotalLoop = new Label();
            btnMinus1 = new Button();
            btnPlus10 = new Button();
            btnPlus1 = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(30, 126);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(293, 411);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnGacha
            // 
            btnGacha.BackgroundImage = (Image)resources.GetObject("btnGacha.BackgroundImage");
            btnGacha.BackgroundImageLayout = ImageLayout.Zoom;
            btnGacha.Location = new Point(30, 598);
            btnGacha.Name = "btnGacha";
            btnGacha.Size = new Size(156, 145);
            btnGacha.TabIndex = 1;
            btnGacha.UseVisualStyleBackColor = true;
            btnGacha.Click += btnGacha_Click;
            // 
            // listBox
            // 
            listBox.BackColor = Color.LightSalmon;
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 25;
            listBox.Location = new Point(385, 126);
            listBox.Name = "listBox";
            listBox.Size = new Size(250, 554);
            listBox.TabIndex = 2;
            // 
            // btnMinus10
            // 
            btnMinus10.BackColor = Color.Transparent;
            btnMinus10.Location = new Point(53, 552);
            btnMinus10.Name = "btnMinus10";
            btnMinus10.Size = new Size(49, 34);
            btnMinus10.TabIndex = 3;
            btnMinus10.Text = "-10";
            btnMinus10.UseVisualStyleBackColor = false;
            btnMinus10.Click += btnMinus10_Click;
            // 
            // lblTotalLoop
            // 
            lblTotalLoop.AutoSize = true;
            lblTotalLoop.BackColor = Color.Transparent;
            lblTotalLoop.Location = new Point(158, 557);
            lblTotalLoop.Name = "lblTotalLoop";
            lblTotalLoop.Size = new Size(22, 25);
            lblTotalLoop.TabIndex = 4;
            lblTotalLoop.Text = "0";
            // 
            // btnMinus1
            // 
            btnMinus1.BackColor = Color.Transparent;
            btnMinus1.Location = new Point(108, 552);
            btnMinus1.Name = "btnMinus1";
            btnMinus1.Size = new Size(39, 34);
            btnMinus1.TabIndex = 5;
            btnMinus1.Text = "-1";
            btnMinus1.UseVisualStyleBackColor = false;
            btnMinus1.Click += btnMinus1_Click;
            // 
            // btnPlus10
            // 
            btnPlus10.BackColor = Color.Transparent;
            btnPlus10.Location = new Point(239, 552);
            btnPlus10.Name = "btnPlus10";
            btnPlus10.Size = new Size(52, 34);
            btnPlus10.TabIndex = 6;
            btnPlus10.Text = "+10";
            btnPlus10.UseVisualStyleBackColor = false;
            btnPlus10.Click += btnPlus10_Click;
            // 
            // btnPlus1
            // 
            btnPlus1.BackColor = Color.Transparent;
            btnPlus1.Location = new Point(191, 552);
            btnPlus1.Name = "btnPlus1";
            btnPlus1.Size = new Size(42, 34);
            btnPlus1.TabIndex = 7;
            btnPlus1.Text = "+1";
            btnPlus1.UseVisualStyleBackColor = false;
            btnPlus1.Click += btnPlus1_Click;
            // 
            // btnClear
            // 
            btnClear.AutoEllipsis = true;
            btnClear.BackgroundImage = (Image)resources.GetObject("btnClear.BackgroundImage");
            btnClear.BackgroundImageLayout = ImageLayout.Stretch;
            btnClear.Location = new Point(192, 598);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(156, 145);
            btnClear.TabIndex = 8;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(672, 755);
            Controls.Add(btnClear);
            Controls.Add(btnPlus1);
            Controls.Add(btnPlus10);
            Controls.Add(btnMinus1);
            Controls.Add(lblTotalLoop);
            Controls.Add(btnMinus10);
            Controls.Add(listBox);
            Controls.Add(btnGacha);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Gacha F1 Card";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button btnGacha;
        private ListBox listBox;
        private Button btnMinus10;
        private Label lblTotalLoop;
        private Button btnMinus1;
        private Button btnPlus10;
        private Button btnPlus1;
        private Button btnClear;
    }
}
