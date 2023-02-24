using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using Models;
using Utility;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections.Generic;

namespace DAL
{
    public class meeting_tableDal
    {
        //
        //插入
        //查询

        //List to dataTable
        //public DataTable GetMeeting_table(List<meeting_table> list)
        //{
        //    DataTable dt = new DataTable();
            

        //    return dt;
        //}
        #region 返回meeting_table表列表222
        /// <summary>
        /// 返回meeting_table表全部列表
        /// </summary>
        /// <returns></returns>
        public List<meeting_table> GetMeeting_tableList1()
        {
            string sql = "select * from meeting_table";

            List<meeting_table> cur_meeting_table_list = new List<meeting_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_meeting_table_list.Add(dr.DataRowToModel<meeting_table>());
            }

            return cur_meeting_table_list;

        }

        #endregion 返回visit_result_table表列表222
        #region 
        /// <summary>
        /// 以meeting_table记录扎入
        /// </summary>
        /// <param name="meeting_table"></param>
        /// <returns></returns>
        public int insert_meeting_table(meeting_table meeting_table_)
        {
            string sql = $"insert into meeting_table(meeting_name, start_time, end_time, illness_id_count, meeting_Key,illness_id1,illness_id2,illness_id3,isMetting,Belong_doc) values" +
                $"(@meeting_name, @start_time, @end_time, @illness_id_count, @meeting_Key,@illness_id1,@illness_id2,@illness_id3,@isMetting,@Belong_doc)";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@meeting_id", meeting_table_.meeting_id),//
                new SqlParameter("@meeting_name", meeting_table_.meeting_name),
                new SqlParameter("@start_time", meeting_table_.start_time),
                new SqlParameter("@end_time", meeting_table_.end_time),
                new SqlParameter("@illness_id_count", meeting_table_.illness_id_count),
                new SqlParameter("@meeting_Key", meeting_table_.meeting_Key),
                new SqlParameter("@illness_id1", meeting_table_.illness_id1),
                new SqlParameter("@illness_id2", meeting_table_.illness_id2),
                new SqlParameter("@illness_id3", meeting_table_.illness_id3),
                new SqlParameter("@isMetting", false),               //  默认是false
                new SqlParameter("@Belong_doc", meeting_table_.Belong_doc)



                );

            return row;
        }
        //跟新
        public int update_meeting_table(meeting_table visit_Result_Table)
        {
            string sql = $"update meeting_table set meeting_name = @meeting_name, start_time = @start_time, end_time = @end_time, illness_id_count = @illness_id_count, meeting_Key=@meeting_Key " +
                $"where meeting_id = @meeting_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@meeting_id", visit_Result_Table.meeting_id),//
                new SqlParameter("@meeting_name", visit_Result_Table.meeting_name),
                new SqlParameter("@start_time", visit_Result_Table.start_time),
                new SqlParameter("@end_time", visit_Result_Table.end_time),
                new SqlParameter("@illness_id_count", visit_Result_Table.illness_id_count),
                new SqlParameter("@meeting_Key", visit_Result_Table.meeting_Key)
                );

            return row;
        }

        /// <summary>
        /// 根据mettingID 去设置isMetting值
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int update_isMeeting(int id,bool isMetting_)
        {
            string sql = $"update meeting_table set  isMetting=@isMetting " +
                $"where meeting_id = @meeting_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@meeting_id", id),//
                new SqlParameter("@isMetting", isMetting_)

                );

            return row;
        }



        /// <summary>
        /// 根据mettingID 去更新start_time值
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int update_isMeeting2(int id,DateTime start_time_)
        {
            string sql = $"update meeting_table set  start_time=@start_time " +
                $"where meeting_id = @meeting_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@meeting_id", id),//
                new SqlParameter("@start_time", start_time_)

                );

            return row;
        }
        //
        /// <summary>
        /// 根据meeting_id查找一行
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public meeting_table getmeeting_tableObject(int id_)
        {
            meeting_table meeting_table_ = new meeting_table();
            string sql = $"select * from meeting_table where meeting_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                meeting_table_ = new meeting_table()
                {

                    meeting_id = Convert.ToInt32(reader1["meeting_id"]),
                    meeting_name = reader1["meeting_name"].ToString(),
                    start_time = Convert.ToDateTime(reader1["start_time"]),
                    end_time = Convert.ToDateTime(reader1["end_time"]),
                    illness_id_count = Convert.ToInt32(reader1["illness_id_count"]),
                    meeting_Key = reader1["meeting_Key"].ToString(),
                    Belong_doc = Convert.ToInt32(reader1["Belong_doc"])     //
                    


                };

            }
            return meeting_table_;
        }
        //
        /// <summary>
        /// 根据开始时间查找一行而且必须是该医生预约的会议。
        /// </summary>
        /// <param name="Cur_start_time"></param>
        /// <returns></returns>
        public meeting_table getmeeting_tableObject2(DateTime Cur_start_time, DateTime Cur_end_time)
        {
            meeting_table meeting_table_ = new meeting_table();
            string sql = $"select * from meeting_table where start_time between '{Cur_start_time}' and '{Cur_end_time}'and isMetting = '{false}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);
            
            while (reader1.Read())
            {
                meeting_table_ = new meeting_table()
                {

                    meeting_id = Convert.ToInt32(reader1["meeting_id"]),
                    meeting_name = reader1["meeting_name"].ToString(),
                    start_time = Convert.ToDateTime(reader1["start_time"]),
                    end_time = Convert.ToDateTime(reader1["end_time"]),
                    illness_id_count = Convert.ToInt32(reader1["illness_id_count"]),
                    meeting_Key = reader1["meeting_Key"].ToString(),
                    illness_id1 = reader1["illness_id1"].ToString(),
                    illness_id2 = reader1["illness_id2"].ToString(),
                    illness_id3 = reader1["illness_id3"].ToString(),
                    Belong_doc = Convert.ToInt32(reader1["Belong_doc"])
                    //ismetting = (bool)reader1["illness_id3"]

                };

            }
            return meeting_table_;
        }
        /// <summary>
        /// 根据int 的visit_result_id去拿到一行
        /// </summary>
        /// <param name="visit_result_id_"></param>
        /// <returns></returns>
        //public visit_result_table getvisit_result_tableObject2(int visit_result_id_)
        //{
        //    visit_result_table visit_result_table_ = new visit_result_table();
        //    string sql = $"select * from visit_result_table where visit_result_id = {visit_result_id_}";
        //    SqlDataReader reader1 = MyHelper.GetDataReader(sql);

        //    while (reader1.Read())
        //    {
        //        visit_result_table_ = new visit_result_table()
        //        {

        //            visit_result_id = Convert.ToInt32(reader1["visit_result_id"]),
        //            illness_id = reader1["illness_id"].ToString(),
        //            drug_allergy = reader1["drug_allergy"].ToString(),
        //            condition = reader1["condition"].ToString(),
        //            sanity = reader1["sanity"].ToString(),
        //            test_result = reader1["test_result"].ToString()
        //        };

        //    }
        //    return visit_result_table_;
        //}
        #endregion 
    }
}
