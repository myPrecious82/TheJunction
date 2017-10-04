using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Data;
using TheJunction.Models;
using TheJunction.Repositories;
using TheJunction.Services;
using TheJunction.ViewModels;

namespace TheJunction.Controllers.Web
{
    public class EmployeeController : Controller
    {
        private ICommonService _commonService;
        private IScheduleRepository _scheduleRepository;
        private IEmployeeRepository _employeeRepository;
        private IShiftRepository _shiftRepository;

        public EmployeeController(
            ICommonService commonService,
            IScheduleRepository scheduleRepository,
            IEmployeeRepository employeeRepository,
            IShiftRepository shiftRepository)
        {
            _commonService = commonService;
            _scheduleRepository = scheduleRepository;
            _employeeRepository = employeeRepository;
            _shiftRepository = shiftRepository;
        }

        private List<ShiftViewModel> GetShiftListByScheduleId(int schedId)
        {
            List<Shift> shifts = _shiftRepository.GetAllShifts().Where(x => x.ScheduleId == schedId).ToList();
            var vmShifts = Mapper.Map<IEnumerable<ShiftViewModel>>(shifts);

            return vmShifts.OrderBy(x => x.StartTime).ToList();
        }

        public IActionResult EmployeeHandbook(EmployeeHandbookAcceptanceViewModel model)
        {
#if DEBUG
            model.IsAccepted = true;
#endif
            return View(model);
        }

        public IActionResult FullSchedule()
        {
            //get current schedule
            var sched = _scheduleRepository.GetAllSchedules().Where(x => x.StartDate.Date <= DateTime.Now && x.StartDate.Date.AddDays(14).AddSeconds(-1) >= DateTime.Now).FirstOrDefault();
            var vmSched = Mapper.Map<Schedule>(sched);

            return View(vmSched);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyContactInformation(EmployeeViewModel model)
        {
            return View(model);
        }

        public IActionResult MySchedule()
        {
            //get current schedule
            var sched = _scheduleRepository.GetAllSchedules().Where(x => x.StartDate.Date <= DateTime.Now && x.StartDate.Date.AddDays(14).AddSeconds(-1) >= DateTime.Now).FirstOrDefault();
            var vmSched = Mapper.Map<Schedule>(sched);

            return View(vmSched);
        }

        public IActionResult MyShiftTradeRequests(ShiftTradeRequestViewModel model)
        {
            return View(model);
        }

        public IActionResult MyTimeOffRequests(TimeOffRequestViewModel model)
        {
            return View(model);
        }

        public IActionResult MyTimesheet(TimeSheetViewModel model)
        {
            return View(model);
        }

        public IActionResult ShiftTradeRequestForm(ShiftTradeRequestViewModel model)
        {
            return View(model);
        }

        public IActionResult TimeOffRequestForm(TimeOffRequestViewModel model)
        {
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
