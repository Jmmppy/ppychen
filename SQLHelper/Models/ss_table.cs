using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 手术申请表
    /// </summary>
    public class ss_table
    {
        public int ss_id { get; set; }
        public string ss_type { get; set; }
        public DateTime ss_date { get; set; }
        public string operation_id { get; set; }
        public string ss_grade { get; set; }
        public string position { get; set; }
        public string body_position { get; set; }
        public string narcosis_way { get; set; }
        public string cut_grade { get; set; }
        public string hepatitisB { get; set; }
        public string hepatitisC { get; set; }
        public string syphilis { get; set; }
        public string HIV { get; set; }
        public string tuberculosis { get; set; }
        public string special_infection { get; set; }
        public string BH_blood { get; set; }
        public string remarks { get; set; }

        public string illness_id { get; set; }

    }
}
