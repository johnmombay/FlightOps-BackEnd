using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AirportDTO
    {
        public int Id { get; set; }

        public string AirportName { get; set; }
        public string ICAO_Code { get; set; }
        public string IATA_Code { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int AirportCategory { get; set; } //

        public double StandardGroundTime { get; set; }
        public double MinimumGroundTime { get; set; }

        public DateTime OperationFrom { get; set; }
        public DateTime OperationTo { get; set; }
        public string PCN { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public CityDTO City { get; set; }
    }
    public class AirportDTO_edit
    {
        public int Id { get; set; }

        public string AirportName { get; set; }
        public string ICAO_Code { get; set; }
        public string IATA_Code { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int AirportCategory{ get; set; } 

        public double StandardGroundTime { get; set; }
        public double MinimumGroundTime { get; set; }

        public DateTime OperationFrom { get; set; }
        public DateTime OperationTo { get; set; }
        public string PCN { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
