using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Services.Helpers
{
    public class appException : Exception
    {
        public appException() : base() { }

        public appException(string message) : base(message) { }

        public appException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
