using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class EmployeeHandbook
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }

        public List<EmployeeHandbookAcceptance> EmployeeHandbookAcceptances { get; set; }
    }
}
