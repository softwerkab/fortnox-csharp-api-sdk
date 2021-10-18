namespace Fortnox.SDK.Search
{
    public class TrustedEmailSendersSearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.TrustedEmailSenders? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.TrustedEmailSenders? FilterBy { get; set; }


    }
}
