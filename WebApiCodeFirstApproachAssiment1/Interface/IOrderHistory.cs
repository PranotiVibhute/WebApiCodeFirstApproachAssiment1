using WebApiCodeFirstApproachAssiment1.Model;

namespace WebApiCodeFirstApproachAssiment1.Interface
{
    public interface IOrderHistory
    {
        Task<List<OrderHistory>> GetAllOrderHistory();
        Task<OrderHistory?> GetOrderHById(int id);

        Task<OrderHistory?>AddorderHistory(OrderHistory orderHistory);
        Task<bool> DeleteOrderHistory(int id);
    }
}
