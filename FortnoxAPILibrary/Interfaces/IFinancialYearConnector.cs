using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IFinancialYearConnector : IEntityConnector
	{

        FinancialYear Create(FinancialYear financialYear);
		FinancialYear Get(long? id);
        EntityCollection<FinancialYearSubset> Find(FinancialYearSearch searchSettings);

        Task<FinancialYear> CreateAsync(FinancialYear financialYear);
		Task<FinancialYear> GetAsync(long? id);
        Task<EntityCollection<FinancialYearSubset>> FindAsync(FinancialYearSearch searchSettings);
	}
}
