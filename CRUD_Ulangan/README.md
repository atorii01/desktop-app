# Penggajian Karyawan - Aplikasi C# & PostgreSQL

Aplikasi **Penggajian Karyawan** berbasis **C# (Windows Forms)** dan **PostgreSQL** yang digunakan untuk mengelola data absensi hari kerja, detail karyawan, serta perhitungan gaji otomatis. Project ini dibuat menggunakan driver `Npgsql`.

---

## 🛠️ Teknologi & Library yang Digunakan

* **Bahasa Pemrograman:** C# (.NET Framework / .NET Core)
* **GUI Framework:** Windows Forms (WinForms)
* **IDE:** Microsoft Visual Studio
* **Database:** PostgreSQL
* **Library / Nuget Packages:**
  * `Npgsql` - Data provider untuk PostgreSQL
  * `Microsoft.Bcl.AsyncInterfaces`
  * `Microsoft.Bcl.HashCode`
  * `Microsoft.Extensions.Logging.Abstractions`

---

## 📁 Struktur Project

```text
CRUD_Ulangan/
├── CRUD_Ulangan/
│   ├── App.config                # Konfigurasi aplikasi & database connection string
│   ├── CRUD_Ulangan.csproj       # File project Visual Studio
│   ├── Form1.cs                  # Logika aplikasi & perhitungan gaji
│   ├── bin/                      # Compiled binaries & dependencies
│   └── ... 
└── CRUD_Ulangan.sln              # Visual Studio Solution File

```

---

## 🚀 Fitur & Penjelasan Isi Aplikasi

Aplikasi ini berfokus pada pengolahan data karyawan dan kalkulasi penggajian berbasis jumlah hari kerja:

* ➕ **Input Data Karyawan:** Menambahkan ID, Nama, Departemen, dan Jumlah Hari Kerja ke database (`datakaryawan`).
* 📋 **Kalkulasi Gaji Otomatis:** Menghitung total gaji secara dinamis (Gaji pokok Rp 5.000.000 untuk minimal 20 hari kerja + bonus Rp 100.000 per hari lembur).
* 🏷️ **Status Kerja:** Mengategorikan status karyawan secara otomatis (`Regular`, `Lembur`, atau `Tidak Valid`).
* ✏️ **Update & Hapus Data:** Memperbarui detail data karyawan atau menghapusnya langsung dari sistem.
* 🔍 **Pencarian Real-time:** Memfilter daftar karyawan secara *live* berdasarkan kata kunci ID, Nama, Departemen, atau Jumlah Hari.

---

## ⚙️ Persyaratan Sistem & Instalasi

### 1. Prasyarat

* [.NET Framework / SDK](https://dotnet.microsoft.com/)
* [Visual Studio 2019 / 2022](https://visualstudio.microsoft.com/)
* [PostgreSQL](https://www.postgresql.org/)

### 2. Setup Database

Buat database bernama `datakaryawan` di PostgreSQL dan jalankan query berikut:

```sql
CREATE TABLE gaji_karyawan (
    Id INT PRIMARY KEY,
    Nama VARCHAR(100),
    Departemen VARCHAR(50),
    Hari INT
);

```

---

## 🏃 Cara Menjalankan Project

1. Buka file `CRUD_Ulangan.sln` menggunakan Visual Studio.
2. Pastikan PostgreSQL sudah aktif dan sesuaikan `connectionString` pada file `Form1.cs`.
3. Tekan tombol `F5` atau klik **Start** untuk menjalankan aplikasi.

---

## 📜 Lisensi

Project ini dibuat untuk tujuan edukasi & tugas praktek pemrograman desktop. Bebas digunakan dan dikembangkan kembali.
