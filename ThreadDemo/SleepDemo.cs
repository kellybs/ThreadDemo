using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class SleepDemo
    {
        static void Main(string[] args)
        {
            
            /*
             * Sleep使用的时候，线程并不会放弃对象的使用权，即不会释放对象锁，所以在同步方法或同步块中使用sleep，一个线程访问时，其他的线程也是无法访问的。
             * 
             */
            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine("Sleep for 30 seconds.");
                Thread.Sleep(20);
            }


            Console.WriteLine("Main thread exits.");
            Console.ReadKey();
        }
        
    }
}
