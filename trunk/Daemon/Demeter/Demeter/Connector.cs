using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Demeter
{
    public class Connector
    {
        public bool Connected { get; set; }
    	private MySqlConnection mConn;
    	private DataSet mDataSet;

        public Connector(string server, string database, string uid, string pwd)
        {
            mConn = new MySqlConnection("Persist Security Info=False;server="+server+";database="+database+";uid="+uid+";pwd="+pwd);
            mDataSet = new DataSet();
            Connected = false;

            try
            {
                mConn.Open();
                Connected = true;
            }
            catch (System.Exception e)
            {
                Connected = false;
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
            }

        }

        public void Connect()
        {
            try
            {
                mConn.Open();
                Connected = true;
            }
            catch (System.Exception e)
            {
                Connected = false;
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
            }
        }

        public void Close()
        {
            try
            {
                mConn.Close();
                Connected = false;
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
            }
        }


        public void Reconnect()
        {
            try
            {
                mConn.Close();
                mConn.Open();
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
            }
        }


        public int RegistraLeitura(SampleData oLeitura)
        {
            if (mConn.State != ConnectionState.Open)
                Connect();

            MySqlCommand Com = new MySqlCommand();
            Com.Connection = mConn;
            Com.CommandText = "INSERT INTO sistema_historicosetor (id_modulo,id_sensor,tipo_sensor,valor_medida,data_medida) VALUES (@1,@2,@3,@4,@5)";
            Com.Parameters.AddWithValue("@1", oLeitura.idModule);
            Com.Parameters.AddWithValue("@2", oLeitura.idSensor);
            Com.Parameters.AddWithValue("@3", oLeitura.idSensorType);
            Com.Parameters.AddWithValue("@4", oLeitura.SensorData);
            Com.Parameters.AddWithValue("@5", oLeitura.TimeStampDevice);

            int id;

            try
            {
                MySqlDataReader _reader = Com.ExecuteReader();
                id = (int)Com.LastInsertedId;
                _reader.Dispose();
                Com.Dispose();
                Close();
                return 1;
            }
            catch
            {
                Com.Dispose();
                Close();
                return 0;
            }

        }


    }

}
