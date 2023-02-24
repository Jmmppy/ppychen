using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using Utility;

namespace BLL
{
    public class ss_tableBll
    {
        ss_tableDal ss_tableDal_ = new ss_tableDal();
        #region 返回ss_table表列表222
        /// <summary>
        /// 查询所以行对象列表，使用泛型反射
        /// </summary>
        /// <returns></returns>
        /// 
        public List<ss_table> GetSs_tableList1()
        {

            return ss_tableDal_.GetSs_tableList1();

        }

        #endregion 返回ss_table表列表222

        #region 
        /// <summary>
        /// 插入ss_table
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int insert_ss_table(ss_table ss_table_)
        {


            return ss_tableDal_.insert_ss_table(ss_table_);
        }
        //跟新
        public int update_ss_table(ss_table ss_table_)
        {
         

            return ss_tableDal_.update_ss_table(ss_table_);
        }


        /// <summary>
        /// 根据illness_id查找一行，用于显示
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public ss_table getss_tableObject(string illness_id)
        {
      


            return ss_tableDal_.getss_tableObject(illness_id);
        }
        /// <summary>
        /// 根据int 的ss_id去拿到一行
        /// </summary>
        /// <param name="ss_id_"></param>
        /// <returns></returns>
        public ss_table getss_tableObject2(int ss_id_)
        {

            return ss_tableDal_.getss_tableObject2(ss_id_);
        }
        #endregion 
    }
}
