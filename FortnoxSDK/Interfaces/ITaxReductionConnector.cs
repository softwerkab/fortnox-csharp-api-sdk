using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITaxReductionConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TaxReduction Update(TaxReduction taxReduction);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TaxReduction Create(TaxReduction taxReduction);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TaxReduction Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<TaxReductionSubset> Find(TaxReductionSearch searchSettings);

    Task<TaxReduction> UpdateAsync(TaxReduction taxReduction);
    Task<TaxReduction> CreateAsync(TaxReduction taxReduction);
    Task<TaxReduction> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<TaxReductionSubset>> FindAsync(TaxReductionSearch searchSettings);
}