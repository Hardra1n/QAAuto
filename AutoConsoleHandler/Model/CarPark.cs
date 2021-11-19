using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Model
{
    public class CarPark
    {
        List<CarGroup> _carGroups;

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
    }
}
