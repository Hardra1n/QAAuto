using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;
using VehicleXML.Model.Exceptions;

namespace VehicleXML.Model.VehicleComponents
{
    [Serializable]
    public class Engine
    {
        int _power;

        double _volume;

        string _serialNumber;

        public Engine() { }

        public Engine(int power, double volume, string type, string serialNumber)
        {
            Power = power;
            Volume = volume;
            SerialNumber = serialNumber;
            try
            {
                Type = (EngineType)Enum.Parse(Type.GetType(), type);
            }
            catch (Exception ex)
            {
                throw new InitializationException("Incorrect engine type", ex);
            }
        }

        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Engine power must be greater then 0");
                }
                _power = value;
            }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Engine volume must be grater then 0");
                }
                _volume = value;
            }
        }

        public EngineType Type { get; set; }

        public string SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                if (value.Length != 5)
                {
                    throw new InitializationException("Engine serial number must exists only five symbols");
                }

                foreach (char symbol in value)
                {
                    if (!(Char.IsDigit(symbol) || Char.IsLetter(symbol)))
                    {
                        throw new InitializationException("Engine serial number must exists only letters and digits");
                    }
                }

                _serialNumber = value;
            }
        }

        /// <summary>
        /// Represents full information about engine
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"Engine: Engine power(hp) {Power}, Engine volume(L): {Volume}, " +
                $"Engine type: {Type}, Serial number: {SerialNumber}.";
        }
    }
}
