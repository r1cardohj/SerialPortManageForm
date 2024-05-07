using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerialPortManageForm
{
    internal class Logger
    {
        private static string Pwd = AppDomain.CurrentDomain.BaseDirectory; //当前工作目录
        private static StreamWriter Writer = new StreamWriter(Pwd + "\\log.txt", true, Encoding.Default);

        private Logger() { }

        public static void Log(string msg)
        {
            Writer.WriteLine(DateTime.Now.ToString() + "  " + msg);
            Writer.Flush();
        }

        public static void Clear()
        { 
            Writer.Close();
        }

        public static void Error(string msg)
        {
            Log($"ERROR: {msg}");
        }
    }
}
