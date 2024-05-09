using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO.Ports;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace SerialPortManageForm
{
    public enum Units { 
        T,
        KG,
        G
    }
    public enum WeigthTypes { 
        GROSS,  //毛重
        NET //净重
    }

    internal class Weight {
        public readonly double Number;
        public readonly Units Unit;
        public readonly WeigthTypes WeigthType;
        public Weight(double Number, Units Unit, WeigthTypes WeigthType) {
            this.Number = Number;
            this.Unit = Unit;
            this.WeigthType = WeigthType;
        }

        public static Weight Decode(byte[] data)
        {
            if (!data.Length.Equals(SerialPortRecDataTranslator.PACK_LENGTH))
                throw new InvalidOperationException("data is invalid, decode failed.");

            return new Weight(
                    ParseNumber(data),
                    ParseUnits(data),
                    ParseWeigthType(data)
                );

        }

        public static double ParseNumber(byte[] data)
        {
            if (!data.Length.Equals(SerialPortRecDataTranslator.PACK_LENGTH))
                throw new InvalidOperationException("param is invalid, Parse failed.");

            int begin_idx = SerialPortRecDataTranslator.NUM_BEGIN_IDX;
            int end_idx = SerialPortRecDataTranslator.NUM_END_IDX;
            byte[] target = new byte[SerialPortRecDataTranslator.NUM_LENGTH];
            //copy
            int target_idx = 0;
            for (int i = begin_idx; i <= end_idx; i++)
                target[target_idx++] = data[i];
            string num_text = Encoding.ASCII.GetString(target);
            
            return Convert.ToDouble(num_text);   
        }

        public static Units ParseUnits(byte[] data)
        {
            if (!data.Length.Equals(SerialPortRecDataTranslator.PACK_LENGTH))
                throw new InvalidOperationException("param is invalid, Parse failed.");
            
            int begin_idx = SerialPortRecDataTranslator.UNIT_BEGIN_IDX;
            int end_idx = SerialPortRecDataTranslator.UNIT_END_IDX;
            byte[] target = new byte[SerialPortRecDataTranslator.UNIT_LENGTH];
            int target_idx = 0;
            for (int i = begin_idx; i <= end_idx; i++)
                target[target_idx++] = data[i];
            if (target[0].Equals(SerialPortRecDataTranslator.UNIT_T_SYMBOL_1) &&
                target[1].Equals(SerialPortRecDataTranslator.UNIT_T_SYMBOL_2))
            {
                return Units.T;
            }
            else if (target[0].Equals(SerialPortRecDataTranslator.UNIT_KG_SYMBOL_1) &&
                     target[1].Equals(SerialPortRecDataTranslator.UNIT_KG_SYMBOL_2))
            {
                return Units.KG;
            }
            else if (target[0].Equals(SerialPortRecDataTranslator.UNIT_G_SYMBOL_1) &&
                     target[1].Equals(SerialPortRecDataTranslator.UNIT_G_SYMBOL_2))
            {
                return Units.G;
            }
            else { throw new InvalidOperationException("no match Units type, parse failed."); }
        }

        public static WeigthTypes ParseWeigthType(byte[] data)
        {
            if (!data.Length.Equals(SerialPortRecDataTranslator.PACK_LENGTH))
                throw new InvalidOperationException("param is invalid, Parse failed.");

            if (data[SerialPortRecDataTranslator.WEIGTH_TYPE_IDX]
                .Equals(SerialPortRecDataTranslator.WEIGTH_TYPE_N_SYMBOL))
                return WeigthTypes.NET;
            else if (data[SerialPortRecDataTranslator.WEIGTH_TYPE_IDX]
                     .Equals(SerialPortRecDataTranslator.WEIGTH_TYPE_G_SYMBOL))
                return WeigthTypes.GROSS;
            else
                throw new InvalidOperationException("no match WeigthType, parse failed.");
        }
        override public string ToString()
        {
            return $"<Weigth {this.Number} {this.Unit} {this.WeigthType}>";
        }

    }
    
    internal class WeightStack
    {
        private static List<Weight> _buf = new List<Weight>();
        private static int MAX_LENGTH = 1024;

        public void Push(Weight d)
        {
            if (_buf.Count >= MAX_LENGTH)
                _buf.Clear();

            _buf.Add(d);
        }
        public Weight Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty, `Pop` function is disable.");
            }
            Weight weight = _buf[_buf.Count - 1];
            _buf.RemoveAt(_buf.Count - 1);

            return weight;
        }
        public bool IsEmpty()
        {
            return _buf.Count == 0;
        }
        public Weight Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty, `Peek` function is disable.");
            }
            return _buf[_buf.Count - 1];
        }
    }
}
