namespace Latihan_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbBangun.Items.Add("1 - Lingkaran");
            cmbBangun.Items.Add("2 - Persegi Panjang");
            cmbBangun.Items.Add("3 - Segitiga");
        }

        private void cmbBangun_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset semua input
            txtRadius.Visible = false;
            txtPanjang.Visible = false;
            txtTinggi.Visible = false;
            txtLebar.Visible = false;

            // Tampilkan input sesuai pilihan
            switch (cmbBangun.SelectedIndex)
            {
                case 0: // Lingkaran
                    txtRadius.Visible = true;
                    break;
                case 1: // Persegi Panjang
                    txtPanjang.Visible = true;
                    txtTinggi.Visible = true;
                    break;
                case 2: // Segitiga
                    txtPanjang.Visible = true;
                    txtLebar.Visible = true;
                    break;
            }

            // Kosongkan hasil sebelumnya
            txtLuasBangun.Clear();
        }
        private void btnHitung_Click(object sender, EventArgs e)
        {
            double radius, panjang, tinggi, lebar, luas;

            switch (cmbBangun.SelectedIndex)
            {
                case 0: // Lingkaran
                    if (double.TryParse(txtRadius.Text, out radius))
                    {
                        luas = Math.PI * Math.Pow(radius, 2);
                        txtLuasBangun.Text = luas.ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show("Masukkan radius yang valid.");
                    }
                    break;

                case 1: // Persegi Panjang
                    if (double.TryParse(txtPanjang.Text, out panjang) &&
                        double.TryParse(txtTinggi.Text, out tinggi))
                    {
                        luas = panjang * tinggi;
                        txtLuasBangun.Text = luas.ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show("Masukkan panjang dan tinggi yang valid.");
                    }
                    break;

                case 2: // Segitiga
                    if (double.TryParse(txtPanjang.Text, out panjang) &&
                        double.TryParse(txtLebar.Text, out lebar))
                    {
                        luas = panjang * lebar / 2;
                        txtLuasBangun.Text = luas.ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show("Masukkan panjang dan lebar yang valid.");
                    }
                    break;

                default:
                    MessageBox.Show("Pilih jenis bangun terlebih dahulu.");
                    break;
            }
        }
    }
}
