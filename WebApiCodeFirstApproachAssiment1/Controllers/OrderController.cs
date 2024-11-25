using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;
using WebApiCodeFirstApproachAssiment1.Service;

namespace WebApiCodeFirstApproachAssiment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;

        public OrderController (IOrder orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var order = await _orderService.GetAllOrder();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Id Not match");
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult>AddOrder(Order order)
        {
            try
            {
                var obj = await _orderService.AddOrder(order);

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                                    
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteOrderById(int id)
        {
            try
            {
                var order = await _orderService.DeleteOrderById(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
