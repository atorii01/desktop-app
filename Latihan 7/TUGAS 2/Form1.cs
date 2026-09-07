namespace TUGAS_2
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();

            // Hubungkan tombol Result ke event handler
            btnResult.Click += new EventHandler(btnResult_Click);

            // Isi ComboBox operasi
            comboOperasi.Items.AddRange(new string[] { "+", "-", "x", "/", "√" });
            comboOperasi.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            btnResult.Click += new EventHandler(btnResult_Click);
            double angka1, angka2 = 0, hasil = 0;
            bool isValid1 = double.TryParse(txtAngka1.Text, out angka1);
            bool isValid2 = double.TryParse(txtAngka2.Text, out angka2);

            string operasi = comboOperasi.SelectedItem?.ToString();

            if (!isValid1 || (operasi != "√" && !isValid2))
            {
                MessageBox.Show("Masukkan angka yang valid.");
                return;
            }

            switch (operasi)
            {
                case "+":
                    hasil = angka1 + angka2;
                    break;
                case "-":
                    hasil = angka1 - angka2;
                    break;
                case "x":
                    hasil = angka1 * angka2;
                    break;
                case "/":
                    if (angka2 == 0)
                    {
                        MessageBox.Show("Tidak bisa membagi dengan nol.");
                        return;
                    }
                    hasil = angka1 / angka2;
                    break;
                case "√":
                    if (angka1 < 0)
                    {
                        MessageBox.Show("Akar dari bilangan negatif tidak valid.");
                        return;
                    }
                    hasil = Math.Sqrt(angka1);
                    break;
                default:
                    MessageBox.Show("Pilih jenis operasi.");
                    return;
            }

            txtHasil.Text = hasil.ToString();

            if (operasi == "√")
                richHistory.AppendText($"√{angka1} = {hasil}\n");
            else
                richHistory.AppendText($"{angka1} {operasi} {angka2} = {hasil}\n");
        }

        private string GetSymbol(string operasi)
        {
            return operasi;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAngka1.Clear();
            txtAngka2.Clear();
            txtHasil.Clear();
            comboOperasi.SelectedIndex = -1;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void comboOperasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: kamu bisa tambahkan logika di sini kalau mau
            // Misalnya menampilkan operasi yang dipilih di MessageBox
            // MessageBox.Show($"Operasi dipilih: {comboOperasi.SelectedItem}");
        }

        private void btnCelarHistory_Click(object sender, EventArgs e)
        {
        richHistory.Clear();
        }
    }
}
