using System.Collections.Generic;
using System.Threading.Tasks;
using Tres.Customers.Models;

namespace Tres.Customers.Services
{
    public interface ICustomerService 
    {
        Task<List<Customer>> GetCustomersAsync(int ModuleId);

        Task<Customer> GetCustomerAsync(int CustomerId);

        Task<Customer> AddCustomerAsync(Customer Customer);

        Task<Customer> UpdateCustomerAsync(Customer Customer);

        Task DeleteCustomerAsync(int CustomerId);
    }
}
