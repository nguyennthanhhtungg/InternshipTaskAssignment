using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public interface IEmployeeDepartmentRepository : IGenericRepository<EmployeeDepartment>
    {
        Task<EmployeeDepartment> GetLastestEmployeeDepartmentByEmployeeId(int employeeId);

        Task<EmployeeDepartment> GetLastestCompletedEmployeeDepartmentByEmployeeId(int employeeId);

        Task<List<EmployeeDepartment>> GetEmployeeDepartmentListByEmployeeId(int employeeId);
    }
}
