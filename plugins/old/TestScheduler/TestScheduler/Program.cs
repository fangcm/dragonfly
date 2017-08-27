using Dragonfly.Common.Utils;
using Dragonfly.Plugin.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SchedulerRegistry.StartAllTask();
            System.Console.ReadKey();
        }
    }
}
