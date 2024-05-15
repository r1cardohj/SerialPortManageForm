using SerialPortManageForm.report;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SerialPortManageForm
{
    internal class ScanContentHandler
    {
        private LabelDataModel data;
        private Action<string> sendCallback;
        private FastReport.Preview.PreviewControl previewCtrl;
        private Action<VoidParamReturnVoidFunc> previewCallback;
        private Action<string> setQRScannerInput;
        private string Printer;
        /*
         * 这个构造方法为测试用 打印到窗口预览上
         */
        public ScanContentHandler(string scanContent,
                                  string Printer,
                                  Action<string> sendCallback,
                                  Action<VoidParamReturnVoidFunc> previewCallback,
                                  Action<string> setQRScannerInput,
                                  FastReport.Preview.PreviewControl previewCtrl
                                  )
        {
            this.data = LabelDataModel.ParseFromCodeStr(scanContent);

            this.sendCallback = sendCallback;
            this.previewCallback = previewCallback;
            this.setQRScannerInput = setQRScannerInput;
            this.previewCtrl = previewCtrl; 
            this.Printer = Printer;

        }

        public ScanContentHandler(string scanContent,
                                  string printer,
                                  Action<string> sendCallback)
        {
            this.data = LabelDataModel.ParseFromCodeStr(scanContent);
            this.Printer = printer;
            this.sendCallback = sendCallback;
        }

        public void handle()
        {
            Thread t = new Thread(() => {

                try
                {
                    this.data.SetGrossWeigth(SerialPortBaseData.WeigthStack.Peek().Number);
                    LabelReport report = new LabelReport(this.data.makeDataSet());
                    //report.RegisterPreviewCtrl(previewCtrl);
                    report.RegisterPrinter(this.Printer);
                    report.CreateQRCodeImg(this.data.makeQRCodeText());
                    report.RegisterPreviewCtrl(this.previewCtrl);
                    this.previewCallback(report.Show);
                    Thread.Sleep(0); //切换下线程让主线程先预览
                    report.Print();
                    this.sendCallback($"{DateTime.Now} : 打印成功" + System.Environment.NewLine);
                }
                catch (Exception e)
                {
                    Logger.Error(e.ToString());
                    this.sendCallback($"{DateTime.Now} : 打印失败, {e}" + System.Environment.NewLine);
                }
                finally
                {
                    SerialPortBaseData.WeigthStack.Clear(); //清空体重信息保存栈
                    this.setQRScannerInput(""); //
                }
            });
            t.Start();
        }
    }
}
