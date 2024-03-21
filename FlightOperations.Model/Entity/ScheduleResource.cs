using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class ScheduleResource:_BaseEntity
    {
        public int AirlineScheduleID { get; set; }
        public int AircraftTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("AirlineScheduleID")]
        public AirlineSchedule AirlineSchedule { get; set; }
    }
}
