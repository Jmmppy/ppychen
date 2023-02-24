using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class cur_patient_table
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
        public string doc_name { get; set; }
        public string pice_place_name { get; set; }
        public string partment_name { get; set; }
        public int ss_id { get; set; }
        public bool Isinput { get; set; }
        public bool Isinput2 { get; set; }
        public string narcosis_doc_name { get; set; }
        public string nurse_name { get; set; }
        public string operation_room { get; set; }
    }
}
