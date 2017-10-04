using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Models;

namespace TheJunction.Data
{
    public class MyContextSeedData
    {
        private MyContext _context;

        public MyContextSeedData(MyContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            // seed codedesc
            if (!_context.CodeDesc.Any())
            {
                var codedesc = new CodeDesc();

                codedesc = new CodeDesc() { GroupId = "CELLCARR", Description = "AT&T", Order = 1, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.CodeDesc.Add(codedesc);

                codedesc = new CodeDesc() { GroupId = "CELLCARR", Description = "Verizon", Order = 2, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.CodeDesc.Add(codedesc);

                codedesc = new CodeDesc() { GroupId = "CELLCARR", Description = "Sprint", Order = 3, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.CodeDesc.Add(codedesc);

                await _context.SaveChangesAsync();
            }

            // seed employees
            if (!_context.Employees.Any())
            {
                _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Employees', RESEED, 0)");
                var emp = new Employee();

                emp = new Employee() { FirstName = "Alexis", LastName = "Atchison", Address1 = "1610 S Pasfield St", Address2 = "", City = "Sringfield", State = "IL", Zip = "62704", CellNumber = "2174736447", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Tom", LastName = "Smith", Address1 = "607 Stewart Rd", Address2 = "", City = "Franklin", State = "IL", Zip = "62638", CellNumber = "2174737501", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Dena", LastName = "Smith", Address1 = "607 Stewart Rd", Address2 = "", City = "Franklin", State = "IL", Zip = "62638", CellNumber = "2174735703", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "4", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "5", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "6", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "7", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "8", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "9", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "10", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "11", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                emp = new Employee() { FirstName = "Employee", LastName = "12", Address1 = "", Address2 = "", City = "", State = "", Zip = "", CellNumber = "", CellCarrierId = 1, IsActive = true, Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Employees.Add(emp);

                await _context.SaveChangesAsync();
            }

            // seed schedule & shift template
            if (!_context.Schedules.Any())
            {
                _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Shifts', RESEED, 0)");
                _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Schedules', RESEED, 0)");
                var sched = new Schedule();

                sched = new Schedule() { StartDate = DateTime.Now.Date, EndDate = DateTime.Now.AddDays(13), Created = DateTime.Now, CreatedBy = 1, Modified = DateTime.Now, ModifiedBy = 1 };
                _context.Schedules.Add(sched);

                await _context.SaveChangesAsync();

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

                await _context.SaveChangesAsync();
            }
        }
    }
}