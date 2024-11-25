using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Interface
{
    public interface IOrder
    {

        Task<List<Order>> GetAllOrder();
        Task<Order?> GetOrderById(int id);
        Task<Order?> AddOrder(Order order);
        Task<bool> DeleteOrderById(int id);

    }
}
