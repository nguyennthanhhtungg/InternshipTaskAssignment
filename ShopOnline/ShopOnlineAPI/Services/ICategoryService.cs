using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface ICategoryService
    {
        Task<Category> GetById(int id);

        Task<List<Category>> GetAll();

        Task<Category> Add(Category category);

        Task<Category> Update(Category category);
    }
}
