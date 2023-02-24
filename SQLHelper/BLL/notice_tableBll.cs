using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
namespace BLL
{
    public class notice_tableBll
    {
        notice_tableDal notice_TableDal_ = new notice_tableDal(); // 初始化DAL层的notice_tableDal类对象
        #region 返回notice表列表
        /// <summary>
        /// 读取notice表的全部对象，返回到界面的DataGridVie里
        /// </summary>
        /// <returns></returns>
        public List<notice_table> Getnotice_TableList()
        {
            //调用DAL层的notice_tableDal类的一个方法
            return notice_TableDal_.Getnotice_TableList();
        }
        #endregion 返回notice表列表


        #region 根据notice_id获取信息
        public notice_table getCurNotice_table(int id)
        {
           
            return notice_TableDal_.getCurNotice_table(id);

        }

        #endregion 根据notice_id获取信息

        #region 根据notice_id获取信息2222
        public notice_table getCurNoticeObject(int id)
        {
        
            return notice_TableDal_.getCurNoticeObject(id);
        }

        #endregion 根据notice_id获取信息222
    }
}
