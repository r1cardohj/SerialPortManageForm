using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace SerialPortManageForm
{
    internal class SerialPortReader
    {

        public byte[] Read(SerialPort serialPort)
        {
            int len = serialPort.BytesToRead;//获取可以读取的字节数
            byte[] buff = new byte[len];//创建缓存数据数
            serialPort.Read(buff, 0, len);//把数据读取到buff数组

            return buff;
        }

        //用于测试
        public byte[] FakeRead(SerialPort serialPort)
        {
            //fake_data = { }
            List<byte[]> lst = new List<byte[]>() {
                Encoding.ASCII.GetBytes("\u0002GMU0044.58kg00\r\n\u0002GMU0044.57kg00\r\n"),
                Encoding.ASCII.GetBytes("\u0002GMU0044.58kg00\r\n\u0002GM"),
                Encoding.ASCII.GetBytes("kg00\r\n\u0002GMU0044.57kg00\r\n"),
                Encoding.ASCII.GetBytes("\u0002GMU0023.58kg00\r\n\u0002GMU0047.58kg00\r\n"),
                Encoding.ASCII.GetBytes("\u0002GMU0025.58kg00\r\n\u0002GM"),
                Encoding.ASCII.GetBytes("kg00\r\n\u0002GMU0021.12kg00\r\n"),
            };
            return randChoice(lst);

        }

        private byte[] randChoice(List<byte[]> lst)
        {
            Random rand = new Random();
            int idx = rand.Next(lst.Count);

            return lst[idx];
        }
    }

}
