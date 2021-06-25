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
        public IActionResult GetAll()
        {
            var employees = employeeRepository.GetAll();

            return Ok(employees);
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Add([FromBody] EmployeeViewModel employeeViewModel)
        {
            try
            {
                Employee employeeMapped = mapper.Map<Employee>(employeeViewModel);

                employeeRepository.Add(employeeMapped);

                return Ok(employeeMapped);
            }
            catch (Exception e)
            {
                return BadRequest(new 
                {
                    ErrorMessage = "Employee Info is invalid!"
                });
            }
        }


        [HttpPut]
        public IActionResult Update([FromBody] EmployeeViewModel employeeViewModel)
        {
            try
            {
                Employee employeeMapped = mapper.Map<Employee>(employeeViewModel);

                employeeRepository.Update(employeeMapped);

                return Ok(employeeMapped);
            }
            catch(Exception e)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Employee Info is invalid!"
                });
            }
        }
    }
}
