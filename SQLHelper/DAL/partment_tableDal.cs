using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class partment_tableDal
    {
        #region 根据partment_id获取信息2222
        public partment_table getPartment_tableObject(int partment_id)
        {
            partment_table partment_ = new partment_table();
            string sql = $"select * from partment_table where partment_id = {partment_id}";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);
            //Console.WriteLine("1111111111111111111111111111111111");
            while (reader1.Read())
            {
                partment_ = new partment_table()
                {
                    partment_id = Convert.ToInt32(reader1["partment_id"]),
                    partment_name = reader1["partment_name"].ToString()

                };

            }
            return partment_;
        }

        #endregion 根据notice_id获取信息222
    }
}
