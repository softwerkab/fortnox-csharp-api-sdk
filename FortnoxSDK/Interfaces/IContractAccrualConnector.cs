using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IContractAccrualConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ContractAccrual Update(ContractAccrual contractAccrual);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ContractAccrual Create(ContractAccrual contractAccrual);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ContractAccrual Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<ContractAccrualSubset> Find(ContractAccrualSearch searchSettings);

		Task<ContractAccrual> UpdateAsync(ContractAccrual contractAccrual);
		Task<ContractAccrual> CreateAsync(ContractAccrual contractAccrual);
		Task<ContractAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<ContractAccrualSubset>> FindAsync(ContractAccrualSearch searchSettings);
	}
}
