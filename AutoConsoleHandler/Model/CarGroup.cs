using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Model
{
    class CarGroup
    {
        private int _amount;

        public CarGroup(string mark, string model, float price, int amount)
        {
            ConcreteCar = new Car(mark, model, price);
            Amount = amount;
        }

        public Car ConcreteCar { get; set; }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"Amount must be more then 0, your input {value}");
                }
                _amount = value;
            }
        }
    }
}
