using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IUnitConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Unit Update(Unit unit);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Unit Create(Unit unit);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Unit Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<Unit> Find(UnitSearch searchSettings);

    Task<Unit> UpdateAsync(Unit unit);
    Task<Unit> CreateAsync(Unit unit);
    Task<Unit> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<Unit>> FindAsync(UnitSearch searchSettings);
}