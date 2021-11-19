using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Model
{
    public class Car
    {
        public Car(string mark, string model, float price)
        {
            Mark = mark;
            Model = model;
            Price = price;
        }

        public string Mark { get; set; }

        public string Model { get; set; }

        public float Price { get; set; }

    }
}
