using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.ViewModels
{
    public class PumpPriceViewModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;
    }
}
