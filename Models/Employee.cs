using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [MaxLength(200)]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [MaxLength(200)]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Address 1")]
        [MaxLength(200)]
        [Required]
        public string Address1 { get; set; }

        [DisplayName("Address 2")]
        [MaxLength(200)]
        public string Address2 { get; set; }

        [DisplayName("City")]
        [MaxLength(200)]
        [Required]
        public string City { get; set; }

        [DisplayName("State")]
        [MaxLength(50)]
        [Required]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [MaxLength(5)]
        [Required]
        public string Zip { get; set; }

        [DisplayName("Cell Phone Number"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "")]
        [MaxLength(200)]
        [Required]
        public string CellNumber { get; set; }

        [DisplayName("Cell Phone Carrier")]
        [Required]
        public int CellCarrierId { get; set; } // will come from CodeDesc table

        public bool IsActive { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }

        public List<EmployeeHandbookAcceptance> HandbookAcceptances { get; set; }

        public List<Shift> Shifts { get; set; }

        public List<ShiftTradeRequest> ShiftTradeRequests { get; set; }

        public List<TimeOffRequest> TimeOffRequests { get; set; }

        public List<TimeSheet> TimeSheets { get; set; }
    }


}
