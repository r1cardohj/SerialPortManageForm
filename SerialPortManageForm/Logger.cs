using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerialPortManageForm
{
    internal class Logger
    {
        private static string Pwd = AppDomain.CurrentDomain.BaseDirectory; //当前工作目录
        private static StreamWriter writer = new StreamWriter(Pwd + "\\log.txt", true, Encoding.Default);

        private Logger() { }

        public static void Log(string msg)
        {
            writer.WriteLine(DateTime.Now.ToString() + " : " + msg);
            writer.Flush(); 
        }

        public static void Clear()
        { 
            writer.Close();
        }

        
    }
}
