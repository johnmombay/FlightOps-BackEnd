using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class AircraftType:_BaseEntity
    {
        public string AircraftTypeName { get; set; }
        public string Make { get; set; }

        public double MaximumFlightHours { get; set; }
        public int ACN { get; set; }
        public int CategoryNumber { get; set; }
    }
}
