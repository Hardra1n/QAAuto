using System;
using System.Collections.Generic;
using System.Linq;
using VehicleXML.Helper;
using VehicleXML.Model.Exceptions;
using VehicleXML.Model.VehicleComponents;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model
{
    public class AutoPark
    {

        public AutoPark(IEnumerable<Vehicle> vehicles, int maxCapacity)
        {
            if (vehicles.ToList().Count > maxCapacity)
            {
                throw new InitializationException("You tried create autopark with capacity less then amount of vehicles you have given");
            }
            MaxCapacity = maxCapacity;

            Vehicles = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicles)
            {
                AddAuto(vehicle);
            }
        }

        public AutoPark(int maxCapacity)
        {
            Vehicles = new List<Vehicle>(maxCapacity);
            MaxCapacity = maxCapacity;
        }

        public List<Vehicle> Vehicles { get; private set; }

        public int MaxCapacity { get; private set; }

        public void AddAuto(Vehicle vehicle)
        {
            AddAutoExceptionThrow(vehicle);
            Vehicles.Add(vehicle);
        }

        private void AddAutoExceptionThrow(Vehicle vehicle)
        {
            if (MaxCapacity <= Vehicles.Count)
            {
                throw new AddException("Autopark is full, impossible to add another vehicle.");
            }
            if (vehicle.Chassis == null || vehicle.Transmission == null || vehicle.Engine == null)
            {
                string message = String.Format("Detail of vehicle is undefined {0} {1} {2}",
                    vehicle.Chassis == null ? "\n Chassis is undefined" : String.Empty,
                    vehicle.Engine == null ? "\n Engine is undefined" : String.Empty,
                    vehicle.Transmission == null ? "\n Transmission is undefined" : String.Empty);

                throw new AddException(message, vehicle);
            }
        }

        public void UpdateAuto(Vehicle vehicle, int id)
        {
            UpdateAutoExceptionThrow(vehicle, id);
            Vehicles[id] = vehicle;
        }

        private void UpdateAutoExceptionThrow(Vehicle vehicle, int id)
        {
            if (id >= Vehicles.Count || id < 0)
            {
                throw new UpdateAutoException("Incorrect given id.");
            }
            if (vehicle.Chassis == null || vehicle.Transmission == null || vehicle.Engine == null)
            {
                string message = String.Format("Detail of vehicle is undefined {0} {1} {2}",
                    vehicle.Chassis == null ? "\n Chassis is undefined" : String.Empty,
                    vehicle.Engine == null ? "\n Engine is undefined" : String.Empty,
                    vehicle.Transmission == null ? "\n Transmission is undefined" : String.Empty);

                throw new UpdateAutoException(message, vehicle);
            }
        }

        public void RemoveAuto(int id)
        {
            Vehicles.RemoveAt(id);
        }

        public void GetAutoByParameter(string param, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets list of vehicles from autopark with Engine greater then 1.5
        /// </summary>
        public List<Vehicle> GetVehiclesWithEngineVolumeGreaterThen1p5()
        {
            var data = Vehicles.Where(x => x.Engine.Volume > 1.5)
                               .ToList();

            return data;
        }

        /// <summary>
        /// Gets list of bus's and truck's engines(type, power, volume) from autopark
        /// </summary>
        public List<Engine> GetBusNTruckEngines()
        {
            var data = Vehicles.Where(x => x is Bus || x is Truck)
                               .Select(delegate (Vehicle vehicle)
                               {
                                   return new Engine()
                                   {
                                       Type = vehicle.Engine.Type,
                                       Power = vehicle.Engine.Power,
                                       Volume = vehicle.Engine.Volume
                                   };
                               })
                               .ToList();
            return data;
        }

        /// <summary>
        /// Gets list of vehicles from autopark grouped by transmission type
        /// </summary>
        public List<Vehicle> GetVehiclesGroupedByTransmissionType()
        {
            var data = Vehicles.GroupBy(x => x.Transmission?.Type).ToList();
            List<Vehicle> list = new List<Vehicle>();
            foreach (var item in data)
            {
                foreach (Vehicle vehicle in item)
                {
                    list.Add(vehicle);
                }
            }
            return list;
        }
    }
}
