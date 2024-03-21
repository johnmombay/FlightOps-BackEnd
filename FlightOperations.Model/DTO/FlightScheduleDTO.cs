using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class FlightScheduleDTO
    {
        public int Id { get; set; }
        public int resourceId { get; set; }//aircraftTypeId

        public string FlightNo { get; set; }
        public string OutboundFlightNo { get; set; }
        public string InboundFlightNo { get; set; }
        //public int RouteId { get; set; }
        public DateTime STD { get; set; }
        public DateTime STA { get; set; }

        public int AirlineScheduleID { get; set; }
        //public AirlineScheduleDTO AirlineSchedule { get; set; }

        public int AircraftTypeID { get; set; }
        public AircraftTypeDTO AircraftType { get; set; }
        public FlightStatusEnum Status { get; set; }

        public double FlyingHours { get; set; }
        public double BlockTime { get; set; }

        public DateTime FlightDate { get; set; }

        public int Airport_OriginID { get; set; }
        public AirportDTO Airport_Origin { get; set; }

        public int Airport_DestinationID { get; set; }
        public AirportDTO Airport_Destination { get; set; }

        public string Days { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public bool isReturn { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class FlightScheduleDTO_Return
    {
        public string Id { get; set; }
        public int resourceId { get; set; } 
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string Title { get; set; }
        public FlightStatusEnum Status { get; set; }
        public FlightScheduleDTO FlightDetails { get; set; }
        public AircraftScheduleDTO AircraftSchedule { get; set; }
        public IEnumerable<CrewDTO> Crews { get; set; }     
        public AircraftDTO Aircraft { get; set; }
        public string EventType { get; set; }
        public string FlightStatus { get; set; }
    }
}
