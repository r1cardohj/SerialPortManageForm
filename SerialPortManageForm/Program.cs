﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerialPortManageForm
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally
            {
                Logger.Clear();
            }
        }

    }
}
