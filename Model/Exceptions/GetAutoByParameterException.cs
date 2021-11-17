using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleXML.Model.Exceptions
{
    public class GetAutoByParameterException : VehicleException
    {
        public GetAutoByParameterException(string message) : base(message) { }

        public GetAutoByParameterException(string message, Exception inner) : base(message, inner) { } 
    }
}
