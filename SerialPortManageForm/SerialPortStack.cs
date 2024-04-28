using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Security;
using System.Text;

namespace SerialPortManageForm
{
    internal class SerialPortStack
    {
        /* SerialPortStack 是用于存放SerialPort对象的栈，通过SerialPortFactory新建
           SerialPort对象会自动把对象放进栈中，Pop方法会自动Close掉SerialPort的连接。
        */
        private List<SerialPort> _data = new List<SerialPort>();

        public void Push(SerialPort port)
        {
            _data.Add(port);
        }

        public SerialPort Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty, `Pop` function is disable.");
            }
            SerialPort port = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            if (port.IsOpen)
                port.Close();

            return port;
        }
        
        public SerialPort Peek() {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty, `Peek` function is disable.");
            }
            return _data[_data.Count - 1];
        }
        
        public bool IsEmpty()
        {
            return _data.Count == 0;
        }
        public int Count() { return _data.Count; }
    }
}
