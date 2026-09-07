using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Tugas_2_Remake
{
    public partial class Fom3 : Form
    {
        List<Penumpang> daftarPenumpang = new List<Penumpang>();
        string kelasGerbong = "";

        public Fom3()
        {
            InitializeComponent();
            panelKursi.Visible = false;
            IsiComboBox();
        }
        private void IsiComboBox()
        {
            string[] kota = { "JAKARTA", "SURABAYA", "YOGYAKARTA", "BANDUNG", "SEMARANG" };
            cmbAsal.Items.AddRange(kota);
            cmbTujuan.Items.AddRange(kota);
            dtpTanggal.Value = DateTime.Today;
        }

        private void PilihKelasGerbong(string kelas)
        {
            kelasGerbong = kelas;
            panelKursi.Visible = true;

            int jumlahBaris = 0;
            int[] barisAB = new int[] { };

            switch (kelas)
            {
                case "Ekonomi":
                    picEkonomi.Visible = true;
                    picBisnis.Visible = false;
                    picEksekutif.Visible = false;
                    jumlahBaris = 22;
                    barisAB = new[] { 1, 2, 21, 22 };
                    break;

                case "Bisnis":
                    picBisnis.Visible = true;
                    picEkonomi.Visible = false;
                    picEksekutif.Visible = false;
                    jumlahBaris = 17;
                    barisAB = new[] { 1, 17 };
                    break;

                case "Eksekutif":
                    picEksekutif.Visible = true;
                    picBisnis.Visible = false;
                    picEkonomi.Visible = false;
                    jumlahBaris = 13;
                    barisAB = new int[] { };
                    break;

                default:
                    MessageBox.Show("Kelas tidak dikenali.");
                    return;
            }

            IsiComboKursi(jumlahBaris, barisAB);
        }

        private void IsiComboKursi(int jumlahBaris, int[] barisAB)
        {
            cmbBaris.Items.Clear();
            cmbKursi.Items.Clear();

            for (int i = 1; i <= jumlahBaris; i++)
                cmbBaris.Items.Add(i.ToString());

            cmbBaris.SelectedIndexChanged += (s, e) =>
            {
                cmbKursi.Items.Clear();

                if (string.IsNullOrWhiteSpace(cmbBaris.Text))
                    return; // kalau kosong, langsung keluar biar nggak error
                int baris = int.Parse(cmbBaris.Text);

                if (Array.Exists(barisAB, b => b == baris))
                    cmbKursi.Items.AddRange(new[] { "A", "B" });
                else
                    cmbKursi.Items.AddRange(new[] { "A", "B", "C", "D" });
            };
        }

        private void btnEkonomi_Click(object sender, EventArgs e)
        {
            PilihKelasGerbong("Ekonomi");
        }

        private void btnBisnis_Click(object sender, EventArgs e)
        {
            PilihKelasGerbong("Bisnis");
        }

        private void btnEksekutif_Click(object sender, EventArgs e)
        {
            PilihKelasGerbong("Eksekutif");
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string kategoriUsia = rbDewasa.Checked ? "Dewasa" :
                                 rbBalita.Checked ? "Balita" : "";

            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") ||
                !Regex.IsMatch(txtHP.Text, @"^\d{12}$") ||
                !Regex.IsMatch(txtKTP.Text, @"^\d{16}$") ||
                cmbAsal.SelectedIndex == -1 ||
                cmbTujuan.SelectedIndex == -1 ||
                cmbBaris.SelectedIndex == -1 ||
                cmbKursi.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(kelasGerbong) ||
                string.IsNullOrWhiteSpace(kategoriUsia))
            {
                MessageBox.Show("Lengkapi semua data dengan format yang benar.");
                return;
            }

            if (cmbAsal.Text == cmbTujuan.Text)
            {
                MessageBox.Show("Asal dan tujuan tidak boleh sama.");
                return;
            }

            Penumpang p = new Penumpang
            {
                Nama = txtNama.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NoHP = txtHP.Text.Trim(),
                NoKTP = txtKTP.Text.Trim(),
                Tanggal = dtpTanggal.Value,
                Asal = cmbAsal.Text,
                Tujuan = cmbTujuan.Text,
                KategoriUsia = kategoriUsia,
                Kelas = kelasGerbong,
                Baris = cmbBaris.Text,
                Kursi = cmbKursi.Text
            };

            daftarPenumpang.Add(p);
            MessageBox.Show("Data penumpang berhasil disimpan.");

            // Reset
            txtNama.Clear();
            txtEmail.Clear();
            txtHP.Clear();
            txtKTP.Clear();
            cmbAsal.SelectedIndex = -1;
            cmbTujuan.SelectedIndex = -1;
            dtpTanggal.Value = DateTime.Today;
            rbDewasa.Checked = false;
            rbBalita.Checked = false;
            cmbBaris.SelectedIndex = -1;
            cmbKursi.Items.Clear();
            panelKursi.Visible = false;
            kelasGerbong = "";

            if (string.IsNullOrWhiteSpace(kelasGerbong))
            {
                MessageBox.Show("Pilih kelas terlebih dahulu.");
                return;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNama.Clear();
            txtEmail.Clear();
            txtHP.Clear();
            txtKTP.Clear();
            cmbAsal.SelectedIndex = -1;
            cmbTujuan.SelectedIndex = -1;
            dtpTanggal.Value = DateTime.Today;
            rbDewasa.Checked = false;
            rbBalita.Checked = false;
            cmbBaris.SelectedIndex = -1;
            cmbKursi.SelectedIndex = -1;
            cmbKursi.Items.Clear();
            panelKursi.Visible = false;
            kelasGerbong = "";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void btnLanjut_Click(object sender, EventArgs e)
        {
            if (daftarPenumpang.Count == 0)
            {
                MessageBox.Show("Belum ada data penumpang.");
                return;
            }

            Form4 prosesForm = new Form4 (daftarPenumpang);
            this.Hide();
            prosesForm.Show();
        }
    }
}

