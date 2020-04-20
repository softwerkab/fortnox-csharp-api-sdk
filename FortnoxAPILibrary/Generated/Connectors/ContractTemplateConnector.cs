using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class ContractTemplateConnector : EntityConnector<ContractTemplate, EntityCollection<ContractTemplateSubset>, Sort.By.ContractTemplate?>, IContractTemplateConnector
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[SearchParameter("filter")]
		public Filter.ContractTemplate? FilterBy { get; set; }

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
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a contractTemplate
		/// </summary>
		/// <param name="contractTemplate">The contractTemplate to update</param>
		/// <returns>The updated contractTemplate</returns>
		public ContractTemplate Update(ContractTemplate contractTemplate)
		{
			return BaseUpdate(contractTemplate, contractTemplate.TemplateNumber.ToString());
		}

		/// <summary>
		/// Creates a new contractTemplate
		/// </summary>
		/// <param name="contractTemplate">The contractTemplate to create</param>
		/// <returns>The created contractTemplate</returns>
		public ContractTemplate Create(ContractTemplate contractTemplate)
		{
			return BaseCreate(contractTemplate);
		}

        /// <summary>
		/// Gets a list of contractTemplates
		/// </summary>
		/// <returns>A list of contractTemplates</returns>
		public EntityCollection<ContractTemplateSubset> Find()
		{
			return BaseFind();
		}
	}
}
