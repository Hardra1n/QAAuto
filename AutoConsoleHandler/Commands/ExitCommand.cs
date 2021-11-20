using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
