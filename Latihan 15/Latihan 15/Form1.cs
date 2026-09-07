namespace Latihan_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTentukan_Click(object sender, EventArgs e)
        {
            string minat = cbxMinat.SelectedItem.ToString();
            int nilaiMatematika = Convert.ToInt32(txtMatematika.Text);
            int nilaiIPA = Convert.ToInt32(txtIPA.Text);
            int nilaiBahasaInggris = Convert.ToInt32(txtBahasaInggris.Text);
            string jurusan = "";

            switch (minat)
            {
                case "Teknologi":
                    if (nilaiMatematika >= 80 && nilaiIPA >= 80)
                    {
                        jurusan = "RPL (Rekayasa Perangkat Lunak)";
                    }
                    else if (nilaiMatematika < 80 && nilaiIPA >= 70)
                    {
                        jurusan = "TKJ (Teknik Komputer dan Jaringan)";
                    }
                    else
                    {
                        jurusan = "Jurusan tidak cocok karena nilai kurang.";
                    }
                    break;

                case "Bisnis":
                    if (nilaiMatematika >= 75 && nilaiBahasaInggris >= 75)
                    {
                        jurusan = "AKL (Akuntansi dan Keuangan Lembaga)";
                    }
                    else if (nilaiMatematika < 75 && nilaiBahasaInggris >= 70)
                    {
                        jurusan = "OTKP (Otomatisasi dan Tata Kelola Perkantoran)";
                    }
                    else
                    {
                        jurusan = "Jurusan tidak cocok karena nilai kurang.";
                    }
                    break;

                case "Seni":
                    if (nilaiBahasaInggris >= 80 && nilaiIPA >= 70)
                    {
                        jurusan = "DKV (Desain Komunikasi Visual)";
                    }
                    else if (nilaiBahasaInggris < 80 && nilaiIPA < 70)
                    {
                        jurusan = "BDP (Bisnis Daring dan Pemasaran)";
                    }
                    else
                    {
                        jurusan = "Jurusan tidak cocok karena nilai kurang.";
                    }
                    break;

                default:
                    MessageBox.Show("Minat tidak dikenali!");
                    break;
            }

            lblJurusanCocok.Text = "Jurusan Yang Cocok : \n" + jurusan;
        }
    }
}
