using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoConsoleHandler.Model
{
    public class CarPark
    {
        List<Car> _cars = new List<Car>();

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
            if (amount <= 0)
            {
                throw new Exception($"Amount must be more then 0, your input {amount}");
            }
            for (int i = 0; i < amount; i++)
            {
                _cars.Add(new Car(mark, model, price));
            }
        }

        public int CountUniqueTypes() => GetUniqueTypes().Length;

        public int CountAllCars() => _cars.Count;

        public float CountAveragePrice()
        {
            if (_cars.Count == 0)
            {
                return 0;
            }

            return _cars.Sum(x => x.Price) / CountAllCars();
        }

        public string[] GetUniqueTypes()
        {
            var carTypes = _cars.Select(x => x.Mark);
            List<string> uniqueTypes = new List<string>();
            foreach (string carType in carTypes)
            {
                if (!uniqueTypes.Contains(carType))
                {
                    uniqueTypes.Add(carType);
                }
            }
            return uniqueTypes.ToArray();
        }

        public float CountAveragePriceOfType(string type)
        {
            var carsOfType = _cars.Where(x => x.Mark.Equals(type)).ToList();
            if (carsOfType is null)
            {
                return 0;
            }

            return carsOfType.Sum(x => x.Price) / carsOfType.Count;
        }
    }
}
