using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ICostCenterConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        CostCenter Update(CostCenter costCenter);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        CostCenter Create(CostCenter costCenter);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        CostCenter Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<CostCenter> Find(CostCenterSearch searchSettings);

        Task<CostCenter> UpdateAsync(CostCenter costCenter);
        Task<CostCenter> CreateAsync(CostCenter costCenter);
        Task<CostCenter> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<CostCenter>> FindAsync(CostCenterSearch searchSettings);
    }
}
