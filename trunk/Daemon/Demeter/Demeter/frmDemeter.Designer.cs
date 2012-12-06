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
            this.nudModules = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lstReadings = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grbDatabase = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpCommand = new System.Windows.Forms.GroupBox();
            this.btnSendKeystroke = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.grbComm.SuspendLayout();
            this.grbReading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.grbDatabase.SuspendLayout();
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
            this.grbReading.Controls.Add(this.nudModules);
            this.grbReading.Controls.Add(this.label4);
            this.grbReading.Controls.Add(this.nudInterval);
            this.grbReading.Controls.Add(this.label3);
            this.grbReading.Location = new System.Drawing.Point(12, 86);
            this.grbReading.Name = "grbReading";
            this.grbReading.Size = new System.Drawing.Size(178, 76);
            this.grbReading.TabIndex = 1;
            this.grbReading.TabStop = false;
            this.grbReading.Text = "Reading";
            // 
            // nudModules
            // 
            this.nudModules.Location = new System.Drawing.Point(90, 18);
            this.nudModules.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudModules.Name = "nudModules";
            this.nudModules.Size = new System.Drawing.Size(82, 20);
            this.nudModules.TabIndex = 3;
            this.nudModules.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Modules:";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(90, 44);
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
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Interval (s):";
            // 
            // lstReadings
            // 
            this.lstReadings.FormattingEnabled = true;
            this.lstReadings.Location = new System.Drawing.Point(204, 56);
            this.lstReadings.Name = "lstReadings";
            this.lstReadings.Size = new System.Drawing.Size(258, 316);
            this.lstReadings.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(204, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(292, 18);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 378);
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
            // grbDatabase
            // 
            this.grbDatabase.Controls.Add(this.txtPassword);
            this.grbDatabase.Controls.Add(this.label6);
            this.grbDatabase.Controls.Add(this.txtUser);
            this.grbDatabase.Controls.Add(this.label7);
            this.grbDatabase.Controls.Add(this.txtDatabase);
            this.grbDatabase.Controls.Add(this.label5);
            this.grbDatabase.Controls.Add(this.btnConnect);
            this.grbDatabase.Controls.Add(this.txtServer);
            this.grbDatabase.Controls.Add(this.label8);
            this.grbDatabase.Location = new System.Drawing.Point(12, 224);
            this.grbDatabase.Name = "grbDatabase";
            this.grbDatabase.Size = new System.Drawing.Size(178, 147);
            this.grbDatabase.TabIndex = 3;
            this.grbDatabase.TabStop = false;
            this.grbDatabase.Text = "Database";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(72, 94);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.Text = "demeter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(72, 69);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 8;
            this.txtUser.Text = "demeter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Login:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(72, 43);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtDatabase.TabIndex = 6;
            this.txtDatabase.Text = "demeter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Database:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(90, 120);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(82, 20);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(72, 18);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 2;
            this.txtServer.Text = "127.0.0.1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Server:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(380, 18);
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
            this.grpCommand.Controls.Add(this.txtCommand);
            this.grpCommand.Location = new System.Drawing.Point(12, 168);
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
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(9, 18);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(106, 20);
            this.txtCommand.TabIndex = 2;
            // 
            // frmDemeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 400);
            this.Controls.Add(this.grpCommand);
            this.Controls.Add(this.grbDatabase);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grbDatabase.ResumeLayout(false);
            this.grbDatabase.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbDatabase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox grpCommand;
        private System.Windows.Forms.Button btnSendKeystroke;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudModules;
        private System.Windows.Forms.Label label4;
    }
}

