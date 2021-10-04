using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IContractTemplateConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ContractTemplate Update(ContractTemplate contractTemplate);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ContractTemplate Create(ContractTemplate contractTemplate);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		ContractTemplate Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<ContractTemplateSubset> Find(ContractTemplateSearch searchSettings);

		Task<ContractTemplate> UpdateAsync(ContractTemplate contractTemplate);
		Task<ContractTemplate> CreateAsync(ContractTemplate contractTemplate);
		Task<ContractTemplate> GetAsync(string id);
        Task<EntityCollection<ContractTemplateSubset>> FindAsync(ContractTemplateSearch searchSettings);
	}
}
