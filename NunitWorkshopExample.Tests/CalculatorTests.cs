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

        [TestCase(int.MaxValue, 10, TestName = "AddWithPositiveOverflowShouldThrowAnOverflowException")]
        [TestCase(int.MinValue, -10, TestName = "AddWithNegativeOverflowShouldThrowAnOverflowException")]
        public void AddWithOverflowShouldThrowAnOverflowException(int addend1, int addend2)
        {
            var calculator = new Calculator();

            Assert.That(() => calculator.Add(addend1, addend2), Throws.InstanceOf<OverflowException>());
        }

        [Test]
        public void DivisionWithoutRestShouldReturnCorrectValue()
        {
            var calculator = new Calculator();

            var divisionResult = calculator.Divide(100, 5);

            Assert.That(divisionResult.Value, Is.EqualTo(20));
        }

        [Test]
        public void DivisionWithoutRestShouldReturnCorrectRest()
        {
            var calculator = new Calculator();

            var divisionResult = calculator.Divide(100, 6);

            Assert.That(divisionResult.Rest, Is.EqualTo(4));
        }

        [Test]
        public void DivisionByZeroShoulThrowDivideByZeroException()
        {
            var calculator = new Calculator();

            Assert.Throws<DivideByZeroException>(() => calculator.Divide(100, 0));
        }
    }
}
