using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Models;
namespace BLL
{
    /// <summary>
    /// 登录业务逻辑类
    /// </summary>
    public class Doc_loginBLL
    {
        //实例化DAL登录类对象
        Doc_loginDal _LoginDal = new Doc_loginDal();

        public doc_table UserLogin(doc_table doc)
        {
            return _LoginDal.UserLogin(doc);  //返回DAL对象里的方法
        }

        //登录方法二
        public bool login(doc_table doc)
        {

            bool result = _LoginDal.login(doc);

            return result;
        }
    }
}
