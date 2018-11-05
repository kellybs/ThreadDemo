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
    class ParallelDownload
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始运行了");
            Stopwatch sw = new Stopwatch();
            sw.Start();


            HttpClient client = new HttpClient();
            var list = StringHelp.GetUrl();
           
            var task=Parallel.ForEach(list, item => {

              
                Console.Write("Url:" + item);
                var resp = client.GetAsync(item);

                var word = ProcessURL(item, client).Result;

                if (!string.IsNullOrWhiteSpace(word))
                {

                    string title = StringHelp.GetSubString(word, "<title>", "</title>");

                    Console.Write("  Title:" + title);

                }
                Console.WriteLine("");
            });
            //var task = Task.Factory.StartNew(() =>
            //{
            //    foreach (var item in list)
            //    {

            //    }
            //});



            sw.Stop();
            Console.WriteLine("Running Time:" + sw.ElapsedMilliseconds);

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

     
    }

    
}
