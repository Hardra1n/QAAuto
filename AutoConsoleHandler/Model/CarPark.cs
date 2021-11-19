using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoConsoleHandler.Model
{
    public class CarPark
    {
        List<CarGroup> _carGroups = new List<CarGroup>();

        static CarPark _carPark;

        private CarPark() { }

        public static CarPark GetInstance()
        {
            if (_carPark == null)
            {
                _carPark = new CarPark();
            }

            return _carPark;
        }

        public void AddCarGroup(string mark, string model, float price, int amount)
        {
            _carGroups.Add(new CarGroup(mark, model, price, amount));
        }

        public int CountUniqueTypes()
        {
            var typesOfAllCars = _carGroups.Select(x => x.ConcreteCar.Mark);
            List<string> uniqueTypes = new List<string>();
            foreach(string carType in typesOfAllCars)
            {
                if (!uniqueTypes.Contains(carType))
                {
                    uniqueTypes.Add(carType);
                }
            }
            return uniqueTypes.Count();
        }

        public int CountAllCars() => _carGroups.Sum(x => x.Amount);

        public float CountAveragePrice()
            => _carGroups.Sum(x => x.ConcreteCar.Price * x.Amount) / CountAllCars();

        public float CountAveragePriceOfType(string type)
        {
            var groupsOfType = SelectCarGroupsOfType(type);
            return groupsOfType.Sum(x => x.ConcreteCar.Price * x.Amount) /
                groupsOfType.Sum(x => x.Amount);
        }

        //=> _carGroups.Where(x => x.ConcreteCar.Mark.Equals(type))
        //             .Sum(x => x.ConcreteCar.Price * x.Amount) /
        //   _carGroups.Where(x => x.ConcreteCar.Mark.Equals(type))
        //             .Sum(x => x.Amount);

        private IEnumerable<CarGroup> SelectCarGroupsOfType(string type)
            => _carGroups.Where(x => x.ConcreteCar.Mark.Equals(type));
    }
}
