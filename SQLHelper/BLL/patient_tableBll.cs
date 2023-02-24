using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;


namespace BLL
{
    public class patient_tableBll
    {
        patient_tableDal patient_tableDal_ = new patient_tableDal();
        #region 返回ss_visitTable表列表222

        public List<cur_patient_table> GetPatient_tableList1()
        {

            return patient_tableDal_.GetPatient_tableList1();
        }
        #endregion 返回ss_visitTable表列表222
        /// <summary>
        /// 有了新的字段的临时表
        /// </summary>
        /// <returns></returns>
        public List<cur_patient_table> GetPatient_tableList2()
        {
           
            return patient_tableDal_.GetPatient_tableList2();

        }




        /// <summary>
        /// 跟新patient_table表
        /// </summary>
        /// <param name="ss_visitTable_"></param>
        /// <returns></returns>
        public int update_patient_table(patient_table patient_table_)
        {

            return patient_tableDal_.update_patient_table(patient_table_);
        }

        public int update_patient_table22(patient_table patient_table_)
        {
            

            return patient_tableDal_.update_patient_table22(patient_table_);
        }
        /// <summary>
        /// 随机分配的跟新patient_table表
        /// </summary>
        /// <param name="ss_visitTable_"></param>
        /// <returns></returns>
        public int update_patient_table2(patient_table patient_table_)
        {
            
            return patient_tableDal_.update_patient_table2(patient_table_);
        }

        /// <summary>
        /// 根据illness_id查找一行，用于显示
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public patient_table getpatient_tableObject(string id_)
        {
            
            return patient_tableDal_.getpatient_tableObject(id_);
        }

    }
}
