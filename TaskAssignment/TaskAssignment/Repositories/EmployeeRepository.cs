using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDBContext context) : base(context)
        {

        }

        //Get Employee Info (include EmployeeDepartments) by EmployeeId
        public async Task<Employee> GetWithEmployeeDepartmentsById(int id)
        {
            return await _context.Set<Employee>().Where<Employee>(emp => emp.EmployeeId == id).Include(emp => emp.EmployeeDepartments).FirstOrDefaultAsync();
        }
    }
}
