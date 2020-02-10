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
		public Filter.ContractTemplate FilterBy { get; set; }


		/// <remarks/>
		public ContractTemplateConnector()
		{
			Resource = "contracttemplates";
		}

		/// <summary>
		/// Find a contractTemplate based on contractTemplatenumber
		/// </summary>
		/// <param name="contractTemplateNumber">The contractTemplatenumber to find</param>
		/// <returns>The found contractTemplate</returns>
		public ContractTemplate Get(string contractTemplateNumber)
		{
			return BaseGet(contractTemplateNumber);
		}

		/// <summary>
		/// Updates a contractTemplate
		/// </summary>
		/// <param name="contractTemplate">The contractTemplate to update</param>
		/// <returns>The updated contractTemplate</returns>
		public ContractTemplate Update(ContractTemplate contractTemplate)
		{
			return BaseUpdate(contractTemplate, contractTemplate.ContractTemplateNumber);
		}

		/// <summary>
		/// Create a new contractTemplate
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
		/// <param name="contractTemplateNumber">The contractTemplatenumber to delete</param>
		public void Delete(string contractTemplateNumber)
		{
			BaseDelete(contractTemplateNumber);
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
