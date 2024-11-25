using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;
using WebApiCodeFirstApproachAssiment1.Service;

namespace WebApiCodeFirstApproachAssiment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistory _orderHistoryService;
        public OrderHistoryController(IOrderHistory orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderHistory()
        {
            var order = await _orderHistoryService.GetAllOrderHistory();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderHById(int id)
        {
           var order = await _orderHistoryService.GetOrderHById(id);
          if (order == null)
              return NotFound();
           return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(OrderHistory orderHistory)
        {
            try
            {
                var model = await _orderHistoryService.AddorderHistory(orderHistory);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var product = await _orderHistoryService.DeleteOrderHistory(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}
