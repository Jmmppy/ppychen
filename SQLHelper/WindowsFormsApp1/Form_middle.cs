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
    public partial class Form_middle : Form
    {
        ss_visitTable ss_visitTable_ = new ss_visitTable();
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll();
        public Form_middle()
        {
            InitializeComponent();
        }

        private void Form_middle_Load(object sender, EventArgs e)
        {
            NewMethod();
        }
        private void NewMethod()
        {



            #region 绑定notice_table表数据
            // 初始化绑定notice_table表数据
            this.dgvss_visit.AutoGenerateColumns = false;  //控制DataGriView只显示需要的列
            // this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList(); //方法一
            List<cur_ss_visitTable> cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1();
            this.dgvss_visit.DataSource = cur_ss_visitTable_.FindAll
                (m => m.is_ss == false);   //方法二
            //////////////this.dgvss_visit.DataSource = cur_ss_visitTable_;                                                                                                   //this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList1().FindAll
            //    (m => m.patient_name.Contains(patient_name_) && m.narcosis_doc_name.Contains(norcosis_name_));   //方法二

            //mettingTable = List_To_table.ToDataTable(cur_ss_visitTable_);           // 运用工具类把List对象转化为DataTable
            
            #endregion 绑定notice_table表数据
        }

        private void dgvss_visit_DoubleClick(object sender, EventArgs e)
        {
            var visit = this.dgvss_visit.CurrentRow.DataBoundItem as cur_ss_visitTable;
            MessageBox.Show(string.Format("成功{0}", visit.illness_id));
            Form_middle2 Form_visit_specific_ = new Form_middle2(visit);
            Form_visit_specific_.ShowDialog();
            NewMethod();
        }
    }
}
