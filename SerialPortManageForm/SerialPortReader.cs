using System;
using System.IO.Ports;
using System.Text;

namespace SerialPortManageForm
{
    internal class SerialPortReader
    {
        public static readonly byte BEGIN_SYMBOL = 0x02;
        public static readonly byte END_SYMBOL1 = 0x0d;
        public static readonly byte END_SYMBOL2 = 0x0a;
        public static readonly int PACK_LENGTH = 17; //完整包的大小占17字节
        public static readonly int STEADY_SIGNAL_IDX = 2;
        public static readonly byte STEADY_SYMBOL = 0x4d;
        static void Test(string[] args)
        {
            try
            {
                SerialPort sp = new SerialPort();
                sp.PortName = "COM5";
                sp.BaudRate = 9600;
                sp.DataBits = 8;
                sp.Open();
                SerialPortReader sReader = new SerialPortReader();

                while (true)
                {
                    string res = sReader.Read(sp);
                    if (!string.IsNullOrEmpty(res))
                        Console.WriteLine(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("finish");
            Console.ReadKey();
        }


        public byte[] Read(SerialPort serialPort)
        {
            int len = serialPort.BytesToRead;//获取可以读取的字节数
            byte[] buff = new byte[len];//创建缓存数据数组
            serialPort.Read(buff, 0, len);//把数据读取到buff数组

            return buff;
        }
    }

}
