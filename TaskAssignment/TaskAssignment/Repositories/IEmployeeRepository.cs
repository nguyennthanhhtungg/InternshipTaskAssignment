using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //Get Employee Info (include EmployeeDepartment) by EmployeeId
        Task<Employee> GetWithEmployeeDepartmentsById(int id);
    }
}
