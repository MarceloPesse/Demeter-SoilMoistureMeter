using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace Demeter
{
    class Protocol
    {
        private SerialPort sp = new SerialPort();
        public string Status;

        #region Constructor / Deconstructor
        public Protocol()
        {
        }
        ~Protocol()
        {
        }
        #endregion

        #region Open / Close Procedures
        public bool Open(string portName, int baudRate, int databits, Parity parity, StopBits stopBits)
        {
            //Ensure port isn't already opened:
            if (!sp.IsOpen)
            {
                //Assign desired settings to the serial port:
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataBits = databits;
                sp.Parity = parity;
                sp.StopBits = stopBits;
                //These timeouts are default and cannot be editted through the class at this point:
                sp.ReadTimeout = 1000;
                sp.WriteTimeout = 1000;
                sp.NewLine = "\r";

                try
                {
                    sp.Open();
                }
                catch (Exception err)
                {
                    Status = "Error opening " + portName + ": " + err.Message;
                    return false;
                }
                Status = portName + " opened successfully";
                return true;
            }
            else
            {
                Status = portName + " already opened";
                return false;
            }
        }
        public bool Close()
        {
            //Ensure port is opened before attempting to close:
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception err)
                {
                    Status = "Error closing " + sp.PortName + ": " + err.Message;
                    return false;
                }
                Status = sp.PortName + " closed successfully";
                return true;
            }
            else
            {
                Status = sp.PortName + " is not open";
                return false;
            }
        }
        #endregion

        #region Get Response
        private String GetResponse()
        {
            //There is a bug in .Net 2.0 DataReceived Event that prevents people from using this
            //event as an interrupt to handle data (it doesn't fire all of the time).  Therefore
            //we have to use the ReadByte command for a fixed length as it's been shown to be reliable.
            //StringBuilder response = new StringBuilder();
            //for (int i = 0; i < 80; i++)
            //{
            //    response.Append((char)sp.ReadByte());
            //}
            //return response.ToString();

            return sp.ReadLine();
        }
        #endregion

        #region Functions

        public String SendRemoteKeystroke(char key)
        {
            //Ensure port is open:
            if (sp.IsOpen)
            {
                //Clear in/out buffers:
                sp.DiscardOutBuffer();
                //sp.DiscardInBuffer();

                //Message is Rc<cr>
                string message = "K" + key + "\r";
                string response;

                //Send message to Serial Port:
                try
                {
                    sp.Write(message);
                    //response = GetResponse();

                    response = sp.ReadExisting();
                }
                catch (Exception err)
                {
                    Status = "Error in write event: " + err.Message;
                    return null;
                }

                Status = "Remote Keystroke successful";
                return response;

            }
            else
            {
                Status = "Serial port not open";
                return null;
            }
        }


        public String SendRemoteString(string message)
        {
            //Ensure port is open:
            if (sp.IsOpen)
            {
                //Clear in/out buffers:
                sp.DiscardOutBuffer();
                //sp.DiscardInBuffer();

                string response;

                //Send message to Serial Port:
                try
                {
                    sp.Write(message);
                    //response = GetResponse();

                    response = sp.ReadExisting();
                }
                catch (Exception err)
                {
                    Status = "Error in write event: " + err.Message;
                    return null;
                }

                Status = "Remote Keystroke successful";
                return response;

            }
            else
            {
                Status = "Serial port not open";
                return null;
            }
        }

        #endregion

    }
}
