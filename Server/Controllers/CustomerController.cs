using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Tres.Customers.Models;
using Tres.Customers.Repository;

namespace Tres.Customers.Controllers
{
    [Route("{site}/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _Customers;
        private readonly ILogManager _logger;

        public CustomerController(ICustomerRepository Customers, ILogManager logger)
        {
            _Customers = Customers;
            _logger = logger;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Roles = Constants.RegisteredRole)]
        public IEnumerable<Customer> Get(string moduleid)
        {
            return _Customers.GetCustomers(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = Constants.RegisteredRole)]
        public Customer Get(int id)
        {
            return _Customers.GetCustomer(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = Constants.AdminRole)]
        public Customer Post([FromBody] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Customer = _Customers.AddCustomer(Customer);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Customer Added {Customer}", Customer);
            }
            return Customer;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public Customer Put(int id, [FromBody] Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Customer = _Customers.UpdateCustomer(Customer);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Customer Updated {Customer}", Customer);
            }
            return Customer;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public void Delete(int id)
        {
            _Customers.DeleteCustomer(id);
            _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Customer Deleted {CustomerId}", id);
        }
    }
}
