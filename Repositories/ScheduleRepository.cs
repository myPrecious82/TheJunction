using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Data;
using TheJunction.Models;

namespace TheJunction.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private MyContext _context;

        public ScheduleRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public Schedule GetScheduleById(int Id)
        {
            return _context.Schedules.Find(Id);
        }

        public int DeleteSchedule(Schedule sched)
        {
            _context.Schedules.Remove(sched);
            return _context.SaveChanges();

        }

        public Schedule SaveSchedule(Schedule sched)
        {
            if (sched.Id > 0)
            {
                _context.Schedules.Update(sched);
            }
            else
            {
                _context.Schedules.Attach(sched);
            }
            _context.SaveChanges();
            return sched;
        }
    }
}
