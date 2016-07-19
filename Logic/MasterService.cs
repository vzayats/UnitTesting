using System;
using System.Linq;

namespace Logic
{
    public class MasterService : IMasterService
    {
        private readonly IAlgoService _algoService;

        private readonly IDataService _dataService;
        
        public MasterService(IAlgoService algo, IDataService data)
        {
            _algoService = algo;
            _dataService = data;
        }

        public int GetDoubleSum()
        {
            var data = _dataService.GetAllData();
            if (data == null || !data.Any())
            {
                throw new InvalidOperationException("We have no data to process");
            }

            return _algoService.DoubleSum(data);;
        }

        //TODO: Make more methods
        public double GetMinValue()
        {
            var data = _dataService.GetAllData();
            if (data == null || !data.Any())
            {
                throw new InvalidOperationException("We have no data to process");
            }
            return _algoService.MinValue(data);
        }

        public double FunctionGetMaxElementAt()
        {
            int a = _dataService.GetMax();
            int b = _dataService.GetElementAt(a);

            if (a <= 0)
            {
                throw new IndexOutOfRangeException("Value A can't be equal zero or less!");
            }
            if (b > 5)
            {
                throw new IndexOutOfRangeException("Value B can't be more than 5!");
            }

            return _algoService.Function(a, b, a, b);
        }

        public double SquarefromGetElementAt()
        {
            var data = _dataService.GetAllData();
            var minimumValue = _algoService.MinValue(data);
            int a = _dataService.GetElementAt(minimumValue);
            if (a <= 100)
            {
                throw new IndexOutOfRangeException("Value can't be less than 100!");
            }
            return _algoService.Sqr(a);
        }

        public double GetAverage()
        {
            var data = _dataService.GetAllData();
            return _algoService.GetAverage(data);
        }

        public double GetMaxSquare()
        {
            var data = _dataService.GetMax();
            return _algoService.Sqr(data);
        }
    }
}