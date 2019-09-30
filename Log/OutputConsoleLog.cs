using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS_Service.Log
{
    /// <summary>
    /// 输出控制台日志
    /// </summary>
    public static class OutputConsoleLog
    {
        public static void Msg(string content)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format("Msg:{0}", content));
        }
        public static void PromptMsg(string content)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("Prompt:{0}", content));
        }
        public static void SuccessMsg(string content)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format("\tSuccess:{0}", content));
        }
        public static void ContentMsg(string content)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Format("\t{0}", content));
        }
        public static void FailureMsg(string content)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(string.Format("\tFailure:{0}", content));
        }
        public static void ExceptionMsg(Exception ex, string content)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("\tException:{0}\r\n\t{1}\r\n\t{2}", content, ex.Message, ex.StackTrace));
        }
    }
}
