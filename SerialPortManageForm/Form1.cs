﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SerialPortManageForm
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer clearScanInputTimer;
        private DateTime lastTextChangeTime;
        public Form1()
        {
            InitializeComponent();
            InitalizeClearScanInputTimmer();
        }
        private void InitalizeClearScanInputTimmer()
        {
            clearScanInputTimer = new System.Windows.Forms.Timer();
            clearScanInputTimer.Interval = 2000;
            clearScanInputTimer.Tick += ClearScanInputTimmer_Tick;
            clearScanInputTimer.Enabled = false;
        }

        private void ClearScanInputTimmer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastTextChangeTime).TotalSeconds >= 2
                && isScanInputErr())
            {
                clearScanInputTimer.Stop();
                textBoxQRScanner.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // init COMPort
            comboBoxCOMPort.Items.AddRange(SerialPortBaseData.GetActivePortNames());
            comboBoxCOMPort.SelectedIndex = 0; //默认选中第一个

            // init BaudRate
            foreach (var i in SerialPortBaseData.BaudRateSet)
            {
                baudRateComboBox.Items.Add(i);
            }
            baudRateComboBox.SelectedItem = SerialPortBaseData.DefaultBaudRate;

            //init DataBits
            foreach (var i in SerialPortBaseData.DataBitsSet)
            {
                dataBitsComboBox.Items.Add(i);
            }
            dataBitsComboBox.SelectedItem = SerialPortBaseData.DefaultDataBits;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            int baudRate, dataBits;
            string portName = comboBoxCOMPort.Text;

            if (int.TryParse(baudRateComboBox.Text, out baudRate) &&
                int.TryParse(dataBitsComboBox.Text, out dataBits)
                )
            {
                if (SerialPortDataVaildator.Vailate(portName, baudRate, dataBits))
                {
                    SerialPortFactory factory = new SerialPortFactory(portName, baudRate, dataBits);
                    SerialPort port = factory.CreateSerialPort();
                    SerialPortHandler handler = new SerialPortHandler(port,
                                                                      this.DataTextBoxRefresh,
                                                                      this.CancelOKOrErrorInfo);
                    handler.handle();
                    this.setConnectDisable(false);
                    textBoxQRScanner.Focus();
                }
                else
                {
                    MessageBox.Show("输入参数异常：输入参数不在给定选择范围内！",
                                    "错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("输入参数异常：波特率和数据位必须是数字！",
                                "错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            

        }


        private void DataTextBoxRefresh(string s) {
            if (DataTextBox.InvokeRequired)
            {
                DataTextBox.Invoke(new Action<string>(DataTextBoxRefresh), s);
            }
            else
            {
                DataTextBox.AppendText(s);
                DataTextBox.ScrollToCaret();
            }
        }

        private void CancelOKOrErrorInfo(bool ret) {
            // todo
            if (!ret)
                MessageBox.Show("工作线程异常终止",
                                "错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("关闭成功！",
                                "successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.setConnectDisable(true);
            }
        }

        private void endBtn_Click(object sender, EventArgs e)
        {
            SerialPortBaseData.workerShouldStop = true;
        }
        private void setConnectDisable(bool ret) { 
            comboBoxCOMPort.Enabled = ret;
            baudRateComboBox.Enabled = ret;
            dataBitsComboBox.Enabled = ret;
            startBtn.Enabled = ret;
        }

        private void textBoxQRScanner_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                if (ScanContentVailator.Vailate(tb.Text))
                {
                    setScanContentOkOrErr(true);
                    clearScanInputTimer.Stop();
                    ScanContentHandler handler = new ScanContentHandler(tb.Text,
                                                                        this.setTextBoxQRScanner,
                                                                        )
                }
                else
                {
                    setScanContentOkOrErr(false);
                    clearScanInputTimer.Start();
                }
            }
        }

        private void setScanContentOkOrErr(bool ret)
        {
            if (ret)
            {
                labelScanQRVaild.Text = "✔";
                labelScanQRVaild.ForeColor = Color.Green;
            }
            else
            { 
                labelScanQRVaild.Text = "❌";
                labelScanQRVaild.ForeColor = Color.Red;
            }
        }

        private bool isScanInputErr()
        {
            return labelScanQRVaild.Text == "❌" 
                && textBoxQRScanner.Text != "";
        }

        private void setTextBoxQRScanner(string s)
        {
            textBoxQRScanner.Text = s;
        }
    }
} 