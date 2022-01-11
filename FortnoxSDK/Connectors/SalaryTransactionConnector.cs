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
        Endpoint = Endpoints.SalaryTransactions;
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