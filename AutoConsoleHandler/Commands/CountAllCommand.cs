using AutoConsoleHandler.Model;
using AutoConsoleHandler.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Commands
{
    public class CountAllCommand : ICommand
    {
        IWriter _writer;

        public CountAllCommand(IWriter writer)
        {
            _writer = writer;
        }

        public void Execute()
        {
            CarPark carPark = CarPark.GetInstance();
            _writer.Write(carPark.CountAllCars());
        }
    }
}
