namespace Fortnox.SDK.Search;

public class PriceListSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.PriceList? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.PriceList? FilterBy { get; set; }


    [SearchParameter]
    public string Code { get; set; }

    [SearchParameter]
    public string Comments { get; set; }
}