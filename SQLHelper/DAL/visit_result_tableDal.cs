using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using System.Linq;
using System.Text;
using Models;
using Utility;

namespace DAL
{
    public class visit_result_tableDal
    {
        #region 返回visit_result_table表列表222
        /// <summary>
        /// 外连接查询到，临时表中
        /// </summary>
        /// <returns></returns>
        public List<visit_result_table> GetVisit_result_tableList1()
        {
            string sql = "select * from visit_result_table";
            
            List<visit_result_table> cur_visit_result_list = new List<visit_result_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_visit_result_list.Add(dr.DataRowToModel<visit_result_table>());
            }

            return cur_visit_result_list;

        }

        #endregion 返回visit_result_table表列表222
        #region 
        /// <summary>
        /// 插入visit_result_table
        /// </summary>
        /// <param name="visit_Result_Table"></param>
        /// <returns></returns>
        public int insert_visit_result_table(visit_result_table visit_Result_Table)
        {
            string sql = $"insert into visit_result_table(illness_id, drug_allergy, sanity, condition, test_result) values" +
                $"(@illness_id, @drug_allergy, @sanity, @condition, @test_result)";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", visit_Result_Table.illness_id),
                new SqlParameter("@drug_allergy", visit_Result_Table.drug_allergy),
                new SqlParameter("@sanity", visit_Result_Table.sanity),
                new SqlParameter("@condition", visit_Result_Table.condition),
                new SqlParameter("@test_result", visit_Result_Table.test_result)
                );

            return row;
        }
        //跟新
        public int update_visit_result_table(visit_result_table visit_Result_Table)
        {
            string sql = $"update visit_result_table set illness_id = @illness_id, drug_allergy = @drug_allergy, sanity = @sanity, condition = @condition, test_result=@test_result " +
                $"where visit_result_id = @visit_result_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@visit_result_id", visit_Result_Table.visit_result_id),//
                new SqlParameter("@illness_id", visit_Result_Table.illness_id),
                new SqlParameter("@drug_allergy", visit_Result_Table.drug_allergy),
                new SqlParameter("@sanity", visit_Result_Table.sanity),
                new SqlParameter("@condition", visit_Result_Table.condition),
                new SqlParameter("@test_result", visit_Result_Table.test_result)
                );

            return row;
        }
        //查找
        public visit_result_table getvisit_result_tableObject(string id_)
        {
            visit_result_table visit_result_table_ = new visit_result_table();
            string sql = $"select * from visit_result_table where illness_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);
            
            while (reader1.Read())
            {
                visit_result_table_ = new visit_result_table()
                {

                    visit_result_id = Convert.ToInt32(reader1["visit_result_id"]),
                    illness_id = reader1["illness_id"].ToString(),
                    drug_allergy = reader1["drug_allergy"].ToString(),
                    condition = reader1["condition"].ToString(),
                    sanity = reader1["sanity"].ToString(),
                    test_result = reader1["test_result"].ToString()
                };

            }
            return visit_result_table_;
        }
        /// <summary>
        /// 根据int 的visit_result_id去拿到一行
        /// </summary>
        /// <param name="visit_result_id_"></param>
        /// <returns></returns>
        public visit_result_table getvisit_result_tableObject2(int visit_result_id_)
        {
            visit_result_table visit_result_table_ = new visit_result_table();
            string sql = $"select * from visit_result_table where visit_result_id = {visit_result_id_}";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                visit_result_table_ = new visit_result_table()
                {

                    visit_result_id = Convert.ToInt32(reader1["visit_result_id"]),
                    illness_id = reader1["illness_id"].ToString(),
                    drug_allergy = reader1["drug_allergy"].ToString(),
                    condition = reader1["condition"].ToString(),
                    sanity = reader1["sanity"].ToString(),
                    test_result = reader1["test_result"].ToString()
                };

            }
            return visit_result_table_;
        }
        #endregion 
    }
}
