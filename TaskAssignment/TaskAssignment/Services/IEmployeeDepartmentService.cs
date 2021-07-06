using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Services
{
    public interface IEmployeeDepartmentService
    {
        Task<EmployeeDepartment> GetById(int id);

        Task<List<EmployeeDepartment>> GetAll();

        Task<EmployeeDepartment> Add(EmployeeDepartment employeeDepartment);

        Task<EmployeeDepartment> Update(EmployeeDepartment employeeDepartment);

        Task<List<EmployeeDepartment>> GetEmployeeDepartmentListByEmployeeId(int employeeId);
    }
}
