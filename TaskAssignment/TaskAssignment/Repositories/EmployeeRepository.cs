using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDBContext context) : base(context)
        {

        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Set<Employee>().Where<Employee>(emp => emp.EmployeeId == id).FirstOrDefaultAsync();
        }
    }
}
