using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class Schedule_AircraftType : _BaseEntity
    {
        public int Airline_ScheduleID { get; set; }
        public int AircraftTypeId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Airline_ScheduleID")]
        public AirlineSchedule AirlineSchedule { get; set; }
        [ForeignKey("AircraftTypeId")]
        public AircraftType AircraftType {get;set;}

    }
}
