using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISalaryTransactionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SalaryTransaction? SortBy { get; set; }
		Filter.SalaryTransaction? FilterBy { get; set; }


		SalaryTransaction Update(SalaryTransaction salaryTransaction);
		SalaryTransaction Create(SalaryTransaction salaryTransaction);
		SalaryTransaction Get(int? id);
		void Delete(int? id);
		EntityCollection<SalaryTransactionSubset> Find();

		Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<SalaryTransactionSubset>> FindAsync();
	}
}
