using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiCodeFirstApproachAssiment1.Context;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Service
{
    public class OrderHistoryServices : IOrderHistory
    {
        private readonly CustomerDbContext _dbContext;
        public OrderHistoryServices(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OrderHistory>>GetAllOrderHistory()
        {
            return await _dbContext.OrderHistorys.ToListAsync();
        }
        public async Task<OrderHistory?> GetOrderHById(int id)
        {
         return await _dbContext.OrderHistorys.FirstOrDefaultAsync(obj=>obj.OrderHistoryID==id);
        }
        public async Task<OrderHistory?> AddorderHistory(OrderHistory orderHistory)
        {
            var obj = new OrderHistory()
            {
                ProductID = orderHistory.ProductID,
                Quantity = orderHistory.Quantity,
                UnitPrice = orderHistory.UnitPrice
            };
            _dbContext.OrderHistorys.Add(obj);
            var result=await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<bool> DeleteOrderHistory(int id)
        {
                var hero = await _dbContext.OrderHistorys.FirstOrDefaultAsync(obj => obj.OrderHistoryID == id);
                if (hero != null)
                {
                    _dbContext.OrderHistorys.Remove(hero);
                    var result = await _dbContext.SaveChangesAsync();
                    return result >= 0;
                }
                return false;
            
        }
    }
}
