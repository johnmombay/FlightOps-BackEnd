using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }

        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public CountryDTO Country { get; set; }
    }
    public class CityDTO_Edit
    {
        public int Id { get; set; }

        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
