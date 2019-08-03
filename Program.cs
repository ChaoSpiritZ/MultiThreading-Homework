using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreading_Homework
{
    class Program
    {
        private static List<int> aList = new List<int>();
        private static Mutex _mutex = new Mutex();
        //first 21 numbers:
        //add remove insert get add remove get remove add get insert remove add remove insert get add remove get remove add
        public static void Job1()
        {
            try
            {
                for (int i = 0; i < 1000000; i++)
                {
                    _mutex.WaitOne();

                    if (i % 4 == 0)
                    {
                        aList.Add(i);
                    }
                    else if (i % 3 == 0)
                    {
                    }
                    else if (i % 2 == 0)
                    {
                        aList.Insert(aList.Count, i);
                    }
                    else
                    {
                        aList.Remove(0);

                    }
                    Console.WriteLine(aList.Get(aList.Count - 1));
                    Console.WriteLine("                         Count: " + aList.Count);
                    Console.WriteLine("                                                  Cycle: " + i);
                    Console.WriteLine("----------------------------------------------------------------------");

                    _mutex.ReleaseMutex();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("PROBLEM IN JOB1");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Thread t1 = new Thread(new ThreadStart(Job1));
                Thread t2 = new Thread(new ThreadStart(Job1));
                aList.Add(69);
                t1.Start();
                //Thread.Sleep(1337);
                t2.Start();

                //in case you want to see the numbers:
                int x = 0;
                while (x != -1)
                {
                    x = int.Parse(Console.ReadLine());
                    if (x == 2)
                    {
                        t1.Suspend();
                        t2.Suspend();
                    }
                    if (x == 3)
                    {
                        t1.Resume();
                        t2.Resume();
                    }
                }

                t1.Join();
                t2.Join();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
