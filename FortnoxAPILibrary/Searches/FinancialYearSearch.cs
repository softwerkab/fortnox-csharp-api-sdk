namespace FortnoxAPILibrary
{
    public class FinancialYearSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.FinancialYear? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.FinancialYear? FilterBy { get; set; }


        [SearchParameter]
        public string Date { get; set; }
    }
}
