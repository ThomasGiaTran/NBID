using System;

namespace NBID.Models
{
    public class nbid_notes
    {
        public int note_id { get; set; }
        public string nbid { get; set; }
        public int user_id { get; set; }
        public DateTime date_time { get; set; }
        public string subject { get; set; }
        public string comment { get; set; }
        public string icon { get; set; }
    }
}