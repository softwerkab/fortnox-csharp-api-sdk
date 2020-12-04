namespace Fortnox.SDK.Search
{
    public class ModeOfPaymentSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.ModeOfPayment? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.ModeOfPayment? FilterBy { get; set; }


        [SearchParameter]
		public string Code { get; set; }
    }
}
