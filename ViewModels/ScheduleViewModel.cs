using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheJunction.Models;

namespace TheJunction.ViewModels
{
    public class ScheduleViewModel
    {
        // TODO: add validation to all ViewModels

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;

        public virtual List<ShiftViewModel> Shifts { get; set; }

        #region Converted Properties

        public string CreatedByName { get; set; }

        public string ModifiedByName { get; set; }

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
                return list.Select(l => new SelectListItem { Selected = (l.Value == Id.ToString()), Text = l.Text, Value = l.Value });
            }
        }

        public IEnumerable<SelectListItem> CellCarrierList
        {
            get
            {
                var codes = new List<CodeDesc>();

                List<SelectListItem> list = new List<SelectListItem> {
                    new SelectListItem() {
                        Text = "AT&T", Value = "1"
                    },
                    new SelectListItem() {
                        Text = "Sprint", Value = "2"
                    },
                    new SelectListItem() {
                        Text = "Verizon", Value = "2"
                    },
                    new SelectListItem() {
                        Text = "Straight Talk", Value = "2"
                    }
            };
                return list.OrderBy(x => x.Text).Select(l => new SelectListItem { Selected = (l.Value == Id.ToString()), Text = l.Text, Value = l.Value });
            }
        }

        #endregion
    }
}
