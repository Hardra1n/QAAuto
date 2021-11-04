using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;

namespace VehicleXML.Model.Vehicle_components
{
    [Serializable]
    public class Transmission
    {
        private TransmissionType type;
        public TransmissionType Type 
        { 
            get 
            {
                return type;
            } 
            set
            {

            } 
        }
        public byte GearsNumber { get; set; }
        public string Manufacturer { get; set; }


        public Transmission() { }
        public Transmission(string type, byte gearsNumber, string manufacturer)
        {
            Type = (TransmissionType)Enum.Parse(this.type.GetType(), type);
            GearsNumber = gearsNumber;
            Manufacturer = manufacturer;
        }

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
