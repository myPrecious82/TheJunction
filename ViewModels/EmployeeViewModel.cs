using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Models;

namespace TheJunction.ViewModels
{
    public class EmployeeViewModel
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

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;

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
