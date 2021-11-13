using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model.Exceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message) : base(message) { }

        public UpdateAutoException(string message, Vehicle problemVehicle) : base(message) { }

        public Vehicle ProblemVehicle { get; private set; }
    }
}
