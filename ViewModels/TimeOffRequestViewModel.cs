using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.ViewModels
{
    public class TimeOffRequestViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; } // will come from EmployeeViewModel

        public DateTime RequestedDate { get; set; }

        public int Reason { get; set; } // will come from CodeDesc table

        public int TimeNeeded { get; set; } // will come from CodeDesc table

        public string Explanation { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDenied { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;
    }
}
