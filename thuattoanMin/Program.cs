using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
//using COMExcel = Microsoft.Office.Core;

namespace Kruskal
{
    public struct EdgeList
    {
        public double begin_node, end_node, weight;
    }

    class Program
    {
        static int soDinhDocLap = 0;
        static int demlap = 0;
        static int dinhLonNhat, bacDinhLonNhat;
        static int[] Bac, DanhDauDinh;
        static int dem = 0;
        static int diemCuoi;
        public static double vertexNumber, edgeNumber;
        public static string Line;
        public static double temp;
        public static EdgeList[] graph, outPutGraph;
        public static void Print(EdgeList[] A)
        {
            for (int i = 0; i < edgeNumber; i++)
            {
                Console.Write(A[i].begin_node + " " + A[i].end_node + " " + A[i].weight);
                Console.Write("\n");
            }
        }
        public static void OutputGraph(EdgeList[] A)
        {
            string listA = null;

            using (StreamWriter sw = new StreamWriter("OutputGraph1.txt"))
            {
                listA = Convert.ToString(vertexNumber);
                sw.WriteLine(listA);
                listA = Convert.ToString(edgeNumber);
                sw.WriteLine(listA);
                for (int i = 0; i < edgeNumber; i++)
                {
                    listA = A[i].begin_node + " " + A[i].end_node;// + " " + A[i].begin_node + A[i].end_node;
                    sw.WriteLine(listA);


                }
            }
        }
        public static void OutputGraph2(EdgeList[] A)
        {
            string listA = null;

            using (StreamWriter sw = new StreamWriter("OutputGraph2.txt"))
            {
                listA = Convert.ToString(vertexNumber);
                sw.WriteLine(listA);
                listA = Convert.ToString(edgeNumber);
                sw.WriteLine(listA);
                for (int i = 0; i < edgeNumber; i++)
                {
                    listA = A[i].begin_node + " " + A[i].end_node + " " + A[i].weight;
                    sw.WriteLine(listA);


                }
            }
        }
        public static void Output(int[] A)
        {
            string listA = null;
            for (int i = 0; i < vertexNumber; i++)
            {
                if (A[i] == 0)
                {
                    soDinhDocLap = soDinhDocLap + 1;
                }
            }
            using (StreamWriter sw = new StreamWriter("Output.txt"))
            {
                listA = "So Dinh Trong Tap Doc Lap: " + soDinhDocLap + "\n";
                sw.WriteLine(listA);
                listA = "# Directed graph (each unordered pair of nodes is saved once): Slashdot0902.txt\n# Slashdot Zoo social network from February 0 2009\n# Nodes: 82168 Edges: 948464";


                sw.WriteLine(listA);
                for (int i = 0; i < vertexNumber; i++)
                {

                    if (A[i] == 0)
                    {
                        listA = i + "\n";
                        sw.WriteLine(listA);
                    }
                }
            }
        }
        public static void InputGraph(string A)
        {

            using (StreamReader sr = new StreamReader(A))
            {
                Line = sr.ReadLine();
                vertexNumber = Convert.ToDouble(Line);
                Line = sr.ReadLine();
                edgeNumber = Convert.ToDouble(Line);
                graph = new EdgeList[Convert.ToInt64(edgeNumber)];
                outPutGraph = new EdgeList[Convert.ToInt64(edgeNumber)];
                for (int i = 0; i < edgeNumber; i++)
                {
                    string chuoi_dau = sr.ReadLine();
                    string[] chuoi_tach = chuoi_dau.Split(new char[] { '	' });
                    string chuoi_ketqua = "";
                    foreach (string s in chuoi_tach)
                    {

                        if (s.Trim() != "")
                            chuoi_ketqua = chuoi_ketqua + s + " ";
                    }
                    //Console.WriteLine(chuoi_ketqua);
                    string[] strS = chuoi_ketqua.Split(' ');
                    graph[i].begin_node = Convert.ToDouble(strS[0]);
                    graph[i].end_node = Convert.ToDouble(strS[1]);
                    if (graph[i].begin_node > graph[i].end_node)
                    {

                        temp = graph[i].begin_node;
                        graph[i].begin_node = graph[i].end_node;
                        graph[i].end_node = temp;

                    }
                    graph[i].weight = 1;
                }
            }
        }
        public static void InputGraph2(string A)
        {

            using (StreamReader sr = new StreamReader(A))
            {
                Line = sr.ReadLine();
                vertexNumber = Convert.ToDouble(Line);
                Line = sr.ReadLine();
                edgeNumber = Convert.ToDouble(Line);
                graph = new EdgeList[Convert.ToInt64(edgeNumber)];
                outPutGraph = new EdgeList[Convert.ToInt64(edgeNumber)];
                for (int i = 0; i < edgeNumber; i++)
                {
                    string chuoi_dau = sr.ReadLine();
                    string[] chuoi_tach = chuoi_dau.Split(new char[] { '	' });
                    string chuoi_ketqua = "";
                    foreach (string s in chuoi_tach)
                    {

                        if (s.Trim() != "")
                            chuoi_ketqua = chuoi_ketqua + s + " ";
                    }
                    //Console.WriteLine(chuoi_ketqua);
                    string[] strS = chuoi_ketqua.Split(' ');
                    graph[i].begin_node = Convert.ToDouble(strS[0]);
                    graph[i].end_node = Convert.ToDouble(strS[1]);
                    if (graph[i].begin_node > graph[i].end_node)
                    {

                        temp = graph[i].begin_node;
                        graph[i].begin_node = graph[i].end_node;
                        graph[i].end_node = temp;
                    }
                    graph[i].weight = 1;//Convert.ToDouble(strS[2]);
                }
            }
        }
        public static void QuickSort(EdgeList[] A, int dau, int cuoi)
        {
            if (dau >= cuoi) { return; }

            double chot = A[cuoi].begin_node;
            int i = dau;
            int j = cuoi;
            do
            {
                while (A[i].begin_node < chot)
                {
                    i++;
                }
                while (A[j].begin_node > chot)
                {
                    j--;
                }
                if (i <= j)
                {
                    if (i < j)
                    {
                        EdgeList temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                    i++;
                    j--;
                }
            } while (i < j);


            QuickSort(A, dau, j);
            QuickSort(A, i, cuoi);


        }  //Sap xep cac canh theo thu tu begin_node tang dan
        public static void QuickSort2(EdgeList[] A, int dau, int cuoi)
        {
            if (dau >= cuoi) { return; }

            double chot = A[cuoi].weight;
            int i = dau;
            int j = cuoi;
            do
            {
                while (A[i].weight < chot)
                {
                    i++;
                }
                while (A[j].weight > chot)
                {
                    j--;
                }
                if (i <= j)
                {
                    if (i < j)
                    {
                        EdgeList temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                    i++;
                    j--;
                }
            } while (i < j);


            QuickSort2(A, dau, j);
            QuickSort2(A, i, cuoi);


        }  //Sap xep cac canh theo thu tu begin_node tang dan
        public static void QuickSort3(EdgeList[] A, int dau, int cuoi)
        {
            if (dau >= cuoi) { return; }

            double chot = A[cuoi].end_node;
            int i = dau;
            int j = cuoi;
            do
            {
                while (A[i].end_node < chot)
                {
                    i++;
                }
                while (A[j].end_node > chot)
                {
                    j--;
                }
                if (i <= j)
                {
                    if (i < j)
                    {
                        EdgeList temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                    i++;
                    j--;
                }
            } while (i < j);


            QuickSort3(A, dau, j);
            QuickSort3(A, i, cuoi);


        }  //Sap xep cac canh theo thu tu begin_node tang dan
        public static void TinhBac(EdgeList[] A, int[] B)
        {
            dinhLonNhat = -1;
            bacDinhLonNhat = 0;
            for (int i = 0; i < vertexNumber; i++)
            {
                if (B[i]== -1)
                {
                    B[i] = -1;
                }
                else
                {
                    B[i] = 0;
                }
            }

            
            if(A[0].weight > 0&&A[0].begin_node != A[0].end_node)
            {

                B[Convert.ToInt32(A[0].begin_node)] = 1;
                B[Convert.ToInt32(A[0].end_node)] = 1;

            }
            for (int i = 1; i< edgeNumber; i++)
            {
                if ((((A[i].begin_node != A[i-1].begin_node)&&A[i].begin_node != A[i].end_node) || (A[i].end_node != A[i - 1].end_node))&&A[i].weight > 0)
                {
                    B[Convert.ToInt32(A[i].begin_node)] = B[Convert.ToInt32(A[i].begin_node)] + 1;
                    B[Convert.ToInt32(A[i].end_node)] = B[Convert.ToInt32(A[i].end_node)] + 1;
                }
            }

            for (int i = 0; i < vertexNumber; i++)
            {
                if (B[i] > bacDinhLonNhat)
                {
                    dinhLonNhat = i;
                    bacDinhLonNhat = B[i];
                }
            }

        }
        public static int ChonDinhLonNhat(int[] A)
        {
            
            return 0;
        }
        public static void MaxAlgorithm(EdgeList[] A, int[] B)
        {
            TinhBac(A, B);

            //for (int i = 0; i < vertexNumber; i++)
            //{
            //    Console.WriteLine(i + "   " + B[i]);
            //}

            if (bacDinhLonNhat == 0)
            {
                return;
            }
            Bac[dinhLonNhat] = -1;
            for (int i = 0; i < edgeNumber; i++)
            {
                if (A[i].begin_node == dinhLonNhat||A[i].end_node == dinhLonNhat)
                {
                    A[i].weight = -1;
                }
            }
            //demlap++;
           // Console.WriteLine(demlap);
             MaxAlgorithm(A, B);
        }
        static void Main(string[] args)
        {


            InputGraph("Slashdot0902.txt");
            QuickSort(graph, 0, Convert.ToInt32(edgeNumber) - 1);
            Bac = new int[Convert.ToInt32(vertexNumber)];
            DanhDauDinh = new int[Convert.ToInt32(vertexNumber)];
            OutputGraph(graph);
            InputGraph2("OutputGraph1.txt");
            //Print(graph);
            Console.WriteLine();
            diemCuoi = 1;
            do
            {
                if(graph[diemCuoi].begin_node == graph[diemCuoi - 1].begin_node)
                {
                    dem++;
                }
                if (graph[diemCuoi].begin_node != graph[diemCuoi - 1].begin_node)
                {
                    QuickSort3(graph, diemCuoi - dem - 1, diemCuoi - 1);
                    dem = 0;
                }
                diemCuoi++; 
            } while (diemCuoi < edgeNumber);


            do
            {
                TinhBac(graph, Bac);

                //for (int i = 0; i < vertexNumber; i++)
                //{
                //    Console.WriteLine(i + "   " + B[i]);
                //}

                if (bacDinhLonNhat == 0)
                {
                    break;
                }
                Bac[dinhLonNhat] = -1;
                for (int i = 0; i < edgeNumber; i++)
                {
                    if (graph[i].begin_node == dinhLonNhat || graph[i].end_node == dinhLonNhat)
                    {
                        graph[i].weight = -1;
                    }
                }
                demlap++;
                 Console.WriteLine(demlap);
            } while (true);




            //MaxAlgorithm(graph, Bac);
            OutputGraph2(graph);

            Output(Bac);
            Console.WriteLine("da chay xong chuong trinh :D");






            Console.ReadLine();
        }
    }
   /* public class Process
    {
        public double vertexNumber;
        public double edgeNumber;
        public EdgeList[] graph;
        public EdgeList[] outPutGraph;

        public void QuickSort(EdgeList[] A, int dau, int cuoi)
        {
            if (dau >= cuoi) { return; }

            double chot = A[cuoi].weight;
            int i = dau;
            int j = cuoi;
            do
            {
                while (A[i].weight < chot)
                {
                    i++;
                }
                while (A[j].weight > chot)
                {
                    j--;
                }
                if (i <= j)
                {
                    if (i < j)
                    {
                        EdgeList temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                    i++;
                    j--;
                }
            } while (i < j);


            QuickSort(A, dau, j);
            QuickSort(A, i, cuoi);


        }  //Sap xep cac canh theo thu tu trong so tang dan
        public void Kruskal()
        {
            //
        }


        public void Print(EdgeList[] A)
        {
            for (int i = 0; i < edgeNumber; i++)
            {
                Console.Write(A[i].begin_node + " " + A[i].end_node + " " + A[i].weight);
                Console.Write("\n");
            }
        }
        public void InputGraph(string A)
        {
            using (StreamReader sr = new StreamReader(A))
            {
                string Line;
                Line = sr.ReadLine();
                vertexNumber = Convert.ToDouble(Line);
                Line = sr.ReadLine();
                edgeNumber = Convert.ToDouble(Line);
                graph = new EdgeList[Convert.ToInt32(edgeNumber)];
                outPutGraph = new EdgeList[Convert.ToInt32(edgeNumber)];
                for (int i = 0; i < edgeNumber; i++)
                {
                    string chuoi_dau = sr.ReadLine();
                    string[] chuoi_tach = chuoi_dau.Split(new char[] { ' ' });
                    string chuoi_ketqua = "";
                    foreach (string s in chuoi_tach)
                    {

                        if (s.Trim() != "")
                            chuoi_ketqua = chuoi_ketqua + s + " ";
                    }
                    string[] strS = chuoi_ketqua.Split(' ');
                    graph[i].begin_node = Convert.ToDouble(strS[0]);
                    graph[i].end_node = Convert.ToDouble(strS[1]);
                    graph[i].weight = 1;
                    //graph[i].weight = Convert.ToInt16(strS[2]);

                }
            }

        }
        public void OutputGraph(EdgeList[] A)
        {
            string listA = null;

            using (StreamWriter sw = new StreamWriter("OutputGraph1.txt"))
            {
                for (int i = 0; i < edgeNumber; i++)
                {
                    if (A[i].begin_node != 0 && A[i].end_node != 0 && A[i].weight != 0)
                    {
                        listA = A[i].begin_node + " " + A[i].end_node + " " + A[i].weight;
                        sw.WriteLine(listA);
                    }

                }
            }
        }
    } */
}







