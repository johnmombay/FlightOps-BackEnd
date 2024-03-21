using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class City:_BaseEntity
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
