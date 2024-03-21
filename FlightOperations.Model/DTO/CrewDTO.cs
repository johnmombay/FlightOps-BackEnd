using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class CrewDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string PassportNo { get; set; }
        public DateTime PassportExpiryDate { get; set; }

        public int CrewPositionID { get; set; }
        public CrewPositionDTO CrewPosition { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
    public class CrewDTO_Edit
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string PassportNo { get; set; }
        public DateTime PassportExpiryDate { get; set; }

        public int CrewPositionID { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
