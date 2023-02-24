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
    public partial class IsForm4 : Form
    {
        ss_visitTable ss_visitTable_ = new ss_visitTable();
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll();

        #region 完成分页的前提
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int pageSize = 12;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int recordCount = 0;

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount = 0;

        /// <summary>
        /// 当前页
        /// </summary>
        public int currentPage = 0;
        DataTable mettingTable;
        List_To_table List_To_table_ = new List_To_table();
        #endregion 
        public IsForm4()
        {
            InitializeComponent();
        }

        private void IsForm4_Load(object sender, EventArgs e)
        {
            start_dgv();

        }

        private void start_dgv()
        {
            string patient_name_ = this.txtname1.Text.Trim();
            string peration_name_ = this.txtname2.Text.Trim();
            bool Is_select = this.chk_input.Checked;           


            #region 绑定n表数据
            // 初始化绑定notice_table表数据
            this.dgvss_visit.AutoGenerateColumns = false;  //控制DataGriView只显示需要的列
            // this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList(); //方法一
            List<cur_ss_visitTable> cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1();
            List<cur_ss_visitTable> cur2_ss_visitTable_ = new List<cur_ss_visitTable>();
            cur_ss_visitTable_.FindAll
                (m => m.is_bool1==true && m.patient_name.Contains(patient_name_) && m.operation_name.Contains(peration_name_) && m.isSelect == Is_select).ForEach(i => cur2_ss_visitTable_.Add(i));    //方法二
                                                                                                                                                                                    //this.dgvss_visit.DataSource = cur_ss_visitTable_;                                                                                                   //this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList1().FindAll
                                                                                                                                                                                    //    (m => m.patient_name.Contains(patient_name_) && m.narcosis_doc_name.Contains(norcosis_name_));   //方法二


            mettingTable = List_To_table.ToDataTable(cur2_ss_visitTable_);       //
            recordCount = mettingTable.Rows.Count;     //记录总行数
            if (recordCount == 0)
            {
                MessageBox.Show(string.Format("当前查询到0条数据\n 请检查筛选条件"));
            }
            else
            {
                pageCount = (recordCount / pageSize);
                if ((recordCount % pageSize) > 0)
                {
                    pageCount++;
                }

                //默认第一页
                currentPage = 1;
                LoadPage();//调用加载数据的方法
                           //取巧
                labPageIndex.Text = "当前页: " + currentPage.ToString() + " / " + pageCount.ToString();//当前页
                labRecordCount.Text = "总行数: " + recordCount.ToString() + " 行";//总记录数
            }
            #endregion 绑定notice_table表数据
        }

        /// <summary>
        /// LoadPage方法
        /// </summary>
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;    //开始指针
            int endRecord;      //结束指针
            DataTable dtTemp;
            dtTemp = mettingTable.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(mettingTable.Rows[i]);
            }

            this.dgvss_visit.Rows.Clear();

            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                this.dgvss_visit.Rows.Add(new object[] { dtTemp.Rows[i][1], dtTemp.Rows[i][2], dtTemp.Rows[i][4], dtTemp.Rows[i][5], dtTemp.Rows[i][6], dtTemp.Rows[i][7], dtTemp.Rows[i][8], dtTemp.Rows[i][10], dtTemp.Rows[i][0], dtTemp.Rows[i][10] });// 要对应！！ 
            }

            labPageIndex.Text = "当前页: " + currentPage.ToString() + " / " + pageCount.ToString();//当前页
            labRecordCount.Text = "总行数: " + recordCount.ToString() + " 行";//总记录数
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            start_dgv();
        }

        private void dgvss_visit_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage = 1;
            LoadPage();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage--;
            LoadPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage++;
            LoadPage();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage = pageCount;
            LoadPage();
        }

        private void dgvss_visit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("选中行" + (e.RowIndex + 1));
            //MessageBox.Show(dgvss_visit.Rows[e.RowIndex].Cells["illness_id"].Value.ToString());//获取选中行指定列的值
            //var visit = this.dgvss_visit.CurrentRow.DataBoundItem as cur_ss_visitTable;
            //MessageBox.Show(string.Format("成功{0}", visit.illness_id));



            string illnessId_ = dgvss_visit.Rows[e.RowIndex].Cells["illness_id"].Value.ToString();
            string patient_name_ = dgvss_visit.Rows[e.RowIndex].Cells["patient_name"].Value.ToString(); //
            DateTime operation_date_ = Convert.ToDateTime(dgvss_visit.Rows[e.RowIndex].Cells["operation_date"].Value);//
            

            DateTime narcosis_time_ = Convert.ToDateTime(dgvss_visit.Rows[e.RowIndex].Cells["narcosis_time"].Value);//
            string operation_name_ = dgvss_visit.Rows[e.RowIndex].Cells["operation_name"].Value.ToString();//

            string doc_name_ = dgvss_visit.Rows[e.RowIndex].Cells["doc_name"].Value.ToString();//
            string narcosis_doc_name_ = dgvss_visit.Rows[e.RowIndex].Cells["narcosis_doc_name"].Value.ToString();//
            string nurse_name_ = dgvss_visit.Rows[e.RowIndex].Cells["nurse_name"].Value.ToString();//
            bool isSelect_ = Convert.ToBoolean(dgvss_visit.Rows[e.RowIndex].Cells["isSelect"].Value);
            int visit_result_id_ = Convert.ToInt32(dgvss_visit.Rows[e.RowIndex].Cells["visit_result_id"].Value);
            cur_ss_visitTable visit = new cur_ss_visitTable()
            {
                illness_id = illnessId_,
                patient_name = patient_name_,
                operation_date = operation_date_,
                
                narcosis_time = narcosis_time_,
                operation_name = operation_name_,
                doc_name = doc_name_,
                narcosis_doc_name = narcosis_doc_name_,
                nurse_name = nurse_name_,
                visit_result_id = visit_result_id_,
                  
                 isSelect = isSelect_


            };
            Form_input Form_input_ = new Form_input(visit);
            Form_input_.ShowDialog();
            //窗体关闭后
            //跟新显示数据表
            start_dgv();


        }
    }
}
