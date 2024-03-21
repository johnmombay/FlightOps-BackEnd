using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Region { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<CityDTO> Cities { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class CountryDTO_edit
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Region { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        //public ICollection<CityDTO_Edit> Cities { get; set; }

        public bool IsDeleted { get; set; }
    }
}
