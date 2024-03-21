using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AirlineScheduleDTO
    {
        public int Id { get; set; }

        public string ScheduleName { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        
        public bool isPublished { get; set; }

        public ICollection<Schedule_AircraftTypeDTO> AircraftTypes { get; set; }
        public ICollection<ScheduleResourceDTO> ScheduleResources { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class AirlineScheduleDTO_edit
    {
        public int Id { get; set; }

        public string ScheduleName { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public bool isPublished { get; set; }

        public ICollection<Schedule_AircraftTypeDTO_edit> AircraftTypes { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class AirlineScheduleDTO_verify
    {
        public int Id { get; set; }
        public string ScheduleName { get; set; }

        public int UpdatedBy { get; set; }
    }
}
