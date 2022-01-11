using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ICostCenterConnector : IEntityConnector
{
    Task<CostCenter> UpdateAsync(CostCenter costCenter);
    Task<CostCenter> CreateAsync(CostCenter costCenter);
    Task<CostCenter> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<CostCenter>> FindAsync(CostCenterSearch searchSettings);
}