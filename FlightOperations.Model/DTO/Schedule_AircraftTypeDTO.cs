using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class Schedule_AircraftTypeDTO
    {
        public int Id { get; set; }

        public int Airline_ScheduleID { get; set; }
        public int AircraftTypeId { get; set; }
        public int Quantity { get; set; }

        public AirlineScheduleDTO AirlineSchedule { get; set; }
        public AircraftTypeDTO AircraftType { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class Schedule_AircraftTypeDTO_edit
    {
        public int Id { get; set; }

        public int Airline_ScheduleID { get; set; }
        public int AircraftTypeId { get; set; }
        public int Quantity { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
}
