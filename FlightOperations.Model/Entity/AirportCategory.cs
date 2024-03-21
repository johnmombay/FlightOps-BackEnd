using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class AirportCategory:_BaseEntity
    {
        public int CategoryNumber { get; set; }
        public string CategoryName { get; set; }
    }
}
