using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.IO.Ports;
using System.Globalization;
using System.IO;

namespace Demeter
{
    public partial class frmDemeter : Form
    {
        Protocol _Protocol = new Protocol();
        SerialPort _spSerial = new SerialPort();
        Connector _Connection;

        System.Timers.Timer _trReader = new System.Timers.Timer();
        System.Timers.Timer _trAlarm = new System.Timers.Timer();

        bool _isPolling = false;
        int _readingCount;
        System.Globalization.CultureInfo _CultureInfo;
        double _LastReading = 0;


        List<SampleData> lSamples = new List<SampleData>();

        #region GUI Delegate Declarations
        public delegate void GUIDelegate(string paramString, string spH, double dPh);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        public frmDemeter()
        {
            InitializeComponent();
            LoadListboxes();

            _Connection = new Connector("10.10.10.1", "demeter", "root", "admin");

            _trReader.Elapsed += new ElapsedEventHandler(_trReader_Elapsed);

            _trAlarm.Enabled = true;
            _trAlarm.Interval = 300;
            _trAlarm.AutoReset = true;
            _trAlarm.Elapsed += new ElapsedEventHandler(_trAlarm_Elapsed);

            _CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;            
        }

        Color _actualPHColor = Color.White;
        void _trAlarm_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (chkAlarmFlash.Checked)
            {
                if (txtPH.BackColor != Color.Green)
                    txtPH.BackColor = (txtPH.BackColor != Color.White) ? Color.White : _actualPHColor;
            }

            if (chkAlarmBeep.Checked)
            {
                if (txtPH.BackColor == Color.Red)
                    Console.Beep();

                if (txtPH.BackColor == Color.Yellow && _actualPHColor == Color.Yellow)
                    Console.Beep();
            }
        }

        #region Delegate Functions
        public void DoGUIClear()
        {
            if (this.InvokeRequired)
            {
                GUIClear delegateMethod = new GUIClear(this.DoGUIClear);
                this.Invoke(delegateMethod);
            }
            else
                this.lstReadings.Items.Clear();
        }
        public void DoGUIStatus(string paramString)
        {
            if (this.InvokeRequired)
            {
                GUIStatus delegateMethod = new GUIStatus(this.DoGUIStatus);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
                this.lblStatus.Text = paramString;
        }
        public void DoGUIUpdate(string paramString, string sPH, double dPH)
        {
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { paramString, sPH, dPH });
            }
            else
            {
                this.lstReadings.Items.Add(paramString);
                this.txtPH.Text = sPH;

                _LastReading = dPH;
                _CheckAlarm(_LastReading);
            }

        }

        private void _CheckAlarm(double dPH)
        {
            if (dPH == 0)
            {
                _actualPHColor = txtPH.BackColor = Color.White;
                return;
            }

            if (dPH <= (double)nudAlarmMin.Value || dPH >= (double)nudAlarmMax.Value)
            {
                _actualPHColor = txtPH.BackColor = Color.Red;

            }
            else if (dPH <= (double)nudAlertLow.Value || dPH >= (double)nudAlertHigh.Value)
            {
                _actualPHColor= txtPH.BackColor = Color.Yellow;
            }
            else
            {
                _actualPHColor = txtPH.BackColor = Color.Green;
            }

        }
        #endregion

        #region Timer Elapsed Event Handler
        void _trReader_Elapsed(object sender, ElapsedEventArgs e)
        {
            _PollFunction();
        }
        #endregion

        #region Load Listboxes
        private void LoadListboxes()
        {
            //Three to load - ports, baudrates, datetype.  Also set default textbox values:
            //1) Available Ports:
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                lstPorts.Items.Add(port);
            }

            lstPorts.SelectedIndex = 0;

            //2) Baudrates:
            string[] baudrates = { "9600", "4800", "2400", "1200", "600", "300", "110" };

            foreach (string baudrate in baudrates)
            {
                lstBaudrate.Items.Add(baudrate);
            }

            lstBaudrate.SelectedIndex = 0;
        }
        #endregion

        #region Start and Stop Procedures
        private void StartPoll()
        {
            _readingCount = 0;

            //Open COM port using provided settings:
            if (_Protocol.Open(lstPorts.SelectedItem.ToString(), Convert.ToInt32(lstBaudrate.SelectedItem.ToString()), 8, Parity.None, StopBits.One))
            {
                //Disable double starts:
                btnStart.Enabled = false;

                //Set polling flag:
                _isPolling = true;

                //Start timer using provided values:
                _trReader.AutoReset = true;
                if (nudInterval.Value != 0)
                    _trReader.Interval = (double)nudInterval.Value * 1000;
                else
                    _trReader.Interval = 1000;
                
                _trReader.Start();
                _trReader_Elapsed(this, null);
            }

            lblStatus.Text = _Protocol.Status;
        }
        private void StopPoll()
        {
            //Stop timer and close COM port:
            _isPolling = false;
            _trReader.Stop();
            _Protocol.Close();

            btnStart.Enabled = true;

            lblStatus.Text = _Protocol.Status;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartPoll();
            _trAlarm.Start();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPoll();
            _trAlarm.Stop();
        }
        #endregion

        #region Poll Function
        private void _PollFunction()
        {
            //Update GUI:
            //DoGUIClear();
            _readingCount++;
            DoGUIStatus("Reading # " + _readingCount.ToString());

            string[] sep = new string[] { "\r\n" };
            string response = "++++", sph = "NA";
            double dPh = 0;
            //Read registers and display data in desired format:
            try
            {
                response = _Protocol.SendRemoteString("#1");

                string[] sSplits;

                sSplits = response.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in sSplits)
                {
                    SampleData oSD = ParseSample(item);
                    if (oSD != null)
                    {
                        response = String.Format("pH {0:0.000} - {1:0.000} C - {2:d/M/yyyy HH:mm:ss}", oSD.Data, oSD.id, oSD.TimeStampDevice);
                        sph = oSD.Data.ToString("0.000");
                        dPh = oSD.Data;

                        lSamples.Add(oSD);
                        _Connection.RegistraLeitura(oSD);

                        DoGUIUpdate(DateTime.Now.ToString("HH:mm:ss") + " - " + response, sph, dPh);

                    }
                }
            }
            catch(Exception err)
            {
                DoGUIStatus("Error in reading: " + err.Message);
            }
        }
        #endregion

        #region Write Function
        private void btnSendKeystroke_Click(object sender, EventArgs e)
        {
            SendKeystroke();
        }
        
        private void SendKeystroke()
        {
            StopPoll();

            if (txtKeystroke.Text != "")
            {
                String response;
                try
                {
                    response = _Protocol.SendRemoteKeystroke(txtKeystroke.Text[0]);
                    DoGUIUpdate("SendKeystroke: " + txtKeystroke.Text[0] + "; Response: " + response, "NA", 0);
                }
                catch (Exception err)
                {
                    DoGUIStatus("Error in SendKeystroke function: " + err.Message);
                }
                DoGUIStatus(_Protocol.Status);
            }
            else
                DoGUIStatus("Enter all fields before attempting a write");

            StartPoll();
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnStop_Click(this, null);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (*.csv)|*.csv";
            sfd.FileName = "phMeter_" + DateTime.Now.ToString("yyMMdd_HHmm") + ".csv";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            _ExportToFileCSV(lSamples, sfd.FileName);
        }

        private void AlarmValuesChanged(object sender, EventArgs e)
        {
            this.nudAlertHigh.Maximum = this.nudAlarmMax.Value;
            this.nudAlertHigh.Minimum = this.nudAlertLow.Value;

            this.nudAlertLow.Maximum = this.nudAlertHigh.Value;
            this.nudAlertLow.Minimum = this.nudAlarmMin.Value;

            _CheckAlarm(_LastReading);
        }



        //# n sensor + id do sensor + 16bits
        private SampleData ParseSample(string sSample)
        {
            SampleData sSD;
            string[] sSplits;
            char[] sep = new char[] { '+' };
            if (sSample == null)
                return null;

            sSplits = sSample.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            //if (!sSplits[0].Contains("Sample"))
            //    return null;

            double dData;
            int id, idtype;

            if (!int.TryParse(sSplits[1], out id))
                return null;

            if (!int.TryParse(sSplits[2], out idtype))
                return null;

            if (!Double.TryParse(sSplits[3], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out dData))
                return null;

            sSD = new SampleData(id, idtype, dData, DateTime.Now);

            return sSD;
        }

        private void _ExportToFileCSV(List<SampleData> ldata, string path)
        {
            TextWriter tw = new StreamWriter(path);

            //Header
            tw.WriteLine("DeviceDate;DeviceTime;HostDate;HostTime;pH;Temperature");


            string line;
            foreach (SampleData sample in ldata)
            {
                // Session Start
                line =  
                        sample.TimeStampDevice.ToString("d/M/yyyy") + ";" +
                        sample.TimeStampDevice.ToString("HH:mm:ss") + ";" +
                        sample.TimeStampHost.ToString("d/M/yyyy") + ";" +
                        sample.TimeStampHost.ToString("HH:mm:ss") + ";" +
                        sample.Data.ToString(_CultureInfo) + ";" +
                        sample.id.ToString(_CultureInfo);

                tw.WriteLine(line);
            }

            tw.Close();
        }

        private void frmPHmetro_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPoll();
        }

    }

    public class SampleData
    {
        public int id;
        public int idType;
        public double Data;
        public DateTime TimeStampDevice;
        public DateTime TimeStampHost;

        public SampleData(int id, int idType, double data, DateTime TimestampDevice)
        {
            this.Data = data;
            this.id = id;
            this.idType = idType;
            this.TimeStampDevice = TimestampDevice;
            this.TimeStampHost = DateTime.Now;
        }
    }

}