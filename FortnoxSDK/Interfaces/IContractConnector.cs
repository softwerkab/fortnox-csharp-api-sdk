using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IContractConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Contract Update(Contract contract);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Contract Create(Contract contract);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Contract Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<ContractSubset> Find(ContractSearch searchSettings);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Contract Finish(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Contract CreateInvoice(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Contract IncreaseInvoiceCount(long? id);

		Task<Contract> UpdateAsync(Contract contract);
		Task<Contract> CreateAsync(Contract contract);
		Task<Contract> GetAsync(long? id);
        Task<EntityCollection<ContractSubset>> FindAsync(ContractSearch searchSettings);
        Task<Contract> FinishAsync(long? id);
        Task<Contract> CreateInvoiceAsync(long? id);
        Task<Contract> IncreaseInvoiceCountAsync(long? id);
	}
}
