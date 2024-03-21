using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class Country:_BaseEntity
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Region { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
