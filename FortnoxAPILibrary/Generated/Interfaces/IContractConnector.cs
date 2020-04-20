using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractConnector
	{
        [SearchParameter("filter")]
		Filter.Contract? FilterBy { get; set; }


        [SearchParameter]
		string CustomerNumber { get; set; }

        [SearchParameter]
		string DocumentNumber { get; set; }

        [SearchParameter]
		string InvoicesRemaining { get; set; }

        [SearchParameter]
		string PeriodEnd { get; set; }

        [SearchParameter]
		string PeriodStart { get; set; }

        [SearchParameter]
		string TemplateNumber { get; set; }

		Contract Update(Contract contract);

		Contract Create(Contract contract);

		Contract Get(int? id);

        EntityCollection<ContractSubset> Find();

		
		Contract Finish(int? id);
		
		Contract CreateInvoice(int? id);
		
		Contract IncreaseInvoiceCount(int? id);
	}
}
