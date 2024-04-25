using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SerialPortManageForm
{
  
    internal class SerialPortBaseData
    {

        public static readonly int[] BaudRateSet = {
            1200, 2400, 4800, 9600, 19200, 38400, 57600, 76800,
            115200, 128000, 230400, 256000, 460800, 512000, 
            576000, 921600
        };

        public static readonly int[] DataBitsSet = { 5, 6, 7, 8 };

        public static readonly int DefaultBaudRate = 9600;

        public static readonly int DefaultDataBits = 8;

        private static readonly SerialPortStack _stack = new SerialPortStack();

        // 工作线程放在_workers中
        private static readonly Stack<Thread> _workers = new Stack<Thread>();

        private SerialPortBaseData() { }

        public static string[] GetActivePortNames()
        {
            return SerialPort.GetPortNames();
        }

        public static SerialPort CurrentPort
        {
            get
            {
                return _stack.Peek();
            }
        }

        public static SerialPortStack PortCtxStack {
            get {
                return _stack;
            }
        }
        
        public static Stack<Thread> WorkerThreads {
            get {
                return _workers;
            }
        }
    }
}
