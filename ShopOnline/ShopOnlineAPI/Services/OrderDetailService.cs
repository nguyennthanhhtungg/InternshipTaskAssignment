using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> Add(OrderDetail orderDetail)
        {
            await orderDetailRepository.Add(orderDetail);
            return orderDetail;
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            var orderDetails = await orderDetailRepository.GetAll();
            return orderDetails.ToList();
        }

        public async Task<OrderDetail> GetById(int id)
        {
            var orderDetail = await orderDetailRepository.GetById(id);
            return orderDetail;
        }

        public async Task<OrderDetail> Update(OrderDetail orderDetail)
        {
            await orderDetailRepository.Update(orderDetail);
            return orderDetail;
        }
    }
}
