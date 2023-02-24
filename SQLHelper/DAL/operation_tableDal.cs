using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Models;
using Utility;

namespace DAL
{
    public class operation_tableDal
    {
        #region 返回operation_table表列表222
        /// <summary>
        /// 查询所以行对象列表，使用泛型反射
        /// </summary>
        /// <returns></returns>
        /// 
        public List<operation_table> GetOperation_tableList1()
        {
            string sql = "select * from operation_table";

            List<operation_table> cur_operation_tableList = new List<operation_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_operation_tableList.Add(dr.DataRowToModel<operation_table>());
            }

            return cur_operation_tableList;

        }

        #endregion 返回operation_table表列表222

        /// <summary>
        /// 根据患者id查询operation_table对象
        /// </summary>
        /// <returns></returns>
        public operation_table getOperation_tableObject(string id_)
        {
            operation_table operation_table_ = new operation_table();
            string sql = $"select * from operation_table where operation_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                operation_table_ = new operation_table()
                {
                    operation_name = reader1["operation_name"].ToString(),
                    operation_id = reader1["operation_id"].ToString(),
                    note = reader1["note"].ToString(),
                    pice_place_id = reader1["pice_place_id"].ToString()

                };

            }
            return operation_table_;
        }


    }
}
