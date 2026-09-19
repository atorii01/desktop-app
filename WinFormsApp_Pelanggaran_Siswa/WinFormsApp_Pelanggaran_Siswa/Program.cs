using System;
using System.Windows.Forms;

namespace WinFormsApp_Pelanggaran_Siswa
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Jalankan aplikasi utama (FormMDI)
                Application.Run(new FormMDI());
            }
            catch (Exception ex)
            {
                // Tangkap semua error yang muncul saat startup
                MessageBox.Show(
                    "Terjadi kesalahan saat menjalankan aplikasi:\n\n" +
                    ex.Message + "\n\n" +
                    "Detail:\n" + ex.StackTrace,
                    "Kesalahan Aplikasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
