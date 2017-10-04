using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Models;
using TheJunction.Repositories;
using TheJunction.Services;
using TheJunction.ViewModels;

namespace TheJunction.Controllers.Web
{
    public class ManagerController : Controller
    {
        private ICommonService _commonService;
        private IScheduleRepository _scheduleRepository;
        private IEmployeeRepository _employeeRepository;
        private IShiftRepository _shiftRepository;
        private ILogger<ManagerController> _logger;

        public ManagerController(
            ICommonService commonService,
            IScheduleRepository scheduleRepository,
            IEmployeeRepository employeeRepository,
            IShiftRepository shiftRepository,
            ILogger<ManagerController> logger)
        {
            _commonService = commonService;
            _scheduleRepository = scheduleRepository;
            _employeeRepository = employeeRepository;
            _shiftRepository = shiftRepository;
            _logger = logger;
        }

        private List<ShiftViewModel> GetShiftListByScheduleId(int schedId)
        {
            List<Shift> shifts = _shiftRepository.GetAllShifts().Where(x => x.ScheduleId == schedId).ToList();
            var vmShifts = Mapper.Map<IEnumerable<ShiftViewModel>>(shifts);

            return vmShifts.OrderBy(x => x.StartTime).ToList();
        }

        private Shift GetShiftById(int Id)
        {
            return _shiftRepository.GetShiftById(Id);
        }

        public IActionResult Employee()
        {
            List<Employee> emps = _employeeRepository.GetAllEmployees().ToList();
            var vmEmps = Mapper.Map<IEnumerable<EmployeeViewModel>>(emps);

            return View(vmEmps);
        }

        public IActionResult EmployeeDetail(int Id)
        {
            Employee emp = _employeeRepository.GetEmployeeById(Id);
            var vmEmp = Mapper.Map<EmployeeViewModel>(emp);

            return View(vmEmp);
        }

        public IActionResult Schedule()
        {
            List<Schedule> scheds = _scheduleRepository.GetAllSchedules().ToList();
            var vmScheds = Mapper.Map<IEnumerable<ScheduleViewModel>>(scheds);

            return View(vmScheds);
        }

        public IActionResult ScheduleDetail(int id)
        {
            Schedule sched = new Schedule();

            List<ShiftViewModel> vmShifts = new List<ShiftViewModel>();
            vmShifts = GetShiftListByScheduleId(id);
            var vmSched = new ScheduleViewModel();

            if (id == 0)
            {
                // create a new blank schedule template
                _commonService.CreateBlankSchedule();
            }
            else
            {
                // get the schedule
                sched = _scheduleRepository.GetScheduleById(id);
            }

            vmSched = Mapper.Map<ScheduleViewModel>(sched);

            //get the shifts
            vmSched.Shifts = GetShiftListByScheduleId(id);

            return View(vmSched);
        }

        public IActionResult SaveShift(ShiftViewModel vmShift)
        {
            var shift = Mapper.Map<Shift>(vmShift);

            shift = _shiftRepository.SaveShift(shift);

            return RedirectToAction("ScheduleDetail", new { id = shift.ScheduleId });
        }

        public IActionResult DailySheet()
        {
            return View();
        }

        public IActionResult EmployeeHandbook()
        {
            return View();
        }

        public IActionResult FoodInstructions()
        {
            return View();
        }

        public IActionResult FoodLabels()
        {
            return View();
        }

        public IActionResult FoodMenu()
        {
            return View();
        }

        public IActionResult FoodRecipes()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }

        public IActionResult OtherPOSReports()
        {
            return View();
        }

        public IActionResult PumpPrices()
        {
            return View();
        }

        public IActionResult ReportFuel()
        {
            return View();
        }

        public IActionResult ReportLottery()
        {
            return View();
        }

        public IActionResult ReportTotalsDaily()
        {
            return View();
        }

        public IActionResult ReportTotalsMonthly()
        {
            return View();
        }

        public IActionResult ShiftTradeRequest()
        {
            return View();
        }

        public IActionResult TimeOffRequest()
        {
            return View();
        }

        public IActionResult Timesheets()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
