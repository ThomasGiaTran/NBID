using NBID.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace NBID.Core
{
    public class QueryManager
    {
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();

        public List<nbid_query> Get(HomeViewModels vm)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = Jasmineconstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            if (vm != null)
            {
                strSQL = "select * ";
                strSQL += "from nbid_query ";
                strSQL += "where 1 = 1";
                if (!string.IsNullOrEmpty(vm.SearchNBID))
                {
                    strSQL += " and nbid = '" + vm.SearchNBID.Trim() + "' ";
                }
                if (!string.IsNullOrEmpty(vm.SearchAccount))
                {
                    strSQL += " and acctno like '%" + vm.SearchAccount.Trim() + "%' ";
                }
                if (!string.IsNullOrEmpty(vm.SearchName))
                {
                    strSQL += " and cust_name like '%" + vm.SearchName.Trim() + "%' ";
                }
                if (!string.IsNullOrEmpty(vm.SearchPhone))
                {
                    strSQL += " and phone like '%" + vm.SearchPhone.Trim() + "%' ";
                }
                if (!string.IsNullOrEmpty(vm.SearchAddress))
                {
                    strSQL += " and (address1 like '%" + vm.SearchAddress.Trim() + "%' or address2 like '%" + vm.SearchAddress.Trim() + "%') ";
                }
                strSQL += " order by cust_name, phone";
            }
            else
            {
                strSQL = "SELECT * from  nbid_query ";
            }

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<nbid_query> results = new List<nbid_query>();

            while (dbread.Read())
            {
                nbid_query item = new nbid_query();
                item.nbid = dbread["nbid"].ToString();
                item.acctno = dbread["acctno"].ToString();
                item.cust_name = dbread["cust_name"].ToString();
                item.phone = dbread["phone"].ToString();
                item.address1 = dbread["address1"].ToString() + " " + dbread["address2"].ToString();
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
    }
}