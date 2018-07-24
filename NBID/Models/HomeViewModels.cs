using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NBID.Models
{
    public class HomeViewModels
    {
        public HomeViewModels()
        {
            //parameters
            queryID = "";
            newQueryID = "";
            queryList = new List<nbid_query>();
            notesList = new List<nbid_notes>();
            notes = new nbid_notes();
            detailsID_1 = "";
            detailsID_2 = "";
            Dmode = "";
            SuccessMessage = false;
            ErrorMessage = false;
            Selected_MCB = new string[] { };
            Selected_UCB = new string[] { };
            AccountNo = "";

            //Results
            UB_ComPlus_List = new List<Results>();
            APVendors_FinPlus_List = new List<Results>();
            Alarm_Billing_ComPlus_List = new List<Results>();
            BL_ComPlus_List = new List<Results>();
            LEADS_PermPlus_List = new List<Results>();
            GB_Munis_List = new List<Results>();
            UB_Munis_List = new List<Results>();
            APVendors_Munis_List = new List<Results>();

            //Details
            Details_ACIS_Historical = new Details();
            Details_AP_Vendor = new Details();
            Details_Alarm_Billing = new Details();
            Details_Business_License = new Details();
            Details_LEADS = new Details();
            Details_GB = new Details();
            Details_UB = new Details();
            Details_MUNIS_VENDORS = new Details();
        }


        //parameters
        public string buttonColors { get; set; }
        public string queryID { get; set; }
        [Required(ErrorMessage = "NBID cannot be empty")]
        public string newQueryID { get; set; }
        public string detailsID_1 { get; set; }
        public string detailsID_2 { get; set; }
        public bool SuccessMessage { get; set; }
        public bool ErrorMessage { get; set; }
        public string[] Selected_MCB { get; set; }
        public string[] Selected_UCB { get; set; }
        public List<nbid_query> queryList { get; set; }
        public List<nbid_notes> notesList { get; set; }
        public nbid_notes notes { get; set; }
        public string Dmode { get; set; }
        public string AccountNo { get; set; }
        public string SearchNBID { get; set; }
        public string SearchAccount { get; set; }
        public string SearchName { get; set; }
        public string SearchAddress { get; set; }
        public string SearchPhone { get; set; }
        public string CustomerNo { get; set; }
        public string VendorNo { get; set; }
        public string getNewNBID { get; set; }

        //Results
        public List<Results> UB_ComPlus_List { get; set; }
        public List<Results> APVendors_FinPlus_List { get; set; }
        public List<Results> Alarm_Billing_ComPlus_List { get; set; }
        public List<Results> BL_ComPlus_List { get; set; }
        public List<Results> LEADS_PermPlus_List { get; set; }
        public List<Results> GB_Munis_List { get; set; }
        public List<Results> UB_Munis_List { get; set; }
        public List<Results> APVendors_Munis_List { get; set; }
        public List<Results> Turbo_Citations_List { get; set; }

        //Details        
        public Details Details_ACIS_Historical { get; set; }
        public Details Details_AP_Vendor { get; set; }
        public Details Details_Alarm_Billing { get; set; }
        public Details Details_Business_License { get; set; }
        public Details Details_LEADS { get; set; }
        public Details Details_GB { get; set; }
        public Details Details_UB { get; set; }
        public Details Details_MUNIS_VENDORS { get; set; }
    }
}