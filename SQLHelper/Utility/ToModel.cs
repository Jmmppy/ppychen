using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace Utility
{
    public static class ToModel
    {
        //使用这个只能全使用数据库表的值传；不能赋值
        public static ToModel DataRowToModel<ToModel>(this DataRow dr)
        {
            Type type = typeof(ToModel);
            ToModel md = (ToModel)Activator.CreateInstance(type);//泛型 是咧化对象
            foreach (var prop in type.GetProperties())         // 遍历所以属性
            {
                prop.SetValue(md, dr[prop.Name], null);
            }
            return md;
        }
    }
    //对这类的优化：泛型
    //private static cur_ss_visitTable ToModel(DataRow dr)  // 上面查询的列信息
    //{
    //    cur_ss_visitTable cur_ss_visitTable_ = new cur_ss_visitTable();  //泛型 是咧化对象
    //    cur_ss_visitTable_.illness_id = dr["illness_id"].ToString();
    //    cur_ss_visitTable_.patient_name = dr["patient_name"].ToString();
    //    cur_ss_visitTable_.operation_date = Convert.ToDateTime(dr["operation_date"]);
    //    cur_ss_visitTable_.operation_room = dr["operation_room"].ToString();
    //    cur_ss_visitTable_.narcosis_time = Convert.ToDateTime(dr["narcosis_time"]);
    //    // ss_visitTable_.operate_id = dr["operate_id"].ToString();
    //    cur_ss_visitTable_.operation_name = dr["operation_name"].ToString();
    //    cur_ss_visitTable_.doc_name = dr["doc_name"].ToString();
    //    cur_ss_visitTable_.narcosis_doc_name = dr["narcosis_doc_name"].ToString();
    //    cur_ss_visitTable_.nurse_name = dr["nurse_name"].ToString();
    //    cur_ss_visitTable_.sickroom = dr["sickroom"].ToString();
    //    cur_ss_visitTable_.isSelect = false; // 新加 默认全为false
    //    return cur_ss_visitTable_;
    //}

}
