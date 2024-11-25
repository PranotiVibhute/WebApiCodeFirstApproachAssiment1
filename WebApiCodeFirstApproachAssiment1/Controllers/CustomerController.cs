using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetallCustomer()
        {
            var customer = await _customerService.GetAllCustomer();
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveEmployees(Customer customerModel)
        {
            try
            {
                var model = await _customerService.AddCustomer(customerModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            try  //Contoller=Expose API
            {
                var model = await _customerService.DeleteCustomerById(id);
                return Ok(model);
            }
            catch (Exception)
            {
               return BadRequest();
            }
        }
    }
}
