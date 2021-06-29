using System;
using System.Collections.Generic;
using System.Text;
using TaskAssignment2.Models;

namespace TaskAssignment2.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IList<Employee> GetAllEmployeesWithIsActivedFalse();
    }
}
