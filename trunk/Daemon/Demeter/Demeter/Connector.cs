using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Demeter
{
    public class Connector
    {
    	private MySqlConnection mConn;
    	private DataSet mDataSet;

        public Connector(string server, string database, string uid, string pwd)
        {
            mConn = new MySqlConnection("Persist Security Info=False;server="+server+";database="+database+";uid="+uid+";pwd="+pwd);
            mDataSet = new DataSet();

            try
            {
                mConn.Open();
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
            }

        }

        public void Connect()
        {
            try
            {
                mConn.Open();
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString());
            }
        }

        public void Close()
        {
            try
            {
                mConn.Close();
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
            Com.CommandText = "INSERT INTO leiutras (id,idtipo,valor,timestamp) VALUES (@1,@2,@3,@4)";
            Com.Parameters.AddWithValue("@1", oLeitura.id);
            Com.Parameters.AddWithValue("@2", oLeitura.idType);
            Com.Parameters.AddWithValue("@3", oLeitura.Data);
            Com.Parameters.AddWithValue("@4", oLeitura.TimeStampDevice);

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
