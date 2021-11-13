using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model.Exceptions
{
    public class UpdateAutoException : VehicleException
    {
        public UpdateAutoException(string message) : base(message) { }

        public UpdateAutoException(Vehicle problemVehicle) : base(problemVehicle) { }
    }
}
