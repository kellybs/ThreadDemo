using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.ThreadSynchronize
{
    class MutexDemo
    {
        static Mutex mut = new Mutex();

        private const int numIterations = 1;
        private const int numThreads = 5;

        static void Main(string[] args)
        {
            #region Mutex 示例
            //每个调用线程在获取互斥锁的所有权之前都被阻塞，所以它必须调用ReleaseMutex方法来释放线程的所有权。
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(ThreadProc);
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

            #endregion



            Console.Read();
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        private static void UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.Name);
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                              Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(50);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the Mutex.
            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        }
    }
}