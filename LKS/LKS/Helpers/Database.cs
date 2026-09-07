using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS
{
    public class Database
    {
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(
                "server=TUFA16;database=Quizify_DB;uid=root;pwd=123;"
            );
        }
    }
}
