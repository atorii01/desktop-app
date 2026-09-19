using System;
using System.Data.SqlClient;

namespace LoginDatabase
{
    public sealed class Koneksi
    {
        // Singleton instance
        private static readonly Koneksi instance = new Koneksi();

        // Use a private constructor to prevent external instantiation
        private Koneksi() { }

        // Public property to get the single instance
        public static Koneksi Instance => instance;

        // Connection string
        private readonly string connectionString =
            "Data Source=HYPEAMD\\SQLEXPRESS;" +
            "Initial Catalog=POS_Pelanggaran;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;" +
            "Max Pool Size=200;" +
            "Connection Timeout=15;";

        // Method to get a new SqlConnection object
        public SqlConnection GetConn()
        {
            return new SqlConnection(connectionString);
        }
    }
}