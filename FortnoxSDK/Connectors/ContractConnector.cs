using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ContractConnector : SearchableEntityConnector<Contract, ContractSubset, ContractSearch>, IContractConnector
{
    public ContractConnector()
    {
        Endpoint = Endpoints.Contracts;
    }
    
    public async Task<EntityCollection<ContractSubset>> FindAsync(ContractSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<Contract> CreateAsync(Contract contract)
    {
        return await BaseCreate(contract).ConfigureAwait(false);
    }

    public async Task<Contract> UpdateAsync(Contract contract)
    {
        return await BaseUpdate(contract, contract.DocumentNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<Contract> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }

    public async Task<Contract> FinishAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Finish).ConfigureAwait(false);
    }

    public async Task<Contract> CreateInvoiceAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.CreateInvoice).ConfigureAwait(false);
    }

    public async Task<Contract> IncreaseInvoiceCountAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.IncreaseInvoiceCount).ConfigureAwait(false);
    }
}