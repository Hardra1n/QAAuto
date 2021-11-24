using AutoConsoleHandler.Adders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.UI
{
    public static class ConsoleCarParkAdder
    {
        static ICarParkAdder _adder = new CarParkAdder();

        public static void StartFillingCarPark()
        {
            while (true)
            {
                string data = Console.ReadLine();
                if (data == "exit")
                {
                    break;
                }

                Console.WriteLine(AddToCarPark(data.Split(' ')));            
            }
        }

        private static string AddToCarPark(string [] data)
        {
            if (data.Length != 4)
            {
                return "Wrong amount of given params";
            }

            string mark = data[0];
            string model = data [1];
            float price;
            int amount;


            if (!Single.TryParse(data[2], out price))
            {
                return $"Imposible to parse {data[2]} into float type";
            }

            if (!Int32.TryParse(data[3], out amount)) 
            {
                return $"Imposible to parse {data[3]} into int type";
            }

            try
            {
                _adder.AddCarGroup(mark, model, price, amount);
                return "Successfull add.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
