using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using Utility;

namespace BLL
{
    public class visit_result_tableBll
    {
        visit_result_tableDal visit_result_table_ = new visit_result_tableDal();

        #region 返回visit_result_table表列表222
        /// <summary>
        /// 外连接查询到，临时表中
        /// </summary>
        /// <returns></returns>
        public List<visit_result_table> GetVisit_result_tableList1()
        {
            

            return visit_result_table_.GetVisit_result_tableList1();

        }

        #endregion 返回visit_result_table表列表222
        /// <summary>
        /// insert_visit_result_table
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int insert_visit_result_table(visit_result_table visit_Result_Table)
        {
          
            return visit_result_table_.insert_visit_result_table(visit_Result_Table);
        }
        //跟新
        public int update_visit_result_table(visit_result_table visit_Result_Table)
        {
            return visit_result_table_.update_visit_result_table(visit_Result_Table);
        }
        //查找
        public visit_result_table getvisit_result_tableObject(string illness_id)
        {
           
            return visit_result_table_.getvisit_result_tableObject(illness_id);
        }
        /// <summary>
        /// 根据int 的visit_result_id去拿到一行
        /// </summary>
        /// <param name="visit_result_id_"></param>
        /// <returns></returns>
        public visit_result_table getvisit_result_tableObject2(int visit_result_id_)
        {
            
            return visit_result_table_.getvisit_result_tableObject2(visit_result_id_);
        }
    }
}
