using SamplePOC.Domain.Entities;

namespace SamplePOC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task <int>AddCustomerAsync(Customer customer);
        Task <int>UpdateCustomerAsync(Customer customer);
        Task <int>RemoveCustomerAsync(Task<Customer> customer);
    }
}
