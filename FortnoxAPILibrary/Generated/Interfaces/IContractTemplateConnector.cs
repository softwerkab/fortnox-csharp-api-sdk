using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractTemplateConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.ContractTemplate? FilterBy { get; set; }

		ContractTemplate Update(ContractTemplate contractTemplate);

		ContractTemplate Create(ContractTemplate contractTemplate);

		ContractTemplate Get(string id);

        EntityCollection<ContractTemplateSubset> Find();

	}
}
