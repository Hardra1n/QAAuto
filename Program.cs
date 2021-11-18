using System;
using System.Linq;
using VehicleXML.Helper;
using VehicleXML.Model;
using VehicleXML.Model.Enums;
using VehicleXML.Model.Exceptions;
using VehicleXML.Model.Vehicles;

namespace VehicleXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[8];
            InitVehicles(vehicles);
            AutoPark autopark = new AutoPark(vehicles, 8);

            //GetFullInfoAboutAutoPark(autopark);

            //AutoparkToXML(autopark);

            ExceptionScenario(autopark);
        }

        /// <summary>
        /// Initializes each vehicle type into massive of vehicles
        /// </summary>
        /// <param name="vehicles"></param>
        static void InitVehicles(Vehicle[] vehicles)
        {
            vehicles[0] = new Car("Ford", "Mustafa", 4, Side.Right);
            vehicles[0].SetChassis(4, "3A11C", 700);
            vehicles[0].SetEngine(300, 3.2, EngineType.Gas, "1Ds3p");
            vehicles[0].SetTransmission(TransmissionType.Mechanic, 6, "KindTrans");


            vehicles[1] = new Scooter("Racer", "Meteor RC50", false, Side.Left);
            vehicles[1].SetChassis(2, "6AC39", 300);
            vehicles[1].SetEngine(4, 1.1, EngineType.Gas, "4dPG8");
            vehicles[1].SetTransmission(TransmissionType.Automatic, 4, "BadTrans");

            vehicles[2] = new Bus("Peugeot", "Boxer", 10, false);
            vehicles[2].SetChassis(4, "7VK23", 1300);
            vehicles[2].SetEngine(160, 2.0, EngineType.Diesel, "1fdR3");
            vehicles[2].SetTransmission(TransmissionType.Mechanic, 6, "Guys&Trans");

            vehicles[3] = new Truck("Ford", "F150", true);
            vehicles[3].SetChassis(4, "901DA", 2000);
            vehicles[3].SetEngine(400, 5.0, EngineType.Gas, "dAmJ4");
            vehicles[3].SetTransmission(TransmissionType.Automatic, 6, "DanceWithTrans");

            vehicles[4] = new Bus("Volkswagen", "Sprinter", 9, false);
            vehicles[4].SetChassis(4, "90R98", 1800);
            vehicles[4].SetEngine(400, 5.0, EngineType.Electric, "3Cds8");
            vehicles[4].SetTransmission(TransmissionType.Mechanic, 6, "BadTrans");

            vehicles[5] = new Scooter("Dream", "Comet2C", true, Side.Right);
            vehicles[5].SetChassis(2, "4CD21", 250);
            vehicles[5].SetEngine(10, 1.4, EngineType.Gas, "JdS81");
            vehicles[5].SetTransmission(TransmissionType.Automatic, 3, "KindTrans");

            vehicles[6] = new Car("Lada", "2107", 3, Side.Left);
            vehicles[6].SetChassis(4, "D2HEL", 500);
            vehicles[6].SetEngine(100, 1.9, EngineType.Gas, "DRsf1");
            vehicles[6].SetTransmission(TransmissionType.Hybrid, 5, "BadTrans");

            vehicles[7] = new Truck("Delivery", "Monster", false);
            vehicles[7].SetChassis(4, "K01DA", 1700);
            vehicles[7].SetEngine(280, 3.4, EngineType.Gas, "dAHD4");
            vehicles[7].SetTransmission(TransmissionType.Hybrid, 6, "RollingTrans");

        }

        static void GetFullInfoAboutAutoPark(AutoPark autopark)
        {
            foreach (Vehicle vehicle in autopark.Vehicles)
                Console.WriteLine(vehicle.GetInfo() + "\n");
        }

        static void AutoparkToXML(AutoPark autopark)
        {
            XmlHelper.XmlSerialize(autopark.GetVehiclesWithEngineVolumeGreaterThen1p5(), "../../../VehiclesWithEngineCondition.xml");
            XmlHelper.XmlSerialize(autopark.GetBusNTruckEngines(), "../../../Engines.xml");
            XmlHelper.XmlSerialize(autopark.GetVehiclesGroupedByTransmissionType(), "../../../TransmissionGroup");
        }

        static void ExceptionScenario(AutoPark autopark)
        {
            AddExceptionScenario();

            InitializationAutoExceptionScenario();

            UpdateAutoExceptionScenario(autopark);

            RemoveAutoExceptionScenario(autopark);

            GetAutoByParameterExceptionScenario(autopark);
        }

        static void AddExceptionScenario()
        {
            Console.WriteLine("AddException Scenario:");
            AutoPark autopark = new AutoPark(1);
            Car car = new Car("Lada", "2107", 3, Side.Left);
            car.SetChassis(4, "D2HEL", 500);
            car.SetEngine(100, 1.9, EngineType.Gas, "DRsf1");
            try
            {
                autopark.AddAuto(car);
            }
            catch (AddException ex)
            {
                Console.WriteLine(ex.Message);
            }
            car.SetTransmission(TransmissionType.Hybrid, 5, "BadTrans");

            try
            {
                autopark.AddAuto(car);
                autopark.AddAuto(car);
            }
            catch (AddException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        static void InitializationAutoExceptionScenario()
        {
            Console.WriteLine("InitializationAutoException Scenario:");
            try
            {
                Car car = new Car("Wolf", "Pancrate", 0, Side.Right);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        static void UpdateAutoExceptionScenario(AutoPark autoPark)
        {
            Console.WriteLine("UpdateAutoException Scenario:");
            Car car = new Car("Lada", "2107", 3, Side.Left);
            car.SetChassis(4, "D2HEL", 500);
            car.SetEngine(100, 1.9, EngineType.Gas, "DRsf1");
            try
            {
                autoPark.UpdateAuto(car, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            car.SetTransmission(TransmissionType.Hybrid, 5, "BadTrans");

            try
            {
                autoPark.UpdateAuto(car, 300);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        static void RemoveAutoExceptionScenario(AutoPark autoPark)
        {
            Console.WriteLine("RemoveAutoException Scenario:");
            try
            {
                autoPark.RemoveAuto(300);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
        
        static void GetAutoByParameterExceptionScenario(AutoPark autoPark)
        {
            Console.WriteLine("GetAutoByParameterException Scenario:");
            try
            {
                autoPark.GetAutoByParameter("Undefined name", "10");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }



    }
}
