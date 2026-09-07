using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Desktop_FA608UM.Model
{
    public class Database
    {

        private string _connectionString = "Data Source=TUFA16\\SQLEXPRESS;Initial Catalog=Quizify_DB;Integrated Security=True"; //inisialization
        public SqlConnection connection;

        public SqlDataReader ReadData(string query, SqlParameter[] parameter = null)
        {
            connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameter != null)
            {
                cmd.Parameters.AddRange(parameter);
            }

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return reader;
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log the error)
                return null;
            }

        }

        public int executeData(string query, SqlParameter[] parameter = null) {
            connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameter != null)
            {
                cmd.Parameters.AddRange(parameter);
            }
            try
            {
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return 0;
            }
        }

        internal System.Data.SqlClient.SqlDataReader ReadData(string sql, System.Data.SqlClient.SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        internal int executeData(string insertQuerry, System.Data.SqlClient.SqlParameter[] insertParameters)
        {
            throw new NotImplementedException();
        }
    }
}
