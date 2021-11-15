using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ContractTemplateConnector : SearchableEntityConnector<ContractTemplate, ContractTemplateSubset, ContractTemplateSearch>, IContractTemplateConnector
{
    public ContractTemplateConnector()
    {
        Endpoint = Endpoints.ContractTemplates;
    }

    public ContractTemplate Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public ContractTemplate Update(ContractTemplate contractTemplate)
    {
        return UpdateAsync(contractTemplate).GetResult();
    }

    public ContractTemplate Create(ContractTemplate contractTemplate)
    {
        return CreateAsync(contractTemplate).GetResult();
    }

    public EntityCollection<ContractTemplateSubset> Find(ContractTemplateSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<ContractTemplateSubset>> FindAsync(ContractTemplateSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<ContractTemplate> CreateAsync(ContractTemplate contractTemplate)
    {
        return await BaseCreate(contractTemplate).ConfigureAwait(false);
    }

    public async Task<ContractTemplate> UpdateAsync(ContractTemplate contractTemplate)
    {
        return await BaseUpdate(contractTemplate, contractTemplate.TemplateNumber).ConfigureAwait(false);
    }

    public async Task<ContractTemplate> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}