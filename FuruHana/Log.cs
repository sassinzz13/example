using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.FuruHana
{
   public class Log
    {
        public static void Normal(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[Msg] - {msg}");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Info] - {msg}");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Warning] - {msg}");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Error] - {msg}");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
