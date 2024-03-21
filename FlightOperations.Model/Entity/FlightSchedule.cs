using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class FlightSchedule:_BaseEntity
    {
        public int resourceId { get; set; }//aircraftTypeId

        public string FlightNo { get; set; }
        public string OutboundFlightNo { get; set; }
        public string InboundFlightNo { get; set; }
        //public int RouteId { get; set; }
        public DateTime STD { get; set; }
        public DateTime STA { get; set; }

        public int AirlineScheduleID { get; set; }
        [ForeignKey("AirlineScheduleID")]
        public AirlineSchedule AirlineSchedule { get; set; }

        public int AircraftTypeID { get; set; }
        [ForeignKey("AircraftTypeID")]
        public AircraftType AircraftType { get; set; }
        public FlightStatusEnum Status { get; set; }

        public double FlyingHours { get; set; }
        public double BlockTime { get; set; }

        public DateTime FlightDate { get; set; }

        public int Airport_OriginID { get; set; }
        [ForeignKey("Airport_OriginID")]
        public Airport Airport_Origin { get; set; }

        public int Airport_DestinationID { get; set; }
        [ForeignKey("Airport_DestinationID")]
        public Airport Airport_Destination { get; set; }

        public string Days { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public bool isReturn { get; set; }
        //[ForeignKey("RouteId")]
        //public Route Route { get; set; }
    }
}
