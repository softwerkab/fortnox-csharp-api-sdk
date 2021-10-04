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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		CostCenter Update(CostCenter costCenter);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		CostCenter Create(CostCenter costCenter);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		CostCenter Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<CostCenter> Find(CostCenterSearch searchSettings);

		Task<CostCenter> UpdateAsync(CostCenter costCenter);
		Task<CostCenter> CreateAsync(CostCenter costCenter);
		Task<CostCenter> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<CostCenter>> FindAsync(CostCenterSearch searchSettings);
	}
}
