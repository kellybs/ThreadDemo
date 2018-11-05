using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Common
{
    public static class StringHelp
    {
        public static string GetItemByTag(this string source,string begin, string end)
        {
            return "(?<=" + begin + ")[\\s\\S]*?(?=" + end + ")";
        }

        public static string GetSubString(string strfull, string strhead, string strfoot)
        {
            string result = "";
            int num = strfull.IndexOf(strhead, StringComparison.OrdinalIgnoreCase);
            if (num > -1)
            {
                int num2 = strfull.IndexOf(strfoot, num + strhead.Length, StringComparison.OrdinalIgnoreCase);
                if (num2 > -1)
                {
                    result = strfull.Substring(num + strhead.Length, num2 - num - strhead.Length);
                }
            }
            return result;
        }

        public static List<string> GetUrl()
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
