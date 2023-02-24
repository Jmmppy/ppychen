using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ss_visitTable
    {
        public string illness_id { get; set; }
        public string patient_name { get; set; }
        public DateTime operation_date { get; set; }
        public string operation_room { get; set; }
        public DateTime start_time { get; set; }
        public DateTime visit_time { get; set; }
        public DateTime narcosis_time { get; set; }
        public int department_id { get; set; }
        public string pice_place_id { get; set; }
        public string operate_id { get; set; }
        public int doc_id { get; set; }
        public int narcosis_doc_id { get; set; }
        public int nurse_id { get; set; }

        //新加
        public int visit_result_id { get; set; }   //为了时，数据库的null
        public bool isSelect { get; set; }

        public bool is_ss { get; set; }

        public bool is_bool1 { get; set; }  // 确保是否已经经过访视的确认
        public bool is_bool2 { get; set; }  // 确保是否已经经过访视 or 线下路线
        public bool is_bool3 { get; set; }  // 确保是否




    }
}
