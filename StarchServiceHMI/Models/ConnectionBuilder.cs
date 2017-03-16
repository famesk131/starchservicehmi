using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;


namespace StarchServiceHMI.Models
{
    public class ConnectionBuilder
    {
        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-87BI6EK\\FAMESK131;Initial Catalog=StarchServiceHMI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            return conn;
        }
    }
}