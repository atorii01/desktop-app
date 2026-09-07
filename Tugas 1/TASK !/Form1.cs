using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TASK__
{
    public partial class Form1 : Form
    {
        private bool sudahHitung = false;
        private bool sudahLayananDipilih = false;
        private bool sudahDipilih = false;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }
        // Saat form dimuat, tambahkan event handler untuk semua checkbox
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control group in this.Controls.OfType<GroupBox>())
            {
                foreach (Control item in group.Controls)
                {
                    if (item is CheckBox cb)
                    {
                        cb.CheckedChanged += (s, ev) => UpdateJumlahItem();
                    }
                }
            }

            lblJumlahItem.Text = "0";
        }
        // Hitung jumlah item yang dicentang
        private void UpdateJumlahItem()
        {
            int count = 0;

            foreach (Control group in this.Controls.OfType<GroupBox>())
            {
                foreach (Control item in group.Controls)
                {
                    if (item is CheckBox cb && cb.Checked)
                    {
                        count++;
                    }
                }
            }
            foreach (Control item in grpCoffee.Controls)
            {
                if (item is RadioButton rb && rb.Checked)
                {
                    count++;
                }
            }

            lblJumlahItem.Text = $"{count}";
        }
        private void btnHitung_Click(object sender, EventArgs e)
        {
            double subtotal = 0;
            rtbPesanan.Clear(); // Bersihkan dulu

            rtbPesanan.AppendText("Daftar Pesanan:\n");


            foreach (Control item in grpCoffee.Controls)
            {
                if (item is RadioButton rb && rb.Checked)
                {
                    double hargaKopi = 0;
                    if (rb.Text == "Espresso") hargaKopi = 18000;
                    else if (rb.Text == "Americano") hargaKopi = 20000;
                    else if (rb.Text == "Cappuccino") hargaKopi = 25000;
                    else if (rb.Text == "Latte") hargaKopi = 25000;
                    else if (rb.Text == "Mochaccino") hargaKopi = 27000;
                    else if (rb.Text == "Flat white") hargaKopi = 26000;
                    else if (rb.Text == "Cold brew") hargaKopi = 24000;
                    else if (rb.Text == "Kopi susu") hargaKopi = 22000;
                    else if (rb.Text == "Affogato") hargaKopi = 30000;
                    else if (rb.Text == "Frappuccino") hargaKopi = 32000;

                    subtotal += hargaKopi;
                    rtbPesanan.AppendText($"{rb.Text} - Rp{hargaKopi:N0}\n");
                }
            }

            foreach (Control group in this.Controls.OfType<GroupBox>())
            {
                foreach (Control item in group.Controls)
                {
                    if (item is CheckBox cb && cb.Checked)
                    {
                        double hargaItem = 0;
                        string nama = cb.Text;

                        if (nama == "Croissant klasik") hargaItem = 12000;
                        else if (nama == "Roti isi coklat") hargaItem = 10000;
                        else if (nama == "Roti isi keju") hargaItem = 11000;
                        else if (nama == "Cinnamon roll") hargaItem = 13000;
                        else if (nama == "Banana bread") hargaItem = 14000;
                        else if (nama == "Roti sobek pandan") hargaItem = 9000;
                        else if (nama == "Roti selai kacang") hargaItem = 10000;
                        else if (nama == "Danish pastry buah") hargaItem = 15000;
                        else if (nama == "Roti isi tuna mayo") hargaItem = 14000;
                        else if (nama == "Donat") hargaItem = 8000;

                        else if (nama == "Whipped cream") hargaItem = 5000;
                        else if (nama == "Coklat serut") hargaItem = 4000;
                        else if (nama == "Caramel drizzle") hargaItem = 4000;
                        else if (nama == "Foam susu") hargaItem = 3000;
                        else if (nama == "Boba") hargaItem = 5000;
                        else if (nama == "Jelly kopi") hargaItem = 4000;
                        else if (nama == "Oreo crumble") hargaItem = 4000;
                        else if (nama == "Marshmallow mini") hargaItem = 4000;
                        else if (nama == "Choco chips") hargaItem = 4000;
                        else if (nama == "Saus hazelnut") hargaItem = 5000;

                        else if (nama == "Extra shot espresso") hargaItem = 5000;
                        else if (nama == "Susu almond") hargaItem = 7000;
                        else if (nama == "Susu oat") hargaItem = 7000;
                        else if (nama == "Sirup vanilla") hargaItem = 4000;
                        else if (nama == "Sirup hazelnut") hargaItem = 4000;
                        else if (nama == "Sirup caramel") hargaItem = 4000;
                        else if (nama == "Gula aren cair") hargaItem = 3000;
                        else if (nama == "Es batu") hargaItem = 2000;
                        else if (nama == "Vegan milk option") hargaItem = 7000;
                        else if (nama == "Kopi decaf") hargaItem = 6000;

                        subtotal += hargaItem;
                        rtbPesanan.AppendText($"{nama} - Rp{hargaItem:N0}\n");
                        sudahHitung = true;
                        sudahDipilih = true;
                    }
                }
            }

            string layanan = "";

            if (rbDineIn.Checked) layanan = "Dine In";
            else if (rbDelivery.Checked) layanan = "Delivery";
            else if (rbTakeAway.Checked) layanan = "Take Away";

            rtbPesanan.AppendText($"\nLayanan: {layanan}\n");
            // Hitung pajak dan total
            double pajak = subtotal * 0.1;
            double total = subtotal + pajak;

            // Tampilkan hasil
            txtSubTotal.Text = subtotal.ToString("C");
            txtPajak.Text = pajak.ToString("C");
            txtTotal.Text = total.ToString("C");

            rtbPesanan.AppendText($"\nSubtotal: {subtotal:C}\n");
            rtbPesanan.AppendText($"Pajak (10%): {pajak:C}\n");
            rtbPesanan.AppendText($"Total: {total:C}\n");
            rtbPesanan.AppendText("Terima kasih telah memesan di Coffee Shop kami!\n");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control group in this.Controls.OfType<GroupBox>())
            {
                foreach (Control item in group.Controls)
                {
                    if (item is CheckBox cb) cb.Checked = false;
                    if (item is RadioButton rb) rb.Checked = false;
                }
            }

            txtSubTotal.Clear();
            txtPajak.Clear();
            txtTotal.Clear();
            rtbPesanan.Clear();
            lblJumlahItem.Text = "0";
        }
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (!sudahHitung)
            {
                MessageBox.Show("Silakan tekan tombol Hitung terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!sudahDipilih)
            {
                MessageBox.Show("Silakan Pilih terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!sudahLayananDipilih)
            {
                MessageBox.Show("Silakan pilih layanan terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }

        private void rbTakeAway_CheckedChanged(object sender, EventArgs e)
        {
            sudahLayananDipilih = true;
        }

        private void rbDineIn_CheckedChanged(object sender, EventArgs e)
        {
            sudahLayananDipilih = true;
        }

        private void rbDelivery_CheckedChanged(object sender, EventArgs e)
        {
            sudahLayananDipilih = true;
        }
    }
}
