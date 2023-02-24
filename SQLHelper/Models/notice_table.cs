using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    //这里【notice_date】：2020-01-26，【notice_time】12：25：34 ,都对应的是C# 的DateTime可能不对
    public class notice_table
    {
        public int notice_id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public DateTime notice_date { get; set; }
        // public DateTime notice_time { get; set; }
        public string notice_man { get; set; }
    }
}
