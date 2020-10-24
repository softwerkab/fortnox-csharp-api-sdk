using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISalaryTransactionConnector : IEntityConnector
	{
		SalaryTransactionSearch Search { get; set; }

		Sort.Order? SortOrder { get; set; }
		Sort.By.SalaryTransaction? SortBy { get; set; }
		Filter.SalaryTransaction? FilterBy { get; set; }


		SalaryTransaction Update(SalaryTransaction salaryTransaction);
		SalaryTransaction Create(SalaryTransaction salaryTransaction);
		SalaryTransaction Get(long? id);
		void Delete(long? id);
		EntityCollection<SalaryTransactionSubset> Find();

		Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SalaryTransactionSubset>> FindAsync();
	}
}
