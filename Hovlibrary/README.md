# Hovlibrary 📚

**Hovlibrary** adalah aplikasi manajemen perpustakaan berbasis desktop yang dibangun menggunakan **C#** dan **.NET Framework 4.7.2** (Windows Forms / WinForms). Aplikasi ini memanfaatkan LINQ to SQL (`DataClasses1.dbml`) untuk mengelola basis data serta menyediakan antarmuka pengguna berbasis formulir untuk pengelolaan koleksi buku dan data perpustakaan.

---

## 🛠️ Fitur Utama

- **Manajemen Buku (Master Book):** Pengelolaan data buku perpustakaan (tambah, ubah, hapus, dan tampilkan data buku).
- **Formulir Utama (Main Form):** Antarmuka pengguna intuitif berbasis Windows Forms untuk navigasi fitur aplikasi.
- **Integrasi Database (LINQ to SQL):** Pemetaan objek relasional (ORM) menggunakan file `.dbml` (`DataClasses1.dbml`) untuk transaksi data yang aman dan efisien.
- **Pengaturan & Resource Terpusat:** Pengelolaan resource gambar dan konfigurasi aplikasi via `App.config` serta `Properties`.

---

## 📂 Struktur Proyek

```text
Hovlibrary/
│
├── Hovlibrary.sln                    # Solution file Visual Studio
│
└── Hovlibrary/                       # Project directory
    ├── App.config                    # Konfigurasi aplikasi & connection string
    ├── Hovlibrary.csproj             # File proyek C# WinForms
    ├── Program.cs                    # Entry point aplikasi
    │
    ├── Form1.cs                      # Form utama aplikasi
    ├── Form1.Designer.cs
    ├── Form1.resx
    │
    ├── MasterBook.cs                 # Form pengolahan data buku (Master Book)
    ├── MasterBook.Designer.cs
    ├── MasterBook.resx
    │
    ├── DataClasses1.dbml             # Diagram LINQ to SQL ORM
    ├── DataClasses1.dbml.layout
    ├── DataClasses1.designer.cs      # Auto-generated code LINQ to SQL
    │
    └── Properties/                   # Assembly info, Resources, & Settings
        ├── AssemblyInfo.cs
        ├── Resources.Designer.cs
        ├── Resources.resx
        ├── Settings.Designer.cs
        └── Settings.settings
```

---

## 💻 Prasyarat & Teknologi

- **Bahasa Pemrograman:** C# (.NET Framework 4.7.2)
- **UI Framework:** Windows Forms (WinForms)
- **Database/ORM:** SQL Server & LINQ to SQL (`.dbml`)
- **IDE:** Visual Studio 2019 / 2022 (dengan workflow *.NET desktop development*)

---

## 🚀 Cara Menjalankan Proyek

1. **Clone / Extract Repository:**
   Pastikan seluruh direktori proyek diekstrak ke komputer lokal Anda.

2. **Buka Proyek di Visual Studio:**
   Double-click pada file `Hovlibrary.sln` atau buka Visual Studio lalu pilih **Open a project or solution** dan pilih `Hovlibrary.sln`.

3. **Konfigurasi Connection String:**
   Buka file `App.config` dan atur `connectionString` agar sesuai dengan server SQL Server lokal Anda:
   ```xml
   <connectionStrings>
       <add name="Hovlibrary.Properties.Settings.HovlibraryConnectionString"
            connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=Hovlibrary;Integrated Security=True"
            providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

4. **Build & Run:**
   - Tekan `Ctrl + Shift + B` untuk me-build proyek.
   - Tekan `F5` atau klik tombol **Start** di Visual Studio untuk menjalankan aplikasi `Hovlibrary.exe`.

---

## 📄 Lisensi

Proyek ini dikembangkan untuk kebutuhan manajemen perpustakaan. Hak cipta milik pengembang Hovlibrary.
