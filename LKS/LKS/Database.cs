using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;

namespace Helpers
{
    public class Database
    {
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(
                "server=TUFA16\\SQLEXPRESS;database=Quizify_DB;uid=root;pwd=123;"
            );
        }
    }
}
