using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.ThreadSynchronize
{
    class TryEnterDemo
    {
        static void Main(string[] args)
        {
            #region Monitor TryEnter示例

            /*
             * TryEnter:这个方法与Enter方法主要的区别在于是否阻塞当前线程，当一个对象通过Enter方法获取锁，而没有执行Exit方法释放锁，
             * 当另一个线程想通过Enter获得锁时，此时该线程将会阻塞，直到另一个线程释放锁为止，而TryEnter不会阻塞线程
             */

            int threadLength = 25;
            TryEnters te = new TryEnters();

            Thread[] th = new Thread[threadLength];
            for (int i = 0; i < threadLength; i++)
            {
                th[i] = new Thread(te.ShowInfo);
                th[i].Name = "Thread" + i;
                th[i].Start();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
