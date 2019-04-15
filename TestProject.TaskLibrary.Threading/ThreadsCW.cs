using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Threading
{
    class ThreadsCW
    {
        public static void Main1()
        {
            Thread t = new Thread(WriteY);
            t.Start();

            for (int i = 0; i < 1000; i++) ConsIO.Write("i");
            //Thread.Sleep(300);

            ConsIO.ReadLine();
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                ConsIO.Write("y");
                //Thread.Sleep(300);
            }
        }
    }

    class ThreadsJoin
    {
        public static void Main2()
        {
            Thread t = new Thread(WriteY);
            t.Start();
            t.Join();
            for (int i = 0; i < 1000; i++) ConsIO.Write("x");
            //Thread.Sleep(300);

            ConsIO.ReadLine();
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                ConsIO.Write("y");
                //Thread.Sleep(300);
            }
        }
    }

    class ThreadsParametrized
    {
        public static void Main3()
        {
            Thread t = new Thread(ThreadsParametrized.WriteY);
            t.Start("42");
            
            for (int i = 0; i < 1000; i++) Console.Write("x");
            //Thread.Sleep(300);

            Console.ReadLine();
        }

        static void WriteY(object data)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(data as string);
                //Thread.Sleep(300);
            }
        }
    }

    class ThreadsSum
    {
        private static int sum;
        private static int bound1, counter=0;

        public static void Main4()
        {
            Stopwatch w1 = new Stopwatch();
            Stopwatch w2 = new Stopwatch();
            Stopwatch w3 = new Stopwatch();
            Stopwatch w4 = new Stopwatch();

            var rnd=new Random();
            var ar = new int[10000];
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = rnd.Next(0, 15000);
            }
            bound1 = ar.Length / 4;
            
            Thread t1 = new Thread(Sum);
            Thread t2 = new Thread(Sum);
            Thread t3 = new Thread(Sum);
            Thread t4 = new Thread(Sum);
            
            w1.Start();
            t1.Start(ar);
            t1.Join();
            w1.Stop();
            w2.Start();
            t2.Start(ar);
            //t2.Join();
            w2.Stop();
            w3.Start();
            t3.Start(ar);
            //t3.Join();
            w3.Stop();
            w4.Start();
            t4.Start(ar);
            //t4.Join();
            w4.Stop();
            
            ConsIO.WriteLine("Thread1 elapsed time (ticks): " + w1.ElapsedTicks);
            ConsIO.WriteLine("Thread2 elapsed time (ticks): " + w2.ElapsedTicks);
            ConsIO.WriteLine("Thread3 elapsed time (ticks): " + w3.ElapsedTicks);
            ConsIO.WriteLine("Thread4 elapsed time (ticks): " + w4.ElapsedTicks);
            ConsIO.WriteLine("Sum: " + sum);
            ConsIO.ReadLine();
        }

        static void Sum(object data)
        {
            try
            {
                var tmp = data as int[];
                switch (counter)
                {
                    case 0:
                        for (int i = 0; i < bound1; i++)
                        {
                            if (tmp[i] % 2 == 0)
                            {
                                sum += tmp[i];
                            }
                        }

                        counter = 1;
                        break;
                    case 1:
                        for (int i = bound1; i < bound1 * 2; i++)
                        {
                            if (tmp[i] % 2 == 0)
                            {
                                sum += tmp[i];
                            }
                        }

                        counter = 2;
                        break;
                    case 2:
                        for (int i = bound1 * 2; i < bound1 * 3; i++)
                        {
                            if (tmp[i] % 2 == 0)
                            {
                                sum += tmp[i];
                            }
                        }

                        counter = 3;
                        break;
                    case 3:
                        for (int i = bound1 * 3; i < tmp.Length; i++)
                        {
                            if (tmp[i] % 2 == 0)
                            {
                                sum += tmp[i];
                            }
                        }

                        counter = 0;
                        break;
                    default:
                        ConsIO.WriteLine("Wrong counter");
                        break;
                }
                ConsIO.WriteLine(sum);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Null array:  " + e);
            }
        }
    }

    class ThreadsTasks
    {
        //public Task(Action action);

        //public delegate void Action();

        

        //public static void Main()
        //{
        //    Task task = new Task();
        //    task = 
            
        //}


        //public async Task DoWork()
        //{
        //    int rec = await Task.FromResult<int>(GetSum(4, 5));
        //}

        //private int GetSum(int a, int b)
        //{
        //    return a + b;
        //}
    }
}
