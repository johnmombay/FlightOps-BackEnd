using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class MaintenanceScheduleDTO
    {
        public int Id { get; set; }

        public int AircraftMaintenanceID { get; set; }
        public AircraftMaintenanceDTO AircraftMaintenance { get; set; }
        public int AircraftID { get; set; }
        public AircraftDTO Aircraft { get; set; }

        public DateTime scheduleFrom { get; set; }
        public DateTime scheduleTo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string ResourceID { get; set; }

        public double Duration{ get; set; }
        public DateTime MaintenanceDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class MaintenanceScheduleDTO_Edit
    {
        public int Id { get; set; }

        public int AircraftMaintenanceID { get; set; }
        public int AircraftID { get; set; }

        public DateTime scheduleFrom { get; set; }
        public DateTime scheduleTo { get; set; }
        public DateTime StartTime { get; set; }

        public string ResourceID { get; set; }
        public DateTime MaintenanceDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class MaintenanceScheduleDTO_Return
    {
        public int Id { get; set; }
        public string resourceId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string Title { get; set; }
        public AircraftDTO Aircraft { get; set; }
        public AircraftMaintenanceDTO MaintenanceDetails { get; set; }
    }
}
