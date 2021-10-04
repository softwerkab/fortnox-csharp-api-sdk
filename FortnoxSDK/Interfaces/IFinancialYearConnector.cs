using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IFinancialYearConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        FinancialYear Create(FinancialYear financialYear);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        FinancialYear Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<FinancialYearSubset> Find(FinancialYearSearch searchSettings);

        Task<FinancialYear> CreateAsync(FinancialYear financialYear);
		Task<FinancialYear> GetAsync(long? id);
        Task<EntityCollection<FinancialYearSubset>> FindAsync(FinancialYearSearch searchSettings);
	}
}
