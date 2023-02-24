using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class patient_tableDal
    {
        #region 返回patient_table表列表222
        /// <summary>
        /// 外连接查询到，临时表中
        /// </summary>
        /// <returns></returns>
        public List<cur_patient_table> GetPatient_tableList1()
        {
            //string sql = "select * from ss_visitTable";
            string sql = "select pa.illness_id, pa.patient_name,pa.age,pa.height,pa.weigth,pa.sickroom,pa.insurance_type,pa.diagnosis,pa.phone,pa.card_type,pa.card_id,pa.isInput,pa.isInput2,pa.ss_id,doc.doc_name,pic.pice_place_name,part.partment_name from patient_table pa   " +
                " Left join doc_table doc on pa.doc_id = doc.doctor_id" +
                " Left join pice_placeTable pic on pa.pice_place_id = pic.pice_place_id" +
                " Left join partment_table part on pa.department_id = part.partment_id";

            List<cur_patient_table> patient_table_list = new List<cur_patient_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                patient_table_list.Add(ToModel(dr));
            }

            return patient_table_list;

        }

        private static cur_patient_table ToModel(DataRow dr)  // 上面查询的列信息(上面可以写很多，但下面的出现的必须是上面所查询的)
        {
            cur_patient_table cur_patient_table_ = new cur_patient_table();
            cur_patient_table_.illness_id = dr["illness_id"].ToString();
            cur_patient_table_.patient_name = dr["patient_name"].ToString();
            cur_patient_table_.age = dr["age"].ToString();
            cur_patient_table_.height = dr["height"].ToString();
            cur_patient_table_.weigth = dr["weigth"].ToString();
            cur_patient_table_.sickroom = dr["sickroom"].ToString();


            cur_patient_table_.insurance_type = dr["insurance_type"].ToString();
            cur_patient_table_.card_type = dr["card_type"].ToString();//
            cur_patient_table_.card_id = dr["card_id"].ToString();///
            cur_patient_table_.phone = dr["phone"].ToString();///
            // ss_visitTable_.operate_id = dr["operate_id"].ToString();
            cur_patient_table_.diagnosis = dr["diagnosis"].ToString();
            cur_patient_table_.doc_name = dr["doc_name"].ToString();
            cur_patient_table_.pice_place_name = dr["pice_place_name"].ToString();
            cur_patient_table_.partment_name = dr["partment_name"].ToString();

            cur_patient_table_.Isinput = (bool)dr["isInput"];// 新加 默认全为false
            cur_patient_table_.Isinput2 = (bool)dr["isInput2"];// 新加 默认全为false

            cur_patient_table_.ss_id = Convert.ToInt32(dr["ss_id"]);
            return cur_patient_table_;
        }
        #endregion 返回ss_visitTable表列表222


        #region 返回patient_table表列表222
        /// <summary>
        /// 有了新的字段的临时表
        /// </summary>
        /// <returns></returns>
        public List<cur_patient_table> GetPatient_tableList2()
        {
            //string sql = "select * from ss_visitTable";
            string sql = "select pa.illness_id, pa.patient_name,pa.age,pa.height,pa.weigth,pa.sickroom,pa.insurance_type,pa.diagnosis,pa.phone,pa.card_type,pa.card_id,pa.isInput,pa.ss_id,doc.doc_name,na.narcosis_doc_name,nur.nurse_name,pa.operation_room,pic.pice_place_name,part.partment_name from patient_table pa   " +
                " Left join doc_table doc on pa.doc_id = doc.doctor_id" +
                " Left join pice_placeTable pic on pa.pice_place_id = pic.pice_place_id" +
                " Left join partment_table part on pa.department_id = part.partment_id" +
                " Left join narcosis_docTable na on pa.narcosis_doc_id = na.narcosis_doc_id" +
                " Left join nurse_table nur on pa.nurse_id = nur.nurse_id";

            List<cur_patient_table> patient_table_list = new List<cur_patient_table>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                patient_table_list.Add(ToModel2(dr));
            }

            return patient_table_list;

        }

        private static cur_patient_table ToModel2(DataRow dr)  // 上面查询的列信息(上面可以写很多，但下面的出现的必须是上面所查询的)
        {
            cur_patient_table cur_patient_table_ = new cur_patient_table();
            cur_patient_table_.illness_id = dr["illness_id"].ToString();
            cur_patient_table_.patient_name = dr["patient_name"].ToString();
            cur_patient_table_.age = dr["age"].ToString();
            cur_patient_table_.height = dr["height"].ToString();
            cur_patient_table_.weigth = dr["weigth"].ToString();
            cur_patient_table_.sickroom = dr["sickroom"].ToString();


            cur_patient_table_.insurance_type = dr["insurance_type"].ToString();
            cur_patient_table_.card_type = dr["card_type"].ToString();//
            cur_patient_table_.card_id = dr["card_id"].ToString();///
            cur_patient_table_.phone = dr["phone"].ToString();///
            // ss_visitTable_.operate_id = dr["operate_id"].ToString();
            cur_patient_table_.diagnosis = dr["diagnosis"].ToString();
            cur_patient_table_.doc_name = dr["doc_name"].ToString();
            cur_patient_table_.pice_place_name = dr["pice_place_name"].ToString();
            cur_patient_table_.partment_name = dr["partment_name"].ToString();

            cur_patient_table_.Isinput = (bool)dr["isInput"];// 新加 默认全为false
            cur_patient_table_.ss_id = Convert.ToInt32(dr["ss_id"]);
            cur_patient_table_.narcosis_doc_name = dr["narcosis_doc_name"].ToString();
            cur_patient_table_.nurse_name = dr["nurse_name"].ToString();
            cur_patient_table_.operation_room = dr["operation_room"].ToString();

            return cur_patient_table_;
        }
        #endregion 返回ss_visitTable表列表222


        /// <summary>
        /// 跟新patient_table表
        /// </summary>
        /// <param name="ss_visitTable_"></param>
        /// <returns></returns>
        public int update_patient_table(patient_table patient_table_)
        {
            string sql = $"update patient_table set isInput = @isInput,ss_id = @ss_id " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", patient_table_.illness_id),//
                new SqlParameter("@isInput", patient_table_.isInput),
                new SqlParameter("@ss_id", patient_table_.ss_id)
                );

            return row;
        }

        public int update_patient_table22(patient_table patient_table_)
        {
            string sql = $"update patient_table set isInput2 = @isInput2 " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", patient_table_.illness_id),//
                new SqlParameter("@isInput2", patient_table_.isInput2)
                
                );

            return row;
        }
        /// <summary>
        /// 随机分配的跟新patient_table表
        /// </summary>
        /// <param name="ss_visitTable_"></param>
        /// <returns></returns>
        public int update_patient_table2(patient_table patient_table_)
        {
            string sql = $"update patient_table set narcosis_doc_id = @narcosis_doc_id,nurse_id = @nurse_id,operation_room = @operation_room " +
                $"where illness_id = @illness_id";
            int row = MyHelper.ExecuteNoteQuery(sql,
                new SqlParameter("@illness_id", patient_table_.illness_id),//
                new SqlParameter("@narcosis_doc_id", patient_table_.narcosis_doc_id),
                new SqlParameter("@nurse_id", patient_table_.nurse_id),
                new SqlParameter("@operation_room", patient_table_.operation_room)
                 );
            return row;
        }

        /// <summary>
        /// 根据illness_id查找一行，用于显示
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public patient_table getpatient_tableObject(string id_)
        {
            patient_table patient_table_ = new patient_table();
            string sql = $"select * from patient_table where illness_id = '{id_}'";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);

            while (reader1.Read())
            {
                patient_table_ = new patient_table()
                {
                    age = reader1["age"].ToString(),
                    card_id = reader1["card_id"].ToString(),
                    card_type = reader1["card_type"].ToString(),
                    department_id = Convert.ToInt32(reader1["department_id"]),
                    diagnosis = reader1["diagnosis"].ToString(),
                    height = reader1["height"].ToString(),
                    insurance_type = reader1["insurance_type"].ToString(),
                    patient_name = reader1["patient_name"].ToString(),
                    phone = reader1["phone"].ToString(),
                    weigth = reader1["weigth"].ToString(),
                    pice_place_id = reader1["pice_place_id"].ToString(),
                    sickroom = reader1["sickroom"].ToString(),
                    operation_room = reader1["operation_room"].ToString(),
                    ss_id = Convert.ToInt32(reader1["ss_id"]),
                    doc_id = Convert.ToInt32(reader1["doc_id"]),
                    narcosis_doc_id = Convert.ToInt32(reader1["narcosis_doc_id"]),
                    nurse_id = Convert.ToInt32(reader1["nurse_id"]),
                    isInput = (bool)reader1["isInput"]



                };

            }
            return patient_table_;
        }
    }
}
