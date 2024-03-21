using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class CrewSchedule:_BaseEntity
    {
        public int FlightScheduleID { get; set; }
        [ForeignKey("FlightScheduleID")]
        public FlightSchedule FlightSchedule { get; set; }
        public int CrewID { get; set; }
        [ForeignKey("CrewID")]
        public Crew Crew { get; set; }
    }
}
