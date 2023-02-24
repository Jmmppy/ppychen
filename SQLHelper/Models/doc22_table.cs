using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 这个才是真正的医生表，doc_table那个是变成登录表
    /// </summary>
    public class doc22_table
    {
        public int doctor_id { get; set; }
        public string doc_name { get; set; }
        public string pice_place { get; set; }
        public string profession { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string phone { get; set; }
        public string pwd { get; set; }
        public int partment_id { get; set; }
    }
}
