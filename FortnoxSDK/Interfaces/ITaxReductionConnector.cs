using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITaxReductionConnector : IEntityConnector
{
    Task<TaxReduction> UpdateAsync(TaxReduction taxReduction);
    Task<TaxReduction> CreateAsync(TaxReduction taxReduction);
    Task<TaxReduction> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<TaxReductionSubset>> FindAsync(TaxReductionSearch searchSettings);
}