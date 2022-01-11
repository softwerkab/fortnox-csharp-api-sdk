using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class ExpenseConnector : SearchableEntityConnector<Expense, ExpenseSubset, ExpenseSearch>, IExpenseConnector
{
    public ExpenseConnector()
    {
        Endpoint = Endpoints.Expenses;
    }

    public async Task<EntityCollection<ExpenseSubset>> FindAsync(ExpenseSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<Expense> CreateAsync(Expense expense)
    {
        return await BaseCreate(expense).ConfigureAwait(false);
    }

    public async Task<Expense> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}