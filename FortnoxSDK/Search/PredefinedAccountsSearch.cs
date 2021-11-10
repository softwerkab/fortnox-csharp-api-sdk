namespace Fortnox.SDK.Search;

public class PredefinedAccountsSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.PredefinedAccounts? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.PredefinedAccounts? FilterBy { get; set; }


}