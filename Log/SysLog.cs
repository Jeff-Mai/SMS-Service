using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Log
{
    public static class SysLog
    {
        #region 公有变量,属性,方法(可重写)
        public static string GetLogDirectoryPath()
        {
            string logDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + @"Log\";
            //日志目录是否存在 不存在创建
            if (!Directory.Exists(logDirectoryPath))
            { Directory.CreateDirectory(logDirectoryPath); }
            return logDirectoryPath;
        }
        #endregion

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="exception">异常对象</param>
        public static void WriteLogFromException(Exception exception)
        {
            StringBuilder logInfo = new StringBuilder("");
            string currentTime = System.DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
            if (exception != null)
            {
                logInfo.Append("\n");
                logInfo.Append("DateTime：" + currentTime.ToString() + "\r\n");
                logInfo.Append("LogType：Error\r\n");
                //获取描述当前的异常的信息
                logInfo.Append("ExceptionMessage：" + exception.Message + "\r\n");
                //获取当前实例的运行时类型
                logInfo.Append("ExceptionType：" + exception.GetType() + "\r\n");
                //获取或设置导致错误的应用程序或对象的名称
                logInfo.Append("ExceptionSource：" + exception.Source + "\r\n");
                //获取引发当前异常的方法
                logInfo.Append("ExceptionFunction：" + exception.TargetSite + "\r\n");
                //获取调用堆栈上直接桢的字符串表示形式
                logInfo.Append("ExceptionStackTrace：\r\n" + exception.StackTrace + "\r\n");
                logInfo.Append("-----------------------------------------------------------\r\n");
            }
            System.IO.File.AppendAllText(GetLogDirectoryPath() + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }
        /// <summary>
        /// 日常日志
        /// </summary>
        /// <param name="source">例如:ClassName OR FileName</param>
        /// <param name="function">例如:FunctionName</param>
        /// <param name="message">日志信息</param>
        public static void WriteLog(string source, string function, string message)
        {
            StringBuilder logInfo = new StringBuilder("");
            string currentTime = System.DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
#if IsDebug
            if (message != null)
            {
                logInfo.Append("\n");
                logInfo.Append("DateTime：" + currentTime.ToString() + "\r\n");
                logInfo.Append("LogType：Info\r\n");
                //记录源:Class
                logInfo.Append("Source：" + source + "\r\n");
                //记录源:Function
                logInfo.Append("Function：" + function + "\r\n");
                //记录日志信息
                logInfo.Append("Message：" + message + "\r\n");
                logInfo.Append("-----------------------------------------------------------\r\n");
            }
#else
            if (message != null && message.Contains("Debug-") == false)
            {
                logInfo.Append("\n");
                logInfo.Append("DateTime：" + currentTime.ToString() + "\r\n");
                logInfo.Append("LogType：Info\r\n");
                //记录源:Class
                logInfo.Append("Source：" + source + "\r\n");
                //记录源:Function
                logInfo.Append("Function：" + function + "\r\n");
                //记录日志信息
                logInfo.Append("Message：" + message + "\r\n");
                logInfo.Append("-----------------------------------------------------------\r\n");
            }
#endif
            System.IO.File.AppendAllText(GetLogDirectoryPath() + DateTime.Now.ToString("yyyy-MM-dd") + ".log", logInfo.ToString());
        }

    }
}
