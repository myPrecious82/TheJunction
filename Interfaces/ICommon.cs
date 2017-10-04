using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheJunction.Models;

namespace TheJunction.Services
{
    public interface ICommonService
    {
        IEnumerable<SelectListItem> GetEmployeeSelectList();
        Schedule CreateBlankSchedule();
    }
}