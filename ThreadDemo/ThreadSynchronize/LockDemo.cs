using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.ThreadSynchronize
{
    /// <summary>
    /// 使用Lock实现线程同步
    /// </summary>
    class LockDemo
    {
        static void Main(string[] args)
        {
            #region lock示例
            BookShop book = new BookShop();
            //创建两个线程同时访问Sale方法
            Thread t1 = new Thread(new ThreadStart(book.Sale));
            Thread t2 = new Thread(new ThreadStart(book.Sale));
            //启动线程
            t1.Start();
            t2.Start();
            #endregion

            Console.ReadKey();
        }
    }

    
}
