using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FastReport;
using FastReport.Barcode;

namespace SerialPortManageForm.report
{
    internal class LabelReport
    {
        private FastReport.Report _rp;

        public LabelReport(DataSet ds)
        { 
            _rp = new FastReport.Report();
            _rp.Load(Settings.FRX_TEMPLATE_FILE_PATH);
            _rp.RegisterData(ds);
        }

        public void CreateQRCodeImg(string codeStr)
        {
            var barcodeObj = _rp.FindObject("Barcode1") as BarcodeObject;
            if (barcodeObj != null)
            {
                barcodeObj.Text = codeStr;
                barcodeObj.Barcode = new BarcodeQR();
            }
        }
        /*
         * 测试用用于绑定预览控件
         */
        public void RegisterPreviewCtrl(FastReport.Preview.PreviewControl ctrl) {
            _rp.Preview = ctrl;
        }
        public void RegisterPrinter(string printer) {
            _rp.PrintSettings.Printer = printer;
        }

        public void Show() {
            //_rp.PrintSettings.ShowDialog = false;
            _rp.PrintSettings.ShowDialog = false;
            _rp.Prepare();
            Console.WriteLine(_rp.PrintSettings.Printer);
            _rp.ShowPrepared();
        }
        public void Print() {
            _rp.PrintPrepared();
            _rp.Print();
        }
    }

}
