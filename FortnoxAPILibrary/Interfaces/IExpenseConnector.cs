using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IExpenseConnector : IEntityConnector
	{


        Expense Create(Expense expense);
		Expense Get(string id);
        EntityCollection<ExpenseSubset> Find(ExpenseSearch searchSettings);

        Task<Expense> CreateAsync(Expense expense);
		Task<Expense> GetAsync(string id);
        Task<EntityCollection<ExpenseSubset>> FindAsync(ExpenseSearch searchSettings);
	}
}
