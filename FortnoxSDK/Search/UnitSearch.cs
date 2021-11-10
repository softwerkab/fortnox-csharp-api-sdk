namespace Fortnox.SDK.Search;

public class UnitSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Unit? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Unit? FilterBy { get; set; }


}