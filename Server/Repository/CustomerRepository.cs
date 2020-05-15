using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Tres.Customers.Models;

namespace Tres.Customers.Repository
{
    public class CustomerRepository : ICustomerRepository, IService
    {
        private readonly CustomerContext _db;

        public CustomerRepository(CustomerContext context)
        {
            _db = context;
        }

        public IEnumerable<Customer> GetCustomers(int ModuleId)
        {
            return _db.Customer.Where(item => item.ModuleId == ModuleId);
        }

        public Customer GetCustomer(int CustomerId)
        {
            return _db.Customer.Find(CustomerId);
        }

        public Customer AddCustomer(Customer Customer)
        {
            _db.Customer.Add(Customer);
            _db.SaveChanges();
            return Customer;
        }

        public Customer UpdateCustomer(Customer Customer)
        {
            _db.Entry(Customer).State = EntityState.Modified;
            _db.SaveChanges();
            return Customer;
        }

        public void DeleteCustomer(int CustomerId)
        {
            Customer Customer = _db.Customer.Find(CustomerId);
            _db.Customer.Remove(Customer);
            _db.SaveChanges();
        }
    }
}
