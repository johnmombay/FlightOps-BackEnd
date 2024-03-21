using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class AircraftSchedule:_BaseEntity
    {
        public int FlightScheduleId { get; set; }
        [ForeignKey("FlightScheduleId")]
        public FlightSchedule FlightSchedule { get; set; }

        public int AircraftID { get; set; }
        [ForeignKey("AircraftID")]
        public Aircraft Aircraft { get; set; }

        public DateTime ASTD { get; set; }
        public DateTime ASTA { get; set; }

        public Nullable<DateTime> ATD { get; set; }
        public Nullable<DateTime> ATA { get; set; }

        public int AdultPAX { get; set; }
        public int ChildPAX { get; set; }
        public int Cargo { get; set; }

        public DateTime AircraftFlightDate { get; set; }
        public string Comments { get; set; }
    }
}
