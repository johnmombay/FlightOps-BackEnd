using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class RouteDTO
    {
        public int Id { get; set; }

        public int Origin { get; set; }//AirportID
        public int Destination { get; set; }//AirportID
        public double TripHours { get; set; }
        public double FlightHours { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }

        public AirportDTO OriginAirport { get; set; }
        public AirportDTO DestinationAirport { get; set; }
    }
    public class RouteDTO_Edit
    {
        public int Id { get; set; }

        public int Origin { get; set; }//AirportID
        public int Destination { get; set; }//AirportID
        public double TripHours { get; set; }
        public double FlightHours { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
}
