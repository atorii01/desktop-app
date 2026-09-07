namespace Latihan_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTerapkan_Click(object sender, EventArgs e)
        {
            int i = 1;
            while (i <= 100)
            {
                flowLayoutPanel1.Controls.Add(new Label { Text = i.ToString() });
                i++;
            }
        }
    }
}
