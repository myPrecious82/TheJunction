using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Models;

namespace TheJunction.ViewModels
{
    public class ShiftViewModel
    {
        public int ShiftId { get; set; }

        public int ScheduleId { get; set; } // will come from ScheduleViewModel

        public DateTime Day { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public int EmployeeId { get; set; } // will come from EmployeeViewModel

        public string strEmployeeId { get; set; }

        public bool IsOnCall { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;

        #region Converted Properties

        public string CreatedByName { get; set; }

        public string ModifiedByName { get; set; }

        public string EmployeeName { get; set; }

        #endregion

        #region SelectList

        public IEnumerable<SelectListItem> EmployeeList
        {
            get
            {
                var emps = new List<Employee>();


                List<SelectListItem> list = new List<SelectListItem> {
                    new SelectListItem() {
                        Text = "Alexis", Value = "1"
                    },
                    new SelectListItem() {
                        Text = "Tom", Value = "2"
                    },
                    new SelectListItem() {
                        Text = "Dena", Value = "3"
                    },
                    new SelectListItem() {
                        Text = "Employee 4", Value = "4"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 5", Value = "5"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 6", Value = "6"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 7", Value = "7"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 8", Value = "8"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 9", Value = "9"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 10", Value = "10"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 11", Value = "11"
                    } ,
                    new SelectListItem() {
                        Text = "Employee 12", Value = "12"
                    }  };
                return list.Select(l => new SelectListItem { Selected = (l.Value == EmployeeId.ToString()), Text = l.Text, Value = l.Value });
            }
        }

        #endregion
    }
}
