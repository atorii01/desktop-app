# 🚨 Aplikasi Pencatatan Pelanggaran Siswa (WinForms C#)

Aplikasi desktop berbasis **Windows Forms (C# / .NET)** yang dirancang untuk mencatat, mengelola, dan memantau poin pelanggaran tata tertib siswa di sekolah secara terstruktur dan efisien.

---

## 🛠️ Fitur Utama

- **📋 Pencatatan Pelanggaran**: Input data siswa (NISN, Nama, Kelas), jenis pelanggaran, jumlah poin, dan tanggal kejadian.
- **📊 Riwayat & Log Pelanggaran**: Menampilkan seluruh data pelanggaran dalam tabel interaktif (`DataGridView`).
- **⚠️ Kalkulasi Poin Akumulasi**: Menghitung total poin siswa untuk menentukan tingkat sanksi/tindakan.
- **🔍 Pencarian & Filter**: Memudahkan pencarian riwayat pelanggaran berdasarkan NISN, Nama, atau Kelas.
- **🧹 Reset / Clear Input**: Form input bersih otomatis setelah data berhasil disimpan.

---

## 💻 Spesifikasi & Teknologi

- **Bahasa Pemrograman**: C# (.NET Framework / .NET Core)
- **Tipe Aplikasi**: Windows Forms Application (WinForms)
- **IDE Pengembang**: Visual Studio 2022
- **Penyimpanan Data**: `DataTable` / Local Database (MySQL / SQL Server)

---

## 📂 Struktur Project

```text
WinFormsApp_Pelanggaran_Siswa/
│
├── Forms/
│   ├── FormUtama.cs            # Layout & Navigasi Utama
│   ├── FormPelanggaran.cs      # Form Input & Data Pelanggaran Siswa
│   └── FormSiswa.cs            # Form Pengelolaan Data Master Siswa
│
├── Models/
│   ├── Siswa.cs                # Model Data Siswa
│   └── Pelanggaran.cs          # Model Data Pelanggaran
│
├── Program.cs                  # Entry Point Aplikasi
└── README.md                   # Dokumentasi Project
```

---

## 🚀 Cara Menjalankan Project

1. **Clone Repository**
   ```bash
   git clone https://github.com/username/WinFormsApp_Pelanggaran_Siswa.git
   ```
2. **Buka Project di Visual Studio**
   - Buka file solution `WinFormsApp_Pelanggaran_Siswa.sln` menggunakan **Visual Studio 2022**.
3. **Build Project**
   - Pilih menu `Build` > `Build Solution` (atau tekan `Ctrl + Shift + B`).
4. **Jalankan Aplikasi**
   - Tekan tombol **Start** / `F5` di Visual Studio.

---

## 👥 Pembagian Tugas Kelompok

| No | Nama Anggota | Peran (Role) | Tanggung Jawab |
|---|---|---|---|
| 1 | **[Nama Member 1]** | Lead Developer & UI Designer | Merancang interface (Form) & alur navigasi aplikasi |
| 2 | **[Nama Member 2]** | Backend Developer | Membuat logika program (C#) & validasi input data |
| 3 | **[Nama Member 3]** | Database Specialist | Mengelola penyimpanan data (`DataTable` / SQL) |
| 4 | **[Nama Member 4]** | Technical Writer & QA | Menyusun dokumentasi (README) & melakukan testing |

---

## 📄 Lisensi

Project ini dibuat untuk memenuhi tugas kelompok mata pelajaran / kuliah Pemrograman Berbasis Objek (PBO) / Pemrograman Desktop.
