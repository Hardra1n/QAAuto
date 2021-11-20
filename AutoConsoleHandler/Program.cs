using AutoConsoleHandler.Model;
using AutoConsoleHandler.UI;
using System;

namespace AutoConsoleHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleCarParkAdder.StartFillingCarPark();
            ConsoleHandler consoleHandler = new ConsoleHandler();
            consoleHandler.Start();
        }
    }
}
