using System;
using System.Threading;

namespace ThreadDemo
{
    class ThreadAdd
    {

        static int count = 0;
        static void Main(string[] args)
        {
            Thread td = new Thread(IncrementCount);
            Thread td2 = new Thread(IncrementCount);

            td.Start();
            td2.Start();
            Console.ReadKey();
        }

        static void IncrementCount()
        {
            while (true)
            {
                int temp = count;
                Thread.Sleep(1000);
                count = temp + 1;
                Console.WriteLine("Thread ID:" + Thread.CurrentThread.ManagedThreadId + " Increment:"+ count);
                Thread.Sleep(1000);
            }
        }

    }
}
