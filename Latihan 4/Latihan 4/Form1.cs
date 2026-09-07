namespace Latihan_4
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
            //menampilkan pesan keterangan
            if (rerata > 90)
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
            txtKeterangan.Text = "";
        }

        private void tblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tblSave_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
