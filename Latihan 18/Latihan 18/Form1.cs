namespace Latihan_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 6; i++)
            {
                cbDadu.Items.Add(i);
            }
        }

        private void btnLemparDadu_Click(object sender, EventArgs e)
        {
            int angkaAcak1, angkaAcak2;
            int doubleCounter = 0;
            string simpan;

            if (cbDadu.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih jumlah double yang diinginkan dari ComboBox");
                return;
            }

            int nilaiHenti = int.Parse(cbDadu.SelectedItem.ToString());

            Random rand = new Random();

            // Mengulangi lemparan dadu hingga mencapai jumlah double yang dipilih
            do
            {
                // Menghasilkan angka acak untuk dua dadu 
                angkaAcak1 = rand.Next(1, 7);
                angkaAcak2 = rand.Next(1, 7);

                simpan = angkaAcak1.ToString() + " " + angkaAcak2.ToString();

                if (angkaAcak1 == angkaAcak2)
                {
                    simpan += " Double!";
                    doubleCounter += 1;
                }

                listBox.Items.Add(simpan);

            } while (doubleCounter < nilaiHenti);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
