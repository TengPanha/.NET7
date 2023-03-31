using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_SERVER_TengPanha
{
    internal class DataConnection
    {
        public static SqlConnection DataCon { get; set; }

        public static void ConnectionDB(string ip, string dbname)
        {
            DataCon = new SqlConnection($"Server={ip};Database={dbname};Trusted_Connection=True");
            DataCon.Open();
        }
        public static void ConnectionDB(string ip, string dbname, string user, string password)
        {
            DataCon = new SqlConnection($"Server={ip};Database={dbname};User Id={user};Password={password};");
            DataCon.Open();
        }
    }
}
