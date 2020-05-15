using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Tres.Customers.Models;

namespace Tres.Customers.Repository
{
    public class CustomerContext : DBContextBase, IService
    {
        public virtual DbSet<Customer> Customer { get; set; }

        public CustomerContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
