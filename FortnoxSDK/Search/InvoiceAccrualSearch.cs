namespace Fortnox.SDK.Search
{
    public class InvoiceAccrualSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.InvoiceAccrual? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.InvoiceAccrual? FilterBy { get; set; }


    }
}
