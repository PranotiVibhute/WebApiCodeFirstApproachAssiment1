using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCodeFirstApproachAssiment1.Context;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Service
{
    public class OrderService : IOrder
    {
        private readonly CustomerDbContext _dbContext;

        public OrderService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Order>> GetAllOrder()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(obj => obj.OrderID == id);
        }
        public async Task<Order?> AddOrder(Order order)
        {
            var obj = new Order()
            {
                CustomerID = order.CustomerID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
            };
            _dbContext.Orders.Add(obj);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<bool> DeleteOrderById(int id)
        {
            var model= await _dbContext.Orders.FirstOrDefaultAsync(obj=>obj.OrderID == id);
            if(model!=null)
            {
                _dbContext.Orders.Remove(model);
                var result=await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
