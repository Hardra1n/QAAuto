using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;
using VehicleXML.Model.Exceptions;

namespace VehicleXML.Model.VehicleComponents
{
    [Serializable]
    public class Transmission
    {
        byte _gearsNumber;

        public Transmission() { }

        public Transmission(string type, byte gearsNumber, string manufacturer)
        {
            try
            {
                Type = (TransmissionType)Enum.Parse(Type.GetType(), type);
            } 
            catch (Exception ex)
            {
                throw new InitializationException("Incorrect transmission type", ex);
            }

            GearsNumber = gearsNumber;
            Manufacturer = manufacturer;
        }

        public TransmissionType Type { get; set; }

        public byte GearsNumber
        {
            get
            {
                return _gearsNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Number of gears must be greater then 0." +
                        $"Your input {value}");
                }
                _gearsNumber = value;
            }
        }

        public string Manufacturer { get; set; }

        /// <summary>
        /// Represents full information about transmission
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"Transmission: Type: {Type}, Number of gears: {GearsNumber}, manufacturer: {Manufacturer}.";
        }

    }
}
