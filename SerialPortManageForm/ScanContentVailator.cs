using System;
using System.Collections.Generic;
using System.Text;

namespace SerialPortManageForm
{
    internal class ScanContentVailator
    {
        public static int ELEMENTS_COUNT = 9;
        //input: {AD504480-A3A0-4AE2-A96B-565D02CF1AE3}|DQ0133|F0000083|C240403023|217.45|52.6|164.85|2024/03/09| 
        // 0: guid
        // 1: 供应商代码
        // 2: 物料代码
        // 3: 盘号
        // 4: 毛重
        // 5: 皮重
        // 6：净重
        // 7: 生产日期
        public static bool Vailate(string s)
        {
            string[] arr = s.Split('|');
            return isElementEnough(arr) &&
                   hasGrossWeight(arr) &&
                   hasTareWeight(arr) &&
                   hasNetWeight(arr);
        }

        private static bool isElementEnough(string[] arr)
        {
            return arr.Length == ELEMENTS_COUNT;
        }

        //判断毛重
        private static bool hasGrossWeight(string[] arr)
        {
            double res;
            return Double.TryParse(arr[4],out res);
        }
        private static bool hasTareWeight(string[] arr)
        {
            double res;
            return Double.TryParse(arr[5], out res);
        }
        private static bool hasNetWeight(string[] arr)
        {
            double res;
            return Double.TryParse(arr[6], out res);
        }
    }
}
