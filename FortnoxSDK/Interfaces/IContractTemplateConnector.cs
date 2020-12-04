using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IContractTemplateConnector : IEntityConnector
	{


		ContractTemplate Update(ContractTemplate contractTemplate);
		ContractTemplate Create(ContractTemplate contractTemplate);
		ContractTemplate Get(string id);
        EntityCollection<ContractTemplateSubset> Find(ContractTemplateSearch searchSettings);

		Task<ContractTemplate> UpdateAsync(ContractTemplate contractTemplate);
		Task<ContractTemplate> CreateAsync(ContractTemplate contractTemplate);
		Task<ContractTemplate> GetAsync(string id);
        Task<EntityCollection<ContractTemplateSubset>> FindAsync(ContractTemplateSearch searchSettings);
	}
}
