using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using TheJunction.Data;
using TheJunction.Models;

namespace TheJunction.Services
{
    public class CommonService : ICommonService
    {
        private MyContext _context;

        public CommonService(MyContext context)
        {
            _context = context;
        }

        public Schedule CreateBlankSchedule()
        {
            // get most recent schedule - we need the end date
            var newStartDate = _context.Schedules.OrderByDescending(x => x.StartDate).First().StartDate.AddDays(14);


            var sched = new Schedule();

            sched = new Schedule() { StartDate = newStartDate, EndDate = newStartDate.AddDays(13), Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
            _context.Schedules.Add(sched);
            _context.SaveChanges();

            var shift = new Shift();
            for (var date = sched.StartDate; date <= sched.EndDate; date = date.AddDays(1))
            {
                switch (date.DayOfWeek)
                {
                    // add all weekday shifts
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        {
                            // opening shifts
                            // employee 1
                            // default to Tom & Dena
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 05, 30, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 08, 00, 00),
                                EmployeeId = 2,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 05, 30, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 08, 00, 00),
                                EmployeeId = 3,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of opening shifts

                            // midday shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 08, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 16, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 08, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 16, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of midday shifts

                            // closing shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 16, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 16, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of closing shifts

                            // on-call shift
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = true,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of on-call shift
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            // opening shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 05, 30, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 14, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 05, 30, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 14, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of opening shifts

                            // closing shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 13, 45, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 13, 45, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of closing shifts

                            // on-call shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = true,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 21
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 23, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 23, 00, 00),
                                EmployeeId = null,
                                IsOnCall = true,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of on-call shifts
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            // opening shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 06, 30, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 14, 15, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {

                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 06, 30, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 14, 15, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of opening shifts

                            // closing shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 14, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 2
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 14, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = false,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of closing shifts

                            // on-call shifts
                            // employee 1
                            shift = new Shift()
                            {
                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 22, 00, 00),
                                EmployeeId = null,
                                IsOnCall = true,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // employee 21
                            shift = new Shift()
                            {

                                ScheduleId = sched.Id,
                                Day = date,
                                StartTime = new DateTime(date.Year, date.Month, date.Day, 23, 00, 00),
                                EndTime = new DateTime(date.Year, date.Month, date.Day, 23, 00, 00),
                                EmployeeId = null,
                                IsOnCall = true,
                                Created = DateTime.Now,
                                CreatedBy = 1,
                                Modified = DateTime.Now,
                                ModifiedBy = 1
                            };
                            _context.Shifts.Add(shift);

                            // end of on-call shifts
                            break;
                        }
                }
            }

            _context.SaveChanges();
            return sched;
        }

        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            var emps = _context.Employees.ToList();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Employee emp in emps)
            {
                list.Add(new SelectListItem()
                {
                    Text = $"{emp.FirstName} {emp.LastName.Substring(0, 1)}",
                    Value = emp.Id.ToString()
                });
            }
            return list;
        }
    }
}
