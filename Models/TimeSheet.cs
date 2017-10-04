using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTimestamp { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndTimestamp { get; set; }

        public bool IsOnCall { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }
    }
}
