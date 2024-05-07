using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Ports;
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

    }
    
    internal class WeightStack
    {
        private static List<Weight> _buf;
        private static bool _AllowWrite = false;

        public void Push(Weight d)
        {
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
