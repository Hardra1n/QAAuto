using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Exceptions;

namespace VehicleXML.Model.VehicleComponents
{
    [Serializable]
    public class Chassis
    {
        byte _wheelNumber;

        int _maxWeight;

        string _serialNumber;

        public Chassis() { }

        public Chassis(byte wheelNumber, string serialNumber, int maxWeight)
        {
            WheelNumber = wheelNumber;
            SerialNumber = serialNumber;
            MaxWeight = maxWeight;
        }
        public byte WheelNumber
        {
            get
            {
                return _wheelNumber;
            }
            set
            {
                if (value <= 1)
                {
                    throw new InitializationException("Number of wheels must be greater then 1");
                }
                _wheelNumber = value;
            }
        }

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
                    throw new InitializationException("Chassis serial number must exists only five symbols");
                }

                foreach (char symbol in value)
                {
                    if (!Char.IsLetterOrDigit(symbol))
                    {
                        throw new InitializationException("Chassis serial number must exists only letters and digits");
                    }
                }

                _serialNumber = value;
            }
        }

        public int MaxWeight
        {
            get
            {
                return _maxWeight;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Chassis maximum weight must be greater then 0");
                }
                _maxWeight = value;
            }
        }


        /// <summary>
        /// Represents full information about chassis
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"Chassis: Number of wheels: {WheelNumber}, " +
                $"Serial number: {SerialNumber}, Weight maximum(kg): {MaxWeight}.";
        }

    }
}
