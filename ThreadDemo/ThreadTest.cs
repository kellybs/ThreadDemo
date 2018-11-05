using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class ThreadTest
    {
        static void Main()
        {
            Thread t = new Thread(Go);
            t.Start();
           
            Console.WriteLine("Thread t has ended!");
            Console.ReadKey();
        }

        static void Go()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("y");
            }
        }
    }
}
