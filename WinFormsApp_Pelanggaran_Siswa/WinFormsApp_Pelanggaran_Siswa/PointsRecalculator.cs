using LoginDatabase;
using System;
using System.Data.SqlClient;

namespace WinFormsApp_Pelanggaran_Siswa
{
    /// <summary>
    /// Helper class untuk recalculate total_point siswa
    /// </summary>
    public static class PointsRecalculator
    {
        /// <summary>
        /// Recalculate total_point untuk semua siswa
        /// </summary>
        public static void RecalculateAllPoints(Koneksi konn)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    conn.Open();

                    // Query untuk update total_point semua siswa
                    string sql = @"
                        UPDATE s
                        SET total_point = ISNULL(t.sum_point, 0)
                        FROM dbo.siswa s
                        LEFT JOIN (
                            SELECT p.nis, SUM(ISNULL(j.point, 0)) AS sum_point
                            FROM dbo.pelanggaran p
                            LEFT JOIN dbo.jenis_pelanggaran j ON p.id_jenis = j.id_jenis
                            GROUP BY p.nis
                        ) t ON s.nis = t.nis";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandTimeout = 120; // 2 menit timeout
                        int affected = cmd.ExecuteNonQuery();

                        // Log untuk debugging
                        System.Diagnostics.Debug.WriteLine($"PointsRecalculator: Updated {affected} siswa records");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"PointsRecalculator: Error - {ex.Message}");
                throw; // Re-throw agar bisa di-catch di level atas
            }
        }

        /// <summary>
        /// Recalculate total_point untuk satu siswa spesifik (optional)
        /// </summary>
        public static void RecalculatePointForStudent(Koneksi konn, string nis)
        {
            if (string.IsNullOrWhiteSpace(nis)) return;

            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    conn.Open();

                    string sql = @"
                        UPDATE s
                        SET total_point = ISNULL(t.sum_point, 0)
                        FROM dbo.siswa s
                        LEFT JOIN (
                            SELECT p.nis, SUM(ISNULL(j.point, 0)) AS sum_point
                            FROM dbo.pelanggaran p
                            LEFT JOIN dbo.jenis_pelanggaran j ON p.id_jenis = j.id_jenis
                            WHERE p.nis = @nis
                            GROUP BY p.nis
                        ) t ON s.nis = t.nis
                        WHERE s.nis = @nis";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nis", nis);
                        cmd.ExecuteNonQuery();

                        System.Diagnostics.Debug.WriteLine($"PointsRecalculator: Updated point for NIS {nis}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"PointsRecalculator: Error for NIS {nis} - {ex.Message}");
                throw;
            }
        }
    }
}