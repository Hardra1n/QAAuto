using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.Vehicles
{
    [Serializable]
    public class Truck : Vehicle
    {

        public Truck() { }

        public Truck(string mark, string model, bool isBuiltInTrunk) : base(mark, model)
        {
            IsBuiltInTrunk = isBuiltInTrunk;
        }
        public bool IsBuiltInTrunk { get; set; }

        /// <summary>
        /// Represents full info about truck, as a vihecle, and unique attribute:
        /// Is trunk built-in
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            return base.GetInfo() +
                $"Truck atrributes: Is built-in trunk? -{IsBuiltInTrunk}.\n";
        }
    }
}
