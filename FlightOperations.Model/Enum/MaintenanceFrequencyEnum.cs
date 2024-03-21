using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Enum
{
    public enum MaintenanceFrequencyEnum
    {
        OneTime = 1, 
        Daily = 2, //+1day
        Weekly = 3, // +7days
        BiMonthly = 4, //+14days
        Monthly = 5, // +1Month
        Quarterly = 6, //+3months
        SemiAnnual = 7, //+6months
        Annual =8, //+1year

    }
}
