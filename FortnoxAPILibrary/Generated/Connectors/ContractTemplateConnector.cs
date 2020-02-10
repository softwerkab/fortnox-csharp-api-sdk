using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ContractTemplateConnector : EntityConnector<ContractTemplate, EntityCollection<ContractTemplateSubset>, Sort.By.ContractTemplate?>
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
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a contractTemplate
		/// </summary>
		/// <param name="contractTemplate">The contractTemplate to update</param>
		/// <returns>The updated contractTemplate</returns>
		public ContractTemplate Update(ContractTemplate contractTemplate)
		{
			return BaseUpdate(contractTemplate, contractTemplate.Id.ToString());
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
		/// Deletes a contractTemplate
		/// </summary>
		/// <param name="id">Identifier of the contractTemplate to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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
