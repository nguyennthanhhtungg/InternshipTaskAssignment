using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface ISupplierService
    {
        Task<Supplier> GetById(int id);

        Task<List<Supplier>> GetAll();

        Task<Supplier> Add(Supplier supplier);

        Task<Supplier> Update(Supplier supplier);
    }
}
