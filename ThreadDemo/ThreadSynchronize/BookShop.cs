using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.ThreadSynchronize
{
    class BookShop
    {
        //剩余图书数量
        public int num = 1;

        object obj = new object();

        public void Sale()
        {
            /*
            所以，使用lock应该注意以下几点：　

　　          １、如果一个类的实例是public的，最好不要lock(this)。因为使用你的类的人也许不知道你用了lock，
                    如果他new了一个实例，并且对这个实例上锁，就很容易造成死锁。

　　          ２、如果MyType是public的，不要lock(typeof(MyType))

　　          ３、永远也不要lock一个字符串

            使用lock关键字解决线程同步问题 
             最佳做法是定义 private 对象来锁定, 或 private static对象变量来保护所有实例所共有的数据。
            */
            lock (obj)
            {
                int tmp = num;
                if (tmp > 0)//判断是否有书，如果有就可以卖
                {
                    Thread.Sleep(1000);
                    num -= 1;
                    Console.WriteLine("售出一本图书，还剩余{0}本", num);
                }
                else
                {
                    Console.WriteLine("没有了");
                }
            }


        }
    }

    class Inventory
    {
        //剩余鞋子数量
        int num = 8;
        private static object obj = new object();
        public void Sale()
        {
            /*
             * 与 lock 关键字类似，监视器可防止多个线程同时执行代码块。 
             * Enter 方法允许有且只有一个线程继续执行下面的语句；执行线程调用 Exit 之前，将阻止其他所有线程。 
             * 这与使用 lock 关键字类似。
             * 
             * 很明显Wait方法的作用是：释放某个对象上的锁以便允许其他线程锁定和访问这个对象。
             * 第二个就是TryEnter方法，这个方法与Enter方法主要的区别在于是否阻塞当前线程，当一个对象通过Enter方法获取锁，而没有执行Exit方法释放锁，
             * 当另一个线程想通过Enter获得锁时，此时该线程将会阻塞，直到另一个线程释放锁为止，而TryEnter不会阻塞线程
             * 
             */
            Monitor.Enter(obj);
            try
            {
                if (num > 0)//判断是否有鞋子，如果有就可以卖
                {
                    Thread.Sleep(200);
                    num -= 1;
                    Console.WriteLine("售出一双鞋子，还剩余{0}", num);
                }
                else
                {
                    Console.WriteLine("没有了");
                }
            }
            finally
            {
                Monitor.Exit(obj);
            }
            
        }
    }

    class TryEnters
    {
        private static object obj = new object();


        public void ShowInfo()
        {
            /*
             * 当线程1获取了obj对象独占权时，线程2尝试调用TryEnter(obj)，此时会由于无法获取独占权而返回false，输出信息如下：不能访问当前线程
             */
            if (!Monitor.TryEnter(obj))
            {
                Console.WriteLine("不能访问当前线程：" + Thread.CurrentThread.Name);
                return;
            }

            try
            {
                Monitor.Enter(obj);
                Console.WriteLine("当前线程：" + Thread.CurrentThread.Name);
            }
            finally
            {
                Monitor.Exit(obj);
            }
           

        }
    }
}
