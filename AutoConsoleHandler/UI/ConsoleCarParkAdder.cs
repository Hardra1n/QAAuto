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
        static ICarParkAdder adder = new CarParkAdder();
        static string nameOfAddMethod = "AddCarGroup";

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

        private static string CreateInputFormatMessage()
        {
            StringBuilder message = new StringBuilder();
            var paramsOfAddMethod = adder.GetType().GetMethod(nameOfAddMethod).GetParameters();
            foreach(var param in paramsOfAddMethod)
            {
                message.Append(param.Name + "\t");
            }

            return message.ToString();
        }

        private static string[] SplitData(string data) => data.Split(' ');

        private static void AddCarGroupToCarPark(object[] convertedData)
        {
            adder.GetType().GetMethod(nameOfAddMethod).Invoke(adder, convertedData);
        }

        private static List<object> ParseData(string[] data)
        {
            var paramsOfAddMethod = adder.GetType().GetMethod(nameOfAddMethod).GetParameters();

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
