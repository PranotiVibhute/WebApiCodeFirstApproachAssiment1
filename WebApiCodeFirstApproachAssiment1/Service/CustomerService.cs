using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCodeFirstApproachAssiment1.Context;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Service
{
    public class CustomerService : ICustomer
    {
        private readonly CustomerDbContext _dbContext;
        public CustomerService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(cust => cust.CustomerID == id);
        }
        public async Task<Customer?> AddCustomer(Customer obj)
        {
            var addCustomer = new Customer()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                Phone = obj.Phone,
                CreatedDate = obj.CreatedDate,
            };
            _dbContext.Customers.Add(addCustomer);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addCustomer : null;
        }
        public async Task<bool> DeleteCustomerById(int id)
        {
            var hero = await _dbContext.Customers.FirstOrDefaultAsync(index => index.CustomerID == id);
            if (hero != null)
            {
                _dbContext.Customers.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}

    
