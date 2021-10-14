using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITaxReductionConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TaxReduction Update(TaxReduction taxReduction);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TaxReduction Create(TaxReduction taxReduction);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TaxReduction Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<TaxReductionSubset> Find(TaxReductionSearch searchSettings);

        Task<TaxReduction> UpdateAsync(TaxReduction taxReduction);
        Task<TaxReduction> CreateAsync(TaxReduction taxReduction);
        Task<TaxReduction> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<TaxReductionSubset>> FindAsync(TaxReductionSearch searchSettings);
    }
}
