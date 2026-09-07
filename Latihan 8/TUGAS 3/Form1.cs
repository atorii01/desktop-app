namespace TUGAS_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBandingkan_Click(object sender, EventArgs e)
        {
            DateTime tanggal1 = dtpTanggal1.Value.Date;
            DateTime tanggal2 = dtpTanggal2.Value.Date;

            if (tanggal1 < tanggal2)
            {
                lblHasil.Text = "Tanggal pertama LEBIH TUA dari tanggal kedua.";
            }
            else if (tanggal1 > tanggal2)
            {
                lblHasil.Text = "Tanggal pertama LEBIH MUDA dari tanggal kedua.";
            }
            else
            {
                lblHasil.Text = "Kedua tanggal SAMA.";

            }
        }
    }
}
