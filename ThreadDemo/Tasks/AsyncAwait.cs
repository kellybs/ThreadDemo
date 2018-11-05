using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo.Tasks
{
    /// <summary>
    /// 统计 async 出现的次数
    /// </summary>
    class AsyncAwait
    {
        private static readonly HttpClient hc = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread begining");
            string url = "https://www.cnblogs.com/mushroom/p/4575417.html";

            Task<int> taskHtml = HtmlCount(url);

            for (int i = 0; i <10; i++)
            {                
                Console.WriteLine(i);
            }
            Console.WriteLine("共出现："+taskHtml.Result);
            Console.WriteLine("Main thread over");
            Console.ReadKey();
        }

        static async Task<int> HtmlCount(string url)
        {
            var html = hc.GetStringAsync(url);

            string result = await html;
           
            return new Regex("APM").Matches(result).Count;
        }
    }
}
