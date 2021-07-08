using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
	/// <remarks/>
	internal class ContractTemplateConnector : SearchableEntityConnector<ContractTemplate, ContractTemplateSubset, ContractTemplateSearch>, IContractTemplateConnector
	{

        /// <remarks/>
		public ContractTemplateConnector()
		{
			Resource = "contracttemplates";
		}

		/// <summary>
		/// Find a contractTemplate based on id
		/// </summary>
		/// <param name="id">Identifier of the contractTemplate to find</param>
		/// <returns>The found contractTemplate</returns>
		public ContractTemplate Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a contractTemplate
		/// </summary>
		/// <param name="contractTemplate">The contractTemplate to update</param>
		/// <returns>The updated contractTemplate</returns>
		public ContractTemplate Update(ContractTemplate contractTemplate)
		{
			return UpdateAsync(contractTemplate).GetResult();
		}

		/// <summary>
		/// Creates a new contractTemplate
		/// </summary>
		/// <param name="contractTemplate">The contractTemplate to create</param>
		/// <returns>The created contractTemplate</returns>
		public ContractTemplate Create(ContractTemplate contractTemplate)
		{
			return CreateAsync(contractTemplate).GetResult();
		}

        /// <summary>
		/// Gets a list of contractTemplates
		/// </summary>
		/// <returns>A list of contractTemplates</returns>
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
}
