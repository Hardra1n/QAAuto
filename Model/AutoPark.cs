using System;
using System.Collections.Generic;
using System.Linq;
using VehicleXML.Helper;
using VehicleXML.Model.VehicleComponents;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model
{
    public class AutoPark
    {

        public AutoPark(IEnumerable<Vehicle> vehicles)
        {
            Vehicles = vehicles.ToList();
        }

        public List<Vehicle> Vehicles { get; private set; }

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
