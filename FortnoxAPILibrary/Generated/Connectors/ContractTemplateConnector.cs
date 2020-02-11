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
		/// Gets a list of contractTemplates
		/// </summary>
		/// <returns>A list of contractTemplates</returns>
		public EntityCollection<ContractTemplateSubset> Find()
		{
			return BaseFind();
		}
	}
}
