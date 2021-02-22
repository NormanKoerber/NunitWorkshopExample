using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitWorkshopExample
{
    public class MySerialPort : ISerialPort
    {
        private readonly SerialPort _serialPort;

        public MySerialPort(string port)
        {
            if (string.IsNullOrEmpty(port))
            {
                throw new ArgumentException($"'{nameof(port)}' cannot be null or empty", nameof(port));
            }

            _serialPort = new SerialPort(port);
        }

        public void Open() => _serialPort.Open();

        public string ReadLine() => _serialPort.ReadLine();

        public void WriteLine(string sendData) => _serialPort.WriteLine(sendData);
    }
}
