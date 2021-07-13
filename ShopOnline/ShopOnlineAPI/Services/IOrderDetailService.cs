using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> GetById(int id);

        Task<List<OrderDetail>> GetAll();

        Task<OrderDetail> Add(OrderDetail orderDetail);

        Task<OrderDetail> Update(OrderDetail orderDetail);
    }
}
