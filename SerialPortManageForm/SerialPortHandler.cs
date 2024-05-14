using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SerialPortManageForm
{
    internal class SerialPortHandler
    {
        private Action<string> sendCallBack;
        private Action<string> sendWeigthCallBack;
        private Action<bool> endCallBack;
        private SerialPort serialPort;
        public SerialPortHandler(SerialPort serialPort,
                                 Action<string> sendWeigthFunc,
                                 Action<string> sendFunc,
                                 Action<bool> endFunc)
        {
            this.serialPort = serialPort;
            this.sendWeigthCallBack = sendWeigthFunc;   //回调函数 用于把体重送回UI线程
            this.sendCallBack = sendFunc; //回调函数 用于把串口返回信息送回UI线程
            this.endCallBack = endFunc; //回调函数 返回用于标志工作线程是否正常中止信息回UI线程
        }

        public void handle()
        {
            Thread worker = new Thread( () => {
                //int i = 0;
                byte[] resp;
                try
                {
                    SerialPortReader reader = new SerialPortReader();
                    SerialPortRecDataTranslator translator = new SerialPortRecDataTranslator();
                    this.serialPort.Open();
                    while (!SerialPortBaseData.workerShouldStop)
                    {
                        Thread.Sleep(200);
                        //resp = i.ToString();

                        if (Settings.DEBUG)
                            resp = reader.FakeRead(this.serialPort);
                        else
                            resp = reader.Read(this.serialPort);
                        this.sendCallBack(Encoding.ASCII.GetString(resp) + Environment.NewLine);
                        List<Weight> list = translator.Translate(resp);
                        foreach (var w in list)
                        {
                            SerialPortBaseData.WeigthStack.Push(w);
                            this.sendWeigthCallBack($"{w.Number}{w.Unit}");
                        }
                        
                        //i++;
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
                    SerialPortBaseData.WorkerThreadsStack.Pop();
                }
            } );
            SerialPortBaseData.workerShouldStop = false;
            worker.Start();
            SerialPortBaseData.WorkerThreadsStack.Push(worker);
        }
    }
}
