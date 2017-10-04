using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.ViewModels
{
    public class ScheduleTwoShiftDayViewModel
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; } // will come from ScheduleViewModel

        public DateTime Day  { get; set; }

        public int Open1EmployeeId { get; set; } // will come from EmployeeViewModel

        public int Open2EmployeeId { get; set; } // will come from EmployeeViewModel

        public int Close1EmployeeId { get; set; } // will come from EmployeeViewModel

        public int Close2EmployeeId { get; set; } // will come from EmployeeViewModel

        public int OnCall1EmployeeId { get; set; } // will come from EmployeeViewModel

        public int OnCall2EmployeeId { get; set; } // will come from EmployeeViewModel

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;
    }
}
