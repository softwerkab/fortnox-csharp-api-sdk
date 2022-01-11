using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class ContractAccrualConnector : SearchableEntityConnector<ContractAccrual, ContractAccrualSubset, ContractAccrualSearch>, IContractAccrualConnector
{
    public ContractAccrualConnector()
    {
        Endpoint = Endpoints.ContractAccruals;
    }

    public async Task<EntityCollection<ContractAccrualSubset>> FindAsync(ContractAccrualSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<ContractAccrual> CreateAsync(ContractAccrual contractAccrual)
    {
        return await BaseCreate(contractAccrual).ConfigureAwait(false);
    }

    public async Task<ContractAccrual> UpdateAsync(ContractAccrual contractAccrual)
    {
        return await BaseUpdate(contractAccrual, contractAccrual.DocumentNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<ContractAccrual> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}