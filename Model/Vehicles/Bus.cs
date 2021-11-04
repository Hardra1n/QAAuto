using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.Vehicles
{
    [Serializable]
    public class Bus : Vehicle 
    {

        public Bus() { }

        public Bus(string mark, string model, byte seatAmount, bool isLong) : base(mark, model)
        {
            SeatAmount = seatAmount;
            IsLong = isLong;
        }
        public byte SeatAmount { get; set; }

        public bool IsLong { get; set; }

        /// <summary>
        /// Represents full info about bus, as a vihecle, and unique attributes:
        /// amount of seats and is it long-bus model
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            return base.GetInfo() + 
                $"Bus attributes: {SeatAmount} number of seats, Is long bus? -{IsLong}.\n";
        }
    }
}
