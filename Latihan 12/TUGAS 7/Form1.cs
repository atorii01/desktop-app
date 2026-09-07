namespace TUGAS_7
{
    public partial class Form1 : Form
    {
        static int jum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                jum += 350000;
            else
                jum -= 350000;
            txtBayar.Text = "Rp" + jum.ToString("N");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                jum += 450000;
            else
                jum -= 450000;
            txtBayar.Text = "Rp" + jum.ToString("N");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                jum += 550000;
            else
                jum -= 550000;
            txtBayar.Text = "Rp" + jum.ToString("N");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                jum += 250000;
            else
                jum -= 250000;
            txtBayar.Text = "Rp" + jum.ToString("N");
        }
    }
}
