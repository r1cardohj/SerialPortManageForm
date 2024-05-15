using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortManageForm.report
{
    internal class LabelDataModel
    {

        private string vendId { get; }
        private string itemId { get;  }
        private string panId { get; }
        private string grossWeigth { get; set; }
        private string tareWeigth { get; }
        private string netWeigth { get; set; }
        private string prodDate { get; }
        private string unit { get; }

        private LabelDataModel(string vendId, 
                               string itemId, 
                               string panId, 
                               string grossWeigth, 
                               string tareWeigth, 
                               string netWeigth,
                               string prodDate,
                               string unit)
        { 
            this.vendId = vendId;
            this.itemId = itemId;
            this.panId = panId; ;
            this.grossWeigth = grossWeigth;
            this.tareWeigth = tareWeigth;
            this.netWeigth =  netWeigth;
            this.prodDate = prodDate;
            this.unit = unit;
        }

        /**
         * 转二维码内容为LabelDataModel对象
         * input:{AD504480-A3A0-4AE2-A96B-565D02CF1AE3}|DQ0133|F0000083|C240403023|217.45|52.6|164.85|2024/03/09|
         * 
         */
        public static LabelDataModel ParseFromCodeStr(string codeStr, Units unit=Units.KG)
        {
            string[] ds = codeStr.Split('|');
            return new LabelDataModel(
                    ds[1],
                    ds[2],
                    ds[3],
                    ds[4],
                    ds[5],
                    ds[6],
                    ds[7],
                    unit.ToString()
                );

        }

        public DataSet makeDataSet()
        {
            DataSet data = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "baseInfo";
            dt.Columns.Add("vendId", typeof(String));
            dt.Columns.Add("itemId", typeof(String));
            dt.Columns.Add("panId", typeof(String));
            dt.Columns.Add("grossWeigth", typeof(String));
            dt.Columns.Add("tareWeigth", typeof(String));
            dt.Columns.Add("netWeigth", typeof(String));
            dt.Columns.Add("prodDate", typeof(String));
            dt.Columns.Add("unit", typeof(String));
            dt.Columns.Add("qrcodeText", typeof(String));

            dt.Rows.Add(new object[] { 
                this.vendId,
                this.itemId,
                this.panId,
                this.grossWeigth,
                this.tareWeigth,
                this.netWeigth,
                this.prodDate,
                this.unit,
                makeQRCodeText()
            });
            data.Tables.Add(dt);

            return data;
        }

        public void SetGrossWeigth(double newGrossWeigth) {
            

            double tw = Double.Parse(this.tareWeigth);

            this.grossWeigth = newGrossWeigth.ToString();
            this.netWeigth = (newGrossWeigth - tw).ToString();
        }
        public string makeQRCodeText() {
            //input: {AD504480-A3A0-4AE2-A96B-565D02CF1AE3}|DQ0133|F0000083|C240403023|217.45|52.6|164.85|2024/03/09|
            return $"{{{Guid.NewGuid()}}}|{this.vendId}|{this.itemId}|{this.panId}|{this.grossWeigth}|{this.tareWeigth}|{this.netWeigth}|{this.prodDate}|";
        }
        
    }
}
