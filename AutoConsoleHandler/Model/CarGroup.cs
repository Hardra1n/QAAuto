using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Model
{
    class CarGroup
    {
        public CarGroup(string mark, string model, float price, int amount)
        {
            ConcreteCar = new Car(mark, model, price);
            Amount = amount;
        }

        public Car ConcreteCar { get; set; }

        public int Amount { get; set; }
    }
}
