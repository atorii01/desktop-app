namespace Latihan_1
{
    public partial class Form1 : Form
    {
        private double dblAngka1;
        private double dblAngka2;
        private double dblHasil;

        public Form1()
        {
            InitializeComponent();
        }

        private void tblClear_Click(object sender, EventArgs e)
        {
            txtAngka1.Text = "0";
            txtAngka2.Text = "0";
            txtHasil.Text = "0";
        }

        private void tblJumlah_Click(object sender, EventArgs e)
        {
            dblAngka1 = Double.Parse(txtAngka1.Text);
            dblAngka2 = Double.Parse(txtAngka2.Text);
            dblHasil = (dblAngka1 + dblAngka2);
            txtHasil.Text = dblHasil.ToString("n2");
        }

        private void tblKurang_Click(object sender, EventArgs e)
        {
            dblAngka1 = Double.Parse(txtAngka1.Text);
            dblAngka2 = Double.Parse(txtAngka2.Text);
            dblHasil = (dblAngka1 - dblAngka2);
            txtHasil.Text = dblHasil.ToString("n2");
        }

        private void tblBagi_Click(object sender, EventArgs e)
        {
            dblAngka1 = Double.Parse(txtAngka1.Text);
            dblAngka2 = Double.Parse(txtAngka2.Text);
            dblHasil = (dblAngka1 / dblAngka2);
            txtHasil.Text = dblHasil.ToString("n2");
        }
    }
}
