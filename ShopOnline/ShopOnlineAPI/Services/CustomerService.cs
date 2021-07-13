using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Add(Customer customer)
        {
            await customerRepository.Add(customer);
            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            var customers = await customerRepository.GetAll();
            return customers.ToList();
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await customerRepository.GetById(id);
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            await customerRepository.Update(customer);
            return customer;
        }
    }
}
