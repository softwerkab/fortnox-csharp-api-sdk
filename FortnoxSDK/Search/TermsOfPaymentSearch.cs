namespace Fortnox.SDK.Search;

public class TermsOfPaymentSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.TermsOfPayment? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.TermsOfPayment? FilterBy { get; set; }


}