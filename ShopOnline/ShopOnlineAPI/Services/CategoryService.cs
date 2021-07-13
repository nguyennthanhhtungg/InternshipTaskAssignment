using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> Add(Category category)
        {
            await categoryRepository.Add(category);
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await categoryRepository.GetAll();
            return categories.ToList();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await categoryRepository.GetById(id);
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            await categoryRepository.Update(category);
            return category;
        }
    }
}
