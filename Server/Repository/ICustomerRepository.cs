using System.Collections.Generic;
using Tres.Customers.Models;

namespace Tres.Customers.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(int ModuleId);
        Customer GetCustomer(int CustomerId);
        Customer AddCustomer(Customer Customer);
        Customer UpdateCustomer(Customer Customer);
        void DeleteCustomer(int CustomerId);
    }
}
