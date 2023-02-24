using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using Utility;

namespace BLL
{
    public class nurse_tableBll
    {
        nurse_tableDal nurse_tableDal_ = new nurse_tableDal();
        #region 返回nurse_table表列表222
        /// <summary>
        /// 返回nurse_table表列表,采用了公共类
        /// </summary>
        /// <returns></returns>
        public List<nurse_table> GetNurse_tableList1()
        {

            return nurse_tableDal_.GetNurse_tableList1();

        }

        #endregion 返回visit_result_table表列表222
    }
}
