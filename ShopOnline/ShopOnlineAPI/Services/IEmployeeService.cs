using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetById(int id);

        Task<List<Employee>> GetAll();

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(Employee employee);
    }
}
