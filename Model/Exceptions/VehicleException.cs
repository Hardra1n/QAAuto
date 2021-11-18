using System;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model.Exceptions
{
    public class VehicleException : Exception
    {
        public VehicleException(string message) : base(message) { }

        public VehicleException(string message, Exception inner) : base(message, inner) { }

        public VehicleException(int id) : base(GetMessageOfIncorrectID(id)) { }

        public VehicleException(Vehicle problemVehicle) : base(GetMessageOfUndefinedVehicle(problemVehicle))
        {
            ProblemVehicle = problemVehicle;
        }



        public Vehicle ProblemVehicle { get; private set; }

        private static string GetMessageOfIncorrectID(int id)
            => $"Incorrect id. Your input: {id}";

        private static string GetMessageOfUndefinedVehicle(Vehicle vehicle)
        {
            return String.Format("Detail of vehicle is undefined {0} {1} {2}",
                    vehicle.Chassis == null ? "\n Chassis is undefined" : String.Empty,
                    vehicle.Engine == null ? "\n Engine is undefined" : String.Empty,
                    vehicle.Transmission == null ? "\n Transmission is undefined" : String.Empty);
        }
    }
}
