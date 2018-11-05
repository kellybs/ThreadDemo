using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Tasks
{
    class TaskBase
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始运行了");
            /*
             * 没有返回值
             */ 
            Task task = new Task(() => {
                Console.WriteLine("Task 执行异步操作");
                for (int i = 0; i < 400; i++)
                {
                    Console.WriteLine("Task:"+i);
                }
            });
            task.Start();

            Console.WriteLine("主线程其他处理");
            for (int x = 0; x < 300; x++)
            {
                Console.WriteLine("Main:" + x);
            }

            Console.WriteLine("主线程运行结束了");
            Console.ReadKey();
        }
    }
}
