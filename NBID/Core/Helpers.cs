using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace NBID.Core
{
    public class Helpers
    {
        string ComPlusconstring = ConfigurationManager.ConnectionStrings["ComplusContext"].ToString();
        string FinPlusconstring = ConfigurationManager.ConnectionStrings["FinplusContext"].ToString();

        public static string Get_AccType(string Account)
        {
            if (Account.IndexOf("AL") >= 0)
            {
                return "ALARMS";
            }
            else if (Account.IndexOf("BB") >= 0)
            {
                return "BEACON BAY";
            }
            else if (Account.IndexOf("DG") >= 0)
            {
                return "DOG LICENSE";
            }
            else if (Account.IndexOf("BT") >= 0)
            {
                return "BUSINESS TAX";
            }
            else if (Account.IndexOf("BY") >= 0)
            {
                return "BALBOA YACHT BASIN";
            }
            else if (Account.IndexOf("C2") >= 0)
            {
                return "CITATIONS";
            }
            else if (Account.IndexOf("CITE") >= 0)
            {
                return "CITATIONS";
            }
            else if (Account.IndexOf("CP") >= 0)
            {
                return "COMMERCIAL PIERS";
            }
            else if (Account.IndexOf("CT") >= 0)
            {
                return "CHARTER TAX";
            }
            else if (Account.IndexOf("DA") >= 0)
            {
                return "DISTURBANCE ADVISEMENT";
            }
            else if (Account.IndexOf("EN") >= 0)
            {
                return "ENCROACHMENT";
            }
            else if (Account.IndexOf("LA") >= 0)
            {
                return "LIVE ABOARD";
            }
            else if (Account.IndexOf("MC") >= 0)
            {
                return "MUNICIPAL CODE";
            }
            else if (Account.IndexOf("MS") >= 0)
            {
                return "WASHINGTON ST";
            }
            else if (Account.IndexOf("RE") >= 0)
            {
                return "RENTAL OF PROPERTY";
            }
            else if (Account.IndexOf("RP") >= 0)
            {
                return "RESIDENTIAL PIER";
            }
            else if (Account.IndexOf("SW") >= 0)
            {
                return "SOLID WASTE";
            }
            else if (Account.IndexOf("UTOT") >= 0)
            {
                return "UNIFORM TRANSIT";
            }
            else
            {
                return "";
            }
        }

        public string Get_Phone(string b_entity_id, string phone)
        {
            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT e_phone_no ";
            strSQL = strSQL + "FROM cpbentity_phone ";
            strSQL = strSQL + "WHERE entity_id = '" + b_entity_id + "' ";
            strSQL = strSQL + "AND e_phone_ins = '" + phone + "'";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            string phone_no = "";
            while (dbread.Read())
            {
                phone_no = dbread["e_phone_no"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return phone_no;
        }

        //public string Get_Sic(string sicCode)
        //{
        //    OdbcConnection dbConn = new OdbcConnection();
        //    dbConn.ConnectionString = FinPlusconstring;
        //    dbConn.Open();

        //    OdbcCommand dbComm = default(OdbcCommand);
        //    OdbcDataReader dbread = default(OdbcDataReader);
        //    string strSQL = null;

        //    strSQL = "SELECT * ";
        //    strSQL = strSQL + "FROM mastperm ";
        //    strSQL = strSQL + "WHERE key_code = '" + sicCode + "' ";

        //    dbComm = new OdbcCommand(strSQL, dbConn);
        //    dbread = dbComm.ExecuteReader();

        //    string sic = "";
        //    while (dbread.Read())
        //    {
        //        sic = dbread["key_code"].ToString() + " - " + dbread["key_desc"].ToString();
        //    }            

        //    dbread.Close();

        //    dbComm.Dispose();

        //    dbConn.Close();
        //    dbConn = null;

        //    return sic;
        //}
    }
}