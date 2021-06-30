using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment2.Models;

namespace TaskAssignment2.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDBContext context) : base(context)
        {

        }

        public async Task<IList<Employee>> GetAllEmployeesWithIsActivedFalse()
        {
            var employees = await context.Set<Employee>().Where(emp => emp.IsActived == false).ToListAsync();

            return employees;
        }
    }
}
