using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_2_Remake
{
    public partial class Form4 : Form
    {
        private List<Penumpang> penumpangList;
        public Form4(List<Penumpang> penumpangList)
        {
            InitializeComponent();
            this.penumpangList = penumpangList;
            TampilkanPerPenumpang();
        }
        private int HitungHarga(Penumpang p)
        {
            int tarif = p.Kelas switch
            {
                "Ekonomi" => 500,
                "Bisnis" => 750,
                "Eksekutif" => 1000,
                _ => 0
            };

            int jarak = (p.Asal, p.Tujuan) switch
            {
                ("JAKARTA", "SURABAYA") or ("SURABAYA", "JAKARTA") => 725,
                ("JAKARTA", "YOGYAKARTA") or ("YOGYAKARTA", "JAKARTA") => 510,
                ("JAKARTA", "BANDUNG") or ("BANDUNG", "JAKARTA") => 150,
                ("JAKARTA", "SEMARANG") or ("SEMARANG", "JAKARTA") => 450,
                _ => 300
            };

            int harga = tarif * jarak;
            if (p.KategoriUsia == "Balita")
                harga /= 2;

            // DEBUG
            Console.WriteLine($"DEBUG: {p.Nama}, {p.Asal}->{p.Tujuan}, {p.Kelas}, {p.KategoriUsia}, Harga={harga}");

            return harga;
        }

        private void TampilkanPerPenumpang()
        {
            flowPanelOutput.Controls.Clear();

            foreach (var p in penumpangList)
            {
                int harga = HitungHarga(p);

                GroupBox gb = new GroupBox();
                gb.Text = $"Tiket: {p.Nama}";
                gb.Width = 400;
                gb.Height = 200;

                Label lblInfo = new Label();
                lblInfo.AutoSize = true;
                lblInfo.MaximumSize = new Size(flowPanelOutput.Width - 20, 0);
                lblInfo.Text = $"Nama: {p.Nama}\nEmail: {p.Email}\n" +
                               $"Kelas: {p.Kelas}\nKursi: {p.Kursi}\nHarga: Rp.{harga:N0}";
                lblInfo.Location = new Point(10, 20);   

                gb.Controls.Add(lblInfo);
                flowPanelOutput.Controls.Add(gb);
            }
        }

    }
}
