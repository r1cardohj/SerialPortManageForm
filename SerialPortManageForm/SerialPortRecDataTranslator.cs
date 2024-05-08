using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SerialPortManageForm
{
    internal class SerialPortRecDataTranslator
    {
        public static readonly byte PACK_BEGIN_SYMBOL = 0x02;
        public static readonly byte PACK_END_SYMBOL1 = 0x0d;
        public static readonly byte PACK_END_SYMBOL2 = 0x0a;
        public static readonly int PACK_LENGTH = 17; //完整包的大小占17字节
        public static readonly int STEADY_SIGNAL_IDX = 2;
        public static readonly byte STEADY_SYMBOL = 0x4d;
        public static readonly int NUM_BEGIN_IDX = 4; //体重数据起始索引
        public static readonly int NUM_END_IDX = 10;
        public static readonly int NUM_LENGTH = 7;
        public static readonly int UNIT_BEGIN_IDX = 11;
        public static readonly int UNIT_END_IDX = 12;
        public static readonly int UNIT_LENGTH = 2;
        public static readonly byte UNIT_T_SYMBOL_1 = 0x74;
        public static readonly byte UNIT_T_SYMBOL_2 = 0x20;
        public static readonly byte UNIT_KG_SYMBOL_1 = 0x6b;
        public static readonly byte UNIT_KG_SYMBOL_2 = 0x67;
        public static readonly byte UNIT_G_SYMBOL_1 = 0x67;
        public static readonly byte UNIT_G_SYMBOL_2 = 0x20;
        public static readonly int WEIGTH_TYPE_IDX = 1;
        public static readonly byte WEIGTH_TYPE_G_SYMBOL = 0x47;    //毛重
        public static readonly byte WEIGTH_TYPE_N_SYMBOL = 0x4e;    //净重


        private bool IsSteadyStatusData(byte[] data)
        {
            return data[STEADY_SIGNAL_IDX].Equals(STEADY_SYMBOL);
        }

        public List<Weight> Translate(byte[] buff)
        {
            //string s = "\u0002GMU0044.58kg00\r\n\u0002GMU0044.57kg00\r\n";

            //byte[] buff = System.Text.Encoding.ASCII.GetBytes(s);
            List<Weight> res = new List<Weight>();
            byte[] pack = new byte[PACK_LENGTH];
            int pack_idx = 0;
            bool isRead = false;
            for (int i = 0; i < buff.Length; i++)
            {
                if (buff[i].Equals(PACK_BEGIN_SYMBOL))
                {
                    if (isRead)
                        Array.Clear(pack, 0, pack.Length);
                    isRead = true;
                }
                else if (buff[i].Equals(PACK_END_SYMBOL1) &&
                         buff[i + 1].Equals(PACK_END_SYMBOL2) &&
                         isRead)
                {

                    isRead = false;
                    pack[pack_idx] = buff[i];
                    pack[pack_idx + 1] = buff[i + 1];
                    pack_idx = 0;
                    if (IsSteadyStatusData(pack))
                    {
                        Weight obj = Weight.Decode(pack);
                        res.Add(obj);
                        Console.WriteLine(obj);
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
