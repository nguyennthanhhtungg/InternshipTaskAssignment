using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Repositories;

namespace TaskAssignment.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task<Department> Add(Department department)
        {
            await departmentRepository.Add(department);
            return department;
        }

        public async Task<List<Department>> GetAll()
        {
            var departments = await departmentRepository.GetAll();
            return departments.ToList();
        }

        public async Task<Department> GetById(int id)
        {
            var department = await departmentRepository.GetById(id);
            return department;
        }

        public async Task<Department> Update(Department department)
        {
            await departmentRepository.Update(department);
            return department;
        }
    }
}
