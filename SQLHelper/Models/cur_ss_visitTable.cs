using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class cur_ss_visitTable
    {
        //9
        /// <summary>
        /// 临时表
        /// </summary>
        public string illness_id { get; set; }
        public string patient_name { get; set; }
        public DateTime operation_date { get; set; }
        public string operation_room { get; set; }
        //public DateTime start_time { get; set; }
        //public DateTime visit_time { get; set; }
        public DateTime narcosis_time { get; set; }
        //public int department_id { get; set; }
        //public string pice_place_id { get; set; }
        public string operation_name { get; set; }
        public string doc_name { get; set; }
        public string narcosis_doc_name { get; set; }
        public string nurse_name { get; set; }
        public string sickroom { get; set; }
        public int visit_result_id { get; set; }
        public bool isSelect { get; set; } //新加
        public bool is_ss { get; set; } //新加 //新加
        //新加
        public bool is_bool1 { get; set; }
        public bool is_bool2 { get; set; }
        public bool is_bool3 { get; set; }

    }
}
