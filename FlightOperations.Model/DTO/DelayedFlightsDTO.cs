using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class DelayedFlightsDTO
    {
        public DateTime DateRequested { get; set; }

        public int NumOfFlights { get; set; }
        public double TotalMinutesDelayed { get; set; }
    }
    public class NumberOfFlightsDTO
    {
        public DateTime DateRequested { get; set; }
        public int TotalAdultPAX { get; set; }
        public int TotalChildPAX { get; set; }
        public int TotalCargo { get; set; }
        public int NumOfFlights { get; set; }
        public int NumberOfAircraft { get; set; }
        public List<NumberOfAircraftType> NumberOfAircraftType { get; set; }
    }
    public class CrewsAssignedDTO
    {
        public DateTime DateRequested { get; set; }

        public string PositionName { get; set; }
        public int NumberOfAssigned { get; set; }
        public PositionTypeEnum PositionType { get; set; }
    }
    public class NumberOfAircraftType
    {
        public string AircraftTypeName { get; set; }
        public int quantity { get; set; }

    }
    
}
