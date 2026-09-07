namespace Latihan_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            int nomorHari = Convert.ToInt32(txtNoHari.Text);
            string namaHari = "";

            switch (nomorHari)
            {
                case 1:
                    namaHari = "Senin";
                    break;
                case 2:
                    namaHari = "Selasa";
                    break;
                case 3:
                    namaHari = "Rabu";
                    break;
                case 4:
                    namaHari = "Kamis";
                    break;
                case 5:
                    namaHari = "Jumat";
                    break;
                case 6:
                    namaHari = "Sabtu";
                    break;
                case 7:
                    namaHari = "Minggu";
                    break;
                default:
                    MessageBox.Show("Nomor hari harus antara 1-7!", "Error");
                    break;
            }

            txtHari.Text = namaHari;
        }
    }
}
