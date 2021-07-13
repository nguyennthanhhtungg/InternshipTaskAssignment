using ShopOnlineAPI.Models;
using ShopOnlineAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
        }

        public async Task<Order> Add(Order order)
        {
            await orderRepository.Add(order);
            return order;
        }

        public async Task<Order> Add(Order order, List<OrderDetail> orderDetailList)
        {
            await orderRepository.Add(order);

            if(order.OrderId != 0)
            {
                foreach(var orderDetail in orderDetailList)
                {
                    orderDetail.OrderId = order.OrderId;
                }

                await orderDetailRepository.AddRange(orderDetailList);

                order.OrderDetails = orderDetailList;
            }

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await orderRepository.GetAll();
            return orders.ToList();
        }

        public async Task<Order> GetById(int id)
        {
            var order = await orderRepository.GetById(id);
            return order;
        }

        public async Task<Order> GetWithOrderDetailListById(int id)
        {
            var order = await orderRepository.GetWithOrderDetailListById(id);
            return order;
        }

        public async Task<Order> Update(Order order)
        {
            await orderRepository.Update(order);
            return order;
        }
    }
}
