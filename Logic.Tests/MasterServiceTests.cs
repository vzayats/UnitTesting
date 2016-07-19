using System;
using System.Linq;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    class MasterServiceTests
    {
        private IMasterService _masterService;
        private IDataService _dataService;
        private IAlgoService _algoService;

        //This method run before executing any of the tests in a fixture
        [OneTimeSetUp]
        public void MasterServiceTestSetup()
        {
            _dataService = new DataService(0);
            _algoService = new AlgoService();
            _masterService = new MasterService(_algoService, _dataService);
        }

        [Test]
        public void GetDoubleSum_When_data_is_null_Then_return_System_InvalidOperationException_with_message()
        {
            _dataService.ClearAll();
            // Assert
            Assert.That(() => _masterService.GetDoubleSum(), Throws.TypeOf<InvalidOperationException>()
                .With.Message.EqualTo("We have no data to process"));
        }

        [Test]
        public void GetDoubleSum_When_method_execute_Then_return_correct_double_value()
        {
            // Arrange
            _dataService.AddItem(10);
            _dataService.AddItem(15);
            _dataService.AddItem(20);

            double expectedValue = _dataService.GetAllData().Sum() * 2;

            // Act
            var data = _masterService.GetDoubleSum();

            // Assert
            Assert.That(data, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetMinValue_When_data_is_null_Then_return_System_InvalidOperationException_with_message()
        {
            _dataService.ClearAll();
            // Assert
            Assert.That(() => _masterService.GetMinValue(), Throws.TypeOf<InvalidOperationException>()
                .With.Message.EqualTo("We have no data to process"));
        }

        [Test]
        public void GetMinValue_When_method_execute_Then_return_correct_minimum_value()
        {
            // Arrange
            _dataService.AddItem(10);
            _dataService.AddItem(15);
            _dataService.AddItem(20);

            double expectedValue = _dataService.GetAllData().Min();

            // Act
            var data = _masterService.GetMinValue();

            // Assert
            Assert.That(data, Is.EqualTo(expectedValue));
        }

        [Test]
        public void FunctionGetMaxElementAt_When_value_outOfRange_Then_return_IndexOutOfRangeException()
        {
            // Arrange
            if (_dataService.ItemsCount == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    _dataService.AddItem(i);
                }
            }

            // Assert
            Assert.That(() => _masterService.FunctionGetMaxElementAt(), Throws.TypeOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Value B can't be more than 5!"));
        }

        [Test]
        public void SquarefromGetElementAt_When_element_is_less_than_100_Then_return_IndexOutOfRangeException()
        {
            _dataService.ClearAll();
            // Arrange
            if (_dataService.ItemsCount == 0)
            {
                for (int i = 0; i < 35; i++)
                {
                    _dataService.AddItem(i);
                }
            }

            // Assert
            Assert.That(() => _masterService.SquarefromGetElementAt(), Throws.TypeOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Value can't be less than 100!"));
        }

        [Test]
        public void GetAverage_When_average_list_is_empty_Then_return_System_InvalidOperationException()
        {
            _dataService.ClearAll();
            // Assert
            Assert.Throws(typeof(InvalidOperationException), () => _masterService.GetAverage());
        }

        [Test]
        public void GetAverage_When_method_execute_Then_return_correct_average_result()
        {
            // Arrange
            double expectedValue = 4.5;

            if (_dataService.ItemsCount == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    _dataService.AddItem(i);
                }
            }

            // Act
            var avgValue = _masterService.GetAverage();

            // Assert
            Assert.That(avgValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetMaxSquare_When_data_is_empty_Then_return_System_InvalidOperationException()
        {
            _dataService.ClearAll();
            // Assert
            Assert.Throws(typeof(InvalidOperationException), () => _masterService.GetMaxSquare());
        }

        [Test]
        public void GetMaxSquare_When_method_execute_Then_return_correct_double_value()
        {
            // Arrange
            double expectedValue = 400;
            if (_dataService.ItemsCount <= 0)
            {
                _dataService.AddItem(10);
                _dataService.AddItem(15);
                _dataService.AddItem(20);
            }

            // Act
            var data = _masterService.GetMaxSquare();

            // Assert
            Assert.That(data, Is.EqualTo(expectedValue));
        }

        //This method run after executing all the tests in a fixture
        [OneTimeTearDown]
        public void TestTearDown()
        {
            _dataService.ClearAll();
            _algoService = null;
            _masterService = null;
        }
    }
}
