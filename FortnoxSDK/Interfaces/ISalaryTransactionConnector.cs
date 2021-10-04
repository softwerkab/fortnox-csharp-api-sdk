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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		SalaryTransaction Update(SalaryTransaction salaryTransaction);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		SalaryTransaction Create(SalaryTransaction salaryTransaction);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		SalaryTransaction Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<SalaryTransactionSubset> Find(SalaryTransactionSearch searchSettings);

		Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction);
		Task<SalaryTransaction> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SalaryTransactionSubset>> FindAsync(SalaryTransactionSearch searchSettings);
	}
}
