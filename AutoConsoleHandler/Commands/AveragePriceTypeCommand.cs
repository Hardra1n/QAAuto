using AutoConsoleHandler.Model;
using AutoConsoleHandler.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Commands
{
    public class AveragePriceTypeCommand : ICommand
    {
        IWriter _writer;

        string _type;

        public AveragePriceTypeCommand(IWriter writer, string type)
        {
            _type = type;
            _writer = writer;
        }

        public void Execute()
        {
            CarPark carPark = CarPark.GetInstance();
            _writer.Write(carPark.CountAveragePriceOfType(_type));
        }
    }
}
