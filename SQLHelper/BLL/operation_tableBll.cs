using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using Utility;

namespace BLL
{
    public class operation_tableBll
    {
        operation_tableDal operation_tableDal_ = new operation_tableDal();
        #region 返回operation_table表列表222
        /// <summary>
        /// 查询所以行对象列表，使用泛型反射
        /// </summary>
        /// <returns></returns>
        /// 
        public List<operation_table> GetOperation_tableList1()
        {

            return operation_tableDal_.GetOperation_tableList1();

        }

        #endregion 返回operation_table表列表222

        /// <summary>
        /// 根据患者id查询operation_table对象
        /// </summary>
        /// <returns></returns>
        public operation_table getOperation_tableObject(string id_)
        {
           
            return operation_tableDal_.getOperation_tableObject(id_);
        }
    }
}
