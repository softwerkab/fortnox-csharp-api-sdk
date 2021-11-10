namespace Fortnox.SDK.Search;

public class CurrencySearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Currency? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Currency? FilterBy { get; set; }


}