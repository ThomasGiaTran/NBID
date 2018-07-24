using NBID.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace NBID.Core
{
    public class NoteManager
    {
        string Jasmineconstring = ConfigurationManager.ConnectionStrings["JasmineContext"].ToString();
        //ADD NOTES
        public void AddNotes(HomeViewModels vm)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = Jasmineconstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            if(vm.notes.icon == null)
            {
                vm.notes.icon = "note.gif";
            }

            strSQL = "INSERT INTO nbid_notes values (";
            strSQL += "'" + vm.notes.nbid + "', '" + vm.notes.user_id + "', '" + vm.notes.date_time + "', '" + vm.notes.subject + "', '" + vm.notes.comment + "', '" + vm.notes.icon + "')";


            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;
        }
        //FIND NOTES
        public nbid_notes FindNotes(int id)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = Jasmineconstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "SELECT note_id, nbid, icon, subject, comment, user_id, date_time ";
            strSQL += "FROM nbid_notes ";
            strSQL += "WHERE note_id = '" + id + "'";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            nbid_notes item = new nbid_notes();

            while (dbread.Read())
            {
                item.note_id = Convert.ToInt32(dbread["note_id"].ToString());
                item.nbid = dbread["nbid"].ToString();
                item.icon = dbread["icon"].ToString();
                item.subject = dbread["subject"].ToString();
                item.comment = dbread["comment"].ToString();
                item.user_id = Convert.ToInt32(dbread["user_id"].ToString());
                item.date_time = Convert.ToDateTime(dbread["date_time"].ToString());
            }

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            return item;
        }
        //EDIT NOTES
        public void EditNotes(HomeViewModels vm)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = Jasmineconstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "UPDATE nbid_notes ";
            strSQL += "SET icon = '" + vm.notes.icon + "', subject = '" + vm.notes.subject + "', ";
            strSQL += "comment = '" + vm.notes.comment + "', user_id = " + vm.notes.user_id + ", ";
            strSQL += "date_time = '" + DateTime.Now + "' ";
            strSQL += "WHERE note_id = " + vm.notes.note_id + "";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            //nbid_notes item = new nbid_notes();

            //while (dbread.Read())
            //{
            //    item.note_id = Convert.ToInt32(dbread["note_id"].ToString());
            //    item.nbid = dbread["nbid"].ToString();
            //    item.icon = dbread["icon"].ToString();
            //    item.subject = dbread["subject"].ToString();
            //    item.comment = dbread["comment"].ToString();
            //    item.user_id = Convert.ToInt32(dbread["user_id"].ToString());
            //    item.date_time = Convert.ToDateTime(dbread["date_time"].ToString());
            //}

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;

            //return item;
        }
        //DELETE NOTES
        public void DeleteNotes(int id)
        {
            SqlConnection dbConn = new SqlConnection();
            dbConn.ConnectionString = Jasmineconstring;
            dbConn.Open();

            SqlCommand dbComm = default(SqlCommand);
            SqlDataReader dbread = default(SqlDataReader);
            string strSQL = null;

            strSQL = "DELETE FROM nbid_notes ";
            strSQL += "WHERE note_id = '" + id + "'";

            dbComm = new SqlCommand(strSQL, dbConn);
            dbread = dbComm.ExecuteReader();

            dbread.Close();

            dbComm.Dispose();

            dbConn.Close();
            dbConn = null;
        }
    }
}