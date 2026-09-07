namespace TUGAS_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tblhitung_Click(object sender, EventArgs e)
        {
            if (Radio1.Checked)
                txtpendaftaran.Text = "Rp" + (0).ToString("N");
            else if (Radio2.Checked)
                txtpendaftaran.Text = "Rp" + (50000).ToString("N");
            else if (Radio3.Checked)
                txtpendaftaran.Text = "Rp" + (100000).ToString("N");
            else if (Radio4.Checked)
                txtpendaftaran.Text = "Rp" + (150000).ToString("N");
            else
                MessageBox.Show("Anda harus membuat pilihan");
        }
    }
}
