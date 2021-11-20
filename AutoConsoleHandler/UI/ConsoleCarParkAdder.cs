using AutoConsoleHandler.Adders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace AutoConsoleHandler.UI
{
    public static class ConsoleCarParkAdder
    {
        static ICarParkAdder _adder = new CarParkAdder();
        static string _nameOfAddMethod = "AddCarGroup";

        public static void StartFillingCarPark()
        {
            Console.WriteLine(CreateInputFormatMessage());
            while (true)
            {
                string data = Console.ReadLine();
                if (data == "exit")
                {
                    break;
                }
                if (data == "scenario1")
                {
                    AddScenario();
                    continue;
                }
                try
                {
                    List<object> convertedData = ParseData(SplitData(data));
                    AddCarGroupToCarPark(convertedData.ToArray());
                    Console.WriteLine("Successfull add.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void AddScenario()
        {
            string[] data = new string[]
             {
                "volvo mc13 15 100",
                "volvo mc23 23 20",
                "audi a6 5,1 3",
                "audi a4 1,3 10",
                "chvrolet comaro 6,1 1"
             };
            foreach (string str in data)
            {
                List<object> convertedData = ParseData(SplitData(str));
                AddCarGroupToCarPark(convertedData.ToArray());
            }

        }

        private static string CreateInputFormatMessage()
        {
            StringBuilder message = new StringBuilder();
            var paramsOfAddMethod = _adder.GetType().GetMethod(_nameOfAddMethod).GetParameters();
            foreach(var param in paramsOfAddMethod)
            {
                message.Append(param.Name + "\t");
            }
            message.Append("\nEnter 'exit' to finalize adding.");
            return message.ToString();
        }

        private static string[] SplitData(string data) => data.Split(' ');

        private static void AddCarGroupToCarPark(object[] convertedData)
        {
            _adder.GetType().GetMethod(_nameOfAddMethod).Invoke(_adder, convertedData);
        }

        private static List<object> ParseData(string[] data)
        {
            var paramsOfAddMethod = _adder.GetType().GetMethod(_nameOfAddMethod).GetParameters();

            if (data.Length != paramsOfAddMethod.Length)
            {
                throw new Exception($"Number of params is invalid." +
                    $" You gave {data.Length}, need {paramsOfAddMethod.Length}");
            }

            List<object> convertedData = new List<object>();

            for (int i = 0; i < paramsOfAddMethod.Length; i++)
            {
                var converter = TypeDescriptor.GetConverter(paramsOfAddMethod[i].ParameterType);
                var result = converter.ConvertFrom(data[i]);
                convertedData.Add(result);
            }

            return convertedData;
        }
    }
}
