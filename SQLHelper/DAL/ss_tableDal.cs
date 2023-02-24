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
    /// <summary>
    /// 填写手术申请表等同于填写访视结果
    /// </summary>
    public class ss_tableDal
    {
        //插入

        //查询
        #region 返回ss_table表列表222
        /// <summary>
        /// 查询所以行对象列表，使用泛型反射
        /// </summary>
        /// <returns></returns>
        /// 
        public List<ss_table> GetSs_tableList1()
        {
            string sql = "select * from ss_table";

            List<ss_table> cur_ss_tableList = new List<ss_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_ss_tableList.Add(dr.DataRowToModel<ss_table>());
            }

            return cur_ss_tableList;

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
            string sql = $"insert into ss_table(ss_type, ss_date, operation_id, ss_grade, position,body_position,narcosis_way,cut_grade,hepatitisB,hepatitisC,syphilis,HIV,tuberculosis,special_infection,BH_blood,remarks,illness_id) values" +
                $"(@ss_type, @ss_date, @operation_id, @ss_grade, @position,@body_position,@narcosis_way,@cut_grade,@hepatitisB,@hepatitisC,@syphilis,@HIV,@tuberculosis,@special_infection,@BH_blood,@remarks,@illness_id)";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@ss_type", ss_table_.ss_type),
                new SqlParameter("@ss_date", ss_table_.ss_date),
                new SqlParameter("@operation_id", ss_table_.operation_id),
                new SqlParameter("@ss_grade", ss_table_.ss_grade),
                new SqlParameter("@position", ss_table_.position),

                new SqlParameter("@body_position", ss_table_.body_position),
                new SqlParameter("@narcosis_way", ss_table_.narcosis_way),
                new SqlParameter("@cut_grade", ss_table_.cut_grade),
                new SqlParameter("@hepatitisB", ss_table_.hepatitisB),
                new SqlParameter("@hepatitisC", ss_table_.hepatitisC),

                new SqlParameter("@syphilis", ss_table_.syphilis),
                new SqlParameter("@HIV", ss_table_.HIV),
                new SqlParameter("@tuberculosis", ss_table_.tuberculosis),
                new SqlParameter("@special_infection", ss_table_.special_infection),
                new SqlParameter("@BH_blood", ss_table_.BH_blood),

                new SqlParameter("@remarks", ss_table_.remarks),
                new SqlParameter("@illness_id", ss_table_.illness_id)


                );

            return row;
        }
        //跟新
        public int update_ss_table(ss_table ss_table_)
        {
            string sql = $"update ss_table set ss_type = @ss_type, ss_date = @ss_date, operation_id = @operation_id, ss_grade = @ss_grade, position=@position " +
                $"body_position = @body_position, narcosis_way = @narcosis_way, cut_grade = @cut_grade, hepatitisB = @hepatitisB, hepatitisC=@hepatitisC" +
                $"syphilis = @syphilis, HIV = @HIV, tuberculosis = @tuberculosis, special_infection = @special_infection, BH_blood=@BH_blood" +
                $"remarks = @remarks, illness_id = @illness_id " +
                $"where ss_id = @ss_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@ss_id", ss_table_.ss_id),//

                new SqlParameter("@ss_type", ss_table_.ss_type),
                new SqlParameter("@ss_date", ss_table_.ss_date),
                new SqlParameter("@operation_id", ss_table_.operation_id),
                new SqlParameter("@ss_grade", ss_table_.ss_grade),
                new SqlParameter("@position", ss_table_.position),

                new SqlParameter("@body_position", ss_table_.body_position),
                new SqlParameter("@narcosis_way", ss_table_.narcosis_way),
                new SqlParameter("@cut_grade", ss_table_.cut_grade),
                new SqlParameter("@hepatitisB", ss_table_.hepatitisB),
                new SqlParameter("@hepatitisC", ss_table_.hepatitisC),

                new SqlParameter("@syphilis", ss_table_.syphilis),
                new SqlParameter("@HIV", ss_table_.HIV),
                new SqlParameter("@tuberculosis", ss_table_.tuberculosis),
                new SqlParameter("@special_infection", ss_table_.special_infection),
                new SqlParameter("@BH_blood", ss_table_.BH_blood),

                new SqlParameter("@remarks", ss_table_.remarks),
                new SqlParameter("@illness_id", ss_table_.illness_id)

                );

            return row;
        }


        /// <summary>
        /// 根据illness_id查找一行，用于显示
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public ss_table getss_tableObject(string id_)
        {
            ss_table ss_table_ = new ss_table();
            string sql = $"select * from ss_table where illness_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                ss_table_ = new ss_table()
                {
                    ss_id = Convert.ToInt32(reader1["ss_id"]),
                    BH_blood = reader1["BH_blood"].ToString(),
                    body_position = reader1["body_position"].ToString(),
                    cut_grade = reader1["cut_grade"].ToString(),
                    hepatitisB = reader1["hepatitisB"].ToString(),
                    hepatitisC = reader1["hepatitisC"].ToString(),
                    HIV = reader1["HIV"].ToString(),
                    narcosis_way = reader1["narcosis_way"].ToString(),
                    operation_id = reader1["operation_id"].ToString(),
                    position = reader1["position"].ToString(),
                    special_infection = reader1["special_infection"].ToString(),
                    syphilis = reader1["syphilis"].ToString(),
                    tuberculosis = reader1["tuberculosis"].ToString(),
                    ss_grade = reader1["ss_grade"].ToString(),
                    ss_type = reader1["ss_type"].ToString(),
                    ss_date = Convert.ToDateTime(reader1["ss_date"]),
                    remarks = reader1["remarks"].ToString()


                };

            }
            return ss_table_;
        }
        /// <summary>
        /// 根据int 的ss_id去拿到一行
        /// </summary>
        /// <param name="ss_id_"></param>
        /// <returns></returns>
        public ss_table getss_tableObject2(int ss_id_)
        {
            ss_table ss_table_ = new ss_table();
            string sql = $"select * from ss_table where ss_id = {ss_id_}";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                ss_table_ = new ss_table()
                {
                    ss_id = Convert.ToInt32(reader1["ss_id"]),
                    BH_blood = reader1["BH_blood"].ToString(),
                    body_position = reader1["body_position"].ToString(),
                    cut_grade = reader1["cut_grade"].ToString(),
                    hepatitisB = reader1["hepatitisB"].ToString(),
                    hepatitisC = reader1["hepatitisC"].ToString(),
                    HIV = reader1["HIV"].ToString(),
                    narcosis_way = reader1["narcosis_way"].ToString(),
                    operation_id = reader1["operation_id"].ToString(),
                    position = reader1["position"].ToString(),
                    special_infection = reader1["special_infection"].ToString(),
                    syphilis = reader1["syphilis"].ToString(),
                    tuberculosis = reader1["tuberculosis"].ToString(),
                    ss_grade = reader1["ss_grade"].ToString(),
                    ss_type = reader1["ss_type"].ToString(),
                    ss_date = Convert.ToDateTime(reader1["ss_date"]),
                    remarks = reader1["remarks"].ToString()

                };

            }
            return ss_table_;
        }
        #endregion 


    }
}
