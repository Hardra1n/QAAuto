using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;

namespace VehicleXML.Model.VehicleComponents
{
    [Serializable]
    public class Transmission
    {
        public Transmission() { }

        public Transmission(string type, byte gearsNumber, string manufacturer)
        {
            Type = (TransmissionType)Enum.Parse(Type.GetType(), type);
            GearsNumber = gearsNumber;
            Manufacturer = manufacturer;
        }

        public TransmissionType Type { get; set; }

        public byte GearsNumber { get; set; }

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
