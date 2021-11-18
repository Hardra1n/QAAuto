using System;
using System.Collections.Generic;
using System.Text;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model.Exceptions
{
    public class UpdateAutoException : VehicleException
    {
        public UpdateAutoException(int id) : base(id) { }

        public UpdateAutoException(Vehicle problemVehicle) : base(problemVehicle) { }
    }
}
