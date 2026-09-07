namespace TUGAS_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            int jum = 0;
            if (checkBox1.Checked)
                jum += 350000;
            if (checkBox2.Checked)
                jum += 450000;
            if (checkBox3.Checked)
                jum += 550000;
            if (checkBox4.Checked)
                jum += 250000;
            txtBayar.Text = "Rp" + jum.ToString("N");
        }
    }
}
