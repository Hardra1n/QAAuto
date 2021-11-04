using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.VehicleComponents
{
    [Serializable]
    public class Engine
    {

        public Engine() { }

        public Engine(int power, double volume, string type, string serialNumber)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serialNumber;
        }

        public int Power { get; set; }

        public double Volume { get; set; }

        public string Type { get; set; }

        public string SerialNumber { get; set; }

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
