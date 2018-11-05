using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Tasks
{
    class TaskReturn
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始运行了");
            /*
             * 等待任务的完成并获取返回值
             */
            Task<int> task = new Task<int>(() => {
                Console.WriteLine("Task 执行异步操作");

                int result = 0;
                for (int i = 0; i < 15; i++)
                {
                    result += i;
                }
                return result;
            });
            task.Start();

            Task<TaskUser> taskUser = new Task<TaskUser>(()=> {
                TaskUser model = new TaskUser()
                {
                    Age = 19,
                    Name = "Link"
                };
                return model;
            });
            taskUser.Start();

            //会等到任务执行完之后执行
            taskUser.GetAwaiter().OnCompleted(() => {
                Console.WriteLine("异步结果：" + taskUser.Result.Name);
            });

            for (int x = 0; x < 30; x++)
            {
                Console.WriteLine("Main:" + x);
            }
            task.Wait();
           
            Console.WriteLine("异步结果："+task.Result);
           // Console.WriteLine("异步结果：" + tu.Name);
            Console.WriteLine("主线程运行结束了");
            Console.ReadKey();
        }
    }

    class TaskUser {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
