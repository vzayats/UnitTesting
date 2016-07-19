using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    class AlgoServiceTests
    {
        private IAlgoService _algoService;

        //This method run before executing any of the tests in a fixture
        [OneTimeSetUp]
        public void TestSetup()
        {
            _algoService = new AlgoService();
        }

        [Test]
        public void DoubleSum_When_try_doubleSum_null_value_Then_return_System_ArgumentNullException()
        {
            // Arrange
            IEnumerable<int> i = null;

            // Assert
            Assert.Throws(typeof(ArgumentNullException), () => new AlgoService().DoubleSum(i));
        }

        [Test]
        public void DoubleSum_When_try_doubleSum_empty_list_Then_return_0_value()
        {
            //Arrange
            int expectedValue = 0;
            IEnumerable<int> i = new List<int> { };

            ////Act
            int doubleValue = _algoService.DoubleSum(i);

            //Assert
            Assert.That(doubleValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void DoubleSum_When_method_execute_Then_return_correct_double_value()
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
        public void MinValue_When_minValue_null_value_Then_return_System_ArgumentNullException()
        {
            // Arrange
            IEnumerable<int> i = null;

            // Assert
            Assert.Throws(typeof(ArgumentNullException), () => new AlgoService().MinValue(i));
        }

        [Test]
        public void MinValue_When_minValue_empty_list_Then_return_System_InvalidOperationException()
        {
            //Arrange
            IEnumerable<int> i = new List<int> { };

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => new AlgoService().MinValue(i));
        }

        [Test]
        public void MinValue_When_Method_execute_Then_return_minimum_value()
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
        public void Function_When_passing_nagative_parameter_Then_return_not_a_number()
        {
            // Arrange
            int a = 10, c = 10;
            double d = 10, b = -100;

            // Act
            var doubleValue = _algoService.Function(a, b, c, d);

            // Assert
            Assert.IsNaN(doubleValue);
        }

        [Test]
        public void GetAverage_When_average_empty_list_Then_return_System_InvalidOperationException()
        {
            //Arrange
            IEnumerable<int> i = new List<int> { };

            //Assert
            Assert.Throws(typeof(InvalidOperationException), () => new AlgoService().GetAverage(i));
        }

        [Test]
        public void GetAverage_When_method_execute_Then_return_correct_average_result()
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
        public void Math_Pow_maximum_integer_value_When_Method_execute_Then_return_correct_double_value()
        {
            // Arrange
            double expectedValue = double.MaxValue;
            int data = int.MaxValue;

            // Act
            var value = _algoService.Sqr(data);

            // Assert
            Assert.Less(value, expectedValue);
        }

        [Test]
        public void Math_Pow_value_When_Method_execute_Then_return_correct_result()
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
