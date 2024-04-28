namespace SerialPortManageForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.dataBitsLabel = new System.Windows.Forms.Label();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.endBtn = new System.Windows.Forms.Button();
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.labelSerialPortMes = new System.Windows.Forms.Label();
            this.dataBoxDisWeigth = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelQRCodeScanner = new System.Windows.Forms.Label();
            this.textBoxQRScanner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelScanQRVaild = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(131, 33);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(56, 20);
            this.comboBoxCOMPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(70, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "端口：";
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baudRateLabel.Location = new System.Drawing.Point(210, 37);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(71, 16);
            this.baudRateLabel.TabIndex = 3;
            this.baudRateLabel.Text = "波特率：";
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Location = new System.Drawing.Point(287, 33);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(69, 20);
            this.baudRateComboBox.TabIndex = 4;
            // 
            // dataBitsLabel
            // 
            this.dataBitsLabel.AutoSize = true;
            this.dataBitsLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataBitsLabel.Location = new System.Drawing.Point(376, 37);
            this.dataBitsLabel.Name = "dataBitsLabel";
            this.dataBitsLabel.Size = new System.Drawing.Size(71, 16);
            this.dataBitsLabel.TabIndex = 5;
            this.dataBitsLabel.Text = "数据位：";
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Location = new System.Drawing.Point(453, 33);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(47, 20);
            this.dataBitsComboBox.TabIndex = 6;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(536, 31);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 7;
            this.startBtn.Text = "连接";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // endBtn
            // 
            this.endBtn.Location = new System.Drawing.Point(631, 30);
            this.endBtn.Name = "endBtn";
            this.endBtn.Size = new System.Drawing.Size(75, 23);
            this.endBtn.TabIndex = 8;
            this.endBtn.Text = "关闭";
            this.endBtn.UseVisualStyleBackColor = true;
            this.endBtn.Click += new System.EventHandler(this.endBtn_Click);
            // 
            // DataTextBox
            // 
            this.DataTextBox.AcceptsReturn = true;
            this.DataTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataTextBox.Location = new System.Drawing.Point(47, 123);
            this.DataTextBox.Multiline = true;
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.ReadOnly = true;
            this.DataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTextBox.Size = new System.Drawing.Size(166, 250);
            this.DataTextBox.TabIndex = 9;
            this.DataTextBox.WordWrap = false;
            // 
            // labelSerialPortMes
            // 
            this.labelSerialPortMes.AutoSize = true;
            this.labelSerialPortMes.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerialPortMes.Location = new System.Drawing.Point(44, 94);
            this.labelSerialPortMes.Name = "labelSerialPortMes";
            this.labelSerialPortMes.Size = new System.Drawing.Size(87, 16);
            this.labelSerialPortMes.TabIndex = 11;
            this.labelSerialPortMes.Text = "端口消息：";
            // 
            // dataBoxDisWeigth
            // 
            this.dataBoxDisWeigth.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataBoxDisWeigth.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataBoxDisWeigth.Location = new System.Drawing.Point(260, 123);
            this.dataBoxDisWeigth.Name = "dataBoxDisWeigth";
            this.dataBoxDisWeigth.ReadOnly = true;
            this.dataBoxDisWeigth.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.dataBoxDisWeigth.Size = new System.Drawing.Size(274, 129);
            this.dataBoxDisWeigth.TabIndex = 12;
            this.dataBoxDisWeigth.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(257, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "当前重量：";
            // 
            // labelQRCodeScanner
            // 
            this.labelQRCodeScanner.AutoSize = true;
            this.labelQRCodeScanner.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelQRCodeScanner.Location = new System.Drawing.Point(257, 266);
            this.labelQRCodeScanner.Name = "labelQRCodeScanner";
            this.labelQRCodeScanner.Size = new System.Drawing.Size(87, 16);
            this.labelQRCodeScanner.TabIndex = 14;
            this.labelQRCodeScanner.Text = "条码信息：";
            // 
            // textBoxQRScanner
            // 
            this.textBoxQRScanner.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxQRScanner.Location = new System.Drawing.Point(260, 294);
            this.textBoxQRScanner.Name = "textBoxQRScanner";
            this.textBoxQRScanner.Size = new System.Drawing.Size(274, 35);
            this.textBoxQRScanner.TabIndex = 15;
            this.textBoxQRScanner.TextChanged += new System.EventHandler(this.textBoxQRScanner_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(540, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 16;
            // 
            // labelScanQRVaild
            // 
            this.labelScanQRVaild.AutoSize = true;
            this.labelScanQRVaild.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanQRVaild.ForeColor = System.Drawing.Color.Black;
            this.labelScanQRVaild.Location = new System.Drawing.Point(539, 302);
            this.labelScanQRVaild.Name = "labelScanQRVaild";
            this.labelScanQRVaild.Size = new System.Drawing.Size(28, 19);
            this.labelScanQRVaild.TabIndex = 17;
            this.labelScanQRVaild.Text = "👀";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelScanQRVaild);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxQRScanner);
            this.Controls.Add(this.labelQRCodeScanner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataBoxDisWeigth);
            this.Controls.Add(this.labelSerialPortMes);
            this.Controls.Add(this.DataTextBox);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.dataBitsComboBox);
            this.Controls.Add(this.dataBitsLabel);
            this.Controls.Add(this.baudRateComboBox);
            this.Controls.Add(this.baudRateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCOMPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.Label dataBitsLabel;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button endBtn;
        private System.Windows.Forms.TextBox DataTextBox;
        private System.Windows.Forms.Label labelSerialPortMes;
        private System.Windows.Forms.RichTextBox dataBoxDisWeigth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelQRCodeScanner;
        private System.Windows.Forms.TextBox textBoxQRScanner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelScanQRVaild;
    }
}

