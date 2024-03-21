using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class MaintenanceSchedule:_BaseEntity
    {
        public int AircraftMaintenanceID { get; set; }
        [ForeignKey("AircraftMaintenanceID")]
        public AircraftMaintenance AircraftMaintenance { get; set; }
        public int AircraftID { get; set; }
        [ForeignKey("AircraftID")]
        public Aircraft Aircraft { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string ResourceID { get; set; }

        public double Duration { get; set; }
        public DateTime MaintenanceDate { get; set; }

        public DateTime scheduleFrom { get; set; }
        public DateTime scheduleTo { get; set; }

    }
}
