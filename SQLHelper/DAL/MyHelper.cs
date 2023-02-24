using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class MyHelper
    {
        /// <summary>
        /// 数据库连接字符串，从配置文件读取
        /// </summary>
        private static readonly string connString = @"Data Source=DESKTOP-52O598N\MSSQLSERVERCPY;Initial Catalog=gdmu;Integrated Security=True;User ID =sa;Password = 123";
        #region 增、删，改
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetSingleResult(string sql)
        {
            //连接Ado.Net,做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetSingleResult(string sql)方法出错 " + ex.Message);
                throw ex;
            }
            finally
            {
                //最后需要处理的
                conn.Close();
            }
        }

        // 读去单一结果
        public static object GetSingleObject(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                object obj = cmd.ExecuteNonQuery();
                return obj;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetSingleResult(string sql)方法出错 " + ex.Message);
                throw ex;
            }
            finally
            {
                //最后需要处理的
                conn.Close();
            }

            
        }

        // 读取多个对象
        public static SqlDataReader GetDataReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                //CommandBehavior.CloseConnection ; //检测并关闭自动连接
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetDataReader(string sql)方法出错 " + ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// 新取数据方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql)
        {
            //连接Ado.Net,做数据查询
            SqlConnection conn = new SqlConnection(connString);  //来连接
            SqlCommand cmd = new SqlCommand(sql, conn); //来管家
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd); //推车
                DataSet ds = new DataSet(); //货车
                sda.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetDataReader(string sql)方法出错 " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 新的非取数据方法——增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNoteQuery(string sql)
        {
            //连接Ado.Net,做数据查询
            SqlConnection conn = new SqlConnection(connString);  //来连接
            SqlCommand cmd = new SqlCommand(sql, conn); //来管家
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows<=0)
                {
                    throw new Exception("执行GetDataReader(string sql)方法出错");
                }

                return rows;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetDataReader(string sql)方法出错 " + ex.Message);
                throw ex;
            }
        }
        #endregion 增、删，改


        #region 加参数的增、删，改
        public static int GetSingleResult(string sql, SqlParameter[] param)
        {
            //连接Ado.Net,做数据查询
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                cmd.Parameters.AddRange(param); //多参数给推车
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetSingleResult(string sql)方法出错 " + ex.Message);
                throw ex;
            }
            finally
            {
                //最后需要处理的
                conn.Close();
            }
        }
        // 读去单一结果
        public static object GetSingleObject(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                cmd.Parameters.AddRange(param);
                object obj = cmd.ExecuteNonQuery();
                return obj;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetSingleResult(string sql)方法出错 " + ex.Message);
                throw ex;
            }
            finally
            {
                //最后需要处理的
                conn.Close();
            }


        }
        // 读取多个对象
        public static SqlDataReader GetDataReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                cmd.Parameters.AddRange(param);
                //CommandBehavior.CloseConnection ; //检测并关闭自动连接
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetDataReader(string sql)方法出错 " + ex.Message);
                throw ex;
            }
            //finally
            //{
            //    //最后需要处理的
            //    conn.Close();
            //}

        }

        /// <summary>
        /// 新的非取数据方法——增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNoteQuery(string sql, params SqlParameter[] SqlParameters)
        {
            //连接Ado.Net,做数据查询
            SqlConnection conn = new SqlConnection(connString);  //来连接
            SqlCommand cmd = new SqlCommand(sql, conn); //来管家
            cmd.Parameters.AddRange(SqlParameters);
            try
            {
                //这里写需要检测的语句,拿推车去操作数据库
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    throw new Exception("执行GetDataReader(string sql)方法出错");
                }

                return rows;
            }
            catch (Exception ex)
            {
                //处理异常
                //可以直接显示或者写入系统日志
                Console.WriteLine("执行GetDataReader(string sql)方法出错 " + ex.Message);
                throw ex;
            }
        }

        # endregion 加参数的增、删，改
    }
}
