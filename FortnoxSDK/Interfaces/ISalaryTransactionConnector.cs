using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISalaryTransactionConnector : IEntityConnector
	{


		SalaryTransaction Update(SalaryTransaction salaryTransaction);
		SalaryTransaction Create(SalaryTransaction salaryTransaction);
		SalaryTransaction Get(long? id);
		void Delete(long? id);
		EntityCollection<SalaryTransactionSubset> Find(SalaryTransactionSearch searchSettings);

		Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SalaryTransactionSubset>> FindAsync(SalaryTransactionSearch searchSettings);
	}
}
