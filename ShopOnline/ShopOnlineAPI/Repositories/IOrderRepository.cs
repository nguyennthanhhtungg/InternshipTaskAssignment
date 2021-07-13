using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetWithOrderDetailListById(int id);
    }
}
