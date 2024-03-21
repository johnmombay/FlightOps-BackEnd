using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class Crew:_BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string PassportNo { get; set; }
        public DateTime PassportExpiryDate { get; set; }

        public int CrewPositionID { get; set; }
        [ForeignKey("CrewPositionID")]
        public CrewPosition CrewPosition { get; set; }
    }
}
