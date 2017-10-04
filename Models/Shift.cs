using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class Shift
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; } // will come from ScheduleViewModel

        public DateTime Day  { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public int? EmployeeId { get; set; }

        public bool IsOnCall { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }
    }
}
