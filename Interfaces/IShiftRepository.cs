using System.Collections.Generic;
using TheJunction.Models;

namespace TheJunction.Repositories
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetAllShifts();
        Shift GetShiftById(int Id);
        int DeleteShift(Shift shift);
        Shift SaveShift(Shift shift);
    }
}