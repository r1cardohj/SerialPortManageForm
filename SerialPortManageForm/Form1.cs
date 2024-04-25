using System;
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
        private volatile bool _workerShouldStop = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label1_Click_2(object sender, EventArgs e)
        {

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
                    SerialPortFactory spfactory = new SerialPortFactory(portName,
                                                                        baudRate,
                                                                        dataBits);
                    SerialPort sp = spfactory.CreateSerialPort();
                    Thread t = new Thread(handle);
                    _workerShouldStop = false;
                    t.Start();
                    SerialPortBaseData.WorkerThreads.Push(t);

                    comboBoxCOMPort.Enabled = false;
                    baudRateComboBox.Enabled = false;
                    dataBitsComboBox.Enabled = false;
                    startBtn.Enabled = false;
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

        private void handle() { }; 
    }
}
