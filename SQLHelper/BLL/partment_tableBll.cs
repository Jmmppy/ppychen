using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public class partment_tableBll
    {
        partment_tableDal partment_tableDal_ = new partment_tableDal(); // 初始化DAL层的partment_tableDal类对象

        #region 根据partment_id获取信息2222
        public partment_table getPartment_tableObject(int partment_id)
        {
            
            return partment_tableDal_.getPartment_tableObject(partment_id);
        }

        #endregion 根据notice_id获取信息222
    }
}
