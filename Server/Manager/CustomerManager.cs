using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Tres.Customers.Models;
using Tres.Customers.Repository;

namespace Tres.Customers.Manager
{
    public class CustomerManager : IInstallable, IPortable
    {
        private ICustomerRepository _Customers;
        private ISqlRepository _sql;

        public CustomerManager(ICustomerRepository Customers, ISqlRepository sql)
        {
            _Customers = Customers;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Tres.Customer." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Tres.Customer.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Customer> Customers = _Customers.GetCustomers(module.ModuleId).ToList();
            if (Customers != null)
            {
                content = JsonSerializer.Serialize(Customers);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Customer> Customers = null;
            if (!string.IsNullOrEmpty(content))
            {
                Customers = JsonSerializer.Deserialize<List<Customer>>(content);
            }
            if (Customers != null)
            {
                foreach(Customer Customer in Customers)
                {
                    Customer _Customer = new Customer();
                    _Customer.ModuleId = module.ModuleId;
                    _Customer.FirstName = Customer.LastName;
                    _Customer.LastName = Customer.LastName;
                    _Customer.Address1 = Customer.Address1;
                    _Customer.Address2 = Customer.Address2;
                    _Customer.City = Customer.City;
                    _Customer.UsState = Customer.UsState;
                    _Customer.ZipCode = Customer.ZipCode;
                    _Customer.Phone = Customer.Phone;
                    _Customer.Email = Customer.Email;
                    _Customers.AddCustomer(_Customer);
                }
            }
        }
    }
}