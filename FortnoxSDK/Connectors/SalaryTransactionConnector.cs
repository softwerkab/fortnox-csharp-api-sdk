using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class SalaryTransactionConnector : SearchableEntityConnector<SalaryTransaction, SalaryTransactionSubset, SalaryTransactionSearch>, ISalaryTransactionConnector
{
    public SalaryTransactionConnector()
    {
        Resource = Endpoints.SalaryTransactions;
    }

    public SalaryTransaction Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public SalaryTransaction Update(SalaryTransaction salaryTransaction)
    {
        return UpdateAsync(salaryTransaction).GetResult();
    }

    public SalaryTransaction Create(SalaryTransaction salaryTransaction)
    {
        return CreateAsync(salaryTransaction).GetResult();
    }

    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<SalaryTransactionSubset> Find(SalaryTransactionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<SalaryTransactionSubset>> FindAsync(SalaryTransactionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction)
    {
        return await BaseCreate(salaryTransaction).ConfigureAwait(false);
    }

    public async Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction)
    {
        return await BaseUpdate(salaryTransaction, salaryTransaction.SalaryRow.ToString()).ConfigureAwait(false);
    }

    public async Task<SalaryTransaction> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}