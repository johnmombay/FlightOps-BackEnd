using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class AirlineSchedule:_BaseEntity
    {
        public string ScheduleName { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public bool isPublished { get; set; }

        public ICollection<Schedule_AircraftType> AircraftTypes { get; set; }
        public ICollection<ScheduleResource> ScheduleResources { get; set; }
    }
}
