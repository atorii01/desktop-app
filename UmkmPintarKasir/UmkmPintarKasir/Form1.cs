using System;
using System.Windows.Forms;

namespace UmkmPintarKasir
{
    public partial class Form1 : Form
    {
        private bool fadeSelesai = false;

        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0;   // start transparan
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 30; // kecepatan animasi
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // ===== FADE IN  =====
            if (!fadeSelesai)
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.05;   // naik perlahan
                }
                else
                {
                    fadeSelesai = true;

                    // Cooldown sebelum pindah form
                    timer1.Stop();
                    timer1.Interval = 1500; // tampil 3 detik
                    timer1.Start();
                }
            }
            else
            {
                timer1.Stop();

                // Buka Login
                FormLogin login = new FormLogin();
                login.Show();

                // Tutup splash
                this.Hide();
            }
        }
    }
}
