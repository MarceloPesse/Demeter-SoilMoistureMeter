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

        int _readingCount;
        System.Globalization.CultureInfo _CultureInfo;


        List<SampleData> lSamples = new List<SampleData>();

        #region GUI Delegate Declarations
        public delegate void GUIDelegate(string paramString);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        public frmDemeter()
        {
            InitializeComponent();
            LoadListboxes();

            

            _trReader.Elapsed += new ElapsedEventHandler(_trReader_Elapsed);

            _CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;            
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
        public void DoGUIUpdate(string paramString)
        {
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
            {
                this.lstReadings.Items.Add(paramString);
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
            _trReader.Stop();
            _Protocol.Close();

            btnStart.Enabled = true;

            lblStatus.Text = _Protocol.Status;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartPoll();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPoll();
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
            string response = "++++";

            for (int idModule = 1; idModule <= nudModules.Value; idModule++)
            {
                for (int idsensor = 1; idsensor <= 5; idsensor++)
                {
                    string sendstring = "#"+idModule.ToString("00") + ":" + idsensor.ToString();

                    try
                    {
                        response = _Protocol.SendRemoteString(sendstring);

                        string[] sSplits = response.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in sSplits)
                        {
                            SampleData oSD = ParseSample(item);
                            if (oSD != null)
                            {
                                lSamples.Add(oSD);

                                if (_Connection != null)
                                    _Connection.RegistraLeitura(oSD);

                                response = String.Format("#{0:000} : {1:000} : {2:000} : {3:00000}", oSD.idModule, oSD.idSensor, oSD.idSensorType, oSD.SensorData);
                                DoGUIUpdate(DateTime.Now.ToString("HH:mm:ss") + " - " + response);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        DoGUIStatus("Error in reading: " + err.Message);
                    }
                }
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

            if (txtCommand.Text != "")
            {
                String response;
                try
                {
                    response = _Protocol.SendRemoteKeystroke(txtCommand.Text[0]);
                    DoGUIUpdate("SendKeystroke: " + txtCommand.Text[0] + "; Response: " + response);
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


        //#n placa [2] : n sensor[1] : id sensor[2] : dados 16bits[4]
        //#01:1;06:0000
        private SampleData ParseSample(string sSample)
        {
            SampleData sSD;
            string[] sSplits;
            char[] sep = new char[] { ';', ':' };
            if (sSample == null)
                return null;

            sSplits = sSample.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            if (!sSplits[0].StartsWith("#"))
                return null;

            int idPlaca, idSensor, idSensorType, iData;

            if (!int.TryParse(sSplits[0].Replace('#', ' '), out idPlaca))
                return null;

            if (!int.TryParse(sSplits[1], out idSensor))
                return null;

            if (!int.TryParse(sSplits[2], out idSensorType))
                return null;

            if (!int.TryParse(sSplits[3], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out iData))
                return null;

            sSD = new SampleData(idPlaca, idSensor, idSensorType, iData, DateTime.Now);

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
                        sample.SensorData.ToString(_CultureInfo) + ";" +
                        sample.idModule.ToString(_CultureInfo);

                tw.WriteLine(line);
            }

            tw.Close();
        }

        private void frmPHmetro_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPoll();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _Connection = new Connector(txtServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
            if (_Connection.Connected)
                MessageBox.Show("Connected");
        }

    }

    public double CalculaMedida(int idSensorType, double data)
    {    
        if (idSensorType == 3)
        {
            double i;
            i = data*5100/65535;
            i = 0,00211 * i - 0,675;
            return i;
        }
        else return data;
    }

    public class SampleData
    {
        public int idModule;
        public int idSensor;
        public int idSensorType;
        public double SensorData;
        public double CalculatedData;
        public DateTime TimeStampDevice;

        public SampleData(int idModule, int idSensor, int idSensorType, double data, DateTime TimestampDevice)
        {
            this.SensorData = data;
            this.idModule = idModule;
            this.idSensor = idSensor;
            this.idSensorType = idSensorType;
            this.TimeStampDevice = TimestampDevice;
            this.CalculatedData = CalculaMedida(idSensorType, data);
        }
    }

}