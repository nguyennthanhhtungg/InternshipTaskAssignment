using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetById(int id);

        Task<List<Department>> GetAll();

        Task<Department> Add(Department department);

        Task<Department> Update(Department department);
    }
}
