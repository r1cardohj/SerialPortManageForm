using System;
using System.Collections.Generic;
using System.Text;

namespace SerialPortManageForm
{
    internal class SerialPortDataVaildator
    {
        public static bool Vailate(string PortName, int Baudrate, int DataBits)
        { 
            return IsActivePortName(PortName) &&
                 IsAllowedBaudrate(Baudrate) &&
                 IsAllowedDataBits(DataBits);
        }

        public static bool IsActivePortName(string PortName)
        {
            return Array.Exists(SerialPortBaseData.GetActivePortNames(), 
                v => v.Equals(PortName));
        }
        public static bool IsAllowedBaudrate(int Baudrate)
        {
            return Array.Exists(SerialPortBaseData.BaudRateSet, 
                v => v.Equals(Baudrate));
        }
        public static bool IsAllowedDataBits(int DataBits)
        {
            return Array.Exists(SerialPortBaseData.DataBitsSet,
                v => v.Equals(DataBits));
        }
    }
}
