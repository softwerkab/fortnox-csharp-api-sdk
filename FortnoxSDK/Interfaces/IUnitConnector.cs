using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IUnitConnector : IEntityConnector
{
    Task<Unit> UpdateAsync(Unit unit);
    Task<Unit> CreateAsync(Unit unit);
    Task<Unit> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<Unit>> FindAsync(UnitSearch searchSettings);
}