using AutoConsoleHandler.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Adders
{
    public class CarParkAdder : ICarParkAdder
    {
        public CarParkAdder() { }

        public void AddCarGroup(string type, string model, float price, int amount)
        {
            CarPark carPark = CarPark.GetInstance();
            carPark.AddCarGroup(type, model, price, amount);
        }
    }
}
