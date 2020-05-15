using Oqtane.Models;
using Oqtane.Modules;

namespace Tres.Customers.Modules
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Customer",
            Description = "Customer",
            Version = "1.0.0",
            ServerManagerType = "Tres.Customers.Manager.CustomerManager, Tres.Customers.Server.Oqtane",
            ReleaseVersions = "1.0.0"
        };
    }
}
