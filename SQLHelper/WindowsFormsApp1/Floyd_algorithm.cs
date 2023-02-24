using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    public class Floyd_algorithm
    {
        Hashtable ht_Floyd  = new Hashtable();//哈希表用于记录Floyd输出结果
        public void star_Floyd()//main（）
        {

            #region  数据结构无向图的点和边的设置
            FloydShortestPath floyd = new FloydShortestPath();
            Vertex vex0 = new Vertex(0);
            Vertex vex1 = new Vertex(1);
            Vertex vex2 = new Vertex(2);
            Vertex vex3 = new Vertex(3);
            Vertex vex4 = new Vertex(4);
            Vertex vex5 = new Vertex(5);
            Vertex vex6 = new Vertex(6);
            Vertex vex7 = new Vertex(7);
            Vertex vex8 = new Vertex(8);
            Vertex vex9 = new Vertex(9);
            Vertex vex10 = new Vertex(10);
            Vertex vex11 = new Vertex(11);
            Vertex vex12 = new Vertex(12);
            Vertex vex13 = new Vertex(13);
            Vertex vex14 = new Vertex(14);
            Vertex vex15 = new Vertex(15);
            Vertex vex16 = new Vertex(16);
            Vertex vex17 = new Vertex(17);
            Vertex vex18 = new Vertex(18);
            Vertex vex19 = new Vertex(19);
            Vertex vex20 = new Vertex(20);
            Vertex vex21 = new Vertex(21);
            












            Vertex[] vex = { vex0, vex1, vex2, vex3, vex4, vex5, vex6, vex7, vex8, vex9, vex10, vex11, vex12, vex13, vex14, vex15, vex16, vex17, vex18, vex19, vex20, vex21 };



            Edge edge0 = new Edge(5, 1, 1);

            Edge edge1 = new Edge(1, 2, 1);

            Edge edge2 = new Edge(2, 3, 1);

            Edge edge3 = new Edge(2, 4, 1);

            Edge edge4 = new Edge(4, 0, 1);

            Edge edge5 = new Edge(0, 6, 1);

            Edge edge6 = new Edge(0, 16, 10);

            Edge edge7 = new Edge(6, 7, 1);

            Edge edge21 = new Edge(7, 8, 1);

            Edge edge8 = new Edge(8, 9, 1);

            Edge edge9 = new Edge(9, 10, 1);

            Edge edge10 = new Edge(9, 20, 10);

            Edge edge11 = new Edge(11, 12, 1);

            Edge edge12 = new Edge(12, 13, 1);

            Edge edge13 = new Edge(13, 14, 1);

            Edge edge14 = new Edge(13, 15, 1);

            Edge edge15 = new Edge(15, 16, 1);

            Edge edge16 = new Edge(16, 17, 1);

            Edge edge17 = new Edge(17, 18, 1);

            Edge edge18 = new Edge(18, 19, 1);

            Edge edge19 = new Edge(19, 20, 1);

            Edge edge20 = new Edge(20, 21, 1);
           



            Edge[] edge = { edge0, edge1, edge2, edge3, edge4, edge5, edge6, edge7, edge8, edge9, edge10, edge11, edge12, edge13, edge14, edge15, edge16, edge17, edge18, edge19, edge20, edge21 };
            #endregion 数据结构无向图的点和边的设置
            //ht_Floyd  = new Hashtable();



            floyd.GraphAdjacencyMatrix(vex, edge);
            ht_Floyd = floyd.Floyd();
            
            Console.WriteLine("---------------测试Hashtable,Keys-------------------");   //√ 
            foreach (string key in ht_Floyd.Keys)
            {
                Console.WriteLine(key);
            }
            //Console.WriteLine("---------------测试Hashtable,Value-------------------");   //√ 
            //foreach (string key in ht_Floyd.Keys)
            //{
            //    weight_path w = (weight_path)ht_Floyd[key];      //把哈希的值（类对象）强制转换
            //    //Console.WriteLine(w.weigth);
            //    List<int> path_list = w.path;
            //    Console.WriteLine("\n");
            //    foreach (int li in path_list) 
            //    {
            //        Console.Write("->" + li);
            //    };
            //}
            

        }
        //函数：根据出发点和目的地 去哈希里查询 返回路径
        public List<int> twoPaint_Floydpath(int paint1, int paint2,out int weigth_)
        {
            Console.WriteLine("---------------测试twoPaint_Floydpath-------------------");
            string paint = (string)(Convert.ToString(paint1) + "," + Convert.ToString(paint2));
            weight_path w = (weight_path)ht_Floyd[paint];      //把哈希的值（类对象）强制转换
            weigth_ = w.weigth;
            Console.WriteLine(w.weigth.ToString());

            //foreach (int li in w.path)
            //{
            //    Console.WriteLine(li);
            //};
            return w.path;
        }
    }

    //类2方便哈希表的操作
    class weight_path
    {
        public int weigth;
        public List<int> path;
        public weight_path(int weigth, List<int> path)
        {
            this.weigth = weigth;
            this.path = path;
        }
        public int get_weigth()
        {
            return weigth;
        }
        public List<int> get_path()
        {
            return path;
        }
        public void output()
        {

        }
    }

    //类
    class Vertex
    {
        public int data;
        public Vertex(int data)
        {
            this.data = data;
        }
    }

    class Edge
    {
        public int tail;
        public int head;
        public int width;
        public Edge(int tail, int head, int width)
        {
            this.tail = tail;
            this.head = head;
            this.width = width;
        }
    }

    class FloydShortestPath
    {
        int[,] matrix;
        int vexCount;
        public void GraphAdjacencyMatrix(Vertex[] vex, Edge[] edge)
        {
            
            matrix = new int[vex.Length, vex.Length];
            for (int i = 0; i < vex.Length; i++)
            {
                for (int j = 0; j < vex.Length; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] = 1000;
                    }
                }
            }
            vexCount = vex.Length;

            for (int i = 0; i < edge.Length; i++)
            {
                int tail = edge[i].tail;
                int head = edge[i].head;
                matrix[tail, head] = edge[i].width;
                matrix[head, tail] = edge[i].width;
            }
            Console.WriteLine("邻接矩阵：");
            Console.Write("\t ");
            for (int i = 0; i < vex.Length; i++)
            {
                Console.Write(vex[i].data + "\t ");
            }
            Console.WriteLine("\n\n");
            for (int i = 0; i < vex.Length; i++)
            {
                Console.Write(vex[i].data + "\t");
                for (int j = 0; j < vex.Length; j++)
                {
                    Console.Write("[" + matrix[i, j] + "]\t");
                }
                Console.WriteLine("\n\n");
            }
        }

        public Hashtable Floyd()
        {
            Hashtable ht_Floyd2 = new Hashtable();   //哈希表智能是局部变量
            //初始化
            int[,] Fmatrix = matrix;
            int[,] Fpath = new int[vexCount, vexCount];//用来存储终点前一个点
            for (int i = 0; i < vexCount; i++)
            {
                for (int j = 0; j < vexCount; j++)
                {
                    Fpath[i, j] = j;
                }
            }
            //核心
            for (int k = 0; k < vexCount; k++)
            {
                for (int i = 0; i < vexCount; i++)
                {
                    for (int j = 0; j < vexCount; j++)
                    {
                        if (Fmatrix[i, j] > Fmatrix[i, k] + Fmatrix[k, j])
                        {
                            Fmatrix[i, j] = Fmatrix[i, k] + Fmatrix[k, j];
                            Fpath[i, j] = Fpath[i, k];//给终点记录前一个点
                        }
                    }
                }
            }
            //打印输出
            for (int i = 0; i < vexCount; i++)
            {
                for (int j = 0; j < vexCount; j++)
                {
                    if (j != i)
                    {
                        Console.Write(i + " -> " + j + " weigth:" + Fmatrix[i, j] + " Path:" + i);
                        //哈希表增加记录
                        string cur_i = i + "," + j;
                        int cur_weigth = Fmatrix[i, j];
                        List<int> cur_path_list = new List<int>();
                        cur_path_list.Add(i);
                        //哈希表增加记录
                        int next = i;
                        while (next != j)
                        {
                            Console.Write(" -> " + Fpath[next, j]);
                            cur_path_list.Add(Fpath[next, j]);                           //
                            next = Fpath[next, j];
                        }
                        ht_Floyd2.Add(cur_i,new weight_path(cur_weigth, cur_path_list));
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
            return ht_Floyd2;
        }
    }
}






