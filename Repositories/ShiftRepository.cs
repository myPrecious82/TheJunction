using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Data;
using TheJunction.Models;

namespace TheJunction.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private MyContext _context;

        public ShiftRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Shift> GetAllShifts()
        {
            return _context.Shifts.ToList();
        }

        public Shift GetShiftById(int Id)
        {
            return _context.Shifts.Find(Id);
        }

        public int DeleteShift(Shift shift)
        {
            _context.Shifts.Remove(shift);
            return _context.SaveChanges();

        }

        public Shift SaveShift(Shift shift)
        {
            if (shift.Id > 0)
            {
                _context.Shifts.Update(shift);
            }
            else
            {
                _context.Shifts.Attach(shift);
            }
            _context.SaveChanges();
            return shift;
        }
    }
}
