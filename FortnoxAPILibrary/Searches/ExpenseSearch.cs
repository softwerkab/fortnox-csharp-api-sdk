namespace FortnoxAPILibrary
{
    public class ExpenseSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Expense? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Expense? FilterBy { get; set; }


    }
}
