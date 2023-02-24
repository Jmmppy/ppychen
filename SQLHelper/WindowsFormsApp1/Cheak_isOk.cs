using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    public class Cheak_isOk
    {
        private List<string> strList = new List<string> { "我操", "cao" ,"操","风骚","诱惑","卧槽"};

        public bool Word_Cheak_is_OK(string str)
        {
            foreach (var item in strList)
            {
                if (str.Contains(item))
                {
                    return true;                  
                }
            }
            return false;
        }
    }
}
