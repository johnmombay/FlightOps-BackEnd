using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
   public class AircraftMaintenance:_BaseEntity
   {
        public string MaintenanceCode { get; set; }
        public string MaintenanceName { get; set; }
        public double Duration { get; set; }
        public int AircraftTypeID { get; set; }
        [ForeignKey("AircraftTypeID")]
        public AircraftType AircraftType { get; set; }

        public MaintenanceFrequencyEnum Frequency { get; set; }
   }
}
