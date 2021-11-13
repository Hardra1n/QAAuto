using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model.Exceptions
{
    public class AddException : VehicleException
    {
        public AddException(string message) : base(message) { }

        public AddException(Vehicle vehicle) : base(vehicle) { }
    }
}
