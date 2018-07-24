using System.Configuration;
using System.Data.SqlClient;

namespace NBID.Core
{
    public class MergeManager
    {
        string ComPlusconstring = ConfigurationManager.ConnectionStrings["ComplusContext"].ToString();
        string FinPlusconstring = ConfigurationManager.ConnectionStrings["FinplusContext"].ToString();
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();
        string SQL2008constring = ConfigurationManager.ConnectionStrings["SQL2008Context"].ToString();
        string TylerCNBconstring = ConfigurationManager.ConnectionStrings["TylerCNB"].ToString();
        string MunisConstring = ConfigurationManager.ConnectionStrings["Mu_Live"].ToString();

        private int findSmall (int x, int y)
        {
            if (x < y)
                return x;
            else
                return y;
        }

        private int findBig (int x, int y)
        {
            if (x > y)
                return x;
            else
                return y;
        }

        //Munis UB, GB, and Vendors
        private void mergeMunis(int small, int big)
        {
            SqlConnection connection = new SqlConnection(MunisConstring);

            string strSQL = null;
            strSQL = "UPDATE mu_live.dbo.spusrdat ";
            strSQL += " SET spud_data = '" + small + "' ";
            strSQL += " WHERE spud_data = '" + big + "' ";
            strSQL += " and spud_applid in ('apvendor', 'arcstmnt') and spud_field in (1, 5) ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Jasmine Notes and Query
        private void mergeJasmine(int small, int big)
        {
            SqlConnection connection = new SqlConnection(Jasmineconstring);

            string strSQL = null;
            //notes table
            strSQL = "UPDATE nbid_notes ";
            strSQL += " SET nbid = '" + small + "' ";
            strSQL += " WHERE nbid = '" + big + "'; ";

            //query table
            strSQL += "UPDATE nbid_query ";
            strSQL += " SET nbid = '" + small + "' ";
            strSQL += " WHERE nbid = '" + big + "' ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Community Plus ACIS, Alarm, and Business License
        private void mergeCommunityPlus(int small, int big)
        {
            SqlConnection connection = new SqlConnection(ComPlusconstring);

            string strSQL = null;
            //ACIS Historical
            strSQL = "UPDATE cubaccount ";
            strSQL += " SET user1 = '" + small + "' ";
            strSQL += " WHERE user1 = '" + big + "'; ";

            //Alarm Billing
            strSQL += "UPDATE cabreg ";
            strSQL += " SET knox_box = '" + small + "' ";
            strSQL += " WHERE knox_box = '" + big + "'; ";

            //Business License
            strSQL += "UPDATE cblbusiness ";
            strSQL += " SET usr1 = '" + small + "' ";
            strSQL += " WHERE usr1 = '" + big + "'; ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Finance Plus for AP Vendors
        private void mergeFinPlus(int small, int big)
        {
            SqlConnection connection = new SqlConnection(FinPlusconstring);

            string strSQL = null;
            //AP Vendor
            strSQL = "UPDATE vendor ";
            strSQL += " SET comm11 = '" + small + "' ";
            strSQL += " WHERE comm11 = '" + big + "'; ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //SQL2008 Permits Plus
        private void mergeSQL2008(int small, int big)
        {
            SqlConnection connection = new SqlConnection(SQL2008constring);

            string strSQL = null;

            //AP Vendor
            strSQL = "UPDATE apd_peo ";
            strSQL += " SET notation = '" + small + "' ";
            strSQL += " WHERE notation = '" + big + "'; ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //Jasmine Turbo Citations
        private void mergeTurboCitations(int small, int big)
        {
            SqlConnection connection = new SqlConnection(Jasmineconstring);

            string strSQL = null;

            //AP Vendor
            strSQL = "UPDATE turbo_citations ";
            strSQL += " SET NBID = '" + small + "' ";
            strSQL += " WHERE NBID = '" + big + "'; ";

            strSQL += " UPDATE nbid_query ";
            strSQL += " SET NBID = '" + small + "' ";
            strSQL += " WHERE NBID = '" + big + "'; ";

            strSQL += " UPDATE nbid_notes ";
            strSQL += " SET NBID = '" + small + "' ";
            strSQL += " WHERE NBID = '" + big + "'; ";

            SqlCommand cmd = new SqlCommand(strSQL, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //The ultimate merge
        public void mergeAll(int x, int y)
        {
            int small = findSmall(x, y);
            int big = findBig(x, y);

            mergeMunis(small, big);
            mergeJasmine(small, big);
            mergeCommunityPlus(small, big);
            mergeFinPlus(small, big);
            mergeSQL2008(small, big);
            mergeTurboCitations(small, big);
        }
    }
}