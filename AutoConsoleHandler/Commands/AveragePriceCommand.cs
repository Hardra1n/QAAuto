using AutoConsoleHandler.Model;
using AutoConsoleHandler.UI;

namespace AutoConsoleHandler.Commands
{
    public class AveragePriceCommand : ICommand
    {
        IWriter _writer;

        public AveragePriceCommand(IWriter writer)
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
