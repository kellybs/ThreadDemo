using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.Tasks
{
    class ParallelDemo
    {
        private static Stopwatch stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始运行了");
            stopWatch.Start();
            Parallel.Invoke(MethodA, MethodB);
            stopWatch.Stop();
            Console.WriteLine("Parallel run " + stopWatch.ElapsedMilliseconds + " ms.");

            stopWatch.Restart();
            MethodA();
            MethodB();
            stopWatch.Stop();
            Console.WriteLine("Normal run " + stopWatch.ElapsedMilliseconds + " ms.");

            Console.ReadKey();
        }

        static void MethodA()
        {

            Thread.Sleep(2000);
            Console.WriteLine("from methodA");
        }
        static void MethodB()
        {

            Thread.Sleep(3000);
            Console.WriteLine("from MethodB");
        }
    }
}
