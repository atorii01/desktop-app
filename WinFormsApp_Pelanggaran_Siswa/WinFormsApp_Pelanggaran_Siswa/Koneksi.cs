using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace LoginDatabase
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = TUFA16\\SQLEXPRESS ; initial " +
                "catalog = POS_Pelanggaran; integrated security = true";
            return Conn;
        }
    }
}