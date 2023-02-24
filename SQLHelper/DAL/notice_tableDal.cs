using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models; // 引入models类库
using System.Data.SqlClient;
using System.Collections;


namespace DAL
{
    /// <summary>
    ///对notice_table表的数据访问层的操作
    /// </summary>
    public class notice_tableDal
    {
        #region 返回notice表列表
        /// <summary>
        /// 读取notice表的全部对象，返回到界面的DataGridVie里
        /// </summary>
        /// <returns></returns>
        public List<notice_table> Getnotice_TableList() 
        {
            string sql = "select * from notice_table";
            List<notice_table> notices_list = new List<notice_table>(); // 准备一个空的列表对象
            SqlDataReader dataReader = MyHelper.GetDataReader(sql); // 这个有问题？？？？？？
            //Console.WriteLine();
            Console.WriteLine("read:"+dataReader.Read());
            while (dataReader.Read()) 
            {
                Console.WriteLine("11111111111");
                //问题要不要写全？？？ 不要写完整
                notices_list.Add(new notice_table()
                {
                    notice_id = Convert.ToInt32(dataReader["notice_id"]),
                    // message = dataReader["message"].ToString(),
                    title = dataReader["title"].ToString(),    // 这个没有问题
                    notice_date = Convert.ToDateTime(dataReader["notice_date"]),
                    //notice_time = Convert.ToDateTime(dataReader["notice_time"])  // 这个有问题？？？？？？

                });
            }
            dataReader.Close();//采用了close进行手动关闭。
            return notices_list;
        }
        #endregion 返回notice表列表

        #region 根据notice_id获取信息
        public notice_table getCurNotice_table(int id)
        {
            notice_table notice_ = new notice_table();
            string sql = "select * from notice_table where notice_id = @notice_id";
            //SqlParameter paremeters = new SqlParameter("@notice_id", id);
            SqlParameter[] paremeters = new SqlParameter[]
            {
                new SqlParameter("@notice_id",id)
            };
            // doc_table newdoc = new doc_table();
            try
            {
                //调用本层的MyHelper类中的公开函数
                SqlDataReader reader = MyHelper.GetDataReader(sql, paremeters);
                if (reader.Read())    //如果有这条记录的话
                {
                    notice_.notice_id = Convert.ToInt32(reader["notice_id"]);
                    notice_.message = reader["message"].ToString();
                    notice_.title= reader["title"].ToString();
                    notice_.notice_date = Convert.ToDateTime(reader["notice_date"]);
                    notice_.notice_man = reader["notice_man"].ToString();
                  

                }
                else
                {
                    notice_ = null;
                }
                //reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return notice_;

        }

        #endregion 根据notice_id获取信息


        #region 根据notice_id获取信息2222
        public notice_table getCurNoticeObject(int id_)
        {
            notice_table notice_ = new notice_table();
            string sql = $"select * from notice_table where notice_id = {id_}";
            SqlDataReader reader1 = MyHelper.GetDataReader(sql);
            Console.WriteLine("1111111111111111111111111111111111");
            while (reader1.Read())
            {
                notice_ = new notice_table()
                {
                    notice_id = Convert.ToInt32(reader1["notice_id"]),
                    title = reader1["title"].ToString(),
                    message = reader1["message"].ToString(),
                    notice_date = Convert.ToDateTime(reader1["notice_date"]),
                    notice_man = reader1["notice_man"].ToString()
                };
               
            }
            return notice_;
        }

        #endregion 根据notice_id获取信息222
    }
}
