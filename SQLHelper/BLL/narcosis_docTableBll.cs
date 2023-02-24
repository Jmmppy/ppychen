using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;
using Utility;

namespace BLL
{
    public class narcosis_docTableBll
    {
        narcosis_docTableDal narcosis_docTableDal_ = new narcosis_docTableDal();

        #region 返回narcosis_docTable表列表222
        /// <summary>
        /// 返回narcosis_docTable表列表,采用了公共类
        /// </summary>
        /// <returns></returns>
        public List<narcosis_docTable> GetNarcosis_docTableList1()
        {

            return narcosis_docTableDal_.GetNarcosis_docTableList1();

        }

        #endregion 返回narcosis_docTable表列表222


        public narcosis_docTable getCurNarcosis_docTable(int id)
        {
            
            return narcosis_docTableDal_.getCurNarcosis_docTable(id);

        }
    }
}
