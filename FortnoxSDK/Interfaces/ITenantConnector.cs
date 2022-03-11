using System.Threading.Tasks;
using Fortnox.SDK.Entities.Tenants;

namespace Fortnox.SDK.Interfaces;
public interface ITenantConnector : IEntityConnector
{
    Task<Tenant> GetAsync();
}
