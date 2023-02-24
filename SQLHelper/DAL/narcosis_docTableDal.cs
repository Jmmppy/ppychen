using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Utility;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class narcosis_docTableDal
    {
        #region 返回narcosis_docTable表列表222
        /// <summary>
        /// 返回narcosis_docTable表列表,采用了公共类
        /// </summary>
        /// <returns></returns>
        public List<narcosis_docTable> GetNarcosis_docTableList1()
        {
            string sql = "select * from narcosis_docTable";

            List<narcosis_docTable> cur_narcosis_docTable_list = new List<narcosis_docTable>(); // 准备一个空的列表对象
            DataTable dt = MyHelper.ExecuteTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                cur_narcosis_docTable_list.Add(dr.DataRowToModel<narcosis_docTable>());
            }

            return cur_narcosis_docTable_list;

        }

        #endregion 返回narcosis_docTable表列表222

        public narcosis_docTable getCurNarcosis_docTable(int id)
        {
            narcosis_docTable doc = new narcosis_docTable();
            string sql = "select * from narcosis_docTable where narcosis_doc_id = @narcosis_doc_id";
            SqlParameter[] paremeters = new SqlParameter[]
            {
                new SqlParameter("@narcosis_doc_id",id)
            };
            // doc_table newdoc = new doc_table();
            try
            {
                //调用本层的MyHelper类中的公开函数
                SqlDataReader reader = MyHelper.GetDataReader(sql, paremeters);
                if (reader.Read())    //如果有这条记录的话
                {

                    doc.narcosis_doc_name = reader["narcosis_doc_name"].ToString();
                    doc.pice_place = reader["pice_place"].ToString();
                    doc.profession = reader["profession"].ToString();
                    doc.sex = reader["sex"].ToString();
                    doc.age = reader["age"].ToString();
                    doc.phone = reader["phone"].ToString();
                    doc.partment_id = Convert.ToInt32(reader["partment_id"]);

                }
                else
                {
                    doc = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doc;

        }
    }
}
