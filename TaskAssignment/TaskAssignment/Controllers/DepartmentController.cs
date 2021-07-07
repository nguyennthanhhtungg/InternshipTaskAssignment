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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await departmentService.GetAll();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await departmentService.GetById(id);

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Department Info is invalid!"
                });
            }

            try
            {
                Department departmentMapped = mapper.Map<Department>(departmentViewModel);

                var department = await departmentService.Add(departmentMapped);

                return Ok(department);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Department Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Department Info is invalid!"
                });
            }

            try
            {
                Department departmentMapped = mapper.Map<Department>(departmentViewModel);

                var department = await departmentService.Update(departmentMapped);

                return Ok(department);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Department Info is invalid!"
                });
            }
        }
    }
}
