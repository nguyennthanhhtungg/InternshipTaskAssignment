using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public interface IOrderService
    {
        Task<Order> GetById(int id);

        Task<List<Order>> GetAll();

        Task<Order> Add(Order order);

        Task<Order> Update(Order order);

        Task<Order> Add(Order order, List<OrderDetail> orderDetailList);

        Task<Order> GetWithOrderDetailListById(int id);
    }
}
