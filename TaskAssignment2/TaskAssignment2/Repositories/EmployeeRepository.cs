using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssignment2.Models;

namespace TaskAssignment2.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDBContext context) : base(context)
        {

        }

        public IList<Employee> GetAllEmployeesWithIsActivedFalse()
        {
            var employees = context.Set<Employee>().Where(emp => emp.IsActived == false).ToList();

            return employees;
        }
    }
}
