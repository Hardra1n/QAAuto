using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.Vehicle_components
{
    [Serializable]
    public class Chassis
    {
        public byte WheelNumber { get; set; }
        public string SerialNumber { get; set; }
        public int MaxWeight { get; set; }

        public Chassis() { }

        public Chassis(byte wheelNumber, string serialNumber, int maxWeight)
        {
            WheelNumber = wheelNumber;
            SerialNumber = serialNumber;
            MaxWeight = maxWeight;
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
