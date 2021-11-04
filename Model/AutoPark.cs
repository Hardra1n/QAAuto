using System;
using System.Collections.Generic;
using System.Linq;
using VehicleXML.Helper;
using VehicleXML.Model.Vehicle_components;
using VehicleXML.Model.Vehicles;

namespace VehicleXML.Model
{
    public class AutoPark
    {
        public List<AVehicle> Vehicles { get; set; }

        public AutoPark(IEnumerable<AVehicle> vehicles)
        {
            Vehicles = vehicles.ToList();
        }

        /// <summary>
        /// Serilializes vehicles with engine volume more then 1.5 liters into XML file.
        /// </summary>
        /// <param name="filepath"></param>
        public void LinqScenqrio1(string filepath)
        {
            var data = Vehicles.Where(x => x.Engine.Volume > 1.5)
                               .ToList();

            XmlHelper.XmlSerialize(data, filepath);
        }

        /// <summary>
        /// Serilializes bus's and truck's engine type, power and volume into XML file
        /// </summary>
        /// <param name="filepath"></param>
        public void LinqScenario2(string filepath)
        {
            var data = Vehicles.Where(x => x is Bus || x is Truck)
                               .Select(delegate (AVehicle vehicle)
                               {
                                   return new Engine()
                                   {
                                       Type = vehicle.Engine.Type,
                                       Power = vehicle.Engine.Power,
                                       Volume = vehicle.Engine.Volume
                                   };
                               })
                               .ToList();
            XmlHelper.XmlSerialize(data, filepath);
        }

        /// <summary>
        /// Serilializes vehicles, grouped by transmission type
        /// </summary>
        /// <param name="filepath"></param>
        public void LinqScenario3(string filepath)
        {
            var data = Vehicles.GroupBy(x => x.Transmission?.Type).ToList();
            List<AVehicle> list = new List<AVehicle>();
            foreach (var item in data)
            {
                foreach (AVehicle vehicle in item)
                {
                    list.Add(vehicle);
                }
            }
            XmlHelper.XmlSerialize(list, filepath);

        }
    }
}
