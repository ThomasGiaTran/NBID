using NBID.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace NBID.Core
{
    public class ResultsManager
    {
        string ComPlusconstring = ConfigurationManager.ConnectionStrings["ComplusContext"].ToString();
        string FinPlusconstring = ConfigurationManager.ConnectionStrings["FinplusContext"].ToString();
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();
        string SQL2008constring = ConfigurationManager.ConnectionStrings["SQL2008Context"].ToString();
        string TylerCNBconstring = ConfigurationManager.ConnectionStrings["TylerCNB"].ToString();
        string MunisConstring = ConfigurationManager.ConnectionStrings["Mu_Live"].ToString();



        //===========================NOTES===========================
        public List<nbid_notes> Get_Notes(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = Jasmineconstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "SELECT icon, subject, comment, user_id, date_time, note_id ";
            strSQL += "FROM nbid_notes ";
            strSQL += "WHERE nbid = '" + id + "'";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<nbid_notes> results = new List<nbid_notes>();


            while (dbread.Read())
            {
                nbid_notes item = new nbid_notes();
                item.icon = dbread["icon"].ToString();
                item.subject = dbread["subject"].ToString();
                item.comment = dbread["comment"].ToString();
                item.user_id = Convert.ToInt32(dbread["user_id"].ToString());
                item.note_id = Convert.ToInt32(dbread["note_id"].ToString());
                item.date_time = Convert.ToDateTime(dbread["date_time"].ToString());
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================Get_UB_ComPlus===========================
        public List<Results> Get_UB_ComPlus(string id)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT a.cust_no, a.cust_ser, a.stat, b.e_name, c.e_adrs1, d.p_adrs, e.e_phone_no, a.balance ";
            strSQL += "FROM cubaccount a, cpbentity b, cpbentity_addr c, cpbparcel d, outer cpbentity_phone e ";
            strSQL += "WHERE a.c_entity_id = b.entity_id ";
            strSQL += "AND a.c_entity_id = c.entity_id AND a.c_addr_ins = c.e_adrs_ins ";
            strSQL += "AND a.parcel_id = d.parcel_id AND  a.c_entity_id = e.entity_id ";
            strSQL += "AND a.c_phone_ins = e.e_phone_ins ";
            strSQL += "AND a.user1 = '" + id + "' ";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["cust_no"].ToString();
                item.cust_ser = dbread["cust_ser"].ToString();
                item.Status = dbread["stat"].ToString();
                item.Name = dbread["e_name"].ToString();
                item.Billing_Address = dbread["e_adrs1"].ToString();
                item.Service_Address = dbread["p_adrs"].ToString();
                item.Phone = dbread["e_phone_no"].ToString();
                item.Balance = dbread["balance"].ToString();
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }

        //===========================Get_APVendors_FinPlus===========================
        public List<Results> Get_APVendors_FinPlus(string id)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = FinPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT vend_no, ven_name[1,25], b_addr_1, b_phone, p_addr_1 ";
            strSQL += "FROM vendor ";
            strSQL += "WHERE comm11 = '" + id + "' ";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["vend_no"].ToString();
                item.cust_ser = "";
                item.Status = "";
                item.Name = dbread["ven_name"].ToString();
                item.Billing_Address = dbread["b_addr_1"].ToString();
                item.Service_Address = dbread["p_addr_1"].ToString();
                item.Phone = dbread["b_phone"].ToString();
                item.Balance = "";
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }

        //===========================Get_Alarm_Billing_ComPlus===========================
        public List<Results> Get_Alarm_Billing_ComPlus(string id)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT a.acct_no, a.stat, b.e_name, d.e_adrs1, a.p_adrs, e.e_phone_no, balance ";
            strSQL += "from cabacct a, cpbentity b, cpbentity_addr c, cpbentity_addr d, outer cpbentity_phone e, cabreg f ";
            strSQL += "where a.m_entity_id = b.entity_id ";
            strSQL += "and a.o_entity_id = c.entity_id ";
            strSQL += "and a.o_addr_no = c.e_adrs_ins ";
            strSQL += "and a.m_entity_id = e.entity_id ";
            strSQL += "and a.m_phone_ins = e.e_phone_ins ";
            strSQL += "and a.m_entity_id = d.entity_id ";
            strSQL += "and a.m_addr_no = d.e_adrs_ins ";
            strSQL += "and a.acct_no = f.acct_no ";
            strSQL += "and f.knox_box = '" + id + "' ";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["acct_no"].ToString();
                item.cust_ser = "";
                item.Status = dbread["stat"].ToString();
                item.Name = dbread["e_name"].ToString();
                item.Billing_Address = dbread["e_adrs1"].ToString();
                item.Service_Address = dbread["p_adrs"].ToString();
                item.Phone = dbread["e_phone_no"].ToString();
                item.Balance = dbread["balance"].ToString();
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================Business License===========================
        public List<Results> Get_BL_ComPlus(string id)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT b.bus_id, b.license, b.stat, c.e_name, a.adrs1, d.e_adrs1, e.e_phone_no, ";
            strSQL += "(fee + adj_pen + transfer_amt + del_1 + del_2 + del_3 + del_4 + bal_ly - exempt_amt - pay_amt + fee_reb + del_amt) + ";
            strSQL += "DECODE(  ";
            strSQL += "(SELECT SUM(f.fee_amt + f.fee_adj - f.pd_to_date) FROM cblfees f WHERE f.bus_id = a.bus_id AND f.license = b.license), ";
            strSQL += "null,  ";
            strSQL += "0, ";
            strSQL += "(SELECT SUM(f.fee_amt + f.fee_adj - f.pd_to_date) FROM cblfees f WHERE f.bus_id = a.bus_id AND f.license = b.license)) ";
            strSQL += "from cblbusiness a, cbllicense b, cpbentity c, cpbentity_addr d, outer cpbentity_phone e ";
            strSQL += "where a.bus_id = b.bus_id ";
            strSQL += "and a.b_entity_id = c.entity_id ";
            strSQL += "and a.b_entity_id = d.entity_id ";
            strSQL += "and a.m_addr_no = d.e_adrs_ins ";
            strSQL += "and a.b_entity_id = e.entity_id ";
            strSQL += "and e.e_phone_ins = 1 ";
            strSQL += "and usr1 = '" + id + "' ";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["license"].ToString();
                item.cust_ser = dbread["bus_id"].ToString();
                item.Status = dbread["stat"].ToString();
                item.Name = dbread["e_name"].ToString();
                item.Billing_Address = dbread["adrs1"].ToString();
                item.Service_Address = dbread["e_adrs1"].ToString();
                item.Phone = dbread["e_phone_no"].ToString();
                item.Balance = "";
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================LEADS===========================
        public List<Results> Get_LEADS_PermPlus(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = SQL2008constring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "select a.number_key as number_key, data_status, name, address_1, address_2, phone_1, balance, title ";
            strSQL += "from apd_base a, apd_peo b ";
            strSQL += "where a.number_key = b.number_key ";
            strSQL += " and LEFT(a.number_key,1) = 'K' ";
            strSQL += " and primary_name = '1' ";
            strSQL += " and notation is not null ";
            strSQL += " AND notation = '" + id + "'";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["number_key"].ToString();
                item.cust_ser = "";
                item.Status = dbread["data_status"].ToString();
                item.Name = dbread["name"].ToString();
                item.Billing_Address = "";
                item.Service_Address = dbread["address_2"].ToString();
                item.Phone = dbread["phone_1"].ToString();
                item.Balance = dbread["balance"].ToString();
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================UB MUNIS===========================
        public List<Results> Get_UB_Munis(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = MunisConstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "SELECT DISTINCT a.utacd_cid, ";
            strSQL += " CASE WHEN GETDATE() < utacd_stop_date THEN 'A' else utsvm_serv_status END as Account_Status,  ";
            strSQL += " a.utacd_account, c.arcs_name1, c.arcs_addr1 as Billing_Address, ";
            strSQL += " CONVERT(VARCHAR(10),b.utacm_loc_no) + ' ' + RTRIM(b.utacm_loc_street) + ' ' + b.utacm_loc_str_typ as Service_Address, c.arcs_phone, ";
            strSQL += " ISNULL((SELECT SUM(bd_original_amount-bd_paid_amount+bd_adjust_amount) ";
            strSQL += " FROM mu_live.dbo.ar_unpd_bills x ";
            strSQL += " WHERE x.a_ar_customer_cid = a.utacd_cid AND x.a_property_code = a.utacd_account),0) as balance ";
            strSQL += " FROM mu_live.dbo.utactcid a, mu_live.dbo.utactmst b, mu_live.dbo.arcstcid c, mu_live.dbo.utsvcmst d, mu_live.dbo.spusrdat e ";
            strSQL += " WHERE a.utacd_account = b.utacm_account AND a.utacd_cid = c.arcs_acct AND a.utacd_key = d.utsvm_utacd_key ";
            strSQL += " AND a.utacd_cid=e.spud_key AND spud_applid = 'arcstmnt' AND spud_field = '5' ";
            strSQL += " AND spud_data = '" + id + "'";


            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["utacd_account"].ToString();
                item.cust_ser = dbread["utacd_cid"].ToString();
                item.Status = dbread["Account_Status"].ToString();
                item.Name = dbread["arcs_name1"].ToString();
                item.Billing_Address = dbread["Billing_Address"].ToString();
                item.Service_Address = dbread["Service_Address"].ToString();
                item.Phone = dbread["arcs_phone"].ToString();
                item.Balance = dbread["balance"].ToString();
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================GENERAL BILLING MUNIS===========================
        public List<Results> Get_GB_Munis(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = MunisConstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "SELECT [a_bill_number] as invoice_no, [a_ar_customer_cid] as custno_nbid, bh_status, a_customer_name, ";
            strSQL += " a.ca_address1 as Billing_Address, a.ca_phone,  ";
            strSQL += " SUM(bd_original_amount-bd_paid_amount+bd_adjust_amount) as balance ";
            strSQL += " FROM [mu_live].[dbo].[ar_unpd_bills] b, ub_customer_addl a, mu_live.dbo.spusrdat e ";
            strSQL += " WHERE a_ar_code NOT IN ('PPL') ";
            strSQL += " AND b.a_ar_category = 1 ";
            strSQL += " AND a.a_customer = b.a_ar_customer_cid ";
            strSQL += " AND ca_address_no = '0' ";
            strSQL += " AND b.a_ar_customer_cid = e.spud_key AND spud_applid = 'arcstmnt' AND spud_field = '5' ";
            strSQL += " AND spud_data = '" + id + "'";
            strSQL += " group by   [a_ar_customer_cid],[a_bill_number],[a_customer_name], ca_address1, ca_phone, bh_status";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["invoice_no"].ToString();
                item.cust_ser = dbread["custno_nbid"].ToString();
                item.Status = dbread["bh_status"].ToString();
                item.Name = dbread["a_customer_name"].ToString();
                item.Billing_Address = dbread["Billing_Address"].ToString();
                item.Service_Address = "";
                item.Phone = dbread["ca_phone"].ToString();
                item.Balance = dbread["balance"].ToString();
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================MUNIS VENDORS===========================
        public List<Results> Get_APVendors_Munis(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = MunisConstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "SELECT a.apvn_vend, a.apvn_name, a.apvn_addr2 as Billing_Address, a.apvn_addr1 as Service_Address, spud_data, a.apvn_cont1_phone ";
            strSQL += " FROM apvendor a, spusrdat b  ";
            strSQL += " WHERE a.apvn_vend = b.spud_key ";
            strSQL += " AND b.spud_applid = 'apvendor' AND spud_field = 1 ";
            strSQL += " AND b.spud_data = '" + id + "'";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            List<Results> results = new List<Results>();


            while (dbread.Read())
            {
                Results item = new Results();
                item.AccountNo = dbread["apvn_vend"].ToString();
                item.cust_ser = dbread["spud_data"].ToString();
                item.Status = "";
                item.Name = dbread["apvn_name"].ToString();
                item.Billing_Address = dbread["Billing_Address"].ToString();
                item.Service_Address = dbread["Service_Address"].ToString();
                item.Phone = dbread["apvn_cont1_phone"].ToString();
                item.Balance = "";
                results.Add(item);
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        public List<Results> Get_Turbo_Citations(string id)
        {

            SqlConnection connection = new SqlConnection(Jasmineconstring);

            string query = "SELECT NBID, number_key, RO_Name, Status, AmountDue " +
                        "FROM NBID.dbo.Turbo_Citations " +
                        "WHERE NBID = '" +id + "'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Results> results = new List<Results>();


            while (reader.Read())
            {
                Results record = new Results();
                record.AccountNo = reader["number_key"].ToString();
                record.Status = reader["Status"].ToString();
                record.Name = reader["RO_Name"].ToString();
                record.Billing_Address = "";
                record.Service_Address = "";
                record.Phone = "";
                record.Balance = reader["AmountDue"].ToString();
                results.Add(record);
            }

            command.Dispose();
            reader.Close();
            connection.Close();

            return results;
        }
    }
}