using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    class AlgoServiceTests
    {
        IAlgoService _algoService;

        //This method run before executing any of the tests in a fixture
        [OneTimeSetUp]
        public void TestSetup()
        {
            _algoService = new AlgoService();
        }

        [Test]
        public void Double_numbers_When_Method_execute_Then_get_double_value()
        {
            // Arrange
            int expectedValue = 330;
            IEnumerable<int> i = new List<int> { 20, 34, 97, 14 };
            var arr = i.ToArray();

            // Act
            var doubleValue = _algoService.DoubleSum(arr);

            // Assert
            Assert.That(doubleValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MinValue_When_Method_execute_Then_get_minimum_value()
        {
            // Arrange
            int expectedValue = 9;
            IEnumerable<int> i = new List<int> { 50, 9, 11, 100 };
            var arr = i.ToArray();

            // Act
            var minValue = _algoService.MinValue(arr);

            // Assert
            Assert.That(minValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Function_When_Method_execute_Then_get_correct_result()
        {
            // Arrange
            double expectedValue = 108.7718968139325;
            int a = 5, c = 7;
            double d = 4.7, b = 91.5;

            // Act
            var doubleValue = _algoService.Function(a, b, c, d);

            // Assert
            Assert.That(doubleValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetAverage_When_Method_execute_Then_get_Average_value()
        {
            // Arrange
            double expectedValue = 21.25;
            IEnumerable<int> i = new List<int> { 10, 15, 25, 35 };
            var value = i.ToArray();

            // Act
            var avgValue = _algoService.GetAverage(value);

            // Assert
            Assert.That(avgValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Math_Pow_value_When_Method_execute_Then_get_correct_result()
        {
            // Arrange
            int expectedValue = 10000;
            int data = 100;

            // Act
            var value = _algoService.Sqr(data);

            // Assert
            Assert.That(value, Is.EqualTo(expectedValue));
        }

        //This method run after executing all the tests in a fixture
        [OneTimeTearDown]
        public void TestTearDown()
        {
            _algoService = null;
        }
    }
}
