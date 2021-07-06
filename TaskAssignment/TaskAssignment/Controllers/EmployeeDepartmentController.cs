using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Services;
using TaskAssignment.ViewModels;

namespace TaskAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentService employeeDepartmentService;
        private readonly IMapper mapper;

        public EmployeeDepartmentController(IEmployeeDepartmentService employeeDepartmentService, IMapper mapper)
        {
            this.employeeDepartmentService = employeeDepartmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeeDepartments = await employeeDepartmentService.GetAll();

            return Ok(employeeDepartments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeDepartment = await employeeDepartmentService.GetById(id);

            return Ok(employeeDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "EmployeeDepartment Info is invalid!"
                });
            }

            try
            {
                EmployeeDepartment employeeDepartmentMapped = mapper.Map<EmployeeDepartment>(employeeDepartmentViewModel);

                var employeeDepartment = await employeeDepartmentService.Add(employeeDepartmentMapped);

                if(employeeDepartment != null)
                {
                    return Ok(employeeDepartment);
                }
                else
                {
                    return BadRequest(new
                    {
                        ErrorMessage = "Start Date or DeptID is invalid!"
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "EmployeeDepartment Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "EmployeeDepartment Info is invalid!"
                });
            }

            try
            {
                EmployeeDepartment employeeDepartmentMapped = mapper.Map<EmployeeDepartment>(employeeDepartmentViewModel);

                var employeeDepartment = await employeeDepartmentService.Update(employeeDepartmentMapped);

                if (employeeDepartment != null)
                {
                    return Ok(employeeDepartment);
                }
                else
                {
                    return BadRequest(new
                    {
                        ErrorMessage = "Start Date or DeptID is invalid!"
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "EmployeeDepartment Info is invalid!"
                });
            }
        }
    }
}
