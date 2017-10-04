using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.Models
{
    public class CodeDesc
    {
        public int Id { get; set; }

        public string GroupId { get; set; }

        public int Order { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public int ModifiedBy { get; set; }

        //#region select lists

        //public IEnumerable<SelectListItem> GetCodeDescSelectList(string groupId)
        //{
        //    var list = new List<CodeDesc>().Where(x => x.GroupId == groupId).ToList;


        //    List<SelectListItem> list = new List<SelectListItem> {
        //            new SelectListItem() {
        //                Text = "Tom", Value = "2"
        //            },
        //            new SelectListItem() {
        //                Text = "Dena", Value = "3"
        //            } };
        //    return list.Select(l => new SelectListItem { Selected = (l.Value == Id.ToString()), Text = l.Text, Value = l.Value });
        //}
        //#endregion
    }
}
