using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FastReport;

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

        public void RegisterQRCodeImg()
        {
            //pass
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

        public void Print() {
            _rp.PrintSettings.ShowDialog = false;
            _rp.Prepare();
            _rp.ShowPrepared();
            //_rp.Print();
        }
    }

}
