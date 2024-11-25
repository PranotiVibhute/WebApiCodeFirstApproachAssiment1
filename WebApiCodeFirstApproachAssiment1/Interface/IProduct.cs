using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Interface
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProduct();
        Task<Product?> GetProductById(int id);
        Task<Product?> AddProduct(Product obj);

        Task<bool> DeleteProductById(int id);

    }
}
