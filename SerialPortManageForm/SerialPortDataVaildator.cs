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
            return Array.Exists(SerialPortBaseData.BAUD_RATE_SET, 
                v => v.Equals(Baudrate));
        }
        public static bool IsAllowedDataBits(int DataBits)
        {
            return Array.Exists(SerialPortBaseData.DATA_BITS_SET,
                v => v.Equals(DataBits));
        }
    }
}
