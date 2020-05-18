using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ExpenseConnector : EntityConnector<Expense, EntityCollection<ExpenseSubset>, Sort.By.Expense?>, IExpenseConnector
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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Creates a new expense
		/// </summary>
		/// <param name="expense">The expense to create</param>
		/// <returns>The created expense</returns>
		public Expense Create(Expense expense)
		{
			return CreateAsync(expense).Result;
		}

		/// <summary>
		/// Gets a list of expenses
		/// </summary>
		/// <returns>A list of expenses</returns>
		public EntityCollection<ExpenseSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<ExpenseSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<Expense> CreateAsync(Expense expense)
		{
			return await BaseCreate(expense);
		}
		public async Task<Expense> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
