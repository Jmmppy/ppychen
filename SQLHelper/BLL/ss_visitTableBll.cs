using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    
    
    public class ss_visitTableBll
    {
        ss_visitTableDal ss_VisitTable = new ss_visitTableDal();

        #region 返回ss_visitTable表列表 不用

        public List<ss_visitTable> GetSs_visitTableList()
        {
           
            return ss_VisitTable.GetSs_visitTableList();
        }
        #endregion 返回ss_visitTable表列表

        #region 返回ss_visitTable表列表222

        public List<cur_ss_visitTable> GetSs_visitTableList1()
        {

            return ss_VisitTable.GetSs_visitTableList1();
        }
        #endregion 返回ss_visitTable表列表222

        public int update_ss_visitTable(ss_visitTable ss_visitTable_)
        {
            
            return ss_VisitTable.update_ss_visitTable(ss_visitTable_);
        }

        public int update_ss_visitTable2(ss_visitTable ss_visitTable_)
        {
          

            return ss_VisitTable.update_ss_visitTable2(ss_visitTable_);
        }

        public int update_ss_visitTable3(ss_visitTable ss_visitTable_)
        {
          
            return ss_VisitTable.update_ss_visitTable3(ss_visitTable_);
        }

        public int update_ss_visitTable4(ss_visitTable ss_visitTable_)
        {

            return ss_VisitTable.update_ss_visitTable4(ss_visitTable_);
        }
        /// <summary>
        /// 根据患者id查询cur_ss_visitTable对象。
        /// </summary>
        /// <returns></returns>
        public cur_ss_visitTable getcur_ss_visitTableObject(string id_)
        {
          
            return ss_VisitTable.getcur_ss_visitTableObject(id_);
        }


        /// <summary>
        /// 根据患者id查询ss_visitTable对象
        /// </summary>
        /// <returns></returns>
        public ss_visitTable getss_visitTableObject(string id_)
        {
           
            return ss_VisitTable.getss_visitTableObject(id_);
        }

    }
}
