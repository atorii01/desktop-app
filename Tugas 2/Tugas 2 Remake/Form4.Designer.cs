namespace Tugas_2_Remake
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            flowPanelOutput = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowPanelOutput
            // 
            flowPanelOutput.AutoScroll = true;
            flowPanelOutput.Location = new Point(559, 147);
            flowPanelOutput.Name = "flowPanelOutput";
            flowPanelOutput.Size = new Size(776, 861);
            flowPanelOutput.TabIndex = 0;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1335, 1009);
            Controls.Add(flowPanelOutput);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowPanelOutput;
    }
}