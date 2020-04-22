using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Contract? SortBy { get; set; }
		Filter.Contract? FilterBy { get; set; }

		string CustomerNumber { get; set; }
		string DocumentNumber { get; set; }
		string InvoicesRemaining { get; set; }
		string PeriodEnd { get; set; }
		string PeriodStart { get; set; }
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
