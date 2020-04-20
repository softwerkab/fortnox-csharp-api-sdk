using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IExpenseConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.Expense? FilterBy { get; set; }

        Expense Create(Expense expense);

		Expense Get(string id);

        EntityCollection<ExpenseSubset> Find();

	}
}
