using System;
using System.IO.Ports;
using System.Text;

namespace SerialPortManage
{
    internal class SerialPortReader
    {
        static void Main(string[] args)
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
        public string Read(SerialPort serialPort)
        {
            int len = serialPort.BytesToRead;//获取可以读取的字节数
            byte[] buff = new byte[len];//创建缓存数据数组
            serialPort.Read(buff, 0, len);//把数据读取到buff数组

            return Encoding.Default.GetString(buff);

        }
    }

}
