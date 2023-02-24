using BLL;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form_Route : Form
    {
        private int data_index;
        //类似于Create——Meeting2窗体
        ss_visitTableBll ss_visitTableBll_;
        List<cur_ss_visitTable> cur_ss_visitTable_;
        cur_ss_visitTable[] cur_table_list;
        int[] index_args;
        List<int> cur_panl_click_indexList = new List<int>();
        List<string> cur_sickroom_List = new List<string>(); // 全局变量：拿到选择的房间号
        List<int> number_List = new List<int>();            // 全局变量：房间号转换的数字
        List<int> Edge_number_List = new List<int>();            // 全局变量：去边结果列表
        List<int> Back_Edge_number_List = new List<int>();            // 全局变量：回边结果列表

        int table_length;

        Hashtable ht;
        Hashtable re_ht;
        Hashtable ht_edge;
        Hashtable ht_edge22;

        public Form_Route(cur_ss_visitTable[] table_list, List<int> panl_click_indexList)
        {
            InitializeComponent();
            cur_table_list = table_list;
            cur_panl_click_indexList = panl_click_indexList;
            index_args = cur_panl_click_indexList.ToArray();

            #region 两个哈希：房间号——哈希——数字------算法------——数字——哈希——房间号
            ht = new Hashtable();
            ht.Add("A10110", 1);
            ht.Add("A10210", 2);
            ht.Add("A10310", 3);
            ht.Add("A10410", 4);
            ht.Add("A10510", 5);
            ht.Add("A10610", 6);
            ht.Add("A10710", 7);
            ht.Add("A10810", 8);
            ht.Add("A10910", 9);
            ht.Add("A11010", 10);
            ht.Add("A21110", 11);
            ht.Add("A21210", 12);
            ht.Add("A21310", 13);
            ht.Add("A21410", 14);
            ht.Add("A21510", 15);
            ht.Add("A21610", 16);
            ht.Add("A21710", 17);
            ht.Add("A21810", 18);
            ht.Add("A21910", 19);
            ht.Add("A22010", 20);
            ht.Add("A22110", 21);

            re_ht = new Hashtable();
            re_ht.Add(1, "A10110");
            re_ht.Add(3, "A10310");
            re_ht.Add(4, "A10410");
            re_ht.Add(8, "A10810");
            re_ht.Add(9, "A10910");
            re_ht.Add(11, "A21110");
            re_ht.Add(13, "A21310");
            re_ht.Add(16, "A21610");
            re_ht.Add(18, "A21810");
            re_ht.Add(20, "A22010");


            #region 由点确定边的哈希
            ht_edge22 = new Hashtable();   //由点确定边的哈希
            ht_edge22.Add("51", 0);
            ht_edge22.Add("15", 0);
            ht_edge22.Add("12", 1);
            ht_edge22.Add("21", 1);
            ht_edge22.Add("23", 2);
            ht_edge22.Add("32", 2);
            ht_edge22.Add("24", 3);
            ht_edge22.Add("42", 3);
            ht_edge22.Add("40", 4);
            ht_edge22.Add("04", 4);
            ht_edge22.Add("06", 5);
            ht_edge22.Add("60", 5);
            ht_edge22.Add("67", 6);
            ht_edge22.Add("76", 6);
            ht_edge22.Add("78", 7);
            ht_edge22.Add("87", 7);
            ht_edge22.Add("89", 8);
            ht_edge22.Add("98", 8);
            ht_edge22.Add("910", 9);
            ht_edge22.Add("109", 9);
            ht_edge22.Add("920", 10);
            ht_edge22.Add("209", 10);
            ht_edge22.Add("016", 11);
            ht_edge22.Add("160", 11);
            ht_edge22.Add("1112", 12);
            ht_edge22.Add("1211", 12);
            ht_edge22.Add("1213", 13);
            ht_edge22.Add("1312", 13);
            ht_edge22.Add("1314", 14);
            ht_edge22.Add("1413", 14);
            ht_edge22.Add("1315", 15);
            ht_edge22.Add("1513", 15);
            ht_edge22.Add("1516", 16);
            ht_edge22.Add("1615", 16);
            ht_edge22.Add("1617", 17);
            ht_edge22.Add("1716", 17);
            ht_edge22.Add("1718", 18);
            ht_edge22.Add("1817", 018);
            ht_edge22.Add("1819", 19);
            ht_edge22.Add("1918", 19);
            ht_edge22.Add("1920", 20);
            ht_edge22.Add("2019", 20);
            ht_edge22.Add("2021", 21);
            ht_edge22.Add("2120", 21);

            ht_edge22.Add("00", 999);
            ht_edge22.Add("11", 999);
            ht_edge22.Add("22", 999);
            ht_edge22.Add("33", 999);
            ht_edge22.Add("44", 999);
            ht_edge22.Add("55", 999);
            ht_edge22.Add("66", 999);
            ht_edge22.Add("77", 999);
            ht_edge22.Add("88", 999);
            ht_edge22.Add("99", 999);
            ht_edge22.Add("1010", 999);
            ht_edge22.Add("1111", 999);
            ht_edge22.Add("1212", 999);
            ht_edge22.Add("1313", 999);
            ht_edge22.Add("1414", 999);
            ht_edge22.Add("1515", 999);
            ht_edge22.Add("1616", 999);
            ht_edge22.Add("1717", 999);
            ht_edge22.Add("1818", 999);
            ht_edge22.Add("1919", 999);
            ht_edge22.Add("2020", 999);
            ht_edge22.Add("2121", 999);
            ht_edge22.Add("2222", 999);
            ht_edge22.Add("2323", 999);
            #endregion 由点确定边的哈希


            #region 由点确定边的哈希
            ht_edge = new Hashtable();   //由点确定边的哈希
            ht_edge.Add("51", 1000);
            ht_edge.Add("15", 1000);
            ht_edge.Add("12", 1001);
            ht_edge.Add("21", 1001);
            ht_edge.Add("23", 1002);
            ht_edge.Add("32", 1002);
            ht_edge.Add("24", 1003);
            ht_edge.Add("42", 1003);
            ht_edge.Add("40", 1004);
            ht_edge.Add("04", 1004);
            ht_edge.Add("06", 1005);
            ht_edge.Add("60", 1005);
            ht_edge.Add("67", 1006);
            ht_edge.Add("76", 1006);
            ht_edge.Add("78", 1007);
            ht_edge.Add("87", 1007);
            ht_edge.Add("89", 1008);
            ht_edge.Add("98", 1008);
            ht_edge.Add("910", 1009);
            ht_edge.Add("109", 1009);
            ht_edge.Add("920", 10010);
            ht_edge.Add("209", 10010);
            ht_edge.Add("016", 10011);
            ht_edge.Add("160", 10011);
            ht_edge.Add("1112", 10012);
            ht_edge.Add("1211", 10012);
            ht_edge.Add("1213", 10013);
            ht_edge.Add("1312", 10013);
            ht_edge.Add("1314", 10014);
            ht_edge.Add("1413", 10014);
            ht_edge.Add("1315", 10015);
            ht_edge.Add("1513", 10015);
            ht_edge.Add("1516", 10016);
            ht_edge.Add("1615", 10016);
            ht_edge.Add("1617", 10017);
            ht_edge.Add("1716", 10017);
            ht_edge.Add("1718", 10018);
            ht_edge.Add("1817", 10018);
            ht_edge.Add("1819", 10019);
            ht_edge.Add("1918", 10019);
            ht_edge.Add("1920", 10020);
            ht_edge.Add("2019", 10020);
            ht_edge.Add("2021", 10021);
            ht_edge.Add("2120", 10021);

            ht_edge.Add("00", 999);
            ht_edge.Add("11", 999);
            ht_edge.Add("22", 999);
            ht_edge.Add("33", 999);
            ht_edge.Add("44", 999);
            ht_edge.Add("55", 999);
            ht_edge.Add("66", 999);
            ht_edge.Add("77", 999);
            ht_edge.Add("88", 999);
            ht_edge.Add("99", 999);
            ht_edge.Add("1010", 999);
            ht_edge.Add("1111", 999);
            ht_edge.Add("1212", 999);
            ht_edge.Add("1313", 999);
            ht_edge.Add("1414", 999);
            ht_edge.Add("1515", 999);
            ht_edge.Add("1616", 999);
            ht_edge.Add("1717", 999);
            ht_edge.Add("1818", 999);
            ht_edge.Add("1919", 999);
            ht_edge.Add("2020", 999);
            ht_edge.Add("2121", 999);
            ht_edge.Add("2222", 999);
            ht_edge.Add("2323", 999);
            #endregion 由点确定边的哈希
            #endregion 两个哈希：房间号——哈希——数字------算法------——数字——哈希——房间号



        }

        private void Form_Route_Load(object sender, EventArgs e)
        {
            #region label在pictureBox上背景色为null
            this.label27.BackColor = Color.Transparent;
            this.label27.Parent = pictureBox28;
            pictureBox28.Controls.Add(label27);
            #endregion
            Edge_color_Back();
            #region 测试拿到点击的index和table_list[]
            Console.WriteLine("---------------测试Form_Route : Form-------------------");
            // 拿到单击的index列表
            //foreach (int i in cur_panl_click_indexList)
            //{
            //    Console.WriteLine(cur_table_list[i].patient_name.ToString());
            //}
            #endregion 
            table_length = cur_panl_click_indexList.ToArray().Length;
            //患者卡片
            data_card(cur_table_list, table_length);
            // 对拿到选择的房间号转化为数字：
            foreach (string item in cur_sickroom_List)
            {
                number_List.Add((int)ht[item]);
            }
            //列表去重 
            HashSet<int> hs = new HashSet<int>(number_List);
            number_List = hs.ToList();



            //Console.WriteLine("---------------测试Form_Route : Form22-------------------");
            //foreach (int i in number_List)
            //{
            //    Console.WriteLine(i);
            //}
            // 实现推荐路线
            Floyd_algorithm Floyd_algorithm_ = new Floyd_algorithm();                                       //弗洛伊德算法实例
            Floyd_algorithm_.star_Floyd();

            #region 只有一个患者时：√
            if (number_List.ToArray().Length == 1)
            {
                List<int> twoPain_pathList = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[0], out var weigth_);//
                List<int> twoPain_pathList_Back = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], 0, out var weigth_Back);//回来

                Console.WriteLine("---------------测试22-------------------");
                string strArray1 = string.Join("-->", twoPain_pathList);
                string strArray2 = string.Join("-->", twoPain_pathList_Back);
                //去重
                //var twoPain_pathList_dedge = twoPain_pathList.Distinct().ToList();
                //var twoPain_pathList_Back_dedge = twoPain_pathList_Back.Distinct().ToList();

                NewMethod(twoPain_pathList, twoPain_pathList_Back);//////

                this.lab_routeSum1.Text = weigth_.ToString();
                this.txb_route1.Text = strArray1.ToString();
                //回来
                this.lab_routeSum2.Text = weigth_Back.ToString();
                this.txb_route2.Text = strArray2.ToString();
            }
            #endregion 只有一个患者时

            #region 只有两个患者时：√
            if (number_List.ToArray().Length == 2)
            {
                List<int> twoPain_pathList1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[0], out var weigth_1);
                List<int> twoPain_pathList3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], number_List[1], out var weigth_3);
                List<int> twoPain_pathList3_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], 0, out var weigth_Back1);//回来

                List<int> twoPain_pathList2 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[1], out var weigth_2);    //dui
                List<int> twoPain_pathList3_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], number_List[0], out var weigth_3_2);
                List<int> twoPain_pathList3_Back2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], 0, out var weigth_Back2);//回来

                if (weigth_1 <= weigth_2)
                {//选择1
                    string strArray2 = string.Join("-->", twoPain_pathList1);
                    string strArray2_ = string.Join("-->", twoPain_pathList3);
                    string strArray2_1 = string.Join("-->", strArray2, strArray2_);     //字符串连接
                    this.txb_route1.Text = strArray2_1.ToString();
                    this.lab_routeSum1.Text = (weigth_1 + weigth_3).ToString();
                    //回来
                    string strArray_Back1 = string.Join("-->", twoPain_pathList3_Back1);

                    //连接
                    List<int> twoPain_pathList_dedge = twoPain_pathList1.Concat(twoPain_pathList3).ToList<int>(); //保留重复项
                    //var twoPain_pathList_dedge = twoPain_pathList1.Union(twoPain_pathList3).ToList<int>(); //剔除重复项
                    //var twoPain_pathList_Back_dedge = twoPain_pathList3_Back1.Distinct().ToList();
                    NewMethod(twoPain_pathList_dedge, twoPain_pathList3_Back1);




                    this.txb_route2.Text = strArray_Back1.ToString();
                    this.lab_routeSum2.Text = weigth_Back1.ToString();
                }

                else
                {//选择2
                    string strArray2 = string.Join("-->", twoPain_pathList2);
                    string strArray2_ = string.Join("-->", twoPain_pathList3_2);
                    string strArray2_1 = string.Join("-->", strArray2, strArray2_);     //字符串连接
                    this.txb_route1.Text = strArray2_1.ToString();
                    this.lab_routeSum1.Text = (weigth_2 + weigth_3_2).ToString();
                    //回来
                    string strArray_Back1 = string.Join("-->", twoPain_pathList3_Back2);

                    //连接
                    List<int> twoPain_pathList_dedge = twoPain_pathList2.Concat(twoPain_pathList3_2).ToList<int>(); //保留重复项
                    //var twoPain_pathList_dedge = twoPain_pathList2.Union(twoPain_pathList3_2).ToList<int>(); //剔除重复项
                    //var twoPain_pathList_Back_dedge = twoPain_pathList3_Back2.Distinct().ToList();
                    NewMethod(twoPain_pathList_dedge, twoPain_pathList3_Back2);


                    this.txb_route2.Text = strArray_Back1.ToString();
                    this.lab_routeSum2.Text = weigth_Back2.ToString();

                }

                //Console.WriteLine(number_List[0]);
                //Console.WriteLine("---------------测试22-------------------");
                //string strArray = string.Join("-->", twoPain_pathList);
                //txb_route1.Text = strArray.ToString();
            }
            #endregion 只有两个患者时

            #region 只有三个患者时：√
            if (number_List.ToArray().Length == 3)
            {
                List<int> twoPain_pathList1_1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[0], out var weigth_11);
                List<int> twoPain_pathList1_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], number_List[1], out var weigth_12);
                List<int> twoPain_pathList1_3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], number_List[2], out var weigth_13);
                List<int> twoPain_pathList1_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[2], 0, out var weigth_Back11);//回来

                //List<int> twoPain_pathList1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[0], out var weigth_11);
                List<int> twoPain_pathList2_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], number_List[2], out var weigth_22);
                List<int> twoPain_pathList2_3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[2], number_List[1], out var weigth_23);
                List<int> twoPain_pathList2_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], 0, out var weigth_Back21);//回来

                List<int> twoPain_pathList3_1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[1], out var weigth_31);
                List<int> twoPain_pathList3_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], number_List[0], out var weigth_32);
                List<int> twoPain_pathList3_3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], number_List[2], out var weigth_33);
                List<int> twoPain_pathList3_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[2], 0, out var weigth_Back31);//回来

                //List<int> twoPain_pathList3_1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[1], out var weigth_31);
                List<int> twoPain_pathList4_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], number_List[2], out var weigth_42);
                List<int> twoPain_pathList4_3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[2], number_List[0], out var weigth_43);
                List<int> twoPain_pathList4_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], 0, out var weigth_Back41);//回来

                List<int> twoPain_pathList5_1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[2], out var weigth_51);
                List<int> twoPain_pathList5_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[2], number_List[0], out var weigth_52);
                List<int> twoPain_pathList5_3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], number_List[1], out var weigth_53);
                List<int> twoPain_pathList5_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], 0, out var weigth_Back51);//回来

                //List<int> twoPain_pathList5_1 = Floyd_algorithm_.twoPaint_Floydpath(0, number_List[2], out var weigth_51);
                List<int> twoPain_pathList6_2 = Floyd_algorithm_.twoPaint_Floydpath(number_List[2], number_List[1], out var weigth_62);
                List<int> twoPain_pathList6_3 = Floyd_algorithm_.twoPaint_Floydpath(number_List[1], number_List[0], out var weigth_63);
                List<int> twoPain_pathList6_Back1 = Floyd_algorithm_.twoPaint_Floydpath(number_List[0], 0, out var weigth_Back61);//回来

                int Is_min1 = weigth_11 + weigth_12 + weigth_13 + weigth_Back11;
                int Is_min2 = weigth_11 + weigth_22 + weigth_23 + weigth_Back21;
                int Is_min3 = weigth_31 + weigth_32 + weigth_33 + weigth_Back31;
                int Is_min4 = weigth_31 + weigth_42 + weigth_43 + weigth_Back41;
                int Is_min5 = weigth_51 + weigth_52 + weigth_53 + weigth_Back51;
                int Is_min6 = weigth_51 + weigth_62 + weigth_63 + weigth_Back61;
                List<int> get_minList = new List<int>();
                get_minList.Add(Is_min1);
                get_minList.Add(Is_min2);
                get_minList.Add(Is_min3);
                get_minList.Add(Is_min4);
                get_minList.Add(Is_min5);
                get_minList.Add(Is_min6);
                var minValue = get_minList.Min();   //六个最小(加了回0的最小)


                if (Is_min1 == minValue)
                {
                    //选择1
                    string strArray1_1 = string.Join("-->", twoPain_pathList1_1);
                    string strArray1_2 = string.Join("-->", twoPain_pathList1_2);
                    string strArray1_3 = string.Join("-->", twoPain_pathList1_3);
                    string str1 = $"{strArray1_1} --> {strArray1_2}-->{strArray1_3}";       //字符串连接

                    this.txb_route1.Text = str1.ToString();
                    this.lab_routeSum1.Text = (Is_min1).ToString();

                    //回来
                    string strArray_Back1 = string.Join("-->", twoPain_pathList1_Back1);

                    // 连接
                    List<int> kk = twoPain_pathList1_1.Concat(twoPain_pathList1_2).ToList<int>(); //保留重复项                  
                    List<int> twoPain_pathList_dedge = kk.Concat(twoPain_pathList1_3).ToList<int>(); //保留重复项

                    NewMethod(twoPain_pathList_dedge, twoPain_pathList1_Back1);

                    this.txb_route2.Text = strArray_Back1.ToString();
                    this.lab_routeSum2.Text = weigth_Back11.ToString();
                }
                else if (Is_min2 == minValue)
                {
                    //选择2
                    string strArray1_1 = string.Join("-->", twoPain_pathList1_1);
                    string strArray2_2 = string.Join("-->", twoPain_pathList2_2);
                    string strArray2_3 = string.Join("-->", twoPain_pathList2_3);
                    string str2 = $"{strArray1_1} --> {strArray2_2}-->{strArray2_3}";       //字符串连接

                    this.txb_route1.Text = str2.ToString();
                    this.lab_routeSum1.Text = (Is_min2).ToString();
                    //回来
                    string strArray_Back2 = string.Join("-->", twoPain_pathList2_Back1);

                    // 连接
                    List<int> kk = twoPain_pathList1_1.Concat(twoPain_pathList2_2).ToList<int>(); //保留重复项                  
                    List<int> twoPain_pathList_dedge = kk.Concat(twoPain_pathList2_3).ToList<int>(); //保留重复项

                    NewMethod(twoPain_pathList_dedge, twoPain_pathList2_Back1);

                    this.txb_route2.Text = strArray_Back2.ToString();
                    this.lab_routeSum2.Text = weigth_Back21.ToString();
                }
                else if (Is_min3 == minValue)
                {
                    //选择3
                    string strArray3_1 = string.Join("-->", twoPain_pathList3_1);
                    string strArray3_2 = string.Join("-->", twoPain_pathList3_2);
                    string strArray3_3 = string.Join("-->", twoPain_pathList3_3);
                    string str3 = $"{strArray3_1} --> {strArray3_2}-->{strArray3_3}";       //字符串连接

                    this.txb_route1.Text = str3.ToString();
                    this.lab_routeSum1.Text = (Is_min3).ToString();
                    //回来
                    string strArray_Back3 = string.Join("-->", twoPain_pathList3_Back1);

                    // 连接
                    List<int> kk = twoPain_pathList3_1.Concat(twoPain_pathList3_2).ToList<int>(); //保留重复项                  
                    List<int> twoPain_pathList_dedge = kk.Concat(twoPain_pathList3_3).ToList<int>(); //保留重复项

                    NewMethod(twoPain_pathList_dedge, twoPain_pathList3_Back1);

                    this.txb_route2.Text = strArray_Back3.ToString();
                    this.lab_routeSum2.Text = weigth_Back31.ToString();
                }
                else if (Is_min4 == minValue)                               /////
                {
                    //选择4
                    string strArray3_1 = string.Join("-->", twoPain_pathList3_1);
                    string strArray4_2 = string.Join("-->", twoPain_pathList4_2);
                    string strArray4_3 = string.Join("-->", twoPain_pathList4_3);
                    string str4 = $"{strArray3_1} --> {strArray4_2}-->{strArray4_3}";       //字符串连接

                    this.txb_route1.Text = str4.ToString();
                    this.lab_routeSum1.Text = (Is_min4).ToString();
                    //回来
                    string strArray_Back4 = string.Join("-->", twoPain_pathList4_Back1);

                    // 连接
                    List<int> kk = twoPain_pathList3_1.Concat(twoPain_pathList4_2).ToList<int>(); //保留重复项                  
                    List<int> twoPain_pathList_dedge = kk.Concat(twoPain_pathList4_3).ToList<int>(); //保留重复项

                    NewMethod(twoPain_pathList_dedge, twoPain_pathList4_Back1);

                    this.txb_route2.Text = strArray_Back4.ToString();
                    this.lab_routeSum2.Text = weigth_Back41.ToString();
                }
                else if (Is_min5 == minValue)
                {
                    //选择5
                    string strArray5_1 = string.Join("-->", twoPain_pathList5_1);
                    string strArray5_2 = string.Join("-->", twoPain_pathList5_2);
                    string strArray5_3 = string.Join("-->", twoPain_pathList5_3);
                    string str5 = $"{strArray5_1} --> {strArray5_2}-->{strArray5_3}";       //字符串连接

                    this.txb_route1.Text = str5.ToString();
                    this.lab_routeSum1.Text = (Is_min5).ToString();
                    //回来
                    string strArray_Back5 = string.Join("-->", twoPain_pathList5_Back1);


                    // 连接
                    List<int> kk = twoPain_pathList5_1.Concat(twoPain_pathList5_2).ToList<int>(); //保留重复项                  
                    List<int> twoPain_pathList_dedge = kk.Concat(twoPain_pathList5_3).ToList<int>(); //保留重复项

                    NewMethod(twoPain_pathList_dedge, twoPain_pathList5_Back1);

                    this.txb_route2.Text = strArray_Back5.ToString();
                    this.lab_routeSum2.Text = weigth_Back51.ToString();
                }
                else if (Is_min6 == minValue)
                {
                    //选择6
                    string strArray5_1 = string.Join("-->", twoPain_pathList5_1);
                    string strArray6_2 = string.Join("-->", twoPain_pathList6_2);
                    string strArray6_3 = string.Join("-->", twoPain_pathList6_3);
                    string str6 = $"{strArray5_1} --> {strArray6_2}-->{strArray6_3}";       //字符串连接

                    this.txb_route1.Text = str6.ToString();
                    this.lab_routeSum1.Text = (Is_min6).ToString();
                    //回来
                    string strArray_Back6 = string.Join("-->", twoPain_pathList6_Back1);


                    // 连接
                    List<int> kk = twoPain_pathList5_1.Concat(twoPain_pathList6_2).ToList<int>(); //保留重复项                  
                    List<int> twoPain_pathList_dedge = kk.Concat(twoPain_pathList6_3).ToList<int>(); //保留重复项

                    NewMethod(twoPain_pathList_dedge, twoPain_pathList6_Back1);

                    this.txb_route2.Text = strArray_Back6.ToString();
                    this.lab_routeSum2.Text = weigth_Back61.ToString();
                }

            }
            #endregion 只有三个患者时






        }

        private void NewMethod(List<int> twoPain_pathList_dedge, List<int> twoPain_pathList_Back_dedge)
        {
            //列表转化为数组
            int[] twoPain_path_Args = twoPain_pathList_dedge.ToArray();
            int[] twoPain_path_Back_Args = twoPain_pathList_Back_dedge.ToArray();
            //那两点找边
            for (int i = 0; i + 1 < twoPain_path_Args.Length; i++)
            {

                string ConcatMystr = string.Concat(twoPain_path_Args[i], twoPain_path_Args[i + 1]);
                //Edge_number_List.Add((int)ht_edge[ConcatMystr]);
                Edge_number_List.Add((int)ht_edge22[ConcatMystr]);
            }
            for (int i = 0; i + 1 < twoPain_path_Back_Args.Length; i++)
            {

                string ConcatMystr = string.Concat(twoPain_path_Back_Args[i], twoPain_path_Back_Args[i + 1]);
                Back_Edge_number_List.Add((int)ht_edge[ConcatMystr]);
            }
            data_card22(Edge_number_List);
            data_card22(Back_Edge_number_List);
        }

        private void data_card(cur_ss_visitTable[] table_list, int table_length)
        {

            //i 绑定数据库的表数据的索引

            for (int i = 0; i < table_length;)
            {


                int j = 0;                                                                           //j 用于记录8个panel框的哪一个
                //int x = this.Controls.Count;                                                      // this.Controls.Count; 改控件的子控件，计数

                for (int _ = this.Controls.Count - 1; _ >= 0; _--)                                  // 循环this窗体的索引子控件
                {
                    Control panel_cc = this.Controls[_];

                    if (panel_cc is Panel && panel_cc.Controls.Count > 2)
                    {
                        // int x = this.Controls.GetChildIndex(panel_cc);

                        panel_cc.Controls[4].Text = table_list[index_args[i]].narcosis_time.ToString(); //
                        panel_cc.Controls[5].Text = table_list[index_args[i]].patient_name.ToString();   // 
                        panel_cc.Controls[6].Text = table_list[index_args[i]].sickroom.ToString(); //
                        cur_sickroom_List.Add(panel_cc.Controls[6].Text);
                        panel_cc.Controls[7].Text = table_list[index_args[i]].operation_name.ToString();
                        i++;
                        j++;
                        data_index++;
                        if (i >= table_length || j > 2)                                             // 数据显示完，或者框体超过4
                        {
                            j = this.Controls.GetChildIndex(panel_cc);                              // 
                            break;
                        }
                    }

                }



                //#region 窗体显示
                //if (whether_left_click == true)
                //{
                //    for (int _ = 0; _ < this.Controls.Count; _++)
                //    {
                //        if (this.Controls[_] is Panel)
                //        {
                //            this.Controls[_].Show();

                //        }
                //    }
                //    whether_left_click = false;
                //}
                //#endregion 窗体显示


                #region 窗体隐藏
                for (int _ = 0; _ < this.Controls.Count && _ < j; _++)
                {
                    Control panel_cc = this.Controls[_];
                    if (panel_cc is Panel && panel_cc.Controls.Count == 8)
                    {
                        this.Controls[_].Hide();

                    }
                }
                break;
                #endregion 窗体隐藏


            }
        }




        private void data_card22(List<int> Edge_number_List22)
        {
            //Edge_color_Back();
            foreach (int index_i in Edge_number_List22)
            {
                if (index_i == 0) { this.e0.BackColor = Color.FromArgb(255, 255, 255); }  //qu 
                if (index_i == 1000) { this.e0_.BackColor = Color.FromArgb(229, 133, 31); }  //hui
                if (index_i == 1) { this.e1.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1001) { this.e1_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 2) { this.e2.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1002) { this.e2_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 3) { this.e3.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1003) { this.e3_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 4) { this.e4.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1004) { this.e4_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 5) { this.e5.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1005) { this.e5_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 6) { this.e6.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1006) { this.e6_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 7) { this.e7.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1007) { this.e7_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 8) { this.e8.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1008) { this.e8_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 9) { this.e9.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 1009) { this.e9_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 10) { this.e10.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10010) { this.e10_.BackColor = Color.FromArgb(229, 133, 31); }

                if (index_i == 11) { this.e11.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10011) { this.e11_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 12) { this.e12.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10012) { this.e12_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 13) { this.e13.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10013) { this.e13_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 14) { this.e14.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10014) { this.e14_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 15) { this.e15.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10015) { this.e15_.BackColor = Color.FromArgb(229, 133, 31); }

                if (index_i == 16) { this.e16.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10016) { this.e16_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 17) { this.e17.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10017) { this.e17_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 18) { this.e18.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10018) { this.e18_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 19) { this.e19.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10019) { this.e19_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 20) { this.e20.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10020) { this.e20_.BackColor = Color.FromArgb(229, 133, 31); }
                if (index_i == 21) { this.e21.BackColor = Color.FromArgb(255, 255, 255); }
                if (index_i == 10021) { this.e21_.BackColor = Color.FromArgb(229, 133, 31); }
            }
        }
        /// <summary>
        /// 边恢复
        /// </summary>
        private void Edge_color_Back()
        {
            this.e0.BackColor = Color.FromArgb(152, 119, 198);
            this.e0_.BackColor = Color.FromArgb(152, 119, 198);
            this.e1.BackColor = Color.FromArgb(152, 119, 198);
            this.e1_.BackColor = Color.FromArgb(152, 119, 198);
            this.e2.BackColor = Color.FromArgb(152, 119, 198);
            this.e2_.BackColor = Color.FromArgb(152, 119, 198);
            this.e3.BackColor = Color.FromArgb(152, 119, 198);
            this.e3_.BackColor = Color.FromArgb(152, 119, 198);
            this.e4.BackColor = Color.FromArgb(152, 119, 198);
            this.e4_.BackColor = Color.FromArgb(152, 119, 198);
            this.e5.BackColor = Color.FromArgb(152, 119, 198);
            this.e5_.BackColor = Color.FromArgb(152, 119, 198);

            this.e6.BackColor = Color.FromArgb(152, 119, 198);
            this.e6_.BackColor = Color.FromArgb(152, 119, 198);
            this.e7.BackColor = Color.FromArgb(152, 119, 198);
            this.e7_.BackColor = Color.FromArgb(152, 119, 198);
            this.e8.BackColor = Color.FromArgb(152, 119, 198);
            this.e8_.BackColor = Color.FromArgb(152, 119, 198);
            this.e9.BackColor = Color.FromArgb(152, 119, 198);
            this.e9_.BackColor = Color.FromArgb(152, 119, 198);
            this.e10.BackColor = Color.FromArgb(152, 119, 198);
            this.e10_.BackColor = Color.FromArgb(152, 119, 198);
            this.e11.BackColor = Color.FromArgb(152, 119, 198);
            this.e11_.BackColor = Color.FromArgb(152, 119, 198);

            this.e12.BackColor = Color.FromArgb(152, 119, 198);
            this.e12_.BackColor = Color.FromArgb(152, 119, 198);
            this.e13.BackColor = Color.FromArgb(152, 119, 198);
            this.e13_.BackColor = Color.FromArgb(152, 119, 198);
            this.e14.BackColor = Color.FromArgb(152, 119, 198);
            this.e14_.BackColor = Color.FromArgb(152, 119, 198);
            this.e15.BackColor = Color.FromArgb(152, 119, 198);
            this.e15_.BackColor = Color.FromArgb(152, 119, 198);
            this.e16.BackColor = Color.FromArgb(152, 119, 198);
            this.e16_.BackColor = Color.FromArgb(152, 119, 198);
            this.e17.BackColor = Color.FromArgb(152, 119, 198);
            this.e17_.BackColor = Color.FromArgb(152, 119, 198);

            this.e18.BackColor = Color.FromArgb(152, 119, 198);
            this.e18_.BackColor = Color.FromArgb(152, 119, 198);
            this.e19.BackColor = Color.FromArgb(152, 119, 198);
            this.e19_.BackColor = Color.FromArgb(152, 119, 198);
            this.e20.BackColor = Color.FromArgb(152, 119, 198);
            this.e20_.BackColor = Color.FromArgb(152, 119, 198);
            this.e21.BackColor = Color.FromArgb(152, 119, 198);
            this.e21_.BackColor = Color.FromArgb(152, 119, 198);


        }
        private void txbmessage_TextChanged(object sender, EventArgs e)
        {



        }
        #region 双向Map：TreeBidiMap —— 实现key和value的互相读取

        #endregion 双向Map：TreeBidiMap —— 实现key和value的互相读取

        private void txb_route2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
