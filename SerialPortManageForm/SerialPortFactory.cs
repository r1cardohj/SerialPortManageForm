using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace SerialPortManageForm
{
    
    internal class SerialPortFactory
    {
        private string PortName;
        private int Baudrate;
        private int DataBits;

        public SerialPortFactory(string PortName, int Baudrate, int DataBits)
        {
            this.PortName = PortName;
            this.Baudrate = Baudrate; 
            this.DataBits = DataBits;
        }

        public SerialPort CreateSerialPort() {
            SerialPort port = new SerialPort();
            port.PortName = this.PortName;
            port.BaudRate = this.Baudrate;
            port.DataBits = this.DataBits;

            SerialPortBaseData.PortCtxStack.Push(port);
            return port;
        }


    }
}
