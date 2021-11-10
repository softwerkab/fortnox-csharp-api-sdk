namespace Fortnox.SDK.Search;

public class AccountSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Account? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Account? FilterBy { get; set; }


    [SearchParameter]
    public string SRU { get; set; }
}