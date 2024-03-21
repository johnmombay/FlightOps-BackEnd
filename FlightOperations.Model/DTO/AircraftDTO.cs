using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AircraftDTO
    {
        public int Id { get; set; }

        public int AircraftTypeId { get; set; }
        public int FirstCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public int PeconomyCapacity { get; set; }
        public int EconomyCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public string Registration { get; set; }
        public int CountryOfRegistration { get; set; }//CountryId
        public DateTime DateOfRegistration { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int FlightScheduleID { get; set; }
        public int AircraftScheduleID { get; set; }

        public AircraftTypeDTO AircraftType { get; set; }
        public CountryDTO Country { get; set; }
    }
    public class AircraftDTO_edit
    {
        public int Id { get; set; }

        public int AircraftTypeId { get; set; }
        public int FirstCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public int PeconomyCapacity { get; set; }
        public int EconomyCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public string Registration { get; set; }
        public int CountryOfRegistration { get; set; }//CountryId
        public DateTime DateOfRegistration { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
