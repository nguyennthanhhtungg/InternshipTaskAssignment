using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetById(int id);

        Task<List<Customer>> GetAll();

        Task<Customer> Add(Customer customer);

        Task<Customer> Update(Customer customer);
    }
}
