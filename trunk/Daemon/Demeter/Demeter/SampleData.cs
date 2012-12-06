using System;
using System.Collections.Generic;
using System.Text;

namespace Demeter
{
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

        public double CalculaMedida(int idSensorType, double data)
        {    
            if (idSensorType == 3)
            {
                double i;
                i = data*5100/65535;
                i = 0.00211 * i - 0.675;
                return i;
            }
            else return data;
        }
    }
}
