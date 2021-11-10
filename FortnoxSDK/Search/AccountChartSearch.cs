namespace Fortnox.SDK.Search;

public class AccountChartSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.AccountChart? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.AccountChart? FilterBy { get; set; }


}