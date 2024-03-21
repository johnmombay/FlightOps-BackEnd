using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class ScheduleResourceDTO
    {
        public int Id { get; set; }

        public int AirlineScheduleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
