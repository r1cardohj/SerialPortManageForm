using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SerialPortManageForm
{
    internal class SerialPortHandler
    {
        private Action<string> sendCallBack;
        private Action<bool> endCallBack;
        private SerialPort serialPort;
        public SerialPortHandler(SerialPort serialPort,
                                 Action<string> sendFunc,
                                 Action<bool> endFunc)
        {
            this.serialPort = serialPort;
            this.sendCallBack = sendFunc; //回调函数 用于把工作线程的体重信息送回UI线程
            this.endCallBack = endFunc; //回调函数 返回用于标志工作线程是否正常中止信息回UI线程
        }

        public void handle()
        {
            this.serialPort.Open();
            Thread reciver = new Thread(
               () => {
                   int i = 0;
                   while (true)
                   {
                       Thread.Sleep(1000);
                       this.sendCallBack(string);
                       i++;
                   }
               }
                );
        }




    }
}
