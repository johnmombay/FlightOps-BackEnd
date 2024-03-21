using FlightOperations.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class CrewPosition:_BaseEntity
    {
        public string PositionName { get; set; }
        public PositionTypeEnum PositionType { get; set; }
    }
}
