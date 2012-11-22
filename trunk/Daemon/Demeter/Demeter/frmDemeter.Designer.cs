namespace Demeter
{
    partial class frmDemeter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbComm = new System.Windows.Forms.GroupBox();
            this.lstBaudrate = new System.Windows.Forms.ComboBox();
            this.lstPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbReading = new System.Windows.Forms.GroupBox();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lstReadings = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grbAlarm = new System.Windows.Forms.GroupBox();
            this.chkAlarmFlash = new System.Windows.Forms.CheckBox();
            this.chkAlarmBeep = new System.Windows.Forms.CheckBox();
            this.nudAlertHigh = new System.Windows.Forms.NumericUpDown();
            this.nudAlertLow = new System.Windows.Forms.NumericUpDown();
            this.nudAlarmMax = new System.Windows.Forms.NumericUpDown();
            this.nudAlarmMin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpCommand = new System.Windows.Forms.GroupBox();
            this.btnSendKeystroke = new System.Windows.Forms.Button();
            this.txtKeystroke = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.Label();
            this.grbComm.SuspendLayout();
            this.grbReading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.grbAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmMin)).BeginInit();
            this.grpCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbComm
            // 
            this.grbComm.Controls.Add(this.lstBaudrate);
            this.grbComm.Controls.Add(this.lstPorts);
            this.grbComm.Controls.Add(this.label2);
            this.grbComm.Controls.Add(this.label1);
            this.grbComm.Location = new System.Drawing.Point(12, 12);
            this.grbComm.Name = "grbComm";
            this.grbComm.Size = new System.Drawing.Size(178, 68);
            this.grbComm.TabIndex = 0;
            this.grbComm.TabStop = false;
            this.grbComm.Text = "Communication:";
            // 
            // lstBaudrate
            // 
            this.lstBaudrate.FormattingEnabled = true;
            this.lstBaudrate.Location = new System.Drawing.Point(90, 40);
            this.lstBaudrate.Name = "lstBaudrate";
            this.lstBaudrate.Size = new System.Drawing.Size(82, 21);
            this.lstBaudrate.TabIndex = 3;
            // 
            // lstPorts
            // 
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.Location = new System.Drawing.Point(90, 13);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(82, 21);
            this.lstPorts.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // grbReading
            // 
            this.grbReading.Controls.Add(this.nudInterval);
            this.grbReading.Controls.Add(this.label3);
            this.grbReading.Location = new System.Drawing.Point(12, 86);
            this.grbReading.Name = "grbReading";
            this.grbReading.Size = new System.Drawing.Size(178, 51);
            this.grbReading.TabIndex = 1;
            this.grbReading.TabStop = false;
            this.grbReading.Text = "Reading";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(90, 19);
            this.nudInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(82, 20);
            this.nudInterval.TabIndex = 1;
            this.nudInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Interval (s):";
            // 
            // lstReadings
            // 
            this.lstReadings.FormattingEnabled = true;
            this.lstReadings.Location = new System.Drawing.Point(207, 108);
            this.lstReadings.Name = "lstReadings";
            this.lstReadings.Size = new System.Drawing.Size(258, 238);
            this.lstReadings.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(207, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(295, 18);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(82, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 356);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(473, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 17);
            this.lblStatus.Text = "Ready";
            // 
            // grbAlarm
            // 
            this.grbAlarm.Controls.Add(this.chkAlarmFlash);
            this.grbAlarm.Controls.Add(this.chkAlarmBeep);
            this.grbAlarm.Controls.Add(this.nudAlertHigh);
            this.grbAlarm.Controls.Add(this.nudAlertLow);
            this.grbAlarm.Controls.Add(this.nudAlarmMax);
            this.grbAlarm.Controls.Add(this.nudAlarmMin);
            this.grbAlarm.Controls.Add(this.label9);
            this.grbAlarm.Controls.Add(this.label6);
            this.grbAlarm.Controls.Add(this.label7);
            this.grbAlarm.Controls.Add(this.label8);
            this.grbAlarm.Enabled = false;
            this.grbAlarm.Location = new System.Drawing.Point(12, 199);
            this.grbAlarm.Name = "grbAlarm";
            this.grbAlarm.Size = new System.Drawing.Size(178, 147);
            this.grbAlarm.TabIndex = 3;
            this.grbAlarm.TabStop = false;
            this.grbAlarm.Text = "Alarm";
            // 
            // chkAlarmFlash
            // 
            this.chkAlarmFlash.AutoSize = true;
            this.chkAlarmFlash.Checked = true;
            this.chkAlarmFlash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlarmFlash.Location = new System.Drawing.Point(95, 125);
            this.chkAlarmFlash.Name = "chkAlarmFlash";
            this.chkAlarmFlash.Size = new System.Drawing.Size(51, 17);
            this.chkAlarmFlash.TabIndex = 0;
            this.chkAlarmFlash.Text = "Flash";
            this.chkAlarmFlash.UseVisualStyleBackColor = true;
            // 
            // chkAlarmBeep
            // 
            this.chkAlarmBeep.AutoSize = true;
            this.chkAlarmBeep.Checked = true;
            this.chkAlarmBeep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlarmBeep.Location = new System.Drawing.Point(28, 125);
            this.chkAlarmBeep.Name = "chkAlarmBeep";
            this.chkAlarmBeep.Size = new System.Drawing.Size(51, 17);
            this.chkAlarmBeep.TabIndex = 9;
            this.chkAlarmBeep.Text = "Beep";
            this.chkAlarmBeep.UseVisualStyleBackColor = true;
            // 
            // nudAlertHigh
            // 
            this.nudAlertHigh.DecimalPlaces = 2;
            this.nudAlertHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAlertHigh.Location = new System.Drawing.Point(90, 97);
            this.nudAlertHigh.Minimum = new decimal(new int[] {
            72,
            0,
            0,
            65536});
            this.nudAlertHigh.Name = "nudAlertHigh";
            this.nudAlertHigh.Size = new System.Drawing.Size(82, 20);
            this.nudAlertHigh.TabIndex = 8;
            this.nudAlertHigh.Value = new decimal(new int[] {
            78,
            0,
            0,
            65536});
            // 
            // nudAlertLow
            // 
            this.nudAlertLow.DecimalPlaces = 2;
            this.nudAlertLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAlertLow.Location = new System.Drawing.Point(90, 71);
            this.nudAlertLow.Maximum = new decimal(new int[] {
            76,
            0,
            0,
            65536});
            this.nudAlertLow.Minimum = new decimal(new int[] {
            72,
            0,
            0,
            65536});
            this.nudAlertLow.Name = "nudAlertLow";
            this.nudAlertLow.Size = new System.Drawing.Size(82, 20);
            this.nudAlertLow.TabIndex = 7;
            this.nudAlertLow.Value = new decimal(new int[] {
            74,
            0,
            0,
            65536});
            this.nudAlertLow.ValueChanged += new System.EventHandler(this.AlarmValuesChanged);
            // 
            // nudAlarmMax
            // 
            this.nudAlarmMax.DecimalPlaces = 2;
            this.nudAlarmMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAlarmMax.Location = new System.Drawing.Point(90, 45);
            this.nudAlarmMax.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudAlarmMax.Name = "nudAlarmMax";
            this.nudAlarmMax.Size = new System.Drawing.Size(82, 20);
            this.nudAlarmMax.TabIndex = 6;
            this.nudAlarmMax.Value = new decimal(new int[] {
            79,
            0,
            0,
            65536});
            this.nudAlarmMax.ValueChanged += new System.EventHandler(this.AlarmValuesChanged);
            // 
            // nudAlarmMin
            // 
            this.nudAlarmMin.DecimalPlaces = 2;
            this.nudAlarmMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAlarmMin.Location = new System.Drawing.Point(90, 19);
            this.nudAlarmMin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudAlarmMin.Name = "nudAlarmMin";
            this.nudAlarmMin.Size = new System.Drawing.Size(82, 20);
            this.nudAlarmMin.TabIndex = 5;
            this.nudAlarmMin.Value = new decimal(new int[] {
            73,
            0,
            0,
            65536});
            this.nudAlarmMin.ValueChanged += new System.EventHandler(this.AlarmValuesChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Alert High:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Alert Low:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Max:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Min:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(383, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(82, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grpCommand
            // 
            this.grpCommand.Controls.Add(this.btnSendKeystroke);
            this.grpCommand.Controls.Add(this.txtKeystroke);
            this.grpCommand.Controls.Add(this.label4);
            this.grpCommand.Location = new System.Drawing.Point(12, 143);
            this.grpCommand.Name = "grpCommand";
            this.grpCommand.Size = new System.Drawing.Size(178, 50);
            this.grpCommand.TabIndex = 2;
            this.grpCommand.TabStop = false;
            this.grpCommand.Text = "Command";
            // 
            // btnSendKeystroke
            // 
            this.btnSendKeystroke.Location = new System.Drawing.Point(121, 18);
            this.btnSendKeystroke.Name = "btnSendKeystroke";
            this.btnSendKeystroke.Size = new System.Drawing.Size(51, 20);
            this.btnSendKeystroke.TabIndex = 3;
            this.btnSendKeystroke.Text = "Send";
            this.btnSendKeystroke.UseVisualStyleBackColor = true;
            this.btnSendKeystroke.Click += new System.EventHandler(this.btnSendKeystroke_Click);
            // 
            // txtKeystroke
            // 
            this.txtKeystroke.Location = new System.Drawing.Point(90, 18);
            this.txtKeystroke.MaxLength = 1;
            this.txtKeystroke.Name = "txtKeystroke";
            this.txtKeystroke.Size = new System.Drawing.Size(25, 20);
            this.txtKeystroke.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Keystroke:";
            // 
            // txtPH
            // 
            this.txtPH.AutoSize = true;
            this.txtPH.BackColor = System.Drawing.Color.White;
            this.txtPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPH.Location = new System.Drawing.Point(207, 55);
            this.txtPH.MinimumSize = new System.Drawing.Size(256, 0);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(256, 46);
            this.txtPH.TabIndex = 7;
            this.txtPH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDemeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 378);
            this.Controls.Add(this.txtPH);
            this.Controls.Add(this.grpCommand);
            this.Controls.Add(this.grbAlarm);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lstReadings);
            this.Controls.Add(this.grbReading);
            this.Controls.Add(this.grbComm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDemeter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Demeter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPHmetro_FormClosing);
            this.grbComm.ResumeLayout(false);
            this.grbComm.PerformLayout();
            this.grbReading.ResumeLayout(false);
            this.grbReading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grbAlarm.ResumeLayout(false);
            this.grbAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlertLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmMin)).EndInit();
            this.grpCommand.ResumeLayout(false);
            this.grpCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbComm;
        private System.Windows.Forms.ComboBox lstBaudrate;
        private System.Windows.Forms.ComboBox lstPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbReading;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstReadings;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.GroupBox grbAlarm;
        private System.Windows.Forms.NumericUpDown nudAlertLow;
        private System.Windows.Forms.NumericUpDown nudAlarmMax;
        private System.Windows.Forms.NumericUpDown nudAlarmMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkAlarmFlash;
        private System.Windows.Forms.CheckBox chkAlarmBeep;
        private System.Windows.Forms.GroupBox grpCommand;
        private System.Windows.Forms.Button btnSendKeystroke;
        private System.Windows.Forms.TextBox txtKeystroke;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAlertHigh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtPH;
    }
}

