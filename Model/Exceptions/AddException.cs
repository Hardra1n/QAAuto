using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model.Exceptions
{
    public class AddException : Exception
    {

        public AddException(string message) : base(message) { }

        public AddException(string message, Vehicle vehicle) : base(message)
        {
            ProblemVehicle = vehicle;
        }

        public Vehicle ProblemVehicle { get; private set; }
    }
}
