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
    }
}
