using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISalaryTransactionConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		SalaryTransaction Update(SalaryTransaction salaryTransaction);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		SalaryTransaction Create(SalaryTransaction salaryTransaction);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		SalaryTransaction Get(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<SalaryTransactionSubset> Find(SalaryTransactionSearch searchSettings);

		Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SalaryTransactionSubset>> FindAsync(SalaryTransactionSearch searchSettings);
	}
}
