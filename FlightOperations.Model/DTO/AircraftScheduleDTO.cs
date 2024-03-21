using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AircraftScheduleDTO
    {
        public int Id { get; set; }

        public int FlightScheduleId { get; set; }
        public int AircraftID { get; set; }

        public DateTime ASTD { get; set; }
        public DateTime ASTA { get; set; }

        public Nullable<DateTime> ATD { get; set; }
        public Nullable<DateTime> ATA { get; set; }

        public int AdultPAX { get; set; }
        public int ChildPAX { get; set; }
        public int Cargo { get; set; }

        public string Comments { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public FlightScheduleDTO FlightSchedule { get; set; }
        public AircraftDTO Aircraft { get; set; }

        public bool isDeleted { get; set; }
    }
    public class AssignAircraftSchedDTO
    {
        public int AirlineScheduleID { get; set; }
        public int ResourceID { get; set; }
        public int AircraftID { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class UpdateAircraftSchedDTO
    {
        public int AirlineScheduleID { get; set; }
        public int ResourceID { get; set; } //AircraftID
        public int AircraftScheduleId { get; set; }

        public DateTime ASTD { get; set; }
    }

    public class ActualFlightDTO
    {
        public int AirlineScheduleID { get; set; }
        public int ResourceID { get; set; }
        public int AircraftScheduleId { get; set; }

        public Nullable<DateTime> ATD { get; set; }
        public Nullable<DateTime> ATA { get; set; }

        public int AdultPAX { get; set; }
        public int ChildPAX { get; set; }
        public int Cargo { get; set; }

        public string Comments { get; set; }
    }
}
