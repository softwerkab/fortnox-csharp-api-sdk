namespace Fortnox.SDK.Search
{
    public class TrustedEmailDomainsSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.TrustedEmailDomains? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.TrustedEmailDomains? FilterBy { get; set; }


    }
}
