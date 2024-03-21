using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class AirportCategoryDTO
    {
        public int Id { get; set; }

        public int CategoryNumber { get; set; }
        public string CategoryName { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
