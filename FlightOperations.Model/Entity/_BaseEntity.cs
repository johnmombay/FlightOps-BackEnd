﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public abstract class _BaseEntity
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }
    }
}
