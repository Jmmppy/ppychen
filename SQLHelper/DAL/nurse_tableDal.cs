using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Utility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class nurse_tableDal
    {
        #region 返回nurse_table表列表222
        /// <summary>
        /// 返回nurse_table表列表,采用了公共类
        /// </summary>
        /// <returns></returns>
        public List<nurse_table> GetNurse_tableList1()
        {
            string sql = "select * from nurse_table";

            List<nurse_table> cur_nurse_table_list = new List<nurse_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_nurse_table_list.Add(dr.DataRowToModel<nurse_table>());
            }

            return cur_nurse_table_list;

        }

        #endregion 返回visit_result_table表列表222
    }
}
