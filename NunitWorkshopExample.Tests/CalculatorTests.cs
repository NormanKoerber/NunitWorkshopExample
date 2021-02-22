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
    public class CalculatorTests
    {
        [Test]
        public void AddShouldReturnCorrectResult()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int sum = calculator.Add(23, 34);

            // Assert
            Assert.That(sum, Is.EqualTo(57));
            // Assert.AreEqual(57, sum);
        }

        [Test]
        public void AddWithOverflowShouldThrowAnOverflowException()
        {
            var calculator = new Calculator();

            Assert.That(() => calculator.Add(int.MaxValue, 10), Throws.InstanceOf<OverflowException>());
        }


        [Test]
        public void AddWithNegativeOverflowShouldThrowAnOverflowException()
        {
            var calculator = new Calculator();

            Assert.That(() => calculator.Add(int.MinValue, -10), Throws.InstanceOf<OverflowException>());
        }
    }
}
