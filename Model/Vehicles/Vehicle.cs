using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using VehicleXML.Model.Enums;
using VehicleXML.Model.VehicleComponents;

namespace VehicleXML.Model.Vehicles
{
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Scooter))]
    [XmlInclude(typeof(Truck))]
    [Serializable]
    public abstract class Vehicle
    {
        public Vehicle() { }

        public Vehicle(string mark, string model)
        {
            Mark = mark;
            Model = model;
        }

        public Engine Engine { get; set; }

        public Chassis Chassis { get; set; }

        public Transmission Transmission { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        /// <summary>
        /// Sets new engine to object
        /// </summary>
        /// <param name="power"> Power of engine in hp</param>
        /// <param name="volume"> Volume of engine in l</param>
        /// <param name="type"> Engine type</param>
        /// <param name="serialNumber"> Engine serial number</param>
        public void SetEngine(int power, double volume, EngineType type, string serialNumber)
            => Engine = new Engine(power, volume, type, serialNumber);

        /// <summary>
        /// Sets new chassis to object
        /// </summary>
        /// <param name="wheelNumber"> Number of wheels</param>
        /// <param name="serialNumber"> Chassis's serial number</param>
        /// <param name="maxWeight"> Maximum weight</param>
        public void SetChassis(byte wheelNumber, string serialNumber, int maxWeight)
            => Chassis = new Chassis(wheelNumber, serialNumber, maxWeight);

        /// <summary>
        /// Sets new transmission to object
        /// </summary>
        /// <param name="type"> Transmission type</param>
        /// <param name="gearsNumber"> Number of gears</param>
        /// <param name="manufacturer"> Creater of transmission</param>
        public void SetTransmission(TransmissionType type, byte gearsNumber, string manufacturer)
            => Transmission = new Transmission(type, gearsNumber, manufacturer);

        /// <summary>
        /// Represents full information about extended object: name of object, mark, model, engine, transmission, chassis.
        /// </summary>
        /// <returns></returns>
        public virtual string GetInfo()
        {
            StringBuilder formatedInfo = new StringBuilder();
            formatedInfo.Append($"{GetType().Name}\n");
            formatedInfo.Append($"{Mark} {Model}\n");
            formatedInfo.Append(Engine == null ? String.Empty : Engine.GetInfo() + '\n');
            formatedInfo.Append(Chassis == null ? String.Empty : Chassis.GetInfo() + '\n');
            formatedInfo.Append(Transmission == null ? String.Empty : Transmission.GetInfo() + '\n');
            return formatedInfo.ToString();
        }
    }
}
