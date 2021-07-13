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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAll();

            List<CategoryViewModel> categoryViewModelListMapped = mapper.Map<List<CategoryViewModel>>(categories);

            return Ok(categoryViewModelListMapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await categoryService.GetById(id);

            CategoryViewModel categoryViewModelMapped = mapper.Map<CategoryViewModel>(category);

            return Ok(categoryViewModelMapped);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Category Info is invalid!"
                });
            }

            try
            {
                Category categoryMapped = mapper.Map<Category>(categoryViewModel);

                var category = await categoryService.Add(categoryMapped);

                CategoryViewModel categoryViewModelMapped = mapper.Map<CategoryViewModel>(category);

                return Ok(categoryViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Category Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Category Info is invalid!"
                });
            }

            try
            {
                Category categoryMapped = mapper.Map<Category>(categoryViewModel);

                var category = await categoryService.Update(categoryMapped);

                CategoryViewModel categoryViewModelMapped = mapper.Map<CategoryViewModel>(category);

                return Ok(categoryViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Category Info is invalid!"
                });
            }
        }
    }
}
