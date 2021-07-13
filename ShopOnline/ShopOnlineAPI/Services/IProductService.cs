using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface IProductService
    {
        Task<Product> GetById(int id);

        Task<List<Product>> GetAll();

        Task<Product> Add(Product product);

        Task<Product> Update(Product product);
    }
}
