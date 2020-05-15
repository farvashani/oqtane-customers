using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Tres.Customers.Models;

namespace Tres.Customers.Services
{
    public class CustomerService : ServiceBase, ICustomerService, IService
    {
        private readonly SiteState _siteState;

        public CustomerService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl=> CreateApiUrl(_siteState.Alias, "Customer");

        public async Task<List<Customer>> GetCustomersAsync(int ModuleId)
        {
            List<Customer> Customers = await GetJsonAsync<List<Customer>>($"{Apiurl}?moduleid={ModuleId}");
            return Customers.OrderBy(item => item.LastName).ToList();
        }

        public async Task<Customer> GetCustomerAsync(int CustomerId)
        {
            return await GetJsonAsync<Customer>($"{Apiurl}/{CustomerId}");
        }

        public async Task<Customer> AddCustomerAsync(Customer Customer)
        {
            return await PostJsonAsync<Customer>($"{Apiurl}?entityid={Customer.ModuleId}", Customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer Customer)
        {
            return await PutJsonAsync<Customer>($"{Apiurl}/{Customer.CustomerId}?entityid={Customer.ModuleId}", Customer);
        }

        public async Task DeleteCustomerAsync(int CustomerId)
        {
            await DeleteAsync($"{Apiurl}/{CustomerId}");
        }
    }
}
