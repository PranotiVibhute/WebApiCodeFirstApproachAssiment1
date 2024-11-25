using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApiCodeFirstApproachAssiment1.Context;
using WebApiCodeFirstApproachAssiment1.Controllers;
using WebApiCodeFirstApproachAssiment1.Interface;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Service
{
    public class ProductService : IProduct
    {
        private readonly CustomerDbContext _dbContext;

        public ProductService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product?> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(obj => obj.ProductID == id);
        }
        public async Task<Product?> AddProduct(Product obj)
        {
            var product = new Product()
            {
                ProductName = obj.ProductName,
                Description = obj.Description,
                StockQuantity = obj.StockQuantity,
                CreatedDate = obj.CreatedDate,
            };
            _dbContext.Products.Add(product);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? product : null;
        }
        public async Task<bool>DeleteProductById(int id)
        {
            var hero = await _dbContext.Products.FirstOrDefaultAsync(obj => obj.ProductID == id);
            if (hero != null)
            {
                _dbContext.Products.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
