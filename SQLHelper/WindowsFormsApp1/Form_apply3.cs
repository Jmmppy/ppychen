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

namespace WindowsFormsApp1
{
    public partial class Form_apply3 : Form
    {
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        public Form_apply3()
        {
            InitializeComponent();
        }

        private void Form_apply3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Form_apply3_Load(object sender, EventArgs e)
        {
            dgv_show();            //MessageBox.Show(string.Format("当前可提交的数据为0条"));
        }

        private void dgv_show()
        {
            string patient_name_ = this.txtname1.Text.Trim();
            string doc_name_ = this.txtname2.Text.Trim();

            #region 绑定n表数据
            // 初始化绑定notice_table表数据
            this.dgvss_visit.AutoGenerateColumns = false;  //控制DataGriView只显示需要的列
                                                           // this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList(); //方法一
            List<cur_patient_table> cur_patient_table_ = patient_tableBll_.GetPatient_tableList1();
            this.dgvss_visit.DataSource = cur_patient_table_.FindAll
                (m => m.patient_name.Contains(patient_name_) && m.doc_name.Contains(doc_name_) && m.Isinput == true && m.Isinput2 == false);   //方法二
                                                                                                                        //this.dgvss_visit.DataSource = cur_ss_visitTable_;                                                                                                   //this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList1().FindAll
                                                                                                                        //    (m => m.patient_name.Contains(patient_name_) && m.narcosis_doc_name.Contains(norcosis_name_));   //方法二
            #endregion 绑定notice_table表数据
        }

        private void dgvss_visit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dgv_show();
        }

        private void dgvss_visit_DoubleClick(object sender, EventArgs e)
        {
            var visit = this.dgvss_visit.CurrentRow.DataBoundItem as cur_patient_table;
            //MessageBox.Show(string.Format("成功{0}", visit.illness_id));
            Form_apply4 Form_apply4_ = new Form_apply4(visit);
            Form_apply4_.ShowDialog();
            //窗体关闭后
            //跟新显示数据表
            dgv_show();
        }
    }
}
