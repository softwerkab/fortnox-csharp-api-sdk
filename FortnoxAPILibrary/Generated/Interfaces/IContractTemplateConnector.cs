using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractTemplateConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.ContractTemplate? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.ContractTemplate? FilterBy { get; set; }

		ContractTemplate Update(ContractTemplate contractTemplate);

		ContractTemplate Create(ContractTemplate contractTemplate);

		ContractTemplate Get(string id);

        EntityCollection<ContractTemplateSubset> Find();

	}
}
