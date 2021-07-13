using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public async Task<Supplier> Add(Supplier supplier)
        {
            await supplierRepository.Add(supplier);
            return supplier;
        }

        public async Task<List<Supplier>> GetAll()
        {
            var suppliers = await supplierRepository.GetAll();
            return suppliers.ToList();
        }

        public async Task<Supplier> GetById(int id)
        {
            var supplier = await supplierRepository.GetById(id);
            return supplier;
        }

        public async Task<Supplier> Update(Supplier supplier)
        {
            await supplierRepository.Update(supplier);
            return supplier;
        }
    }
}
