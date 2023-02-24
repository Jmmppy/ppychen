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

namespace WindowsFormsApp1
{
    public partial class Form_middle2 : Form
    {
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll();
        ss_tableBll ss_tableBll_ = new ss_tableBll();
        patient_table patient_table_;
        ss_table ss_table_;
        cur_ss_visitTable cur_ss_visitTable_;
        bool cheak_ok1 = false;
        bool cheak_ok2 = false;
        bool result = false;
        public Form_middle2(cur_ss_visitTable visit)
        {
            InitializeComponent();
            cur_ss_visitTable_ = visit;
            #region 显示信息
            this.lbname.Text = visit.patient_name.ToString();
            this.lb_ilnessid.Text = visit.illness_id.ToString();

            #endregion 显示信息
        }

        private void Form_middle2_Load(object sender, EventArgs e)
        {
            #region 患者信息
            patient_table_ = patient_tableBll_.getpatient_tableObject(cur_ss_visitTable_.illness_id);
            this.lb_sex.Text = "男";
            this.lb_department.Text = patient_table_.age.ToString();
            this.lb_sickroom.Text = patient_table_.sickroom.ToString();
            this.txbmessage.Text = patient_table_.diagnosis.ToString();

            #endregion

            #region 手术申请
            int ss_Id = Convert.ToInt32(patient_table_.ss_id);
            if (ss_Id != 0)
            {
                ss_table_ = ss_tableBll_.getss_tableObject2(ss_Id);
                this.lb_ss_time.Text = Convert.ToString(ss_table_.ss_date);
                this.label42.Text = ss_table_.ss_type.ToString();
                this.label43.Text = ss_table_.ss_grade.ToString();
                this.label9.Text = ss_table_.operation_id.ToString();       //////
                this.label11.Text = ss_table_.position.ToString();
                this.label44.Text = ss_table_.body_position.ToString();
                this.label45.Text = ss_table_.cut_grade.ToString();
                this.label46.Text = ss_table_.narcosis_way.ToString();
                this.label47.Text = ss_table_.special_infection.ToString();
                this.label48.Text = ss_table_.remarks.ToString();
                this.label20.Text = ss_table_.hepatitisB.ToString();
                this.label21.Text = ss_table_.hepatitisC.ToString();
                this.label23.Text = ss_table_.syphilis.ToString();
                this.label25.Text = ss_table_.HIV.ToString();
                this.label27.Text = ss_table_.tuberculosis.ToString();
            }


            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cheak_ok1 = true;
            button1.BackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cheak_ok2 = true;
            button3.BackColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = cheak_ok1 && cheak_ok2;
            if (result)
            {
                Form_middle3 Form_visit_specific_ = new Form_middle3(cur_ss_visitTable_);
                Form_visit_specific_.ShowDialog();
                
                ss_visitTable ss_Visit = new ss_visitTable()
                {
                    illness_id = cur_ss_visitTable_.illness_id,
                    is_ss = true
                };
                //跟新
                int row = ss_visitTableBll_.update_ss_visitTable2(ss_Visit);
                this.Close();
            }
            else
            {
                button4.Enabled = false;
            }
        }
    }
}
