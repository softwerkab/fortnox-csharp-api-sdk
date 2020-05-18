using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IExpenseConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Expense? SortBy { get; set; }
		Filter.Expense? FilterBy { get; set; }


        Expense Create(Expense expense);
		Expense Get(string id);
        EntityCollection<ExpenseSubset> Find();

        Task<Expense> CreateAsync(Expense expense);
		Task<Expense> GetAsync(string id);
        Task<EntityCollection<ExpenseSubset>> FindAsync();
	}
}
