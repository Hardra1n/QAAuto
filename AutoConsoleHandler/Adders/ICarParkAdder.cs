using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Adders
{
    interface ICarParkAdder
    {
        public void AddCarGroup(string type, string model, float price, int amount);
    }
}
