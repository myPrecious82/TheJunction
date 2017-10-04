using System.Collections.Generic;
using TheJunction.Models;

namespace TheJunction.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int Id);
        int DeleteEmployee(Employee emp);
        Employee SaveEmployee(Employee emp);
    }
}