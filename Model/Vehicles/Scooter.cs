using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;
using VehicleXML.Model.Exceptions;

namespace VehicleXML.Model.Vehicles
{
    [Serializable]
    public class Scooter : Vehicle 
    {

        public Scooter() { }

        public Scooter(string mark, string model, bool isBacketOn, Side lockerSide) : base(mark, model)
        {
            IsBacketOn = isBacketOn;
            LockerSide = lockerSide;
        }
        public bool IsBacketOn { get; set; }

        public Side LockerSide { get; set; }

        /// <summary>
        /// Represents full info about scooter, as a vihecle, and unique attributes:
        /// is backet placed on and locker side
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            return base.GetInfo() +
                $"Scooter attributes: Scooter has {LockerSide} lockerside," +
                $" Is backet placed on scooter? -{IsBacketOn}.\n";
        }
    }
}
