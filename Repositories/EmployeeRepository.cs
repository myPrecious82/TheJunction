using System.Collections.Generic;
using System.Linq;
using TheJunction.Data;
using TheJunction.Models;

namespace TheJunction.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MyContext _context;

        public EmployeeRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public int DeleteEmployee(Employee emp)
        {
            _context.Employees.Remove(emp);
            return _context.SaveChanges();

        }

        public Employee SaveEmployee(Employee emp)
        {
            if (emp.Id > 0)
            {
                _context.Employees.Update(emp);
            }
            else
            {
                _context.Employees.Attach(emp);
            }
            _context.SaveChanges();
            return emp;
        }
    }
}
