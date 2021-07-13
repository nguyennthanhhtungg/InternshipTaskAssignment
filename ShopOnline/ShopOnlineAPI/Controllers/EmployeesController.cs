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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await employeeService.GetAll();

            List<EmployeeViewModel> employeeViewModelListMapped = mapper.Map<List<EmployeeViewModel>>(employees);

            return Ok(employeeViewModelListMapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await employeeService.GetById(id);

            EmployeeViewModel employeeViewModelMapped = mapper.Map<EmployeeViewModel>(employee);

            return Ok(employeeViewModelMapped);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Employee Info is invalid!"
                });
            }

            try
            {
                Employee employeeMapped = mapper.Map<Employee>(employeeViewModel);

                var employee = await employeeService.Add(employeeMapped);

                EmployeeViewModel employeeViewModelMapped = mapper.Map<EmployeeViewModel>(employee);

                return Ok(employeeViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Employee Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Employee Info is invalid!"
                });
            }

            try
            {
                Employee employeeMapped = mapper.Map<Employee>(employeeViewModel);

                var employee = await employeeService.Update(employeeMapped);

                EmployeeViewModel employeeViewModelMapped = mapper.Map<EmployeeViewModel>(employee);

                return Ok(employeeViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Employee Info is invalid!"
                });
            }
        }
    }
}
