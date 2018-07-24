using Microsoft.AspNet.Identity;
using NBID.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NBID.Core
{
    public class AccountManager
    {
        static string TylerConString = ConfigurationManager.ConnectionStrings["TylerCNB"].ConnectionString;
        static string DefaultConString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool ValidLogin(LoginViewModel vm)
        {
            bool valid = false;
            string dbPassword = "";
            int iknt = 0;
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = TylerConString;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);

            string strSQL;
            strSQL = "SELECT phash ";
            strSQL = strSQL + "FROM cnb_auth ";
            strSQL = strSQL + "WHERE RTrim(empl_no) = @EmplNo ";

            //response.write(strSQL)
            dbComm = new SqlCommand(strSQL, dbConn);
            dbComm.Parameters.AddWithValue("@EmplNo", vm.empl_no.Trim());
            dbread = dbComm.ExecuteReader();


            while (dbread.Read())
            {
                iknt = iknt + 1;
                dbPassword = dbread["phash"].ToString();
            }

            dbread.Close();
            dbComm = null;
            dbConn.Close();
            dbConn = null;

            if (iknt > 0)
            {
                PasswordHasher myPasswordHasher = new PasswordHasher();
                PasswordVerificationResult result;
                result = myPasswordHasher.VerifyHashedPassword(dbPassword, vm.Password);
                if (result.ToString().Trim() == "Success")
                {
                    valid = true;
                }
            }
            return valid;
        }

        public bool Existed(LoginViewModel vm)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = DefaultConString;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;
            int iknt = 0;

            strSQL = "SELECT * FROM [tyler_cnb].[dbo].[AspNetUsers] ";
            strSQL += "WHERE UserName = @EmplNo ";

            //response.write(strSQL)
            dbComm = new SqlCommand(strSQL, dbConn);
            dbComm.Parameters.AddWithValue("@EmplNo", vm.empl_no.Trim());
            dbread = dbComm.ExecuteReader();

            while (dbread.Read())
            {
                iknt = iknt + 1;
            }

            dbread.Close();
            dbComm = null;
            dbConn.Close();
            dbConn = null;

            if (iknt > 0)
                return true;
            else
                return false;
        }

        public LoginViewModel getUserNames(string s)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = DefaultConString;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "SELECT * FROM [tyler_cnb].[dbo].[CNB_users] ";
            strSQL += "WHERE empl_no = @EmplNo ";

            //response.write(strSQL)
            dbComm = new SqlCommand(strSQL, dbConn);
            dbComm.Parameters.AddWithValue("@EmplNo", s);
            dbread = dbComm.ExecuteReader();

            LoginViewModel user = new LoginViewModel();

            while (dbread.Read())
            {
                user.userFullName = dbread["FirstName"].ToString() + " " + dbread["LastName"].ToString();
                user.empl_no = dbread["empl_no"].ToString();
            }

            dbread.Close();
            dbComm = null;
            dbConn.Close();
            dbConn = null;

            return user;
        }
    }
}