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
    public partial class Form_arrage1 : Form
    {
        List<int> nurse_table_idList = new List<int>();
        int nurse_table_idList_length;
        List<int> narcosis_docTable_idList = new List<int>();
        int narcosis_docTable_idList_length;
        List<string> operation_roomList = new List<string>();
        IDictionary<string, int> operation_room_dic = new Dictionary<string, int>();
        Dictionary<int, int> ListToDictionary_nurseId;
        Dictionary<int, int> ListToDictionary_narcosisId;
        int operation_room_dic_length;
        //numberNames.Add(1,"One"); //使用Add()方法添加键/值
        //numberNames.Add(2,"Two");
        //numberNames.Add(3,"Three");
        int curTable_length;            //记录显示表的长度
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        nurse_tableBll nurse_tableBll_ = new nurse_tableBll();
        narcosis_docTableBll narcosis_docTableBll_ = new narcosis_docTableBll();
        List<cur_patient_table> cur_patient_table_22;   //全局对象列表 用于记录当前显示的行对象
        public Form_arrage1()
        {
            InitializeComponent();
        }

        private void Form_arrage1_Load(object sender, EventArgs e)
        {
            start_dgv();
            #region 初始化手术台
            operation_roomList.Add("A1");
            operation_roomList.Add("A2");
            operation_roomList.Add("A3");
            operation_roomList.Add("A4");
            operation_roomList.Add("A5");
            //获取字典的长度——》没空写所以取巧……
            operation_room_dic.Add("A1",1);
            operation_room_dic.Add("A2", 1);
            operation_room_dic.Add("A3", 1);
            operation_room_dic.Add("A4", 1);
            operation_room_dic.Add("A5", 1);
            //获取字典的长度——》没空写所以取巧……
            operation_room_dic_length = operation_roomList.ToArray().Length;
            #endregion 初始化手术台

            List<nurse_table> nurse_table_list =  nurse_tableBll_.GetNurse_tableList1();
            List<narcosis_docTable> narcosis_docTable_ = narcosis_docTableBll_.GetNarcosis_docTableList1();
            nurse_table_idList_length = nurse_table_list.ToArray().Length;
            narcosis_docTable_idList_length = narcosis_docTable_.ToArray().Length;
            //Console.WriteLine("长度：    ok" + nurse_table_idList_length);          //检验正确
            //Console.WriteLine("长度：    ok" + narcosis_docTable_idList_length);

            foreach (var li in nurse_table_list)
            {
                nurse_table_idList.Add(li.nurse_id);
            }           
            foreach (var li in narcosis_docTable_)
            {
                narcosis_docTable_idList.Add(li.narcosis_doc_id);
            }

            ListToDictionary_nurseId = nurse_table_idList.ToDictionary(key => key, value => value = 1);
            ListToDictionary_narcosisId = narcosis_docTable_idList.ToDictionary(key => key, value => value = 1);
            

            //foreach (var li in ListToDictionary_nurseId)    //检验正确
            //{
            //    Console.WriteLine("key" + li.Key + "  Value:" + li.Value);
            //}
            //foreach (var li in nurse_table_idList)    //检验正确
            //{
            //    Console.WriteLine(li);
            //}
            //foreach (var li in narcosis_docTable_idList)    //检验正确
            //{
            //    Console.WriteLine(li);
            //}

        }
        private void start_dgv()
        {
            


            #region 绑定n表数据
            // 初始化绑定notice_table表数据
            this.dgvss_visit.AutoGenerateColumns = false;  //控制DataGriView只显示需要的列
            // this.dgvss_visit.DataSource = ss_visitTableBll_.GetSs_visitTableList(); //方法一
            List<cur_patient_table> cur_patient_table_ = patient_tableBll_.GetPatient_tableList2();
            //curTable_length = cur_patient_table_.ToArray().Length;
            cur_patient_table_22 = cur_patient_table_.FindAll(m => m.Isinput == true);
            curTable_length = cur_patient_table_22.ToArray().Length;
            this.dgvss_visit.DataSource = cur_patient_table_22;   // 这里只选择写过的
               
                                                                                                                                                                                                              
                                                                                                                          
            #endregion 绑定notice_table表数据
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int nurse_table_id_;
            int narcosis_docTableId_;
            string operation_room_;
            Random Random_nurse_table_id = new Random();
            Random Random_narcosis_docTable = new Random();
            Random Random_operation_room_dic = new Random();
            int j_1;
            int j_2;
            int j_3;
            int max = 100; //每个医师不能超过多少次                              
            int ss1;
            int ss2;
            int ss3;
            int row = 0;  //记录更新的行数
            int j = 0;  //记录有多少次不成功的
            bool result = true;
            //j_2 = Random_narcosis_docTable.Next(0, narcosis_docTable_idList_length);
            //Console.WriteLine("-----------------------------------ok");
            //narcosis_docTableId_ = narcosis_docTable_idList[j_2];
            //Console.WriteLine("-列表 :"+ narcosis_docTableId_);

            //Console.WriteLine("-字典1 :" + ListToDictionary_narcosisId[narcosis_docTableId_]);
            //ListToDictionary_narcosisId[narcosis_docTableId_] += 1;
            //int ss = ListToDictionary_narcosisId[narcosis_docTableId_];
            //Console.WriteLine("-字典2 :" + ss);
            //foreach (var li in ListToDictionary_narcosisId)    //检验正确
            //{
            //    Console.WriteLine("key" + li.Key + "  Value:" + li.Value);
            //}
            for (int i = 0; i < curTable_length; i++)
            {
                //产生随机数
                while (result == true)
                {
                    j_1 = Random_nurse_table_id.Next(0, nurse_table_idList_length);
                    j_2 = Random_narcosis_docTable.Next(0, narcosis_docTable_idList_length);
                    j_3 = Random_operation_room_dic.Next(0, operation_room_dic_length);

                    narcosis_docTableId_ = narcosis_docTable_idList[j_2];
                    nurse_table_id_ = nurse_table_idList[j_1];
                    operation_room_ = operation_roomList[j_3];
                    //判断如果是一个对象的三个随机就不charu
                    //三字段的插入
                    patient_table patient_table_ = new patient_table()
                    {
                        illness_id = cur_patient_table_22[i].illness_id,
                        narcosis_doc_id = narcosis_docTableId_,
                        nurse_id = nurse_table_id_,
                        operation_room = operation_room_
                    };
                    ss1 = ListToDictionary_narcosisId[narcosis_docTableId_];
                    ss2 = ListToDictionary_nurseId[nurse_table_id_];
                    //ss3 =
                    row = 0;
                    if (ss1 <= max && ss2 <= max)
                    {
                        row = patient_tableBll_.update_patient_table2(patient_table_);
                        if (row == 1)
                        {// 更新成功 对应的Value++更改Value值
                            ListToDictionary_narcosisId[narcosis_docTableId_] += 1;
                            ListToDictionary_nurseId[nurse_table_id_] += 1;
                            operation_room_dic[operation_room_] += 1;
                        }
                        break;
                    }
                    else { result = true; }
                    
                    // ……
                }



            }
            //已经随机分配成功，
            //分配完再显示
            start_dgv();
            foreach (var li in ListToDictionary_narcosisId)    //检验正确
            {
                Console.WriteLine("key" + li.Key + "  Value:" + li.Value);
            }
        }

        private void dgvss_visit_DoubleClick(object sender, EventArgs e)
        {
            var visit = this.dgvss_visit.CurrentRow.DataBoundItem as cur_patient_table;
            MessageBox.Show(string.Format("成功{0}", visit.illness_id));
            Form_arrage2 Form_arrage2_ = new Form_arrage2(visit);

            Form_arrage2_.ShowDialog();
            start_dgv();


            //右键按钮，回退功能没写：就是把这条记录删除，连通其他的表的记录也删除；恢复到没有申请的时候......
        }
    }
}
