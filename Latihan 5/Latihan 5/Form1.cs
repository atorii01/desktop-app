namespace Latihan_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tblHitung_Click(object sender, EventArgs e)
        {
            //inisiasi variabel dan type data
            Double nilai1 = 0.0;
            Double nilai2 = 0.0;
            Double nilai3 = 0.0;
            Double rerata = 0.0;
            //input data dan menyimpan kedalam variabel
            nilai1 = Double.Parse(txtNilai1.Text);
            nilai2 = Double.Parse(txtNilai2.Text);
            nilai3 = Double.Parse(txtNilai3.Text);
            //menghitung rerata
            rerata = (nilai1 + nilai2 + nilai3) / 3;
            //menampilkan rerata
            txtRerata.Text = rerata.ToString("n2");
            //menampilkan kategori
            if (rerata < 60)
                txtKategori.Text = "E";
            else if (rerata < 70)
                txtKategori.Text = "D";
            else if (rerata < 80)
                txtKategori.Text = "C";
            else if (rerata < 90)
                txtKategori.Text = "B";
            else if (rerata <= 100)
                txtKategori.Text = "A";
            //menampilkan pesan keterangan
            if (rerata > 80)
                txtKeterangan.Text = "Selamat anda berhasil";
            else
                txtKeterangan.Text = "Tetap semangat";
        }

        private void tblClear_Click(object sender, EventArgs e)
        {
            txtNilai1.Text = "";
            txtNilai2.Text = "";
            txtNilai3.Text = "";
            txtRerata.Text = "";
            txtKategori.Text = "";
            txtKeterangan.Text = "";
        }

        private void tblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tblSave_Click(object sender, EventArgs e)
        {
            // Menyimpan data ke file teks
            using (StreamWriter sw = new StreamWriter("hasil.txt", true))
            {
                sw.WriteLine("Nilai 1: " + txtNilai1.Text);
                sw.WriteLine("Nilai 2: " + txtNilai2.Text);
                sw.WriteLine("Nilai 3: " + txtNilai3.Text);
                sw.WriteLine("Rerata: " + txtRerata.Text);
                sw.WriteLine("Kategori: " + txtKategori.Text);
                sw.WriteLine("Keterangan: " + txtKeterangan.Text);
                sw.WriteLine("-------------------------------");
            }
            MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
