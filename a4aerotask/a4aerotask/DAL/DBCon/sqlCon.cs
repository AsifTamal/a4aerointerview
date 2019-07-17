using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace a4aerotask.DAL.DBCon
{
    public class sqlCon
    {
        public SqlConnection con = null;
        public sqlCon()
        {
            con = getConnection();
        }

        public SqlConnection getConnection()
        {

            string connection = "";
            connection = ConfigurationManager.ConnectionStrings["A4areoDbCon"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            return con;
        }
    }
}