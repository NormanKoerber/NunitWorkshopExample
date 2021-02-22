using NUnitWorkshopExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitWorkshopExample.Tests
{
    internal class MockSerialPort : ISerialPort
    {
        public bool IsOpen { get; private set; }
        public string LastWrittenLine { get; private set; }
        public string ReadLineData { get; set; } = "0";

        public void Open()
        {
            IsOpen = true;
        }

        public string ReadLine()
        {
            return ReadLineData;
        }

        public void WriteLine(string sendData)
        {
            LastWrittenLine = sendData;
        }
    }
}
