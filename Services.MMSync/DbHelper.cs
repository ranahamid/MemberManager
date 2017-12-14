using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Services.MMSync
{
    public static class DbHelper
    {
        public static SqlConnection CreateAndOpenConnection()
        {
            string connectionsstring = ConfigurationManager.ConnectionStrings["MemberManager"].ToString();
            var conn = new SqlConnection(connectionsstring);

            conn.Open();

            return conn;
        }
    }
}
