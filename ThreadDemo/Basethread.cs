using System;
using System.Threading;

namespace ThreadDemo
{
    class Basethread
    {
        static void Main(string[] args)
        {
            Thread thread = Thread.CurrentThread;//获取当前的线程
            thread.Name = "Main Thread";//设置当前线程的名称

            /*
             * ThreadStart是一个无参的、返回值为void的委托。
             * 可以运行静态的方法，还可以运行实例方法(本例是静态方法)
             */
            Thread child = new Thread(new ThreadStart(Sum));//创建线程

            /*
             * 通过Lambda表达式创建
             */
            Thread childLambda = new Thread(() => {
                Console.WriteLine("我是通过Lambda表达式创建的线程");
                int count = 0;
                for (int i = 101; i <= 106; i++)
                {
                    count += i;
                    Console.WriteLine("第" + (i-100) + "次: " + count);
                }
            });

            /*
             * ParameterizedThreadStart是一个有参的、返回值为void的委托
             * 方法里面的参数类型必须是Object类型
             */
            Thread child2 = new Thread(new ParameterizedThreadStart(Sum));

            /*
             * 线程启动了，但是不一定立即执行，需要去抢，所以本实例每次运行程序可能看到结果不一样
             */
            child.Start();
            childLambda.Start();
            child2.Start(5);

            string strMsg = string.Format("Thread ID:{0}\n" + "Thread Name:{1}\n" +
                  "Thread State:{2}\n" + "Thread Priority:{3}\n", thread.ManagedThreadId, thread.Name,
                  thread.ThreadState, thread.Priority);
            Console.WriteLine(strMsg);
            Console.WriteLine("主线程运行结束了");
            Console.ReadKey();
        }

        static void Sum()
        {
            int result = 0;
            for (int i =1; i <= 10; i++)
            {
                result += i; 
                Console.WriteLine("第"+i+"次: "+result);
            }           
        }

        static void Sum(object obj)
        {
            int number = (int)obj;

            int result = 0, begin = 20,count=1;

            while (number > 0)
            {
                result += begin;
                Console.WriteLine("第" + count + "次: " + result);
                number--;
                begin++;
                count++;
            }

           
        }
    }
}
