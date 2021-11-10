using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class FinancialYearConnector : SearchableEntityConnector<FinancialYear, FinancialYearSubset, FinancialYearSearch>, IFinancialYearConnector
{

    /// <remarks/>
    public FinancialYearConnector()
    {
        Resource = "financialyears";
    }
    /// <summary>
    /// Find a financialYear based on id
    /// </summary>
    /// <param name="id">Identifier of the financialYear to find</param>
    /// <returns>The found financialYear</returns>
    public FinancialYear Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    /// <summary>
    /// Creates a new financialYear
    /// </summary>
    /// <param name="financialYear">The financialYear to create</param>
    /// <returns>The created financialYear</returns>
    public FinancialYear Create(FinancialYear financialYear)
    {
        return CreateAsync(financialYear).GetResult();
    }

    /// <summary>
    /// Gets a list of financialYears
    /// </summary>
    /// <returns>A list of financialYears</returns>
    public EntityCollection<FinancialYearSubset> Find(FinancialYearSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<FinancialYearSubset>> FindAsync(FinancialYearSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
    public async Task<FinancialYear> CreateAsync(FinancialYear financialYear)
    {
        return await BaseCreate(financialYear).ConfigureAwait(false);
    }
    public async Task<FinancialYear> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}