using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.ThreadSynchronize
{
    class MonitorDemo
    {
        static void Main(string[] args)
        {
            #region Monitor示例
           

            int threadLength = 15;
            Inventory it = new Inventory();
                
            Thread[] th=new Thread[threadLength];
            for (int i = 0; i < threadLength; i++)
            {
                th[i] = new Thread(it.Sale);
                th[i].Start();
            }           
            #endregion

            Console.ReadKey();
        }
    }
}
