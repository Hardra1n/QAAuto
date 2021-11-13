using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.Exceptions
{
    public class RemoveAutoException : VehicleException 
    {
        public RemoveAutoException(string message) : base(message) { }
    }
}
