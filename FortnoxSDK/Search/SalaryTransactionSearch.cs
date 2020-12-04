namespace Fortnox.SDK.Search
{
    public class SalaryTransactionSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.SalaryTransaction? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.SalaryTransaction? FilterBy { get; set; }


        [SearchParameter]
        public string EmployeeId { get; set; }

        [SearchParameter]
        public string Date { get; set; }
    }
}
