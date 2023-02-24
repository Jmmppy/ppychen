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
    public partial class Form_input : Form
    {
        cur_ss_visitTable cur_visit;
        visit_result_tableBll visit_result_tableBll_ = new visit_result_tableBll();
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll(); 
        visit_result_table visit_result_table_;
        ss_visitTable ss_visitTable_;
        private bool isInput = false;

        public Form_input(cur_ss_visitTable visit)
        {
            InitializeComponent();
            cur_visit = visit;
            #region 显示信息
            this.lbname.Text = visit.patient_name.ToString();
            this.label11.Text = visit.illness_id.ToString();
            this.label14.Text = visit.narcosis_doc_name.ToString();
            this.label16.Text = visit.nurse_name.ToString();
            this.label18.Text = visit.operation_name.ToString();

            #endregion 显示信息
        }

        private void Form_input_Load(object sender, EventArgs e)
        {
            //判断是否已经录入
            if (cur_visit.isSelect == true)
            {
                isInput = true;
                //根据result_id 去查找
                visit_result_table_ = visit_result_tableBll_.getvisit_result_tableObject2(cur_visit.visit_result_id);
                //显示已经选择的数据
                this.txb_drug_allergy.Text = visit_result_table_.drug_allergy.ToString();
                this.txb_sanity.Text = visit_result_table_.sanity.ToString();
                this.txb_condition.Text = visit_result_table_.condition.ToString();
                this.txb_test_result.Text = visit_result_table_.test_result.ToString();


                //btn命名为“修改”
                this.btnOK.Text = "修 改";
                //跟新表
            }
            else
            {
                isInput = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string drug_allergy_ = this.txb_drug_allergy.Text;
            string sanity_ = this.txb_sanity.Text;
            string condition_ = this.txb_condition.Text;
            string test_result_ = this.txb_test_result.Text;
           
            if (drug_allergy_ =="" || sanity_ == ""|| condition_ == ""|| test_result_ == "")
            {
                MessageBox.Show(string.Format("字段不应该为空！请重新输入"));
            }
            else
            {
                if (isInput == true)
                {//已经录入 “修改”
                 //跟新到visit_result_table表
                    visit_result_table visit_result_table_2 = new visit_result_table()
                    {
                        visit_result_id = cur_visit.visit_result_id,
                        condition = condition_,
                        drug_allergy = drug_allergy_,
                        sanity = sanity_,
                        test_result = test_result_,
                        illness_id = cur_visit.illness_id
                    };
                    int row = visit_result_tableBll_.update_visit_result_table(visit_result_table_2);
                    if (row > 0)
                    {// 修改成功
                        MessageBox.Show(string.Format("成功修改！"));
                        this.Close();
                    }
                }
                else
                {

                    //对象初始化器
                    visit_result_table visit_result_table_ = new visit_result_table()
                    {
                        illness_id = cur_visit.illness_id,
                        drug_allergy = drug_allergy_,
                        sanity = sanity_,
                        condition = condition_,
                        test_result = test_result_
                    };

                    int row = visit_result_tableBll_.insert_visit_result_table(visit_result_table_);//插入visit_result_table
                    if (row > 0)
                    {// 插入成功
                        visit_result_table_ = visit_result_tableBll_.getvisit_result_tableObject(cur_visit.illness_id);

                        //返回visit_result_id  为  visit_result_table_.visit_result_id
                        ss_visitTable_ = new ss_visitTable()
                        {
                            illness_id = cur_visit.illness_id,
                            visit_result_id = visit_result_table_.visit_result_id,
                            isSelect = true

                        };

                        //跟新ss_visitTable  visit_result_id、isSelect
                        int row2 = ss_visitTableBll_.update_ss_visitTable(ss_visitTable_);
                        this.Close();
                    }

                }
            }
            
            
           

           
            

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //清空已经选择的数据
            this.txb_drug_allergy.Text = "";
            this.txb_sanity.Text = "";
            this.txb_condition.Text = "";
            this.txb_test_result.Text = "";
        }
    }
}
