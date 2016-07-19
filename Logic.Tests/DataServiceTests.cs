using System;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    class DataServiceTests
    {
        IDataService _dataService;
        int capacity = 10;

        //This method run before executing any of the tests in a fixture
        [OneTimeSetUp]
        public void TestSetup()
        {
            _dataService = new DataService(capacity);
        }

        [Test]
        public void DataService_initialize_with_negative_value_Then_return_System_ArgumentOutOfRangeException()
        {
            // Arrange
            int negativeValue = -1;

            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new DataService(negativeValue));
        }

        [Test]
        public void ItemsCount_When_method_execute_Then_returns_number_of_elements()
        {
            // Arrange
            int expectedValue = 2;
            _dataService = new DataService(5);
            _dataService.AddItem(Int32.MaxValue);
            _dataService.AddItem(Int32.MaxValue);

            // Act
            var value = _dataService.ItemsCount;

            // Assert
            Assert.That(value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void AddItem_When_method_execute_Then_add_elements()
        {
            // Arrange
            int expectedValue = 3;

            // Act
            _dataService.AddItem(10);
            _dataService.AddItem(11);
            _dataService.AddItem(12);

            // Assert
            Assert.That(_dataService.ItemsCount, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetElementAt_When_method_execute_Then_get_element_at_index()
        {
            // Arrange
            int expectedValue = 65;

            _dataService = new DataService(5);
            _dataService.AddItem(35);
            _dataService.AddItem(45);
            _dataService.AddItem(55);
            _dataService.AddItem(65);

            // Act
            var valueAtIndex = _dataService.GetElementAt(3);

            // Assert
            Assert.That(valueAtIndex, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetElementAt_with_negative_index_Then_return_System_ArgumentOutOfRangeException()
        {
            // Arrange
            int negativeIndex = -1;

            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _dataService.GetElementAt(negativeIndex));
        }

        [Test]
        public void GetElementAt_When_index_more_then_elements_Then_return_System_ArgumentOutOfRangeException()
        {
            // Arrange
            _dataService.AddItem(16);
            _dataService.AddItem(17);
            _dataService.AddItem(18);
            _dataService.AddItem(19);

            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _dataService.GetElementAt(10));
        }

        [Test]
        public void GetAllData_When_dataService_is_empty_Then_result_іs_empty()
        {
            // Act
            var resultValue = _dataService.GetAllData();

            // Assert
            Assert.IsEmpty(resultValue);
        }

        [Test]
        public void RemoveAt_When_Method_execute_Then_remove_element()
        {
            // Arrange
            int expectedValue = 55;

            _dataService = new DataService(5);
            _dataService.AddItem(35);
            _dataService.AddItem(45);
            _dataService.AddItem(55);
            _dataService.AddItem(65);

            // Act
            _dataService.RemoveAt(1);

            // Assert
            Assert.That(_dataService.GetElementAt(1), Is.EqualTo(expectedValue));
        }

        [Test]
        public void RemoveAt_When_index_more_than_elements_Then_return_System_ArgumentOutOfRangeException()
        {
            // Arrange
            _dataService.AddItem(16);
            _dataService.AddItem(17);
            _dataService.AddItem(18);
            _dataService.AddItem(19);

            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _dataService.RemoveAt(7));
        }

        [Test]
        public void RemoveAt_When_with_negative_index_Then_return_System_ArgumentOutOfRangeException()
        {
            // Arrange
            _dataService.AddItem(16);
            _dataService.AddItem(17);
            _dataService.AddItem(18);
            _dataService.AddItem(19);

            // Assert
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _dataService.RemoveAt(-1));
        }

        [Test]
        public void ClearAll_When_method_execute_Then_clear_all_elements()
        {
            // Arrange
            _dataService.AddItem(16);
            _dataService.AddItem(17);
            _dataService.AddItem(18);
            _dataService.AddItem(19);

            // Act
            _dataService.ClearAll();

            // Assert
            Assert.IsEmpty(_dataService.GetAllData());
        }

        [Test]
        public void GetMax_When_method_execute_Then_get_maximum_value()
        {
            // Arrange
            int expectedValue = 90;

            _dataService.AddItem(50);
            _dataService.AddItem(55);
            _dataService.AddItem(70);
            _dataService.AddItem(90);

            // Act
            int maxValue = _dataService.GetMax();

            // Assert
            Assert.That(maxValue, Is.EqualTo(expectedValue));
        }

        //This method run after executing all the tests in a fixture
        [OneTimeTearDown]
        public void TestTearDown()
        {
            _dataService = null;
        }
    }
}
