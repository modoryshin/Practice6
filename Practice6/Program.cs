using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    class Program
    {
        static double[] Three(double[] s)
        {
            double dis;
            bool ok;
            for (int j = 0; j < 3; j++)
            {
                do
                {
                    Console.WriteLine("Enter element {0}", j + 1);
                    ok = Double.TryParse(Console.ReadLine(), out dis);
                    if (!ok)
                        Console.WriteLine("Invalid data type.");
                } while (!ok);
                s[j] = dis;
            }
            return s;
        }
        static double[] Fill(double[] s)
        {
            for(int i = 3; i < s.Length; i++)
            {
                s[i] = (s[i - 1] + s[i - 2]) / (3 + 3 * (s[i - 3]));
            }
            return s;
        }
        static int EnterN()
        {
            int dis;
            bool ok;
            do
            {
                Console.WriteLine("Enter the index of end element.");
                ok = Int32.TryParse(Console.ReadLine(), out dis);
                if (!ok)
                    Console.WriteLine("Invalid data type.");
                else if (dis < 0 || dis > 99)
                    Console.WriteLine("No element with such index.");
            } while (!ok|| (dis < 0 || dis > 99));
            return dis;
        }
        static double EnterM()
        {
            double dis;
            bool ok;
            do
            {
                Console.WriteLine("Enter the number.");
                ok = Double.TryParse(Console.ReadLine(), out dis);
                if (!ok)
                    Console.WriteLine("Invalid data type.");
            } while (!ok);
            return dis;
        }
        static void Counting(double[] s,int N,double M)
        {
            List<int> ind = new List<int>();
            int count = 0;
            Console.WriteLine("Elements of sequance from 1 to {0}:", N + 1);
            for(int i = 0; i <= N; i++)
            {
                if (s[i] == M)
                {
                    count++;
                    ind.Add(i);
                }
                Console.WriteLine(s[i]);
            }
            if (count != 0)
            {
                Console.WriteLine("{0} elements of the sequance equal {1}", count, M);
                Console.WriteLine("They are:");
                foreach(int x in ind)
                {
                    Console.WriteLine(x);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("There are no elements in the sequance? such as {0}", M);
            }
        }
        static int[] Counting(double[] s, int N, double M, int c, int[] j2, int i, int l)
        {
                if (i == N)
                {
                    Array.Resize(ref j2, j2.Length + 1);
                    j2[j2.Length - 1] = c;
                    return j2;
                }
                else
                {
                    if (s[i] == M)
                    {
                        c++;
                        Array.Resize(ref j2, j2.Length + 1);
                        j2[l] = i;
                        l++;
                    }
                    i++;
                   return Counting(s, N, M, c, j2, i, l);
                }
            }
        static void Show(double[] s)
        {
            foreach (double x in s)
                Console.WriteLine(x);
        }
        static void Final(int[] j)
        {
            if (j[j.Length - 1] == 0)
                Console.WriteLine("There are no such elements.");
            else
            {
                Console.WriteLine("This sequance has {0} elements such as this one.", j[j.Length - 1]);
                Console.WriteLine("Their indexes are:");
                for (int i = 0; i < j.Length - 1; i++)
                    Console.WriteLine(j[i]);
            }
            }
        static void Main(string[] args)
        {
            double M;
            int N;
            double[] sequance = new double[100];
            sequance = Three(sequance);
            sequance = Fill(sequance);
            N = EnterN();
            M = EnterM();
            int count = 0;
            int[] t1 = new int[0];
            int i = 0;
            int l = 0;
            int[] t=Counting(sequance,N,M,count,t1,i,l);
            Console.WriteLine("Elements of sequance from 1 to {0}:", N + 1);
            Show(sequance);
            Final(t);
            Console.ReadKey();
        }
    }
}
