﻿using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;

namespace VehicleXML.Model.Vehicles
{
    [Serializable]
    public class Scooter : AVehicle 
    {
        public bool IsBacketOn { get; set; }
        public Side LockerSide { get; set; }

        public Scooter() { }

        public Scooter(string mark, string model, bool isBacketOn, string lockerSide) : base(mark, model)
        {
            IsBacketOn = isBacketOn;
            LockerSide = (Side)Enum.Parse(LockerSide.GetType(), lockerSide);
        }

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
