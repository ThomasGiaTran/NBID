using NBID.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NBID.Core
{
    public class UnclusterManager
    {
        string ComPlusconstring = ConfigurationManager.ConnectionStrings["ComplusContext"].ToString();
        string FinPlusconstring = ConfigurationManager.ConnectionStrings["FinplusContext"].ToString();
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();
        string SQL2008constring = ConfigurationManager.ConnectionStrings["SQL2008Context"].ToString();
        string TylerCNBconstring = ConfigurationManager.ConnectionStrings["TylerCNB"].ToString();
        string MunisConstring = ConfigurationManager.ConnectionStrings["Mu_Live"].ToString();

        //UB_Munis
        public void Uncluster_UB_Munis(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(MunisConstring);

            string strSQL = null;
            strSQL = "UPDATE mu_live.dbo.spusrdat ";
            strSQL += " SET spud_data = @New_NBID ";
            strSQL += " WHERE spud_data = @Old_NBID ";
            strSQL += " AND spud_key = @CustomerNo ";
            strSQL += " and spud_field = 5 AND spud_applid = 'arcstmnt'  ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@CustomerNo", vm.CustomerNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //GB_Munis
        public void Uncluster_GB_Munis(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(MunisConstring);

            string strSQL = null;
            strSQL = "UPDATE mu_live.dbo.spusrdat ";
            strSQL += " SET spud_data = @New_NBID ";
            strSQL += " WHERE spud_data = @Old_NBID ";
            strSQL += " AND spud_key = @CustomerNo ";
            strSQL += " AND spud_field = 5 AND spud_applid = 'arcstmnt' ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@CustomerNo", vm.CustomerNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //APVendors_Munis
        public void Uncluster_APVendors_Munis(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(MunisConstring);

            string strSQL = null;
            strSQL = "UPDATE mu_live.dbo.spusrdat ";
            strSQL += " SET spud_data = @New_NBID ";
            strSQL += " WHERE spud_data = @Old_NBID ";
            strSQL += " AND spud_key = @VendorNo ";
            strSQL += " AND spud_field = 1 AND spud_applid = 'apvendor' ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@VendorNo", vm.VendorNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //UB ComPlus
        public void Uncluster_UB_ComPlus(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(ComPlusconstring);

            string strSQL = null;
            strSQL = "UPDATE cubaccount ";
            strSQL += " SET user1 = @New_NBID ";
            strSQL += " WHERE user1 = @Old_NBID ";
            strSQL += " AND cust_no = @AccountNo ";
            strSQL += " AND cust_ser = @CustomerNo ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", vm.AccountNo.Trim());
            cmd.Parameters.AddWithValue("@CustomerNo", vm.CustomerNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Alarm Billing ComPlus
        public void Uncluster_Alarm_Billing_ComPlus(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(ComPlusconstring);

            string strSQL = null;
            strSQL = "UPDATE cabreg ";
            strSQL += " SET knox_box = @New_NBID ";
            strSQL += " WHERE knox_box = @Old_NBID ";
            strSQL += " AND acct_no = @AccountNo ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", vm.AccountNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Business License ComPlus
        public void Uncluster_Business_License_ComPlus(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(ComPlusconstring);

            string strSQL = null;
            strSQL = "UPDATE cblbusiness ";
            strSQL += " SET usr1 = @New_NBID ";
            strSQL += " WHERE usr1 = @Old_NBID ";
            strSQL += " AND bus_id = @CustomerNo ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@CustomerNo", vm.CustomerNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Finance Plus for AP Vendors
        public void Uncluster_APVendors_FinPlus(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(FinPlusconstring);

            string strSQL = null;
            strSQL = "UPDATE vendor ";
            strSQL += " SET comm11 = @New_NBID ";
            strSQL += " WHERE comm11 = @Old_NBID ";
            strSQL += " AND vend_no = @AccountNo ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", vm.AccountNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //LEADS PermPlus
        public void Uncluster_LEADS_PermPlus(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(SQL2008constring);

            string strSQL = null;
            strSQL = "UPDATE apd_peo ";
            strSQL += " SET notation = @New_NBID ";
            strSQL += " WHERE notation = @Old_NBID ";
            strSQL += " AND number_key = @AccountNo ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", vm.AccountNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Turbo Citations
        public void Uncluster_Turbo_Citations(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(SQL2008constring);

            string strSQL = null;
            strSQL = " UPDATE apd_peo ";
            strSQL += " SET notation = @New_NBID ";
            strSQL += " WHERE notation = @Old_NBID ";
            strSQL += " AND number_key = @AccountNo; ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", vm.AccountNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Turbo Citations
        public void Uncluster_Turbo_Temp_Tables(HomeViewModels vm)
        {
            SqlConnection connection = new SqlConnection(Jasmineconstring);

            string strSQL = null;
            strSQL += "  UPDATE Turbo_Citations " +
                        " SET NBID = @New_NBID " +
                        " WHERE NBID = @Old_NBID" +
                        " AND number_key = @AccountNo ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);
            cmd.Parameters.AddWithValue("@New_NBID", vm.newQueryID.Trim());
            cmd.Parameters.AddWithValue("@Old_NBID", vm.queryID.Trim());
            cmd.Parameters.AddWithValue("@AccountNo", vm.AccountNo.Trim());

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}