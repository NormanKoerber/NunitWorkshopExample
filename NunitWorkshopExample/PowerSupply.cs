using System;
using System.IO.Ports;

namespace NUnitWorkshopExample
{
    internal class PowerSupply
    {
        private readonly ISerialPort _serialPort;

        public PowerSupply(ISerialPort port)
        {
            _serialPort = port ?? throw new ArgumentNullException(nameof(port));
            _serialPort.Open();
        }

        public void SetVoltage(double voltageInVolt)
        {
            if (voltageInVolt < 0.0 || voltageInVolt > 30.0)
                throw new ArgumentOutOfRangeException(nameof(voltageInVolt), $"Voltage must be between {0.0} and {30.0}V.");

            string sendText = string.Format("SV{000}", voltageInVolt * 10);
            _serialPort.WriteLine(string.Format(sendText));
            
            string receivedText = _serialPort.ReadLine();
            int status = int.Parse(receivedText);

            if (status != 0)
                throw new ErrorNumberException(status);
        }
    }

    public class ErrorNumberException : Exception
    {
        public ErrorNumberException(int number) : base($"Error {number} received.")
        {
            Number = number;
        }

        public int Number { get; }
    }
}