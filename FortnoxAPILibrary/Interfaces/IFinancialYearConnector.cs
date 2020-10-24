using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IFinancialYearConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.FinancialYear? SortBy { get; set; }
		Filter.FinancialYear? FilterBy { get; set; }

        FinancialYear Create(FinancialYear financialYear);
		FinancialYear Get(long? id);
        EntityCollection<FinancialYearSubset> Find();

        Task<FinancialYear> CreateAsync(FinancialYear financialYear);
		Task<FinancialYear> GetAsync(long? id);
        Task<EntityCollection<FinancialYearSubset>> FindAsync();
	}
}
