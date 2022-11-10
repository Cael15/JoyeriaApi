using Joyeria.APIs.ViewModels;
using Joyeria.Core.Models;
using Joyeria.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
           
        }


        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                
                
                var orders = await this._orderService.GetOrdersAsync();
                foreach (var item in orders)
                {
                    Console.WriteLine(item.detalle);
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("resumen")]
        public async Task<IActionResult> Resumen()
        {
            try
            {
                var orders = await this._orderService.GetResumen();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            try
            {
                var order = await this._orderService.GetOrdeByIdAsync(id);
                if (order == null) return BadRequest($"Order con id {id} no existe");

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderVM order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload order no es valido");
                

                var orderToCreate = new Order()
                {
                    Date = order.Date,
                    UserId = order.UserId,
                    StatusId = order.StatusId,
                    Total = order.Total,
                    detalle =  new List<OrderItem>()
                    //CategoryId = proorderduct.CategoryId,
                };
                foreach (var itemCrear in order.detalle)
                {
                    orderToCreate.detalle.Add(new OrderItem
                    {
                        Amount = itemCrear.Amount,
                        Price = itemCrear.Price,
                        TotalAmount = itemCrear.TotalAmount,
         
                        ProductId = itemCrear.ProductId

                    });
                }

                var orderCreated = await _orderService.CreateAsync(orderToCreate);

                return Ok(orderCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
