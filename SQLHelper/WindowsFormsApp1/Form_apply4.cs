using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using BLL;
using Utility;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form_apply4 : Form
    {
        cur_patient_table cur_visit;
        private bool cur_isInput = false;
        partment_tableBll partment_tableBll_ = new partment_tableBll();
        ss_tableBll ss_tableBll_ = new ss_tableBll();
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        patient_table patient_table_;
        public Form_apply4(cur_patient_table visit)
        {
            InitializeComponent();
            cur_visit = visit;
            #region 显示信息
            this.lbname.Text = cur_visit.patient_name.ToString();
            this.lb_ilnessid.Text = cur_visit.illness_id.ToString();
            this.lbsickroom.Text = cur_visit.sickroom.ToString();
            //没写完……
            #endregion 显示信息
        }

        private void Form_apply4_Load(object sender, EventArgs e)
        {
            //ss_id 去查找
            ss_table ss_table_ = ss_tableBll_.getss_tableObject2(cur_visit.ss_id);   //
            string a = Convert.ToString(ss_table_.ss_date);
            //显示已经选择的数据
            this.dateTimePicker1.Text = Convert.ToString(ss_table_.ss_date);///
            this.cmb_ss_type.Text = ss_table_.ss_type;
            this.cmb_ss_grade.Text = ss_table_.ss_grade;

            this.cmb_operation.Text = ss_table_.operation_id;////
            this.cmb_position.Text = ss_table_.position;
            this.cmb_body_position.Text = ss_table_.body_position;
            this.cmb_cut_grade.Text = ss_table_.cut_grade;

            this.cmb_narcosis_way.Text = ss_table_.narcosis_way;

            this.cmb_hepatitisB.Text = ss_table_.hepatitisB;
            this.cmb_hepatitisC.Text = ss_table_.hepatitisC;
            this.cmb_syphilis.Text = ss_table_.syphilis;
            this.cmb_HIV.Text = ss_table_.HIV;
            this.cmb_tuberculosis.Text = ss_table_.tuberculosis;

            this.cmb_BH_blood.Text = ss_table_.BH_blood;
            this.txb_special_infection.Text = ss_table_.special_infection;
            this.txt_remarks.Text = ss_table_.remarks;

            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            patient_table_ = new patient_table()
            {
                illness_id = cur_visit.illness_id,
                 
                isInput2 = true


            };
            //跟新ss_visitTable  visit_result_id、isSelect
            int row2 = patient_tableBll_.update_patient_table22(patient_table_);

            this.Close();
        }
    }
}
