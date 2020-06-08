using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IFinancialYearConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.FinancialYear? SortBy { get; set; }
		Filter.FinancialYear? FilterBy { get; set; }

		string Date { get; set; }

        FinancialYear Create(FinancialYear financialYear);
		FinancialYear Get(int? id);
        EntityCollection<FinancialYearSubset> Find();

        Task<FinancialYear> CreateAsync(FinancialYear financialYear);
		Task<FinancialYear> GetAsync(int? id);
        Task<EntityCollection<FinancialYearSubset>> FindAsync();
	}
}
