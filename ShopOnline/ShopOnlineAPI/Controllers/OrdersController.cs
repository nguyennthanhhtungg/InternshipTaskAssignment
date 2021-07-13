using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineAPI.Models;
using ShopOnlineAPI.Services;
using ShopOnlineAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await orderService.GetAll();

            List<OrderViewModel> orderViewModelListMapped = mapper.Map<List<OrderViewModel>>(orders);

            return Ok(orderViewModelListMapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await orderService.GetWithOrderDetailListById(id);

            OrderViewModel orderViewModelMapped = mapper.Map<OrderViewModel>(order);

            return Ok(orderViewModelMapped);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Order Info is invalid!"
                });
            }

            try
            {
                Order orderMapped = mapper.Map<Order>(orderViewModel);
                List<OrderDetail> orderDetailListMapped = mapper.Map<List<OrderDetail>>(orderViewModel.OrderDetails);

                var order = await orderService.Add(orderMapped, orderDetailListMapped);

                OrderViewModel orderViewModelMapped = mapper.Map<OrderViewModel>(order);

                return Ok(orderViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Order Info is invalid!"
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Order Info is invalid!"
                });
            }

            try
            {
                Order orderMapped = mapper.Map<Order>(orderViewModel);

                var order = await orderService.Update(orderMapped);

                OrderViewModel orderViewModelMapped = mapper.Map<OrderViewModel>(order);

                return Ok(orderViewModelMapped);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return BadRequest(new
                {
                    ErrorMessage = "Order Info is invalid!"
                });
            }
        }
    }
}
