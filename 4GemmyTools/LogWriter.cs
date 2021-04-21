using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GemmyTools
{
    public static class LogWriter
    {
        private static string logPath = string.Empty;
        private static string logFielPrefix = string.Empty;

        public static string LogPath
        {
            get
            {
                if (logPath == string.Empty)
                {
                    logPath = AppDomain.CurrentDomain.BaseDirectory + @"Log\";
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }
                }
                return logPath;
            }
            set
            {
                logPath = value;
            }
        }

        /// <summary>
        /// 日志文件前缀
        /// </summary>
        public static string LogFielPrefix
        {
            get { return logFielPrefix; }
            set { logFielPrefix = value; }
        }

        private static void WriteLog(string msg, string logFile)
        {
            try
            {
                string fileName = LogPath + LogFielPrefix + logFile + "_" +
                    DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.None);
                StreamWriter sw = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] "));
                sb.Append(msg);
                sw.WriteLine(sb.ToString());
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="logType"></param>
        public static void WriteLog(string msg, LogType logType)
        {
            WriteLog(msg, logType.ToString());
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            WriteLog(msg, "log");
        }
        public static string ClearFrontZreo(string str)
        {
            if (str == "")
            {
                return "0";

            }
            char[] arr = str.ToCharArray();
            string rtstr = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].ToString() != "0")
                {
                    rtstr = str.Substring(i, str.Length - i);
                    return rtstr;
                }
            }
            return "0";

        }
    }



    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        Trace,
        Warning,
        Error,
        SQL
    };

}
