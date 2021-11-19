using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.UI
{
    public class ConsoleHandler : IWriter
    {
        public void Write<T>(T data)
        {
            Console.Write(data);
        }
    }
}
