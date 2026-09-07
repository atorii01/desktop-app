using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tugas_1
{
    public partial class Form2 : Form
    {
        public Form2(string noKTP, string nama, string ttl, string jenisKelamin, string agama, string email, string alamat)
        {

        InitializeComponent();
        // Tampilkan data ke label
        lblNoKTP.Text = $"No KTP: {noKTP}";
        lblNama.Text = $"Nama: {nama}";
        lblTTL.Text = $"Tempat, Tanggal Lahir: {ttl}";
        lblJenisKelamin.Text = $"Jenis Kelamin: {jenisKelamin}";
        lblAgama.Text = $"Agama: {agama}";
        lblEmail.Text = $"Email: {email}";
        lblAlamat.Text = $"Alamat: {alamat}";
        }
    }
}
