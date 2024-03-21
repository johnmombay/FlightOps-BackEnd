using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class Route:_BaseEntity
    {
        public int Id { get; set; }

        public int Origin { get; set; }//AirportID
        public int Destination { get; set; }//AirportID
        public double TripHours { get; set; }
        public double FlightHours { get; set; }

        [ForeignKey("Origin")]
        public Airport OriginAirport { get; set; }
        [ForeignKey("Destination")]
        public Airport DestinationAirport { get; set; }

    }
}
