namespace Latihan_19
{
    public partial class Form1 : Form
    {
        // Add periodeBunga as a private field
        private int periodeBunga = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void rdbPerTahun_CheckedChanged(object sender, EventArgs e)
        {
            periodeBunga = 1;
        }

        private void rdbPerBulan_CheckedChanged(object sender, EventArgs e)
        {
            periodeBunga = 12;
        }

        private void rdbPerMinggu_CheckedChanged(object sender, EventArgs e)
        {
            periodeBunga = 52;
        }

        private void rdbPerHari_CheckedChanged(object sender, EventArgs e)
        {
            periodeBunga = 365;
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            double investasi = double.Parse(txtInvestasi.Text);
            double sukuBunga = double.Parse(txtBunga.Text);
            int jumlahTahun = int.Parse(txtJumlahTahun.Text);

            int periodePembayaran = jumlahTahun * periodeBunga;

            double sukuBungaPerPeriode = (sukuBunga / 100) / periodeBunga;

            double nilaiSekarang;

            for (int i = 1; i <= periodePembayaran; i++)
            {
                nilaiSekarang = investasi * sukuBungaPerPeriode;
                investasi = investasi + nilaiSekarang;
                listBox.Items.Add(i + ": " + investasi.ToString("N0"));
            }

            txtHasil.Text = "Anda mendapatkan Rp. " + investasi.ToString("N0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInvestasi.Clear();
            txtBunga.Clear();
            txtJumlahTahun.Clear();
            txtHasil.Clear();
            listBox.Items.Clear();
        }
    }
}
