using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NBID.Core
{
    public class NewIDManager
    {
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();

        public string Get_newNBID()
        {
            string newNBID = "";
            SqlConnection connection = new SqlConnection(Jasmineconstring);
            connection.Open();

            string strSQL = null;
            strSQL = "select next value for dbo.nbid newNBID ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            SqlDataReader dbread = default(SqlDataReader);
            dbread = cmd.ExecuteReader();

            while (dbread.Read())
            {
                newNBID = dbread["newNBID"].ToString();
            }

            dbread.Close();
            connection.Close();

            return newNBID;


        }
    }
}