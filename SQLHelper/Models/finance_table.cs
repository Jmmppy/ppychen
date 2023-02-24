using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class finance_table
    {
        public int finance_id { get; set; }
        public string topic_name { get; set; }
        public string topic_introduct { get; set; }
        public string doc_name { get; set; }
        public int doc_id { get; set; }
        public int funds { get; set; }
        public string states { get; set; }
    }
}
