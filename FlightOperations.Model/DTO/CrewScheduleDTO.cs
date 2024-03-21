using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class CrewScheduleDTO
    {
        public int ID { get; set; }
        public int FlightScheduleID { get; set; }
        public FlightScheduleDTO FlightSchedule { get; set; }

        public int CrewID { get; set; }
        public CrewDTO Crew { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }

    }
    public class CrewScheduleDTO_Edit
    {
        public int ID { get; set; }
        public int FlightScheduleID { get; set; }
        public int CrewID { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }

    public class BatchCrewScheduleDTO
    {
        public List<CrewScheduleDTO_Edit> CrewSchedules { get; set; }
    }
}
