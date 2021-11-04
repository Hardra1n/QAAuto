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
        public List<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Serilializes vehicles with engine volume more then 1.5 liters into XML file.
        /// </summary>
        /// <param name="filepath"></param>
        public List<Vehicle> LinqScenqrio1()
        {
            var data = Vehicles.Where(x => x.Engine.Volume > 1.5)
                               .ToList();

            return data;
        }

        /// <summary>
        /// Serilializes bus's and truck's engine type, power and volume into XML file
        /// </summary>
        /// <param name="filepath"></param>
        public List<Engine> LinqScenario2()
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
        /// Serilializes vehicles, grouped by transmission type
        /// </summary>
        /// <param name="filepath"></param>
        public List<Vehicle> LinqScenario3()
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
