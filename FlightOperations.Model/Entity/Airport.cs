using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class Airport : _BaseEntity
    {
        public string AirportName { get; set; }
        public string ICAO_Code { get; set; }
        public string IATA_Code { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int AirportCategory{ get; set; } 

        public DateTime OperationFrom { get; set; }
        public DateTime OperationTo{ get; set; }
        public string PCN { get; set; }
       
        public double StandardGroundTime { get; set; }
        public double MinimumGroundTime { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
