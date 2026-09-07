namespace Latihan_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            int angkaAnda, pengali, JumBerjalan = 0;
            angkaAnda = int.Parse(txtAngka.Text);
            pengali = int.Parse(txtKali.Text);
            int jawaban;

            for (int i = 0; i <= 10; i++)
            {
                jawaban = i * angkaAnda;
                listBox.Items.Add(i + "X" + angkaAnda + "=" + jawaban);
                JumBerjalan = JumBerjalan + jawaban;
            }
            listBox.Items.Add("Total" + JumBerjalan);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            txtAngka.Clear();
            txtKali.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
