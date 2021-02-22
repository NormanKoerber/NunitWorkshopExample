using NUnit.Framework;
using NUnitWorkshopExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitWorkshopExample.Tests
{
    [TestFixture]
    public class PowerSupplyTests
    {
        [Test]
        public void ConstructorShouldThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new PowerSupply(null));
            Assert.That(ex.ParamName, Is.EqualTo("port"));
        }

        [Test]
        public void ConstructorShouldOpenPort()
        {
            var serialPort = new MockSerialPort();

            var powerSupply = new PowerSupply(serialPort);

            Assert.That(serialPort.IsOpen);
        }

        [Test]
        public void WritesVoltageValueCorrectToSerialPort()
        {
            var serialPort = new MockSerialPort();
            var powerSupply = new PowerSupply(serialPort);

            powerSupply.SetVoltage(13.7);

            Assert.That(serialPort.LastWrittenLine, Is.EqualTo("SV137"));
        }

        [Test]
        public void WhenPowerSupplyReturnAnErrorAnErrorNumberExcaptionIsThrown()
        {
            const string ErrorReturnValue = "1";
            var serialPort = new MockSerialPort() { ReadLineData = ErrorReturnValue };
            var powerSupply = new PowerSupply(serialPort);

            Assert.Throws<ErrorNumberException>(() => powerSupply.SetVoltage(13.4));
        }
    }
}
