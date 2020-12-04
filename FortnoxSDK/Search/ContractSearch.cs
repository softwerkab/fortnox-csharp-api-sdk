namespace Fortnox.SDK.Search
{
    public class ContractSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Contract? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Contract? FilterBy { get; set; }


        [SearchParameter]
		public string CustomerNumber { get; set; }

        [SearchParameter]
		public string DocumentNumber { get; set; }

        [SearchParameter]
		public string InvoicesRemaining { get; set; }

        [SearchParameter]
		public string PeriodEnd { get; set; }

        [SearchParameter]
		public string PeriodStart { get; set; }

        [SearchParameter]
		public string TemplateNumber { get; set; }
    }
}
