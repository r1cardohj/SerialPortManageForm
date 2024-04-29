using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SerialPortManageForm
{
    internal class WeightBuffer
    {
        private static List<double> _buf;
        private static bool _AllowWrite = false;

        public static void Write(double d)
        {
            _buf.Add(d);
        }

        public static void Open() {
            _AllowWrite = true;
        }
        public static void Close()
        {
            _AllowWrite = false;
        }
        public static void Clear() {
            _buf.Clear();
        }
        public static List<double> GetLastThreeElement() {
            if (_buf.Count < 3)
                throw new InvalidOperationException("buffer length is less than 3.");
            List<double> lastThreeElement = _buf.GetRange(_buf.Count - 3, 3);

            return lastThreeElement;
        }

    }
}
