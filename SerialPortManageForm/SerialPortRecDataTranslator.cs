using System;
using System.Collections.Generic;
using System.Text;

namespace SerialPortManageForm
{
    internal class SerialPortRecDataTranslator
    {
        public static readonly byte BEGIN_SYMBOL = 0x02;
        public static readonly byte END_SYMBOL1 = 0x0d;
        public static readonly byte END_SYMBOL2 = 0x0a;
        public static readonly int PACK_LENGTH = 17; //完整包的大小占17字节
        public static readonly int STEADY_SIGNAL_IDX = 2;
        public static readonly byte STEADY_SYMBOL = 0x4d;

        private bool IsSteadyStatusData(byte[] data)
        {
            return data[STEADY_SIGNAL_IDX].Equals(STEADY_SYMBOL);
        }

        List<byte[]> Translate(byte[] buff)
        {
            //string s = "\u0002GMU0044.58kg00\r\n\u0002GMU0044.57kg00\r\n";

            //byte[] buff = System.Text.Encoding.ASCII.GetBytes(s);
            List<byte[]> res = new List<byte[]>();
            byte[] pack = new byte[PACK_LENGTH];
            int pack_idx = 0;
            bool isRead = false;
            for (int i = 0; i < buff.Length; i++)
            {
                if (buff[i].Equals(BEGIN_SYMBOL))
                {
                    if (isRead)
                        Array.Clear(pack, 0, pack.Length);
                    isRead = true;
                }
                else if (buff[i].Equals(END_SYMBOL1) &&
                         buff[i + 1].Equals(END_SYMBOL2) &&
                         isRead)
                {

                    isRead = false;
                    pack[pack_idx] = buff[i];
                    pack[pack_idx + 1] = buff[i + 1];
                    pack_idx = 0;
                    if (IsSteadyStatusData(pack))
                    {
                        byte[] data = new byte[PACK_LENGTH];
                        for (int j = 0; j < pack.Length; j++)
                            data[j] = pack[j];
                        res.Add(data);
                        Console.WriteLine(BitConverter.ToString(data));
                    }
                    Array.Clear(pack, 0, pack.Length);

                }
                if (isRead)
                    pack[pack_idx++] = buff[i];
                

            }
            return res;
        }


    }
}
