using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.ViewModels
{
    public class EmployeeHandbookAcceptanceViewModel
    {
        public int Id { get; set; }

        public int EmployeeHandbookId { get; set; } // will come from EmployeeHandbookViewModel

        public int EmployeeId { get; set; } // will come from EmployeeViewModel

        public bool IsAccepted { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;
    }
}
