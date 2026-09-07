using Npgsql;
using System.Data;

namespace UmkmPintarKasir.Data
{
    public static class DbConnectionHelper
    {
        // Sesuaikan db, user, password, dan host
        private static string _connString =
            "Host=localhost;Port=5432;Database=UMKM_PINTAR_DB;Username=postgres;Password=190109";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connString);
        }

        public static DataTable ExecuteQuery(string sql, params NpgsqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static int ExecuteNonQuery(string sql, params NpgsqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params NpgsqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
