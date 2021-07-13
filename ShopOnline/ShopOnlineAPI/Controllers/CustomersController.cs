using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineAPI.Models;
using ShopOnlineAPI.Services;
using ShopOnlineAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await customerService.GetAll();

            List<CustomerViewModel> customerViewModelListMapped = mapper.Map<List<CustomerViewModel>>(customers);

            return Ok(customerViewModelListMapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await customerService.GetById(id);

            CustomerViewModel customerViewModelMapped = mapper.Map<CustomerViewModel>(customer);

            return Ok(customerViewModelMapped);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Customer Info is invalid!"
                });
            }

            try
            {
                Customer customerMapped = mapper.Map<Customer>(customerViewModel);

                var customer = await customerService.Add(customerMapped);

                CustomerViewModel customerViewModelMapped = mapper.Map<CustomerViewModel>(customer);

                return Ok(customerViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Customer Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Customer Info is invalid!"
                });
            }

            try
            {
                Customer customerMapped = mapper.Map<Customer>(customerViewModel);

                var customer = await customerService.Update(customerMapped);

                CustomerViewModel customerViewModelMapped = mapper.Map<CustomerViewModel>(customer);

                return Ok(customerViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Customer Info is invalid!"
                });
            }
        }
    }
}
