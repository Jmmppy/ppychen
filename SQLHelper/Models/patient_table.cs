using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class patient_table
    {
        public string illness_id { get; set; }
        public string patient_name { get; set; }
        public string age { get; set; }
        public string height { get; set; }
        public string weigth { get; set; }
        public string insurance_type { get; set; }
        public string card_type { get; set; }
        public string card_id { get; set; }
        public string phone { get; set; }
        public string diagnosis { get; set; }
        public string sickroom { get; set; }
        public int doc_id { get; set; }
        public string pice_place_id { get; set; }
        public int department_id { get; set; }
        //新加
        public int ss_id { get; set; }
        public bool isInput { get; set; }
        public bool isInput2 { get; set; }

        public int narcosis_doc_id { get; set; }
        public int nurse_id { get; set; }
        public string operation_room { get; set; }

    }
}
