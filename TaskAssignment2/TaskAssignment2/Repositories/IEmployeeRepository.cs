using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment2.Models;

namespace TaskAssignment2.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IList<Employee>> GetAllEmployeesWithIsActivedFalse();
    }
}
