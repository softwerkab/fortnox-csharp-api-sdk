using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IContractConnector : IEntityConnector
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
		Contract Get(long? id);
        EntityCollection<ContractSubset> Find();
		Contract Finish(long? id);
		Contract CreateInvoice(long? id);
		Contract IncreaseInvoiceCount(long? id);

		Task<Contract> UpdateAsync(Contract contract);
		Task<Contract> CreateAsync(Contract contract);
		Task<Contract> GetAsync(long? id);
        Task<EntityCollection<ContractSubset>> FindAsync();
	}
}
