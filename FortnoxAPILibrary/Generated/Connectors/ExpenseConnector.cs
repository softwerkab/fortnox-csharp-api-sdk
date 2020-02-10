using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ExpenseConnector : EntityConnector<Expense, EntityCollection<ExpenseSubset>, Sort.By.Expense?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Expense? FilterBy { get; set; }


		/// <remarks/>
		public ExpenseConnector()
		{
			Resource = "expenses";
		}

		/// <summary>
		/// Find a expense based on id
		/// </summary>
		/// <param name="id">Identifier of the expense to find</param>
		/// <returns>The found expense</returns>
		public Expense Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a expense
		/// </summary>
		/// <param name="expense">The expense to update</param>
		/// <returns>The updated expense</returns>
		public Expense Update(Expense expense)
		{
			return BaseUpdate(expense, expense.Code.ToString());
		}

		/// <summary>
		/// Creates a new expense
		/// </summary>
		/// <param name="expense">The expense to create</param>
		/// <returns>The created expense</returns>
		public Expense Create(Expense expense)
		{
			return BaseCreate(expense);
		}

		/// <summary>
		/// Deletes a expense
		/// </summary>
		/// <param name="id">Identifier of the expense to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of expenses
		/// </summary>
		/// <returns>A list of expenses</returns>
		public EntityCollection<ExpenseSubset> Find()
		{
			return BaseFind();
		}
	}
}
