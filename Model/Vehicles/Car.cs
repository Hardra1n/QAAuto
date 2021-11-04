using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;

namespace VehicleXML.Model.Vehicles
{
    [Serializable]
    public class Car : AVehicle
    {
        public byte DoorAmount { get; set; }
        public Side HandDrive { get; set; }

        public Car() { }

        public Car(string mark, string model, byte doorAmount, string handDrive) : base(mark, model)
        {
            DoorAmount = doorAmount;
            HandDrive = (Side)Enum.Parse(HandDrive.GetType(), handDrive);
        }

        /// <summary>
        /// Represents full info about car, as a vihecle, and unique attributes: amount of doors, hand-drive side.
        /// </summary>
        /// <returns></returns>
        public override string GetInfo()
        {
            return base.GetInfo() +
                $"Car atributes: Door amount: {DoorAmount}, Hand-drive: {HandDrive}-side\n";
        }

    }
}
