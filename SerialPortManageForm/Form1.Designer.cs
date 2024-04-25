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
            this.SuspendLayout();
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(131, 33);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(56, 20);
            this.comboBoxCOMPort.TabIndex = 1;
            this.comboBoxCOMPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
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
            // 
            // DataTextBox
            // 
            this.DataTextBox.Location = new System.Drawing.Point(94, 173);
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.Size = new System.Drawing.Size(249, 21);
            this.DataTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

