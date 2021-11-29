using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExemploBancoDeDados
{
    public class ConnectionManager
    {
        private static string ConnStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=exemploDB;Data Source=NOTE-ANDRE\SQLEXPRESS";

        public static SqlConnection GetConnection()
        {
            var cn = new SqlConnection(ConnStr);
            return cn;
        }
    }
}
