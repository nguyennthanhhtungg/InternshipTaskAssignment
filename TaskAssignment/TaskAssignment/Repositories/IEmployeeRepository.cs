using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetById(int id);
    }
}
