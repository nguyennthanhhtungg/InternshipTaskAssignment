using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Add(Product product)
        {
            await productRepository.Add(product);
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await productRepository.GetAll();
            return products.ToList();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await productRepository.GetById(id);
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            await productRepository.Update(product);
            return product;
        }
    }
}
