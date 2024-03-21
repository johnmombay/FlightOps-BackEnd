using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class Aircraft : _BaseEntity
    {
        public int AircraftTypeId { get; set; }
        public int FirstCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public int PeconomyCapacity { get; set; }
        public int EconomyCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public string Registration { get; set; }
        public int CountryOfRegistration { get; set; }//CountryId
        public DateTime DateOfRegistration { get; set; }

        [ForeignKey("AircraftTypeId")]
        public AircraftType AircraftType { get; set; }
        [ForeignKey("CountryOfRegistration")]
        public Country Country { get; set; }

        public int FlightScheduleID { get; set; }
        public int AircraftScheduleID { get; set; }
    }
}
