using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Repositories;

namespace TaskAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            employeeRepository = employeeRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = employeeRepository.GetAll();

            return Ok(new
            {
                employees
            });
        }

    }
}
