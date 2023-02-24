using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ss_visitTableDal
    {

        #region 返回ss_visitTable表列表

        public List<ss_visitTable> GetSs_visitTableList()
        {
            string sql = "select * from ss_visitTable";
            //string sql = "select ss.illness_id, ss.patient_name, ss.operation_date,ss.operation_room,ss.visit_time, op.operation_name, doc.doc_name,na.narcosis_doc_name,nurse_name from ss_visitTable ss "+
            //    " left join operation_table op on ss.operate_id = op.operation_id"+
            //    " Left join doc_table doc on ss.doc_id = doc.doctor_id"+
            //    " Left join narcosis_docTable na on ss.narcosis_doc_id = na.narcosis_doc_id"+
            //    " Left join nurse_table nu on ss.nurse_id = nu.nurse_id";
            List<ss_visitTable> ss_visits_list = new List<ss_visitTable>(); // 准备一个空的列表对象
            SqlDataReader dataReader = MyHelper.GetDataReader(sql); // 这个有问题？？？？？？
            //Console.WriteLine();
            Console.WriteLine("read:" + dataReader.Read());
            while (dataReader.Read())
            {
                Console.WriteLine("11111111111");
                //问题要不要写全？？？ 不要写完整
                ss_visits_list.Add(new ss_visitTable()
                {
                    illness_id = dataReader["illness_id"].ToString(),
                    patient_name = dataReader["patient_name"].ToString(),
                    operation_date = Convert.ToDateTime(dataReader["operation_date"]),
                    operation_room = dataReader["operation_room"].ToString(),
                    narcosis_time = Convert.ToDateTime(dataReader["narcosis_time"]),
                    operate_id = dataReader["operate_id"].ToString(),
                    doc_id = Convert.ToInt32(dataReader["doc_id"]),
                    narcosis_doc_id = Convert.ToInt32(dataReader["narcosis_doc_id"]),
                    nurse_id = Convert.ToInt32(dataReader["nurse_id"])

                });
            }
            dataReader.Close();//采用了close进行手动关闭。
            return ss_visits_list;
        }
        #endregion 返回ss_visitTable表列表

        #region 返回ss_visitTable表列表222
        /// <summary>
        /// 外连接查询到，临时表中
        /// </summary>
        /// <returns></returns>
        public List<cur_ss_visitTable> GetSs_visitTableList1()
        {
            //string sql = "select * from ss_visitTable";
            string sql = "select ss.illness_id, ss.patient_name, ss.operation_date,ss.operation_room,ss.narcosis_time, op.operation_name, doc.doc_name,na.narcosis_doc_name,nu.nurse_name,ss.sickroom,ss.isSelect,ss.is_ss,ss.is_bool1,ss.is_bool2,ss.is_bool3,ss.visit_result_id from ss_visitTable ss " +
                " left join operation_table op on ss.operate_id = op.operation_id" +
                " Left join doc_table doc on ss.doc_id = doc.doctor_id" +
                " Left join narcosis_docTable na on ss.narcosis_doc_id = na.narcosis_doc_id" +
                " Left join nurse_table nu on ss.nurse_id = nu.nurse_id";
            List<cur_ss_visitTable> cur_ss_visits_list = new List<cur_ss_visitTable>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_ss_visits_list.Add(ToModel(dr));
            }

            return cur_ss_visits_list;
            
        }

        private static cur_ss_visitTable ToModel(DataRow dr)  // 上面查询的列信息
        {
            cur_ss_visitTable cur_ss_visitTable_ = new cur_ss_visitTable();
            cur_ss_visitTable_.illness_id = dr["illness_id"].ToString();
            cur_ss_visitTable_.patient_name = dr["patient_name"].ToString();
            cur_ss_visitTable_.operation_date = Convert.ToDateTime(dr["operation_date"]);
            cur_ss_visitTable_.operation_room = dr["operation_room"].ToString();
            cur_ss_visitTable_.narcosis_time = Convert.ToDateTime(dr["narcosis_time"]);
            // ss_visitTable_.operate_id = dr["operate_id"].ToString();
            cur_ss_visitTable_.operation_name = dr["operation_name"].ToString();
            cur_ss_visitTable_.doc_name = dr["doc_name"].ToString();
            cur_ss_visitTable_.narcosis_doc_name = dr["narcosis_doc_name"].ToString();
            cur_ss_visitTable_.nurse_name = dr["nurse_name"].ToString();
            cur_ss_visitTable_.sickroom = dr["sickroom"].ToString();
            cur_ss_visitTable_.isSelect = (bool)dr["isSelect"];
            cur_ss_visitTable_.is_ss = (bool)dr["is_ss"];

            cur_ss_visitTable_.is_bool1 = (bool)dr["is_bool1"];
            cur_ss_visitTable_.is_bool2 = (bool)dr["is_bool2"];
            cur_ss_visitTable_.is_bool3 = (bool)dr["is_bool3"];

            cur_ss_visitTable_.visit_result_id = Convert.ToInt32(dr["visit_result_id"]);
            //cur_ss_visitTable_.isSelect = false; // 新加 默认全为false
            return cur_ss_visitTable_;
        }
        #endregion 返回ss_visitTable表列表222



        /// <summary>
        /// 根据患者id查询cur_ss_visitTable对象。不用
        /// </summary>
        /// <returns></returns>
        public cur_ss_visitTable getcur_ss_visitTableObject(string id_)
        {
            cur_ss_visitTable cur_ss_visitTable_ = new cur_ss_visitTable();
            string sql = $"select * from cur_ss_visitTable where illness_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                cur_ss_visitTable_ = new cur_ss_visitTable()
                {
                    illness_id = reader1["illness_id"].ToString(),
                    doc_name = reader1["doc_name"].ToString(),
                    narcosis_doc_name = reader1["narcosis_doc_name"].ToString(),
                    narcosis_time = Convert.ToDateTime(reader1["narcosis_time"]),
                    nurse_name = reader1["nurse_name"].ToString(),
                    operation_date = Convert.ToDateTime(reader1["operation_date"]),
                    operation_name = reader1["operation_name"].ToString(),
                    operation_room = reader1["operation_room"].ToString(),
                    patient_name = reader1["patient_name"].ToString(),
                    sickroom = reader1["sickroom"].ToString(),
                    visit_result_id = Convert.ToInt32(reader1["visit_result_id"])                  

                };

            }
            return cur_ss_visitTable_;
        }


        /// <summary>
        /// 根据患者id查询ss_visitTable对象
        /// </summary>
        /// <returns></returns>
        public ss_visitTable getss_visitTableObject(string id_)
        {
            ss_visitTable ss_visitTable_ = new ss_visitTable();
            string sql = $"select * from ss_visitTable where illness_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                ss_visitTable_ = new ss_visitTable()
                {
                    illness_id = reader1["illness_id"].ToString(),
                    department_id = Convert.ToInt32(reader1["department_id"]),
                    narcosis_doc_id = Convert.ToInt32(reader1["narcosis_doc_id"]),
                    nurse_id = Convert.ToInt32(reader1["nurse_id"]),
                    doc_id = Convert.ToInt32(reader1["doc_id"]),
                    operate_id = reader1["operate_id"].ToString(),
                    start_time = Convert.ToDateTime(reader1["start_time"]),
                    visit_time = Convert.ToDateTime(reader1["visit_time"]),
                    pice_place_id = reader1["pice_place_id"].ToString(),
                    patient_name = reader1["patient_name"].ToString(),
                    operation_date = Convert.ToDateTime(reader1["operation_date"]),
                    narcosis_time = Convert.ToDateTime(reader1["narcosis_time"]),
                    operation_room = reader1["operation_room"].ToString()
                         


                };

            }
            return ss_visitTable_;
        }



        //跟新
        public int update_ss_visitTable(ss_visitTable ss_visitTable_)
        {
            string sql = $"update ss_visitTable set isSelect = @isSelect,visit_result_id = @visit_result_id " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", ss_visitTable_.illness_id),//
                new SqlParameter("@isSelect", ss_visitTable_.isSelect),
                new SqlParameter("@visit_result_id", ss_visitTable_.visit_result_id)
                );

            return row;
        }


        public int update_ss_visitTable2(ss_visitTable ss_visitTable_)
        {
            string sql = $"update ss_visitTable set is_ss = @is_ss " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", ss_visitTable_.illness_id),//
                new SqlParameter("@is_ss", ss_visitTable_.is_ss)
                
                );

            return row;
        }

        public int update_ss_visitTable3(ss_visitTable ss_visitTable_)
        {
            string sql = $"update ss_visitTable set is_bool1 = @is_bool1 " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", ss_visitTable_.illness_id),//
                new SqlParameter("@is_bool1", ss_visitTable_.is_bool1)

                );

            return row;
        }

        public int update_ss_visitTable4(ss_visitTable ss_visitTable_)
        {
            string sql = $"update ss_visitTable set is_bool3 = @is_bool3 " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", ss_visitTable_.illness_id),//
                new SqlParameter("@is_bool3", ss_visitTable_.is_bool3)

                );

            return row;
        }
        #region 返回ss_visitTable表列表333
        /// <summary>
        /// 外连接查询到，临时表中
        /// </summary>
        /// <returns></returns>
        //public List<ss_visitTable> GetSs_visitTableList3()
        //{
        //    //string sql = "select * from ss_visitTable";
        //    string sql = "select ss.illness_id, ss.patient_name, ss.operation_date,ss.operation_room,ss.narcosis_time, op.operation_name, doc.doc_name,na.narcosis_doc_name,nu.nurse_name,ss.sickroom,ss.visit_result_id,ss.Select from ss_visitTable ss " +
        //        " left join operation_table op on ss.operate_id = op.operation_id" +
        //        " Left join doc_table doc on ss.doc_id = doc.doctor_id" +
        //        " Left join narcosis_docTable na on ss.narcosis_doc_id = na.narcosis_doc_id" +
        //        " Left join nurse_table nu on ss.nurse_id = nu.nurse_id";
        //    List<ss_visitTable> ss_visitTable_list = new List<ss_visitTable>(); // 准备一个空的列表对象
        //    DataTable dt = MyHelper.ExecuteTable(sql);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ss_visitTable_list.Add(ToModel3(dr));
        //    }

        //    return ss_visitTable_list;

        //}

        //private static ss_visitTable ToModel3(DataRow dr)  // 上面查询的列信息
        //{
        //    ss_visitTable cur_ss_visitTable_ = new ss_visitTable();
        //    cur_ss_visitTable_.illness_id = dr["illness_id"].ToString();
        //    cur_ss_visitTable_.patient_name = dr["patient_name"].ToString();
        //    cur_ss_visitTable_.operation_date = Convert.ToDateTime(dr["operation_date"]);
        //    cur_ss_visitTable_.operation_room = dr["operation_room"].ToString();
        //    cur_ss_visitTable_.narcosis_time = Convert.ToDateTime(dr["narcosis_time"]);
        //    // ss_visitTable_.operate_id = dr["operate_id"].ToString();
        //    cur_ss_visitTable_.operation_name = dr["operation_name"].ToString();
        //    cur_ss_visitTable_.doc_name = dr["doc_name"].ToString();
        //    cur_ss_visitTable_.narcosis_doc_name = dr["narcosis_doc_name"].ToString();
        //    cur_ss_visitTable_.nurse_name = dr["nurse_name"].ToString();
        //    cur_ss_visitTable_.sickroom = dr["sickroom"].ToString();
        //    cur_ss_visitTable_.isSelect = false; // 新加 默认全为false
        //    return cur_ss_visitTable_;
        //}
        #endregion 返回ss_visitTable表列表222
    }
}
