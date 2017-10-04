using System.Collections.Generic;
using TheJunction.Models;

namespace TheJunction.Repositories
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> GetAllSchedules();
        Schedule GetScheduleById(int Id);
        int DeleteSchedule(Schedule sched);
        Schedule SaveSchedule(Schedule sched);
    }
}