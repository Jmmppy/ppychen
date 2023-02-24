using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Models
{
    public class meeting_table
    {
        public int meeting_id { get; set; }
        public string meeting_name { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public int illness_id_count { get; set; }
        public string  meeting_Key { get; set; }

        public string illness_id1 { get; set; }
        public string illness_id2 { get; set; }
        public string illness_id3 { get; set; }
        public bool ismetting { get; set; }
        public int Belong_doc { get; set; }
    }
}
