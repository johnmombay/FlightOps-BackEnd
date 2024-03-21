using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AircraftTypeDTO
    {
        public int Id { get; set; }

        public string AircraftTypeName { get; set; }
        public string Make { get; set; }

        public int ACN { get; set; }
        public int CategoryNumber { get; set; }

        public double MaximumFlightHours { get; set; }
        public List<AircraftDTO> Aircrafts { get; set; }
        public int AircraftCount { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class AircraftTypeDTO_Edit
    {
        public int Id { get; set; }

        public string AircraftTypeName { get; set; }
        public string Make { get; set; }

        public int ACN { get; set; }
        public int CategoryNumber { get; set; }

        public double MaximumFlightHours { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
