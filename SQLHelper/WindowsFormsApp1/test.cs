using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class test : Form
    {
        static int node = 22;
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            init();
            ShortestPathByDijkstra();
        }

        private void init()
        {
            for(int i = 0; i < node; i++)
            {
                for(int j = 0;j < node; j++)
                {
                    graph[i, j] = 10000;  //初始化全为不通
                }
            }
            #region 无向图连通设置
            graph[5, 1] = 1;
            graph[1, 5] = 1;
            graph[1, 2] = 1;
            graph[2, 1] = 1;
            graph[2, 3] = 1;
            graph[3, 2] = 1;
            graph[2, 4] = 1;
            graph[4, 2] = 1;
            graph[4, 0] = 1;
            graph[0, 4] = 1;
            graph[0, 6] = 1;
            graph[6, 0] = 1;
            graph[0, 16] = 10;
            graph[16, 0] = 10;
            graph[6, 7] = 1;
            graph[7, 6] = 1;
            graph[8, 9] = 1;
            graph[9, 8] = 1;
            graph[9, 10] = 1;
            graph[10, 9] = 1;
            graph[9, 20] = 10;
            graph[20, 9] = 10;
            //

            graph[11, 12] = 1;
            graph[12, 11] = 1;
            graph[12, 13] = 1;
            graph[13, 12] = 1;
            graph[13, 14] = 1;
            graph[14, 13] = 1;
            graph[13, 15] = 1;
            graph[15, 13] = 1;
            graph[15, 16] = 1;
            graph[16, 15] = 1;
            graph[16, 17] = 1;
            graph[17, 16] = 1;
            graph[17, 18] = 1;
            graph[18, 17] = 1;
            graph[18, 19] = 1;
            graph[19, 18] = 1;
            graph[19, 20] = 1;
            graph[20, 19] = 1;
            graph[20, 21] = 1;
            graph[21, 20] = 1;
            #endregion 无向图连通设置


            for (int i = 0; i < node; i++)
            {
                S[i] = 0;
                mid[i] = "";
            }
        }

        static int[,] graph = new int[node, node];
        static int[] S = new int[node];//最短路径的顶点集合
        static string[] mid = new string[node];//点的路线


        public static int IsContain(int m)//判断元素是否在mst中
        {
            int index = -1;
            for (int i = 1; i < node; i++)
            {
                if (S[i] == m)
                {
                    index = i;
                }
            }
            return index;
        }

        #region Dijkstrah实现最短路算法
        /// <summary>
        /// Dijkstrah实现最短路算法
        /// </summary>
        static void ShortestPathByDijkstra()
        {
            int min;
            int next;

            for (int f = node-1; f > 0; f--)
            {
                //置为初始值

                min = 1000;
                next = 0;//第一行最小的元素所在的列 next点
                //找出第一行最小的列值
                for (int j = 1; j < node; j++)//循环第0行的列
                {
                    if ((IsContain(j) == -1) && (graph[0, j] < min))//不在S中,找出第一行最小的元素所在的列
                    {
                        min = graph[0, j];
                        next = j;
                    }
                }
                //将下一个点加入S
                S[next] = next;
                //输出最短距离和路径
                if (min == 1000)
                {
                    Console.WriteLine("V0到V{0}的最短路径为：无", next);
                }
                else
                {
                    Console.WriteLine("V0到V{0}的最短路径为：{1},路径为：V0{2}->V{0}", next, min, mid[next]);
                }
                // 重新初始0行所有列值
                for (int j = 1; j < node; j++)//循环第0行的列
                {
                    if (IsContain(j) == -1)//初始化除包含在S中的
                    {
                        if ((graph[next, j] + min) < graph[0, j])//如果小于原来的值就替换
                        {
                            graph[0, j] = graph[next, j] + min;
                            mid[j] = mid[next] + "->V" + next;//记录过程点
                        }
                    }
                }

            }

        }
        #endregion Dijkstrah实现最短路算法







    }





}
