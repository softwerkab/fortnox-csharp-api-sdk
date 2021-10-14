using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IExpenseConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Expense Create(Expense expense);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Expense Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<ExpenseSubset> Find(ExpenseSearch searchSettings);

        Task<Expense> CreateAsync(Expense expense);
        Task<Expense> GetAsync(string id);
        Task<EntityCollection<ExpenseSubset>> FindAsync(ExpenseSearch searchSettings);
    }
}
