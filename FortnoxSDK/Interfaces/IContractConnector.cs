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
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Contract Update(Contract contract);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Contract Create(Contract contract);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Contract Get(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<ContractSubset> Find(ContractSearch searchSettings);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Contract Finish(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Contract CreateInvoice(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
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
