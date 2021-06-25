using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Repositories;
using TaskAssignment.ViewModels;

namespace TaskAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await employeeRepository.GetAll();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await employeeRepository.GetById(id);

            return Ok(employee);
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Add([FromBody] EmployeeViewModel employeeViewModel)
        {
            try
            {
                Employee employeeMapped = mapper.Map<Employee>(employeeViewModel);

                await employeeRepository.Add(employeeMapped);

                return Ok(employeeMapped);
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
            try
            {
                Employee employeeMapped = mapper.Map<Employee>(employeeViewModel);

                await employeeRepository.Update(employeeMapped);

                return Ok(employeeMapped);
            }
            catch(Exception e)
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
