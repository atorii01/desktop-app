namespace LKS
{
    partial class AddEditQuestionForm
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
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.cbQuestionImage = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbD = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(24, 69);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(775, 80);
            this.txtQuestion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Question";
            // 
            // picQuestion
            // 
            this.picQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQuestion.Location = new System.Drawing.Point(24, 171);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(205, 176);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuestion.TabIndex = 2;
            this.picQuestion.TabStop = false;
            this.picQuestion.Click += new System.EventHandler(this.picQuestion_Click);
            // 
            // cbQuestionImage
            // 
            this.cbQuestionImage.AutoSize = true;
            this.cbQuestionImage.Location = new System.Drawing.Point(99, 384);
            this.cbQuestionImage.Name = "cbQuestionImage";
            this.cbQuestionImage.Size = new System.Drawing.Size(80, 24);
            this.cbQuestionImage.TabIndex = 3;
            this.cbQuestionImage.Text = "Image";
            this.cbQuestionImage.UseVisualStyleBackColor = true;
            this.cbQuestionImage.CheckedChanged += new System.EventHandler(this.cbQuestionImage_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(99, 414);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(459, 26);
            this.txtA.TabIndex = 5;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(99, 446);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(459, 26);
            this.txtB.TabIndex = 6;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(99, 478);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(459, 26);
            this.txtC.TabIndex = 7;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(99, 510);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(459, 26);
            this.txtD.TabIndex = 8;
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Location = new System.Drawing.Point(44, 414);
            this.rbA.Name = "rbA";
            this.rbA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbA.Size = new System.Drawing.Size(49, 24);
            this.rbA.TabIndex = 9;
            this.rbA.TabStop = true;
            this.rbA.Text = ".A";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(44, 444);
            this.rbB.Name = "rbB";
            this.rbB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbB.Size = new System.Drawing.Size(49, 24);
            this.rbB.TabIndex = 10;
            this.rbB.TabStop = true;
            this.rbB.Text = ".B";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(44, 480);
            this.rbC.Name = "rbC";
            this.rbC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbC.Size = new System.Drawing.Size(49, 24);
            this.rbC.TabIndex = 11;
            this.rbC.TabStop = true;
            this.rbC.Text = ".C";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // rbD
            // 
            this.rbD.AutoSize = true;
            this.rbD.Location = new System.Drawing.Point(44, 512);
            this.rbD.Name = "rbD";
            this.rbD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbD.Size = new System.Drawing.Size(50, 24);
            this.rbD.TabIndex = 12;
            this.rbD.TabStop = true;
            this.rbD.Text = ".D";
            this.rbD.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 852);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 37);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Brown;
            this.btnSave.Location = new System.Drawing.Point(705, 852);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 37);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddEditQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 901);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbD);
            this.Controls.Add(this.rbC);
            this.Controls.Add(this.rbB);
            this.Controls.Add(this.rbA);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbQuestionImage);
            this.Controls.Add(this.picQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuestion);
            this.Name = "AddEditQuestionForm";
            this.Text = "AddEditQuestionForm";
            this.Load += new System.EventHandler(this.AddEditQuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.CheckBox cbQuestionImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.RadioButton rbD;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}