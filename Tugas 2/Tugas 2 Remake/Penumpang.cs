using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_2_Remake
{
    public class Penumpang
    {
        public string Nama { get; set; }
        public string Email { get; set; }
        public string NoHP { get; set; }
        public string NoKTP { get; set; }
        public DateTime Tanggal { get; set; }
        public string Asal { get; set; }
        public string Tujuan { get; set; }
        public string KategoriUsia { get; set; } // "Dewasa" atau "Balita"
        public string Kelas { get; set; }        // Ekonomi, Bisnis, Eksekutif
        public string Baris { get; set; }        // 1–22, 1–17, 1–13
        public string Kursi { get; set; }        // A, B, C, D

    }
}
