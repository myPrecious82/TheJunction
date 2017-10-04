using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class TimeOffRequest
    {
        public int Id { get; set; }

        public DateTime RequestedDate { get; set; }

        public int Reason { get; set; } // will come from CodeDesc table

        public int TimeNeeded { get; set; } // will come from CodeDesc table

        public string Explanation { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDenied { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }
    }
}
