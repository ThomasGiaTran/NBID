using NBID.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NBID.Core
{
    public class DetailsManager
    {
        string ComPlusconstring = ConfigurationManager.ConnectionStrings["ComplusContext"].ToString();
        string FinPlusconstring = ConfigurationManager.ConnectionStrings["FinplusContext"].ToString();
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();
        string SQL2008constring = ConfigurationManager.ConnectionStrings["SQL2008Context"].ToString();
        string TylerCNBconstring = ConfigurationManager.ConnectionStrings["TylerCNB"].ToString();
        string MunisConstring = ConfigurationManager.ConnectionStrings["Mu_Live"].ToString();

        //===========================Get_UB_ComPlus===========================
        public Details GetDetails_ACIS_Historical(string id, string id1)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "select a.*, b.*, c.*, d.*, e.*, f.e_name as prop_owner, f.e_adrs1 as po_adrs1, f.e_adrs2 as po_adrs2, f.e_city as po_city, f.e_state as po_state, f.e_zip as po_zip ";
            strSQL += "from cubaccount a, cpbentity b, cpbentity_addr c, cpbparcel d, outer cpbentity_phone e, cnb_propowner f ";
            strSQL += "where a.c_entity_id = b.entity_id ";
            strSQL += "and a.c_entity_id = c.entity_id ";
            strSQL += "and a.c_addr_ins = c.e_adrs_ins ";
            strSQL += "and a.parcel_id = d.parcel_id ";
            strSQL += "and a.c_entity_id = e.entity_id ";
            strSQL += "and a.c_phone_ins = e.e_phone_ins ";
            strSQL += "and d.prop_key = f.prop_key ";
            strSQL += "AND a.cust_no = '" + id + "'";
            strSQL += "AND a.cust_ser = '" + id1 + "'";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();

            while (dbread.Read())
            {
                results.a = dbread["cust_no"].ToString();
                results.b = dbread["cust_ser"].ToString();
                results.c = dbread["stat"].ToString();
                results.d = dbread["e_name"].ToString();
                results.e = dbread["p_adrs"].ToString();
                results.f = dbread["p_city"].ToString();
                results.g = dbread["p_state"].ToString();
                results.h = dbread["p_zip"].ToString();
                results.i = dbread["e_adrs1"].ToString();
                results.j = dbread["e_adrs2"].ToString();
                results.k = dbread["e_adrs3"].ToString();
                results.l = dbread["e_city"].ToString();
                results.m = dbread["e_state"].ToString();
                results.n = dbread["e_zip"].ToString();
                results.o = "????";
                results.p = dbread["e_mail_code"].ToString();
                results.q = dbread["e_phone_no"].ToString();
                results.r = "????";
                results.s = "????";
                results.t = dbread["route"].ToString();
                results.u = dbread["own_flag"].ToString();
                results.v = dbread["tax_x"].ToString();
                results.w = dbread["penalty_x"].ToString();
                results.x = dbread["discon_x"].ToString();
                results.y = dbread["user1"].ToString();
                results.z = dbread["user2"].ToString();
                results.aa = dbread["user3"].ToString();
                results.bb = dbread["user4"].ToString();
                results.cc = dbread["munic"].ToString();
                results.dd = dbread["credit"].ToString();
                results.ee = dbread["balance"].ToString();
                results.ff = dbread["read_pd"].ToString();
                results.gg = dbread["e_house_num"].ToString();
                results.hh = dbread["e_street"].ToString();
                results.ii = dbread["e_street_cd"].ToString();
                results.jj = dbread["from_dt"].ToString();
                results.kk = dbread["to_dt"].ToString();
                results.ll = dbread["prop_owner"].ToString();
                results.mm = dbread["po_adrs1"].ToString();
                results.nn = dbread["po_adrs2"].ToString();
                results.oo = dbread["po_city"].ToString();
                results.pp = dbread["po_state"].ToString();
                results.qq = dbread["po_zip"].ToString();
                results.rr = dbread["parcel_id"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================GetDetails_Alarm_Billing===========================
        public Details GetDetails_Alarm_Billing(string id)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT a.acct_no, a.acct_type, a.stat, b.e_name as cust_name, a.p_adrs, a.p_city, a.p_state, a.p_zip, d.e_adrs1 as b_adrs1, d.e_adrs2 as b_adrs2, d.e_adrs3 as b_adrs3, d.e_city as b_city, d.e_state as b_state, d.e_zip as b_zip, e.e_phone_no as h_phone, a.parcel_id, i.e_name as owner_name, balance, c.e_adrs1 as own_addy, c.e_adrs2 as own_addy2, c.e_city as o_city, c.e_state as o_state, c.e_zip as o_zip ";
            strSQL = strSQL + "from cabacct a, cpbentity b, cpbentity_addr c, cpbentity_addr d, outer cpbentity_phone e, cpbentity f, cpbentity i ";
            strSQL = strSQL + "where a.m_entity_id = b.entity_id ";
            strSQL = strSQL + "and a.o_entity_id = c.entity_id ";
            strSQL = strSQL + "and a.o_addr_no = c.e_adrs_ins ";
            strSQL = strSQL + "and a.m_entity_id = e.entity_id ";
            strSQL = strSQL + "and a.m_phone_ins = e.e_phone_ins ";
            strSQL = strSQL + "and a.m_entity_id = d.entity_id ";
            strSQL = strSQL + "and a.m_addr_no = d.e_adrs_ins ";
            strSQL = strSQL + "and a.occup_id = f.entity_id ";
            strSQL = strSQL + "and a.o_entity_id = i.entity_id ";
            strSQL += "AND a.acct_no = '" + id + "'";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();

            while (dbread.Read())
            {
                results.a = dbread["acct_no"].ToString();
                results.b = dbread["acct_type"].ToString();
                results.c = dbread["stat"].ToString();
                results.d = dbread["cust_name"].ToString();
                results.e = dbread["p_adrs"].ToString();
                results.f = dbread["p_city"].ToString();
                results.g = dbread["p_state"].ToString();
                results.h = dbread["p_zip"].ToString();
                results.i = dbread["b_adrs1"].ToString();
                results.j = dbread["b_adrs2"].ToString();
                results.k = dbread["b_adrs3"].ToString();
                results.l = dbread["b_city"].ToString();
                results.m = dbread["b_state"].ToString();
                results.n = dbread["b_zip"].ToString();
                results.o = dbread["h_phone"].ToString();
                results.p = dbread["parcel_id"].ToString();
                results.q = dbread["balance"].ToString();
                results.r = dbread["owner_name"].ToString();
                results.s = dbread["own_addy"].ToString();
                results.t = dbread["own_addy2"].ToString();
                results.u = dbread["o_city"].ToString();
                results.v = dbread["o_state"].ToString();
                results.w = dbread["o_zip"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================GetDetails_Business_License===========================
        public Details GetDetails_Business_License(string id)
        {

            OdbcConnection dbConn = new OdbcConnection();
            dbConn.ConnectionString = ComPlusconstring;
            dbConn.Open();

            OdbcCommand dbComm = default(OdbcCommand);
            OdbcDataReader dbread = default(OdbcDataReader);
            string strSQL = null;

            strSQL = "SELECT b.bus_id as bus_id, b.license as license, b.stat as stat, b.category as category, cu.e_name, a.adrs1, ";
            strSQL = strSQL + "a.city, a.state_id, a.zip, ca.e_adrs1 as cust_adrs1, ca.e_adrs2 as cust_adrs2, ca.e_city as cust_city, ";
            strSQL = strSQL + "ca.e_state as cust_state, ca.e_zip as cust_zip, owner.e_name as owner_name, ";
            strSQL = strSQL + "a.o_entity_id, a.o_phone_ins, b.expiration, b_entity_id, cblrise.*, cblrise.state_id as sein, ";
            strSQL = strSQL + "establish, units, a.* ";
            strSQL = strSQL + "from cblbusiness a, cbllicense b, cpbentity cu, cpbentity_addr ca, cpbentity owner, cpbentity_addr owner_addr, outer cblrise ";
            strSQL = strSQL + "where a.bus_id = b.bus_id ";
            strSQL = strSQL + "and a.b_entity_id = cu.entity_id ";
            strSQL = strSQL + "and a.b_entity_id = ca.entity_id ";
            strSQL = strSQL + "and a.m_addr_no = ca.e_adrs_ins and a.o_entity_id = owner.entity_id ";
            strSQL = strSQL + "and a.o_entity_id = owner_addr.entity_id and a.o_addr_no = owner_addr.e_adrs_ins and a.bus_id = cblrise.bus_id ";
            strSQL += "AND b.license = '" + id + "'";

            dbComm = new OdbcCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();
            Helpers helps = new Helpers();

            while (dbread.Read())
            {
                results.a = Helpers.Get_AccType(dbread["license"].ToString());
                results.b = dbread["license"].ToString();
                results.c = dbread["category"].ToString();
                results.d = dbread["bus_id"].ToString();
                results.e = dbread["e_name"].ToString();
                results.f = dbread["owner_name"].ToString();
                results.g = helps.Get_Phone(dbread["o_entity_id"].ToString(), dbread["o_phone_ins"].ToString());
                results.h = dbread["o_type"].ToString();
                results.i = dbread["expiration"].ToString();
                results.j = dbread["adrs1"].ToString();
                results.k = dbread["city"].ToString() + ", " + dbread["state_id"].ToString() + ", " + dbread["zip"].ToString();
                results.l = dbread["cust_adrs1"].ToString();
                results.m = dbread["cust_adrs2"].ToString();
                results.n = dbread["cust_city"].ToString() + ", " + dbread["cust_state"].ToString();
                results.o = dbread["cust_zip"].ToString();
                results.p = helps.Get_Phone(dbread["b_entity_id"].ToString(), "1");
                results.q = dbread["fei_number"].ToString();
                results.r = dbread["sein"].ToString();
                results.s = dbread["establish"].ToString();
                results.t = dbread["sic_code"].ToString();
                results.u = dbread["units"].ToString();
                results.v = dbread["usr1"].ToString();
                results.w = dbread["usr2"].ToString();
                results.x = dbread["usr3"].ToString();
                results.y = dbread["usr4"].ToString();
                results.z = dbread["usr5"].ToString();
                results.aa = dbread["usr6"].ToString();
                results.bb = dbread["usr7"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================GetDetails_LEADS===========================
        public Details GetDetails_LEADS(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = SQL2008constring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string sql = null;

            sql = "select a.number_key as number_key, data_status, name, address_1, address_2, address_3, address_4, zip, phone_1, balance, title, text_000, date_018, user_id, mon_036 as est_tax, mon_035 as est_pen ";
            sql = sql + "from apd_base a, apd_peo b, apd_txt0 c, apd_num0 d, apd_mon0 e ";
            sql = sql + "where a.number_key = b.number_key ";
            sql = sql + "and a.number_key = c.number_key ";
            sql = sql + "and a.number_key = d.number_key ";
            sql = sql + "and a.number_key = e.number_key ";
            sql = sql + "and primary_name = '1' ";
            sql = sql + "and LEFT(a.number_key,1) = 'K' ";
            sql = sql + "AND a.number_key = '" + id + "'";
            sql = sql + "and notation is not null ";

            dbComm = new SqlCommand(sql, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();

            while (dbread.Read())
            {
                results.a = dbread["number_key"].ToString();
                results.b = dbread["address_4"].ToString();
                results.c = dbread["data_status"].ToString();
                results.d = dbread["name"].ToString();
                results.e = dbread["address_1"].ToString();
                results.f = dbread["address_2"].ToString();
                results.g = dbread["address_3"].ToString() + " " + dbread["zip"].ToString();
                results.h = dbread["TEXT_000"].ToString();
                results.i = dbread["date_018"].ToString();
                results.j = dbread["user_id"].ToString();
                results.k = dbread["est_tax"].ToString();
                results.l = dbread["est_pen"].ToString();
                results.m = dbread["balance"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================UB MUNIS===========================
        public Details GetDetails_UB_Munis(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = MunisConstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string sql = null;

            sql = "SELECT utacd_account, utacm_start_date, utacm_stop_date, ";
            sql = sql + " utacd_relation, utacd_billable, utacd_start_date, utacd_stop_date, ";
            sql = sql + " utacd_cid, arcs_name1, utacd_prem_phone, arcs_addr1, arcs_city, arcs_state, arcs_zip ";
            sql = sql + " FROM utactcid a, utactmst b, mu_live.dbo.arcstcid c ";
            sql = sql + " WHERE a.utacd_account = b.utacm_account AND a.utacd_cid = c.arcs_acct ";
            sql = sql + " AND utacd_cid = '" + id + "'";

            dbComm = new SqlCommand(sql, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();

            while (dbread.Read())
            {
                results.a = dbread["utacd_account"].ToString();
                results.b = dbread["utacm_start_date"].ToString();
                results.c = dbread["utacm_stop_date"].ToString();
                results.d = dbread["utacd_relation"].ToString();
                results.e = dbread["utacd_billable"].ToString();
                results.f = dbread["utacd_start_date"].ToString();
                results.g = dbread["utacd_stop_date"].ToString();
                results.h = dbread["utacd_cid"].ToString();
                results.i = dbread["arcs_name1"].ToString();
                results.j = dbread["utacd_prem_phone"].ToString();
                results.k = dbread["arcs_addr1"].ToString();
                results.l = dbread["arcs_city"].ToString();
                results.m = dbread["arcs_state"].ToString();
                results.n = dbread["arcs_zip"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================VENDORS MUNIS===========================
        public Details GetDetails_Vendors_Munis(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = MunisConstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string sql = null;

            sql = "SELECT apvn_vend, apvn_entity, ";
            sql = sql + " apvn_alpha_sort, apvn_genl_type, ";
            sql = sql + " apvn_stat_cd, apvn_stat_resn, ";
            sql = sql + " apvn_name, apvn_name2, apvn_dba, ";
            sql = sql + " apvn_addr1, apvn_addr2, ";
            sql = sql + " apvn_zip, apvn_city, apvn_state, apvn_email_addr ";
            sql = sql + " FROM apvendor";
            sql = sql + " WHERE apvn_vend = '" + id + "'";

            dbComm = new SqlCommand(sql, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();

            while (dbread.Read())
            {
                results.a = dbread["apvn_vend"].ToString();
                results.b = dbread["apvn_entity"].ToString();
                results.c = dbread["apvn_alpha_sort"].ToString();
                results.d = dbread["apvn_genl_type"].ToString();
                results.e = dbread["apvn_stat_cd"].ToString();
                results.f = dbread["apvn_stat_resn"].ToString();
                results.g = dbread["apvn_name"].ToString();
                results.h = dbread["apvn_name2"].ToString();
                results.i = dbread["apvn_dba"].ToString();
                results.j = dbread["apvn_addr1"].ToString();
                results.k = dbread["apvn_addr2"].ToString();
                results.l = dbread["apvn_zip"].ToString();
                results.m = dbread["apvn_city"].ToString();
                results.n = dbread["apvn_state"].ToString();
                results.o = dbread["apvn_email_addr"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
        //===========================GENERAL BILLING MUNIS===========================
        public Details GetDetails_GB_Munis(string id)
        {

            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = MunisConstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string sql = null;

            sql = "SELECT DISTINCT gboh_acct, gboh_ar_code, gboh_bill, gboh_inv_date, ";
            sql = sql + " gboh_batch, gboh_clerk, gboh_cust_po, arbh_unpd_bal, gboh_disc_pct, gboh_dept, gboh_parcel, ";
            sql = sql + " gboh_contract, gboh_for_loc, ca_name1, ca_name2, ca_address1, ca_city, ca_state, ca_zip ";
            sql = sql + " FROM gbinvoih a, arbilhdr b , ub_customer_addl c ";
            sql = sql + " WHERE a.gboh_acct = b.arbh_acct AND a.gboh_acct = c.a_customer AND a.gboh_bill = b.arbh_bill ";
            sql = sql + " AND a.gboh_bill = '" + id + "'";

            dbComm = new SqlCommand(sql, dbConn);
            dbread = dbComm.ExecuteReader();

            Details results = new Details();

            while (dbread.Read())
            {
                results.a = dbread["gboh_acct"].ToString();
                results.b = dbread["gboh_ar_code"].ToString();
                results.c = dbread["gboh_bill"].ToString();
                results.d = dbread["gboh_inv_date"].ToString();
                results.e = dbread["gboh_batch"].ToString();
                results.f = dbread["gboh_clerk"].ToString();
                results.g = dbread["gboh_cust_po"].ToString();
                results.h = dbread["arbh_unpd_bal"].ToString();
                results.i = dbread["gboh_disc_pct"].ToString();
                results.j = dbread["gboh_dept"].ToString();
                results.k = dbread["gboh_parcel"].ToString();
                results.l = dbread["gboh_contract"].ToString();
                results.m = dbread["gboh_for_loc"].ToString();
                results.n = dbread["ca_name1"].ToString();
                results.o = dbread["ca_name2"].ToString();
                results.p = dbread["ca_address1"].ToString();
                results.q = dbread["ca_city"].ToString();
                results.r = dbread["ca_state"].ToString();
                results.s = dbread["ca_zip"].ToString();
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return results;
        }
    }
}