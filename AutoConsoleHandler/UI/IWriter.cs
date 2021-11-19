using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsoleHandler.UI
{
    interface IWriter
    {
        void Write<T>(T data);
    }
}
