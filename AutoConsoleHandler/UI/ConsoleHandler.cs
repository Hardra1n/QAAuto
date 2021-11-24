using AutoConsoleHandler.Adders;
using AutoConsoleHandler.Commands;
using AutoConsoleHandler.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.UI
{
    public class ConsoleHandler : IWriter
    {
        Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public ConsoleHandler()
        {
            CommandInit();
        }

        public void Start()
        {
            while (true)
            {
                InterpitateCommand(Console.ReadLine());
            }
        }
        
        private void CommandInit()
        {
            commands.Add("average price", new AveragePriceCommand(this));
            commands.Add("count all", new CountAllCommand(this));
            commands.Add("count types", new CountTypesCommand(this));
            commands.Add("exit", new ExitCommand());
            InitAveragePriceTypeCommand();
        }

        private void InitAveragePriceTypeCommand()
        {
            foreach (string type in CarPark.GetInstance().GetUniqueTypes())
            {
                commands.Add("average price " + type, new AveragePriceTypeCommand(this, type));
            }
        }

        private void InterpitateCommand(string command)
        {
            if (commands.ContainsKey(command))
            {
                commands[command].Execute();
            }
            else
            {
                Console.WriteLine("Unrecognized command");
            }
        }

        public void Write<T>(T data)
        {
            Console.WriteLine(data);
        }
    }
}
