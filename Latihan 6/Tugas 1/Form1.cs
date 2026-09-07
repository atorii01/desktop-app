namespace Tugas_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Isi ComboBox Tempat Lahir
            comboTempatLahir.Items.AddRange(new string[] {
                "Jakarta", "Bandung", "Surabaya", "Yogyakarta", "Medan"
            });

            // Isi ComboBox Jenis Kelamin
            comboJenisKelamin.Items.AddRange(new string[] {
                "Laki-laki", "Perempuan"
            });

            // Isi ComboBox Agama
            comboAgama.Items.AddRange(new string[] {
                "Islam", "Kristen", "Katolik", "Hindu", "Buddha", "Konghucu"
            });

            // Format DateTimePicker
            dateTanggalLahir.Format = DateTimePickerFormat.Short;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string noKTP = txtNoKTP.Text;
            string nama = txtNama.Text;
            string tempatLahir = comboTempatLahir.SelectedItem?.ToString() ?? "";
            string tanggalLahir = dateTanggalLahir.Value.ToShortDateString();
            string ttl = $"{tempatLahir}, {tanggalLahir}";
            string jenisKelamin = comboJenisKelamin.SelectedItem?.ToString() ?? "";
            string agama = comboAgama.SelectedItem?.ToString() ?? "";
            string email = txtEmail.Text;
            string alamat = txtAlamat.Text;

            // Membuka Form2 dengan data yang telah diisi
            Form2 form2 = new Form2(noKTP, nama, ttl, jenisKelamin, agama, email, alamat);
            form2.Show();

        }
    }
}
