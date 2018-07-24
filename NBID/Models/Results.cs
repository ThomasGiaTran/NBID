using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NBID.Models
{
    public class Results
    {
        public string AccountNo;
        public string cust_ser;
        public string Status;
        public string Notes;
        public string Name;
        public string Billing_Address;
        public string Service_Address;
        public string Phone;
        public string Balance;
        public bool isChecked { get; set; }
    }
}