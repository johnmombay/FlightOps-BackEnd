using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class CrewPositionDTO
    {
        public int Id { get; set; }

        public string PositionName { get; set; }
        public PositionTypeEnum PositionType { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class CrewPositionDTO_Edit
    {
        public int Id { get; set; }

        public string PositionName { get; set; }
        public PositionTypeEnum PositionType { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
