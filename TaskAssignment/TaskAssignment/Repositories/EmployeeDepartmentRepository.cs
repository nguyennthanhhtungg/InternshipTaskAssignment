using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public class EmployeeDepartmentRepository : GenericRepository<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        public EmployeeDepartmentRepository(EmployeeDBContext context) : base(context)
        {

        }

        public Task<EmployeeDepartment> GetLastestEmployeeDepartmentByEmployeeId(int employeeId)
        {
            return _context.Set<EmployeeDepartment>().Where<EmployeeDepartment>(ed => ed.EmployeeID == employeeId && ed.EndDate == null).FirstOrDefaultAsync();
        }

        public Task<EmployeeDepartment> GetLastestCompletedEmployeeDepartmentByEmployeeId(int employeeId)
        {
            return _context.Set<EmployeeDepartment>().Where<EmployeeDepartment>(ed => ed.EmployeeID == employeeId && ed.EndDate != null).OrderByDescending(ed => ed.StartDate).FirstOrDefaultAsync();
        }

        public Task<List<EmployeeDepartment>> GetEmployeeDepartmentListByEmployeeId(int employeeId)
        {
            return _context.Set<EmployeeDepartment>().Where<EmployeeDepartment>(ed => ed.EmployeeID == employeeId).ToListAsync();
        }
    }
}
