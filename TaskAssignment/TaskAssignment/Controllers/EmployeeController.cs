using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Services;
using TaskAssignment.ViewModels;

namespace TaskAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var employees = await employeeService.GetAll();
            await Task.Delay(TimeSpan.FromSeconds(10));

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                //Get Employee Info (include EmployeeDepartments) by EmployeeId
                var employee = await employeeService.GetWithEmployeeDepartmentsById(id);


                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "EmployeeID is invalid!"
                });
            }
        }

        [HttpPost]
        [Route("Registration")]
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

                return Ok(employee);
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

                return Ok(employee);
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
