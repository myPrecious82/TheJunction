using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class ShiftTradeRequest
    {
        public int Id { get; set; }

        public int Employee1ShiftId { get; set; } // will come from ShiftViewModel??

        public int Employee2ShiftId { get; set; } // will come from ShiftViewModel??

        public bool IsEmployee2Approved { get; set; }

        public string Explanation { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDenied { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }
    }
}
