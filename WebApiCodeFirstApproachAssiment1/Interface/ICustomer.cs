using WebApiCodeFirstApproachAssiment1.Model;
namespace WebApiCodeFirstApproachAssiment1.Interface
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer?>GetCustomerById(int id);

        Task<Customer?> AddCustomer(Customer obj);

        //Task<Customer> UpdateCustomer(int id);
        Task<bool> DeleteCustomerById(int id);
    }
}
