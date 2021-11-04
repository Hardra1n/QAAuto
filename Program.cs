﻿using System;
using System.Collections.Generic;
using VehicleXML.Model;
using VehicleXML.Model.Vehicles;

namespace VehicleXML
{
    class Program
    {
        /// <summary>
        /// Initializes each vehicle type into massive of vehicles
        /// </summary>
        /// <param name="vehicles"></param>
        static void InitVehicles(AVehicle[] vehicles)
        {
            vehicles[0] = new Car("Ford", "Mustafa", 4, "right");
            vehicles[0].SetChassis(4, "3A11C", 700);
            vehicles[0].SetEngine(300, 3.2, "Gas", "1Ds3p");
            vehicles[0].SetTransmission("Mechanic", 6, "KindTrans");


            vehicles[1] = new Scooter("Racer", "Meteor RC50", false, "left");
            vehicles[1].SetChassis(2, "6AC39", 300);
            vehicles[1].SetEngine(4, 1.1, "Gas", "4dPG8");
            vehicles[1].SetTransmission("Automatic", 4, "BadTrans");

            vehicles[2] = new Bus("Peugeot", "Boxer", 10, false);
            vehicles[2].SetChassis(4, "7VK23", 1300);
            vehicles[2].SetEngine(160, 2.0, "Diesel", "1fdR3");
            vehicles[2].SetTransmission("Mechanic", 6, "Guys&Trans");

            vehicles[3] = new Truck("Ford", "F150", true);
            vehicles[3].SetChassis(4, "901DA", 2000);
            vehicles[3].SetEngine(400, 5.0, "Gas", "dAmJ4");
            vehicles[3].SetTransmission("Automatic", 6, "DanceWithTrans");

            vehicles[4] = new Bus("Volkswagen", "Sprinter", 9, false);
            vehicles[4].SetChassis(4, "90R98", 1800);
            vehicles[4].SetEngine(400, 5.0, "Gas", "3Cds8");
            vehicles[4].SetTransmission("Mechanic", 6, "BadTrans");

            vehicles[5] = new Scooter("Dream", "Comet2C", true, "right");
            vehicles[5].SetChassis(2, "4CD21", 250);
            vehicles[5].SetEngine(10, 1.4, "Gas", "JdS81");
            vehicles[5].SetTransmission("Automatic", 3, "KindTrans");

            vehicles[6] = new Car("Lada", "2107", 3, "left");
            vehicles[6].SetChassis(4, "D2HEL", 500);
            vehicles[6].SetEngine(100, 1.9, "Gas", "DRsf1");
            vehicles[6].SetTransmission("Hybrid", 5, "BadTrans");

            vehicles[7] = new Truck("Delivery", "Monster", false);
            vehicles[7].SetChassis(4, "K01DA", 1700);
            vehicles[7].SetEngine(280, 3.4, "Gas", "dAHD4");
            vehicles[7].SetTransmission("Hybrid", 6, "RollingTrans");

        }

        static void Main(string[] args)
        {
            AVehicle[] vehicles = new AVehicle[8];
            InitVehicles(vehicles);
            AutoPark autopark = new AutoPark(vehicles);

            autopark.LinqScenqrio1("../../../VehiclesWithEngineCondition.xml");
            autopark.LinqScenario2("../../../Engines.xml");
            autopark.LinqScenario3("../../../TransmissionGroup");

            foreach (AVehicle vehicle in autopark.Vehicles)
                Console.WriteLine(vehicle.GetInfo() + "\n");
        }
    }
}
