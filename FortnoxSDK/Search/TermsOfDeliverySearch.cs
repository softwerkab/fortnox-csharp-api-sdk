namespace Fortnox.SDK.Search;

public class TermsOfDeliverySearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.TermsOfDelivery? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.TermsOfDelivery? FilterBy { get; set; }


    [SearchParameter]
    public string Code { get; set; }
}