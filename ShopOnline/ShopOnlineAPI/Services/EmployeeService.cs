using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employee> Add(Employee employee)
        {
            await employeeRepository.Add(employee);
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await employeeRepository.GetAll();
            return employees.ToList();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await employeeRepository.GetById(id);
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            await employeeRepository.Update(employee);
            return employee;
        }
    }
}
