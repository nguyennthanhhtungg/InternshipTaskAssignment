using Microsoft.EntityFrameworkCore;
using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopOnlineDBContext context) : base(context)
        {
        }

        public async Task<Order> GetWithOrderDetailListById(int id)
        {
            return await context.Set<Order>().Where(o => o.OrderId == id).Include(o => o.OrderDetails).FirstOrDefaultAsync();
        }
    }
}
