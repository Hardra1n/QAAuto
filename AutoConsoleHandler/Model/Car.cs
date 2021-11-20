using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Model
{
    public class Car
    {
        private string _mark;

        private string _model;

        private float _price;

        public Car(string mark, string model, float price)
        {
            Mark = mark;
            Model = model;
            Price = price;
        }

        public string Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                foreach (char symbol in value)
                {
                    if (!Char.IsLetter(symbol))
                    {
                        throw new Exception($"Type must have only letters," +
                            $" your input: {value}");
                    }
                }
                _mark = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                foreach(char symbol in value)
                {
                    if (!Char.IsLetterOrDigit(symbol))
                    {
                        throw new Exception($"Model must have only letters and digits," +
                            $" your input {value}");
                    }
                }
            }
        }

        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"Price must be more then 0, your input {value}");
                }
                _price = value;
            }
        }

    }
}
