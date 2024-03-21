using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AircraftMaintenanceDTO
    {
        public int Id { get; set; }

        public string MaintenanceCode { get; set; }
        public string MaintenanceName { get; set; }
        public double Duration { get; set; }
        public int AircraftTypeID { get; set; }
        public AircraftTypeDTO AircraftType { get; set; }

        public MaintenanceFrequencyEnum Frequency { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class AircraftMaintenanceDTO_Edit
    {
        public int Id { get; set; }

        public string MaintenanceCode { get; set; }
        public string MaintenanceName { get; set; }
        public double Duration { get; set; }
        public int AircraftTypeID { get; set; }

        public MaintenanceFrequencyEnum Frequency { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }

    }
}
