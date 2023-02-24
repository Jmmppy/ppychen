using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using Utility;

namespace BLL
{
    public class meeting_tableBll
    {
        meeting_tableDal meeting_tableDal_ = new meeting_tableDal();


        #region 返回meeting_table表列表222
        /// <summary>
        /// 返回meeting_table表全部列表
        /// </summary>
        /// <returns></returns>
        public List<meeting_table> GetMeeting_tableList1()
        {

            return meeting_tableDal_.GetMeeting_tableList1();

        }

        #endregion 返回visit_result_table表列表222

        /// <summary>
        /// 以meeting_table记录扎入
        /// </summary>
        /// <param name="meeting_table"></param>
        /// <returns></returns>
        public int insert_meeting_table(meeting_table meeting_table_)
        {          
            return meeting_tableDal_.insert_meeting_table(meeting_table_);
        }
        public int update_meeting_table(meeting_table visit_Result_Table)
        {
           

            return meeting_tableDal_.update_meeting_table(visit_Result_Table);
        }

        /// <summary>
        /// 根据mettingID 去设置isMetting值
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int update_isMeeting(int id, bool isMetting_)
        {
           
            return meeting_tableDal_.update_isMeeting(id, isMetting_);
        }


        /// <summary>
        /// 根据mettingID 去更新start_time值
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int update_isMeeting2(int id, DateTime start_time_)
        {
         
            return meeting_tableDal_.update_isMeeting2(id, start_time_);
        }




        /// <summary>
        /// 根据meeting_id查找一行
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public meeting_table getmeeting_tableObject(int id_)
        {
            
            return meeting_tableDal_.getmeeting_tableObject(id_);
        }


        //
        /// <summary>
        /// 根据开始时间查找一行
        /// </summary>
        /// <param name="Cur_start_time"></param>
        /// <returns></returns>
        public meeting_table getmeeting_tableObject2(DateTime Cur_start_time, DateTime Cur_end_time)
        {
           
            return meeting_tableDal_.getmeeting_tableObject2(Cur_start_time, Cur_end_time);
        }

    }
}
