using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL; 

namespace BLL
{
    public class doc_tableBll
    {
        // 初始化Dal对象
        doc_tableDal _doc_tableDal = new doc_tableDal();
        #region 查询doc_table表一条记录
        public doc_table getCurDoc_table(int id)
        {
           
            return _doc_tableDal.getCurDoc_table(id);

        }
        #endregion 查询doc_table表记录
    }
}
