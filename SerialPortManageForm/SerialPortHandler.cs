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
            Thread worker = new Thread( () => {
                int i = 0;
                string resp;
                try
                {
                    SerialPortReader reader = new SerialPortReader();
                    this.serialPort.Open();
                    while (!SerialPortBaseData.workerShouldStop)
                    {
                        Thread.Sleep(500);
                        //resp = i.ToString();
                        resp = reader.Read(this.serialPort);

                        if (!string.IsNullOrEmpty(resp))
                        {
                            resp += Environment.NewLine;
                            this.sendCallBack(resp);
                            Logger.Log($"GET {this.serialPort.PortName}: {resp}");
                            //todo: parse resp and send to form
                        }
                        i++;
                    }
                    if (this.serialPort.IsOpen)
                        this.serialPort.Close();
                    this.endCallBack(true);
                }
                catch (Exception e)
                {
                    Logger.Error(e.ToString());
                    this.endCallBack(false);
                }
                finally
                { 
                    SerialPortBaseData.PortCtxStack.Pop();
                    SerialPortBaseData.WorkerThreads.Pop();
                }
            } );
            SerialPortBaseData.workerShouldStop = false;
            worker.Start();
            SerialPortBaseData.WorkerThreads.Push(worker);
        }
    }
}
