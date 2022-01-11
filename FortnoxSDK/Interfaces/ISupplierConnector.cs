using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ISupplierConnector : IEntityConnector
{
    Task<Supplier> UpdateAsync(Supplier supplier);
    Task<Supplier> CreateAsync(Supplier supplier);
    Task<Supplier> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<SupplierSubset>> FindAsync(SupplierSearch searchSettings);
}