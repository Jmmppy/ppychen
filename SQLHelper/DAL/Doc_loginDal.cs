using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models; // 引入models类库
using System.Data.SqlClient;
using System.Collections;
namespace DAL
{
    public class Doc_loginDal
    {
        /// <summary>
        /// 处理登录时，如果输入的id 和密码有记录则返回一条有全部8个字段的记录
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public doc_table UserLogin(doc_table doc) 
        {
            string sql = "select doctor_id,pwd from doc_table where doctor_id = @doctor_id and pwd = @pwd";
            SqlParameter[] paremeters = new SqlParameter[]
            {
                new SqlParameter("@doctor_id",doc.doctor_id),
                new SqlParameter("@pwd",doc.pwd)
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

        //登录方法二
        public bool login(doc_table doc)
        {
            bool res = false;
            using (SqlConnection m_cnADONetConnection = new SqlConnection())
            {
                m_cnADONetConnection.ConnectionString = connection.connect_str;

                SqlCommand cmd = m_cnADONetConnection.CreateCommand();
                string sql = "select count(*)from doc_table where doctor_id=@doctor_id and pwd = @pwd";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@doctor_id", doc.doctor_id);
                cmd.Parameters.AddWithValue("@pwd", doc.pwd);
                m_cnADONetConnection.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result == 1) res = true;
            }
            return res;
        }
    }
}
