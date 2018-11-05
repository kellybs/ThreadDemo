using System;
using System.Threading;

namespace ThreadDemo
{
    class JoinDemo
    {
        static Thread thread1, thread2;

        static void Main(string[] args)
        {

            /*
             * Join是一种同步方法，阻止调用线程 （即，调用的方法的线程），直到线程其Join方法调用已完成。 
             * 使用此方法以确保线程已终止。 如果线程不会终止，调用方将无限期阻止。
             * 
             */
            thread1 = new Thread(ThreadProc);
            thread1.Name = "Thread1";
            thread1.Start();

            thread2 = new Thread(ThreadProc);
            thread2.Name = "Thread2";
            thread2.Start();


            Console.WriteLine("Main thread exits.");
            Console.ReadKey();
        }

        private static void ThreadProc()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "Thread1" &&
                thread2.ThreadState != ThreadState.Unstarted)
                thread2.Join();

            Thread.Sleep(2000);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread1: {0}", thread1.ThreadState);
            Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
        }
    }
}
