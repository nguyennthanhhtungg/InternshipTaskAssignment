using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeDBContext context) : base(context)
        {

        }
    }
}
