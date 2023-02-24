using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;

namespace DAL
{
    public class doc_tableDal
    {
        #region 查询doc_table表记录
        public doc_table getCurDoc_table(int id)
        {
            doc_table doc = new doc_table();
            string sql = "select * from doc_table where doctor_id = @doctor_id";
            SqlParameter[] paremeters = new SqlParameter[]
            {
                new SqlParameter("@doctor_id",id)
            };
            // doc_table newdoc = new doc_table();
            try
            {
                //调用本层的MyHelper类中的公开函数
                SqlDataReader reader = MyHelper.GetDataReader(sql, paremeters);
                if (reader.Read())    //如果有这条记录的话
                {
                    doc.doc_name = reader["doc_name"].ToString();
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
        #endregion 查询doc_table表记录
    }
}
