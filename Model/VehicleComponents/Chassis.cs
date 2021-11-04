using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.VehicleComponents
{
    [Serializable]
    public class Chassis
    {
        public Chassis() { }

        public Chassis(byte wheelNumber, string serialNumber, int maxWeight)
        {
            WheelNumber = wheelNumber;
            SerialNumber = serialNumber;
            MaxWeight = maxWeight;
        }
        public byte WheelNumber { get; set; }

        public string SerialNumber { get; set; }

        public int MaxWeight { get; set; }


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
