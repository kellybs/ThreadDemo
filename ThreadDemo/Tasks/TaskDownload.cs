using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using ThreadDemo.Common;

namespace ThreadDemo.Tasks
{
    class TaskDownload
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始运行了");
            Stopwatch  sw = new Stopwatch();
            sw.Start();
            

            HttpClient client = new HttpClient();
            var list = GetUrl();
            var task=Task.Factory.StartNew(() =>
            {                
                foreach (var item in list)
                {
                    Console.Write("Url:" + item);
                    var resp = client.GetAsync(item);

                    var word = ProcessURL(item, client).Result;

                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        
                        string title = StringHelp.GetSubString(word,"<title>", "</title>");

                        Console.Write("  Title:" + title);                       

                    }
                    Console.WriteLine("");
                }
            });
            


            task.GetAwaiter().OnCompleted(() => {
                sw.Stop();
                Console.WriteLine("Running Time:" + sw.ElapsedMilliseconds);
            });

            Console.ReadKey();
        }

        async static Task<string> ProcessURL(string url, HttpClient client)
        {
            // GetAsync returns a Task<HttpResponseMessage>.   
            HttpResponseMessage response = await client.GetAsync(url);

            // Retrieve the website contents from the HttpResponseMessage.  
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        static List<string> GetUrl()
        {
            List<string> list = new List<string>();
            list.Add("https://blog.gkarch.com/threading/part5.html");
            list.Add("http://sports.163.com/ding");
            list.Add("https://blog.csdn.net/youarenotme/article/details/72828223");
            list.Add("https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/async/start-multiple-async-tasks-and-process-them-as-they-complete");
            list.Add("https://www.cnblogs.com/qiu2013/p/4220487.html");
            return list;
        }


    }

   
}
