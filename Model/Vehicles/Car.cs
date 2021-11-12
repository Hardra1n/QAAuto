using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Enums;
using VehicleXML.Model.Exceptions;

namespace VehicleXML.Model.Vehicles
{
    [Serializable]
    public class Car : Vehicle
    {
        byte _doorAmount;

        public Car() { }

        public Car(string mark, string model, byte doorAmount, string handDrive) : base(mark, model)
        {
            DoorAmount = doorAmount;
            try
            {
                HandDrive = (Side)Enum.Parse(HandDrive.GetType(), handDrive);
            }
            catch (Exception ex)
            {
                throw new InitializationException("Incorrect car hand drive side", ex);
            }
        }
        public byte DoorAmount
        {
            get
            {
                return _doorAmount;
            }
            set
            {
                if (value <= 1)
                {
                    throw new InitializationException("Car door amount must be greater then 1");
                }
                _doorAmount = value;
            }
        }

        public Side HandDrive { get; set; }

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
