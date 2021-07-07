using System.Collections.Generic;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetById(int id);

        //Get Employee Info (include EmployeeDepartment) by EmployeeId
        Task<Employee> GetWithEmployeeDepartmentsById(int id);

        Task<List<Employee>> GetAll();

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(Employee employee);
    }
}
